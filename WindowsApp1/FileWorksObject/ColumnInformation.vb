Public Class ColumnInformation(Of T)
    Public Property ColumnName As String
    Public Property ColumnValue As T
    Public Property ColumnValue2 As T
    Public Property SelectFlag As Boolean
    '''<summary>
    '''Condition Key :
    '''0-Not encluded.
    '''1-Exact value.
    '''2-(Start with/Greater/After).
    '''3-(End with/Smaller/Before).
    '''4-(Contain/Between).
    '''</summary>
    Public Property ConditionType As Integer
    Public Sub Clear()
        ColumnValue = Nothing
        ColumnValue2 = Nothing
        SelectFlag = True
        ConditionType = 0
    End Sub
End Class
