﻿Imports System.Security.Cryptography
Public Class User
    Private fullNameValue As String
    Private loginNameValue As String
    Private passwordValue As String
    Private lastModifierValue As String

    Public Property fullName() As String
        Get
            Return fullNameValue
        End Get
        Set(value As String)
            If value.Length <= 255 Then
                fullNameValue = value
            Else
                fullNameValue = value.Substring(0, 255)
            End If
        End Set
    End Property 'fullName prop
    Public Property loginName() As String
        Get
            Return loginNameValue
        End Get
        Set(value As String)
            If value.Length <= 255 Then
                loginNameValue = value
            Else
                loginNameValue = value.Substring(0, 255)
            End If
        End Set
    End Property 'loginName prop
    Public Property Password() As String
        Get
            Return passwordValue
        End Get
        Set(value As String)

            Dim hashingOb As New SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte = Text.Encoding.ASCII.GetBytes(value)

            bytesToHash = hashingOb.ComputeHash(bytesToHash)

            Dim strResult As String = ""

            For Each item In bytesToHash
                passwordValue += item.ToString("x2")
            Next
        End Set
    End Property 'Password prop
    Public Property lastModifier() As String
        Get
            Return lastModifierValue
        End Get
        Set(value As String)
            If value.Length <= 255 Then
                lastModifierValue = value
            Else
                lastModifierValue = value.Substring(0, 255)
            End If
        End Set
    End Property 'lastModifier prop
End Class
