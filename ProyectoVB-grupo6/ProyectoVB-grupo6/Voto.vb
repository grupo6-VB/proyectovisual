Public Class Voto

    Private _cargo As String 'SI ES PARA PRESIDENTE o ASAMBLEISTA
    Public Property Votantes() As String
        Get
            Return _cargo
        End Get
        Set(ByVal value As String)
            _cargo = value
        End Set
    End Property

    Private _idCandidato As Integer 'IDENTIFICADOR DEL CANDIDATO
    Public Property Id() As Integer
        Get
            Return _idCandidato
        End Get
        Set(ByVal value As Integer)
            _idCandidato = value
        End Set
    End Property

End Class
