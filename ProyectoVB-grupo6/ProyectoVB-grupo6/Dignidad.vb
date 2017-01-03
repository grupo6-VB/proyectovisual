Public Class Dignidad
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _cantElegir As Integer 'DEFINE EL MAX SE CANDIDATOS A SELECCIONAR
    Public Property CantElegir() As Integer
        Get
            Return _cantElegir
        End Get
        Set(ByVal value As Integer)
            _cantElegir = value
        End Set
    End Property

    Public Sub New(nombre As String, id As Integer, cantElegir As Integer)
        Me.Nombre = nombre
        Me.Id = id
        Me.CantElegir = cantElegir
    End Sub
End Class
