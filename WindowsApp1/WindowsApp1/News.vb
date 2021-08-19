Public Class News
    'Members
    Private titleValue As String
    Private descriptionValue As String
    Private categoryValue As String
    Private bodyValue As String
    Private creationDateValue As DateTime

    Sub New()
        creationDateValue = DateTime.Now
    End Sub
    Public Property Title() As String
        Get
            Return titleValue
        End Get
        Set(value As String)
            If value.Length <= 255 Then
                titleValue = value
            Else
                titleValue = value.Substring(0, 255)
            End If
        End Set
    End Property 'Title prop
    Public Property Description() As String
        Get
            Return descriptionValue
        End Get
        Set(value As String)
            If value.Length <= 255 Then
                descriptionValue = value
            Else
                descriptionValue = value.Substring(0, 255)
            End If
        End Set
    End Property 'Description prop
    Public Property Category() As String
        Get
            Return categoryValue
        End Get
        Set(value As String)
            If value.Length <= 255 Then
                categoryValue = value
            Else
                categoryValue = value.Substring(0, 255)
            End If
        End Set
    End Property 'Category prop
    Public Property Body() As String
        Get
            Return bodyValue
        End Get
        Set(value As String)
            If value.Length <= 10000 Then
                bodyValue = value
            Else
                bodyValue = value.Substring(0, 10000)
            End If
        End Set
    End Property 'Body prop
    Public Property creationDate As DateTime
        Get
            Return creationDateValue
        End Get
        Set(ByVal value As DateTime)
            creationDateValue = value
        End Set

    End Property
End Class
