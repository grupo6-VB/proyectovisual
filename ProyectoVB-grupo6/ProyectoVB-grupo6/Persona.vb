Public Class Persona
    Private _cedula As String
    Public Property Cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
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

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _estadoSufragio As Boolean 'Para saber si la persona ya sufragó o no
    Public Property EstadoSufragio() As Boolean
        Get
            Return _estadoSufragio
        End Get
        Set(ByVal value As Boolean)
            _estadoSufragio = value
        End Set
    End Property

    Public Sub New()
        Me.Cedula = ""
        Me.Nombre = ""
        Me.Apellido = ""
        Me.EstadoSufragio = False
    End Sub

    Public Sub New(cedula As String)
        Me.Cedula = cedula
        Me.Nombre = ""
        Me.Apellido = ""
        Me.EstadoSufragio = False
    End Sub

    Public Sub MostrarDatos()
        Console.WriteLine(Me.Cedula & vbTab & Me.Nombre & vbTab & Me.Apellido & vbTab & Me.EstadoSufragio)
    End Sub

End Class
