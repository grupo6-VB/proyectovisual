Public Class Recinto
    Private _numeroRecinto As Integer
    Public Property NumeroRecinto() As Integer
        Get
            Return _numeroRecinto
        End Get
        Set(ByVal value As Integer)
            _numeroRecinto = value
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
End Class
