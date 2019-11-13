Imports System.Windows.Forms

Public Class SearchForm

    Friend searchedloadlist As New List(Of DBEngine.LoadRecord)
    Private index As Integer = -1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        If ListView1.SelectedItems.Count > 0 Then
            index = ListView1.SelectedIndices.Item(0)
            Dim currentrecord As Integer

            If index <> -1 Then
                currentrecord = CInt((MainForm.matchingloadList.Item(index).RecordNumber) - 1)
                MainForm.currentRecord = currentrecord
                MainForm.UpdateFields(currentrecord, MainForm.loadList)
                MainForm.UpdateControls(sender, MainForm.loadList)

                index = -1
            End If
        End If

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SearchForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OK_Button.Enabled = False

        ListView1.Columns.Item(0).Width = 45
        For i As Integer = 1 To 7
            ListView1.Columns.Item(i).Width = 100
        Next
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            index = ListView1.SelectedIndices.Item(0)
            Dim currentrecord As Integer

            currentrecord = CInt((MainForm.matchingloadList.Item(index).RecordNumber) - 1)
            MainForm.currentrecord = currentrecord
            MainForm.UpdateFields(currentrecord, MainForm.loadList)
            MainForm.UpdateControls(sender, MainForm.loadList)

            index = -1

            Me.Close()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 0 Then
            OK_Button.Enabled = False
        Else
            OK_Button.Enabled = True
        End If
    End Sub

    'Private Sub ListView1_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
    '    If ListView1.Sorting = SortOrder.None _
    '    OrElse ListView1.Sorting = SortOrder.Descending Then
    '        ListView1.Sorting = SortOrder.Ascending
    '    ElseIf ListView1.Sorting = SortOrder.Ascending Then
    '        ListView1.Sorting = SortOrder.Descending
    '    End If
    '    ListView1.Sort()
    'End Sub

    'Private Sub SearchForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    ListView1.Sorting = SortOrder.None
    'End Sub
End Class
