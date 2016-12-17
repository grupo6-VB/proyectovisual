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
        Dim path As String = "MESAS/" & Me.NrodeMesa & ".xml"
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

    Public Function VerificarVotante() As Boolean
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
            'Console.WriteLine("presiono" & c)
            Do Until num
                Dim ex As Integer = InStr(1, c, CStr(n_b))
                If ex > 0 Then
                    cedula = cedula & n_b
                    num = True
                Else
                    n_b += 1
                    If c.Length = 1 Or c.Length > 2 Or n_b > 9 Then
                        'Console.WriteLine("presiono: " & c)
                        'Console.WriteLine("no es num")
                        Exit Do
                    Else

                    End If
                End If
            Loop

            'Console.WriteLine("presiono" & n_b)
            If CInt(n_b) >= 0 Then
                'Console.WriteLine("presiono" & c)
                Console.Clear()
                Console.Write(vbTab & "CEDULA # " & cedula)
            End If
            
            'Loop While cki.Key <> ConsoleKey.Escape

        End While
        Console.WriteLine()
        Console.WriteLine("CEDULA COMPLETA ----- PROCEDIENDO A VOTAR")
        Console.ReadLine()
        Return False
    End Function

    Public Sub ProcesoVotacion()
        VerificarVotante()

       
    End Sub

    
End Class
