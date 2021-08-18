﻿Public Class Image
    'Members
    Private titleValue As String
    Private descriptionValue As String
    Private imageValue As String
    Private bodyValue As String

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
    Public Property Image() As String
        Get
            Return imageValue
        End Get
        Set(value As String)
            imageValue = value
        End Set
    End Property 'Image prop
    Public Property Body() As String
        Get
            Return bodyValue
        End Get
        Set(value As String)
            If value.Length <= 10000 Then
                imageValue = value
            Else
                imageValue = value.Substring(0, 10000)
            End If
        End Set
    End Property 'Body prop
End Class
