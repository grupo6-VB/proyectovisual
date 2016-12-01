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

    Private _estado As Boolean
    Public Property Estado() As Boolean
        Get
            Return _estado
        End Get
        Set(ByVal value As Boolean)
            _estado = value
        End Set
    End Property

    Private _candidatos As ArrayList
    Public Property Candidatos() As ArrayList
        Get
            Return _candidatos
        End Get
        Set(ByVal value As ArrayList)
            _candidatos = value
        End Set
    End Property
End Class
