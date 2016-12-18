Public Class Partido_Politico
    Private _id As String
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    'Private _estado As Boolean
    'Public Property Estado() As Boolean
    '    Get
    '        Return _estado
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _estado = value
    '    End Set
    'End Property

    Private _candidatos As ArrayList
    Public Property Candidatos() As ArrayList
        Get
            Return _candidatos
        End Get
        Set(ByVal value As ArrayList)
            _candidatos = value
        End Set
    End Property

    Public Sub New(id As String, nombre As String)
        Me.Id = id
        Me.Nombre = nombre
        Me.Candidatos = New ArrayList()
    End Sub

    Public Sub AgregarCandidato(candidato As Candidato)
        Me.Candidatos.Add(candidato)
    End Sub

    Public Sub MostrarCandidatos()
        Console.WriteLine("ESTOS SON LOS CANDIDATOS DE {0}", Me.Nombre)
        For Each candidato As Candidato In Candidatos
            candidato.MostrarDatosC()
        Next
    End Sub
End Class
