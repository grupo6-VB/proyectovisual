Imports System.Xml

Module Module1

    Sub Main()

        Dim mesa As Mesa = New Mesa("0001")
        mesa.CargarPadron()
        'mesa.ListarVotantes()
        'mesa.ProcesoVotacion()
        CargarCandidatos()
        Dim opc As Byte = MenuPrincipal()

        Select Case opc
            Case 1
            Case 2
                mesa.ListarVotantes()
            Case 3
                mesa.ProcesoVotacion()
            Case 4
                Console.WriteLine("GRACIAS POR SU VISITA")
                Exit Select
            Case Else
                Exit Sub
        End Select


        Console.ReadLine()

    End Sub

    Private Sub CargarCandidatos()
        Dim part_politicos As ArrayList = New ArrayList()
        Dim path As String = "POLITICA/PARTIDOSPOLITICOS.xml"
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim politica As XmlNodeList = xmlDoc.GetElementsByTagName("politica")
        For Each pol As XmlNode In politica
            For Each partido As XmlNode In pol
                'Console.WriteLine(partido.Name)
                Dim p_p As Partido_Politico = New Partido_Politico(partido.Attributes("id").Value, partido.Attributes("nombre").Value)
                For Each candidato As XmlNode In partido
                    Dim cand As Candidato = New Candidato(candidato.Attributes("id").Value, candidato.Attributes("cargo").Value)
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
    End Sub

    Function MenuPrincipal() As Byte
        Dim opc As Byte = 0
        While opc <= 0 Or opc > 4
            Console.WriteLine("SELECCIONE UNA OPCION" & vbNewLine)
            Console.WriteLine("{0}. ADMINISTRAR", 1)
            Console.WriteLine("{0}. CONSULTAS", 2)
            Console.WriteLine("{0}. SUFRAGAR", 3)
            Console.WriteLine("{0}. CERRAR", 4)
            Try
                opc = Console.ReadLine
            Catch ex As Exception
                Console.WriteLine("ERROR - INSERTE UN NUMERO")
                opc = 0
            End Try
        End While


        Return opc
    End Function


End Module
