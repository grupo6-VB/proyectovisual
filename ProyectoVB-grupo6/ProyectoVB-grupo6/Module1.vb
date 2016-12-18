Imports System.Xml

Module Module1

    Sub Main()

        Dim mesa As Mesa = New Mesa("0001")
        mesa.CargarPadron()
        'mesa.ListarVotantes()
        mesa.ProcesoVotacion()
        CargarCandidatos()
        Console.ReadLine()
        'MENU PRINCIPAL
    End Sub
    'ADMINISTRAR
    'RESULTADO X CANDIDATO
    'SUFRAGAR
    'CERRAR

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

            For Each p_p As Partido_Politico In part_politicos
                Console.WriteLine()
                p_p.MostrarCandidatos()
            Next
        Next
    End Sub
End Module
