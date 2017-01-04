Imports System.Xml

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
        Console.WriteLine(Me.Cedula & vbTab & Me.Nombre & vbTab & Me.Apellido)
    End Sub

    Public Sub GuardarEstadoSufragio(cedula As String)
        Dim path As String = "DATOS.xml"
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim lista_votantes As XmlNodeList = xmlDoc.GetElementsByTagName("votante")
        For Each votante As XmlNode In lista_votantes
            'Console.WriteLine(votante.Name)
            If votante.Attributes("cedula").Value = cedula Then
                For Each nodo As XmlNode In votante
                    If nodo.Name = "estadoSufragio" Then
                        Dim n As XmlNode = xmlDoc.CreateElement("estadoSufragio")
                        n.InnerText = "TRUE"
                        votante.RemoveChild(nodo)
                        votante.AppendChild(n)
                        xmlDoc.Save(path)
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub

End Class
