Public Class Candidato
    Inherits Persona
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _cargo As String 'dignidad a la que aspira ejem: PRESIDENTE, ASAMBLEISTA, ETC
    Public Property Cargo() As String
        Get
            Return _cargo
        End Get
        Set(ByVal value As String)
            _cargo = value
        End Set
    End Property

    Private _votos As Integer 'La cantidad de votos que va acumulando por parte de los votantes
    Public Property Votos() As Integer
        Get
            Return _votos
        End Get
        Set(ByVal value As Integer)
            _votos = value
        End Set
    End Property

End Class
