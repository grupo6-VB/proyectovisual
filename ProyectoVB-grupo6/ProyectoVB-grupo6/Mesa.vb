Imports System.Xml

Public Class Mesa
    Private _nromesa As String
    Public Property NrodeMesa() As String
        Get
            Return _nromesa
        End Get
        Set(ByVal value As String)
            _nromesa = value
        End Set
    End Property

    Private _padron As ArrayList
    Public Property Padron() As ArrayList
        Get
            Return _padron
        End Get
        Set(ByVal value As ArrayList)
            _padron = value
        End Set
    End Property

    Private _votos As ArrayList
    Public Property Votos() As ArrayList
        Get
            Return _votos
        End Get
        Set(ByVal value As ArrayList)
            _padron = value
        End Set
    End Property

    Public Sub New(nromesa As String)
        Me.NrodeMesa = nromesa
        Me.Padron = New ArrayList
        Me.Votos = New ArrayList
    End Sub

    Public Sub AgregarVotante(persona As Persona)
        Me._padron.Add(persona)
    End Sub

    Public Sub CargarPadron()
        Dim path As String = "DATOS.xml"
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim padron As XmlNodeList = xmlDoc.GetElementsByTagName("votante")
        For Each votante As XmlNode In padron
            Dim persona As Persona = New Persona(votante.Attributes("cedula").Value)
            'Console.WriteLine("C.I.:" & votante.Attributes("cedula").Value)
            For Each nodo As XmlNode In votante.ChildNodes
                Select Case nodo.Name
                    Case "nombre"
                        persona.Nombre = nodo.InnerText
                    Case "apellido"
                        persona.Apellido = nodo.InnerText
                    Case "estadoSufragio"
                        persona.EstadoSufragio = CBool(nodo.InnerText)
                    Case Else
                End Select
            Next
            AgregarVotante(persona)
        Next
    End Sub

    Public Sub ListarVotantes()
        Console.WriteLine("PADRON ELECTORAL DE LA MESA # " & Me.NrodeMesa)
        For Each persona As Persona In Padron
            persona.MostrarDatos()
        Next
    End Sub

    Public Function VerificarVotante() As Persona
        Dim cki As ConsoleKeyInfo
        Dim cedula As String = ""
        Dim car As Integer = 0
        Console.WriteLine("BIENVENIDO... INGRESE SU NUMERO DE CEDULA")
        While cedula.Length < 10
            'Do
            cki = Console.ReadKey()
            Dim c As String = cki.Key.ToString
            Dim num As Boolean = False
            Dim n_b As Byte = 0
            Do Until num
                Dim ex As Integer = InStr(1, c, CStr(n_b))
                If ex > 0 Then
                    cedula = cedula & n_b
                    num = True
                Else
                    n_b += 1
                    If c.Length = 1 Or c.Length > 2 Or n_b > 9 Then
                        Exit Do
                    Else

                    End If
                End If
            Loop

            If CInt(n_b) >= 0 Then
                Console.Clear()
                Console.Write(vbTab & "CEDULA # " & cedula)
            End If

        End While
        Console.WriteLine()
        Console.WriteLine("CONSULTANDO DATOS .....")
        Console.ReadLine()

        Dim vot As Persona = New Persona()
        For Each votante As Persona In Me.Padron
            'votante.MostrarDatos()
            If votante.Cedula = cedula Then
                vot = votante
            End If
        Next
        Return vot
    End Function

    Public Sub ProcesoVotacion()
        Dim votante As Persona = VerificarVotante()
        If votante.Nombre = "" Then
            Console.WriteLine("NO SE ENCUENTRA EN EL PADRON")
            Exit Sub
        Else
            votante.MostrarDatos()
        End If

        If votante.EstadoSufragio Then
            Console.WriteLine("UD YA EJERCIO SU DERECHO AL VOTO" & vbNewLine)
            Console.ReadLine()
            Exit Sub
        Else
            Dim dignidades As ArrayList = CargarDignidades()
            Dim partidos As ArrayList = CargarCandidatos()
            Dim tipo_cargo As Byte = 1
            For Each dignidad As Dignidad In dignidades
                Dim candidatos_actuales As ArrayList = New ArrayList()
                For Each part_poli As Partido_Politico In partidos
                    For Each cand As Candidato In part_poli.Candidatos
                        If cand.Cargo = CStr(dignidad.Id) Then
                            candidatos_actuales.Add(cand)
                            'cand.MostrarDatosC()
                            'Console.WriteLine(" ---> " & part_poli.Nombre & vbNewLine)
                        End If
                    Next
                Next
                Dim opc As Byte = 0
                Do While opc <= 0 Or opc > candidatos_actuales.Count
                    Console.WriteLine("CANDIDATOS A : " & dignidad.Nombre)
                    For Each cand As Candidato In candidatos_actuales
                        cand.MostrarDatosC()
                        Console.WriteLine()
                        'Console.WriteLine(" ---> " & part_poli.Nombre & vbNewLine)
                    Next

                    Try
                        Console.Write("ESCRIBA LA OPCION A ELEGIR: ")
                        opc = Console.ReadLine()
                    Catch ex As Exception
                        Console.WriteLine(vbNewLine & "INGRESE SOLO NUMEROS")
                    End Try

                Loop
                Dim c As Candidato = candidatos_actuales.Item(opc - 1)
                Console.WriteLine("UD HA ELEGIDO")
                c.MostrarDatosC()
            Next
            'Dim candidatos_actuales As ArrayList = New ArrayList()
            'For Each part_poli As Partido_Politico In partidos
            '    For Each cand As Candidato In part_poli.Candidatos
            '        If cand.Cargo = "1" Then
            '            candidatos_actuales.Add(cand)
            '            'cand.MostrarDatosC()
            '            'Console.WriteLine(" ---> " & part_poli.Nombre & vbNewLine)
            '        End If
            '    Next
            'Next
            'Dim opc As Byte = 0
            'Do While opc <= 0 Or opc > candidatos_actuales.Count
            '    Console.WriteLine("CANDIDATOS A : --------")
            '    For Each cand As Candidato In candidatos_actuales
            '        cand.MostrarDatosC()
            '        Console.WriteLine()
            '        'Console.WriteLine(" ---> " & part_poli.Nombre & vbNewLine)
            '    Next

            '    Try
            '        Console.Write("ESCRIBA LA OPCION A ELEGIR: ")
            '        opc = Console.ReadLine()
            '    Catch ex As Exception
            '        Console.WriteLine(vbNewLine & "INGRESE SOLO NUMEROS")
            '    End Try

            'Loop
            'Dim c As Candidato = candidatos_actuales.Item(opc - 1)
            'Console.WriteLine("UD HA ELEGIDO")
            'c.MostrarDatosC()

        End If

        Console.ReadLine()
    End Sub

    Private Function CargarCandidatos() As ArrayList
        Dim part_politicos As ArrayList = New ArrayList()
        Dim path As String = "DATOS.xml"
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim politica As XmlNodeList = xmlDoc.GetElementsByTagName("politica")
        For Each pol As XmlNode In politica
            For Each partido As XmlNode In pol
                'Console.WriteLine(partido.Name)
                Dim p_p As Partido_Politico = New Partido_Politico(partido.Attributes("id").Value, partido.Attributes("nombre").Value)
                For Each candidato As XmlNode In partido
                    Dim cand As Candidato = New Candidato(candidato.Attributes("id").Value, candidato.Attributes("dignidad").Value)
                    For Each nodo As XmlNode In candidato.ChildNodes
                        Select Case nodo.Name
                            Case "nombre"
                                cand.Nombre = nodo.InnerText
                            Case "apellido"
                                cand.Apellido = nodo.InnerText
                            Case "votos"
                                cand.EstadoSufragio = CInt(nodo.InnerText)
                            Case Else
                        End Select
                    Next
                    p_p.AgregarCandidato(cand)
                Next
                part_politicos.Add(p_p)
            Next

            'For Each p_p As Partido_Politico In part_politicos
            '    Console.WriteLine()
            '    p_p.MostrarCandidatos()
            'Next
        Next
        Return part_politicos
    End Function

    Private Function CargarDignidades() As ArrayList
        Dim dignidades As ArrayList = New ArrayList()
        Dim path As String = "DATOS.xml"
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim lista_dignidades As XmlNodeList = xmlDoc.GetElementsByTagName("dignidad")
        For Each dignidad As XmlNode In lista_dignidades
            Console.WriteLine(dignidad.Name)
            Dim dig As Dignidad = New Dignidad(dignidad.Attributes("nombre").Value, CInt(dignidad.Attributes("id").Value), CInt(dignidad.Attributes("max").Value))
            dignidades.Add(dig)
        Next
        Return dignidades
    End Function
End Class
