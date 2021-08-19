Imports System.IO

Public Module dirManipulator
    Sub addFile(dirPath As String, Info As String)
        Try

            If Not (Directory.Exists(dirPath)) Then
                FileSystem.MkDir(dirPath)
            End If
            Dim fileName = dirPath & "\" & Guid.NewGuid.ToString() & ".txt"
            Dim fileWrite As FileStream = New FileStream(fileName, FileMode.Create, FileAccess.Write)
            Dim streamWr As StreamWriter = New StreamWriter(fileWrite)

            streamWr.Write(Info)
            streamWr.Flush()
            fileWrite.Close()
            MessageBox.Show("Process end successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub editFile(filePath As String, Info As String)
        Try
            Dim fileWrite As FileStream = New FileStream(filePath, FileMode.Create, FileAccess.Write)
            Dim streamWr As StreamWriter = New StreamWriter(fileWrite)

            streamWr.Write(Info)
            streamWr.Flush()
            fileWrite.Close()

            MessageBox.Show("Process end successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As IOException
            MessageBox.Show("Process failed", "IO ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Function readFile(filePath As String) As String()

        Dim fileRead = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim streamRd = New StreamReader(fileRead)

        Dim line = streamRd.ReadLine()
        Dim Info = Split(line, "^_^")

        fileRead.Close()

        Return Info
    End Function
End Module
