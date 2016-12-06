Imports System.Xml

Public Class Mesa
    Private _nromesa As String
    Public Property NrodeMesa() As String
        Get
            Return _nromesa
        End Get
        Set(ByVal value As String)
            _nromesa = value
        End Set
    End Property

    Private _padron As ArrayList
    Public Property Padron() As ArrayList
        Get
            Return _padron
        End Get
        Set(ByVal value As ArrayList)
            _padron = value
        End Set
    End Property

    Private _votos As ArrayList
    Public Property Votos() As ArrayList
        Get
            Return _votos
        End Get
        Set(ByVal value As ArrayList)
            _padron = value
        End Set
    End Property

    Public Sub New(nromesa As String)
        Me.NrodeMesa = nromesa
        Me.Padron = New ArrayList
        Me.Votos = New ArrayList
    End Sub

    Public Sub AgregarVotante(persona As Persona)
        Me._padron.Add(persona)
    End Sub

    Public Sub LeerPadron()
        Dim path As String = "MESAS/" & Me.NrodeMesa & ".xml"
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim padron As XmlNodeList = xmlDoc.GetElementsByTagName("votante")
        For Each votante As XmlNode In padron
            Dim persona As Persona = New Persona(votante.Attributes("cedula").Value)
            'Console.WriteLine("C.I.:" & votante.Attributes("cedula").Value)
            For Each nodo As XmlNode In votante.ChildNodes
                Select Case nodo.Name
                    Case "nombre"
                        persona.Nombre = nodo.InnerText
                    Case "apellido"
                        persona.Apellido = nodo.InnerText
                    Case Else
                End Select
            Next
            AgregarVotante(persona)
        Next
    End Sub

    Public Sub ListarVotantes()
        Console.WriteLine("PADRON ELECTORAL DE LA MESA # " & Me.NrodeMesa)
        For Each persona As Persona In Padron
            persona.MostrarDatos()
        Next
    End Sub
End Class
