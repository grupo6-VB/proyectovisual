Module Module1

    Sub Main()

        'Dim cki As ConsoleKeyInfo
        ' Prevent example from ending if CTL+C is pressed.
        Console.TreatControlCAsInput = True

        'Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.")
        'Console.WriteLine("Press the Escape (Esc) key to quit: " + vbCrLf)
        'Do
        '    cki = Console.ReadKey()
        '    Console.Write(" --- You pressed ")
        '    If (cki.Modifiers And ConsoleModifiers.Alt) <> 0 Then Console.Write("ALT+")
        '    If (cki.Modifiers And ConsoleModifiers.Shift) <> 0 Then Console.Write("SHIFT+")
        '    If (cki.Modifiers And ConsoleModifiers.Control) <> 0 Then Console.Write("CTL+")
        '    Console.WriteLine(cki.Key.ToString)
        'Loop While cki.Key <> ConsoleKey.Escape

        Dim mesa As Mesa = New Mesa("0001")
        mesa.CargarPadron()
        mesa.ListarVotantes()
        mesa.ProcesoVotacion()
        'Console.ReadLine()
        'MENU PRINCIPAL
    End Sub
    'ADMINISTRAR
    'RESULTADO X CANDIDATO
    'SUFRAGAR
    'CERRAR
End Module
