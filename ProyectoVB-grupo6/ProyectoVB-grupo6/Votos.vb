Public Class Votos

    Private _votantes As ArrayList
    Public Property Candidatos() As ArrayList
        Get
            Return _votantes
        End Get
        Set(ByVal value As ArrayList)
            _votantes = value
        End Set
    End Property

End Class
