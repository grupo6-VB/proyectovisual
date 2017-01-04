Imports System.Xml

Module Module1

    Sub Main()

        Dim mesa As Mesa = New Mesa("0001")
        mesa.CargarPadron()
        'mesa.ListarVotantes()
        'mesa.ProcesoVotacion()
        'CargarCandidatos()
        Dim opc As Byte = MenuPrincipal()

        Select Case opc
            Case 1
            Case 2
                Dim partidos_politicos As ArrayList = mesa.CargarCandidatos
                Dim dignidades As ArrayList = mesa.CargarDignidades
                Sesion_Candidato(dignidades, partidos_politicos)
                opc = MenuPrincipal()
            Case 3
                mesa.ProcesoVotacion()
                opc = MenuPrincipal()
            Case 4
                Console.WriteLine("GRACIAS POR SU VISITA")
                Exit Select
            Case Else
                Exit Sub
        End Select

        Console.ReadLine()

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

    Public Sub Mostrar_Resultados()

    End Sub

    Public Sub Sesion_Candidato(dig As ArrayList, partidos As ArrayList)
        Dim cand As ArrayList = New ArrayList()
        Dim t_d As Integer = 0
        For Each p As Partido_Politico In partidos
            For Each c As Candidato In p.Candidatos
                cand.Add(c)
            Next
        Next
        Console.Clear()
        Dim login As Boolean = False
        Do Until login
            Console.Write("USER: ")
            Dim user As String = Console.ReadLine()
            Console.Write("PASS: ")
            Dim pass As String = Console.ReadLine()

            For Each c As Candidato In cand
                If user = CStr(c.Id) And pass = c.Pass Then
                    login = True
                    c.MostrarDatos_D()
                    c.Seleccion = True
                    t_d = CInt(c.Cargo)
                    Exit For
                End If
            Next

            If login Then
                Exit Do
            Else
                Dim opc As Byte = 0
                While opc <= 0 Or opc > 2
                    Try
                        Console.WriteLine("LAS CREDENCIALES SON INVALIDAS")
                        Console.WriteLine("REINTENTAR: {0}.- SI   {0}.- NO", 1, 2)
                        opc = Console.ReadLine
                        If opc = 2 Then
                            Exit Sub
                        End If
                    Catch ex As Exception
                        Console.WriteLine("INSERTE 1 o 2")
                    End Try

                End While
            End If
        Loop
        Dim d As String = ""
        For Each di As Dignidad In dig
            If di.Id = t_d Then
                d = di.Nombre
            End If
        Next
        Console.WriteLine("LOS PARCIALES PARA " & d & " SON:")
        For Each c As Candidato In cand
            If c.Cargo = CStr(t_d) Then
                Console.Write("{0} VOTOS" & vbTab, c.Votos)
                c.MostrarDatos_D()
            End If
        Next
    End Sub

End Module
