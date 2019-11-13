Imports System.Windows.Forms

Public Class AdvancedSearch

    Private nonNumberEntered As Boolean
    Private numberEntered As Boolean


#Region "Control Events"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
        Search()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbSearchPayDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSearchPayDate.CheckedChanged
        If cbSearchPayDate.CheckState = CheckState.Checked Then
            dtpSearchPayDate.Enabled = True
            btnSearch.Enabled = True
        Else
            btnSearch.Enabled = False
            dtpSearchPayDate.Enabled = False
            If tbSearchLast.Text <> "" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchFirst.Text <> "" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchMiddle.Text <> "" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchGross.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchNetPay.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchTotalDeductions.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchCashAdvances.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchFood.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchFuel.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchMotel.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchTires.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchParts.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchService.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchMiscellaneous.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchHighwayTax.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchFuelTax.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchLicensing.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchInsurance.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchWorkmansComp.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchTruckPayment.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchPhonePayment.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
            If tbSearchFees.Text <> "0.00" Then
                btnSearch.Enabled = True
                Return
            End If
        End If
    End Sub

    Private Sub MoneyTextBoxesSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSearchWorkmansComp.KeyPress, tbSearchTruckPayment.KeyPress, tbSearchTotalDeductions.KeyPress, tbSearchTires.KeyPress, tbSearchService.KeyPress, tbSearchPhonePayment.KeyPress, tbSearchParts.KeyPress, tbSearchNetPay.KeyPress, tbSearchMotel.KeyPress, tbSearchMiscellaneous.KeyPress, tbSearchLicensing.KeyPress, tbSearchInsurance.KeyPress, tbSearchHighwayTax.KeyPress, tbSearchGross.KeyPress, tbSearchFuelTax.KeyPress, tbSearchFuel.KeyPress, tbSearchFood.KeyPress, tbSearchFees.KeyPress, tbSearchCashAdvances.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            Console.Beep()
            e.Handled = True
        End If
    End Sub

    Private Sub MoneyTextBoxesSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbSearchWorkmansComp.KeyDown, tbSearchTruckPayment.KeyDown, tbSearchTotalDeductions.KeyDown, tbSearchTires.KeyDown, tbSearchService.KeyDown, tbSearchPhonePayment.KeyDown, tbSearchParts.KeyDown, tbSearchNetPay.KeyDown, tbSearchMotel.KeyDown, tbSearchMiscellaneous.KeyDown, tbSearchLicensing.KeyDown, tbSearchInsurance.KeyDown, tbSearchHighwayTax.KeyDown, tbSearchGross.KeyDown, tbSearchFuelTax.KeyDown, tbSearchFuel.KeyDown, tbSearchFood.KeyDown, tbSearchFees.KeyDown, tbSearchCashAdvances.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        If e.KeyCode = Keys.Decimal OrElse e.KeyCode = Keys.OemPeriod Then
            If sender.text.contains(".") Then
                'A non-numerical keystroke was pressed. 
                'Set the flag to true and evaluate in KeyPress event.
                nonNumberEntered = True
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        If e.Shift Then
            nonNumberEntered = True
            Exit Sub
        End If
        'Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            'Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                'Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub MoneyTextBoxesSearch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearchWorkmansComp.Leave, tbSearchTruckPayment.Leave, tbSearchTotalDeductions.Leave, tbSearchTires.Leave, tbSearchService.Leave, tbSearchPhonePayment.Leave, tbSearchParts.Leave, tbSearchNetPay.Leave, tbSearchMotel.Leave, tbSearchMiscellaneous.Leave, tbSearchLicensing.Leave, tbSearchInsurance.Leave, tbSearchHighwayTax.Leave, tbSearchGross.Leave, tbSearchFuelTax.Leave, tbSearchFuel.Leave, tbSearchFood.Leave, tbSearchFees.Leave, tbSearchCashAdvances.Leave
        If sender.text.StartsWith(",") Then
            sender.text = sender.text.Remove(0, 1)
        End If
        If sender.Text.EndsWith(",") OrElse sender.text.EndsWith(".") Then
            sender.text = sender.Text.Remove((sender.Text.Length - 1), 1)
        End If

        Dim Fmt As String = "###,###,##0.00"
        If sender.text <> "" And sender.text <> "0.00" Then
            Dim d As Double = CDbl(sender.text)
            Dim s As String
            s = Format(d, Fmt)
            sender.text = s
        Else
            sender.text = "0.00"
        End If
        sender.BackColor = SystemColors.Window
        sender.SelectionLength = 0
    End Sub

    Private Sub MoneyTextBoxesSearch_Layout(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles tbSearchWorkmansComp.Layout, tbSearchTruckPayment.Layout, tbSearchTotalDeductions.Layout, tbSearchTires.Layout, tbSearchService.Layout, tbSearchPhonePayment.Layout, tbSearchParts.Layout, tbSearchNetPay.Layout, tbSearchMotel.Layout, tbSearchMiscellaneous.Layout, tbSearchLicensing.Layout, tbSearchInsurance.Layout, tbSearchHighwayTax.Layout, tbSearchGross.Layout, tbSearchFuelTax.Layout, tbSearchFuel.Layout, tbSearchFood.Layout, tbSearchFees.Layout, tbSearchCashAdvances.Layout
        sender.text = "0.00"
    End Sub

    Private Sub AllTextBoxesSearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearchWorkmansComp.Enter, tbSearchTruckPayment.Enter, tbSearchTotalDeductions.Enter, tbSearchTires.Enter, tbSearchService.Enter, tbSearchPhonePayment.Enter, tbSearchParts.Enter, tbSearchNetPay.Enter, tbSearchMotel.Enter, tbSearchMiscellaneous.Enter, tbSearchMiddle.Enter, tbSearchLicensing.Enter, tbSearchLast.Enter, tbSearchInsurance.Enter, tbSearchHighwayTax.Enter, tbSearchGross.Enter, tbSearchFuelTax.Enter, tbSearchFuel.Enter, tbSearchFood.Enter, tbSearchFirst.Enter, tbSearchFees.Enter, tbSearchCashAdvances.Enter
        sender.BackColor = Color.LightSteelBlue
        If sender.text = "0.00" Then
            sender.text = ""
        Else
            sender.SelectAll()
        End If
    End Sub

    Private Sub NamesSearch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearchMiddle.Leave, tbSearchLast.Leave, tbSearchFirst.Leave
        sender.BackColor = SystemColors.Window
        sender.SelectionLength = 0
    End Sub

    Private Sub NamesSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbSearchMiddle.KeyDown, tbSearchLast.KeyDown, tbSearchFirst.KeyDown
        numberEntered = False

        ' Determine whether the keystroke is a letter.
        If e.KeyCode < Keys.A OrElse e.KeyCode > Keys.Z Then
            If e.KeyCode <> Keys.LShiftKey OrElse e.KeyCode <> Keys.RShiftKey Then
                If e.KeyCode <> Keys.Back Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    numberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub NamesSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbSearchMiddle.KeyPress, tbSearchLast.KeyPress, tbSearchFirst.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If numberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            Console.Beep()
            e.Handled = True
        End If
    End Sub

    Private Sub AllTextBoxesSearch_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbSearchWorkmansComp.MouseDown, tbSearchTruckPayment.MouseDown, tbSearchTotalDeductions.MouseDown, tbSearchTires.MouseDown, tbSearchService.MouseDown, tbSearchPhonePayment.MouseDown, tbSearchParts.MouseDown, tbSearchNetPay.MouseDown, tbSearchMotel.MouseDown, tbSearchMiscellaneous.MouseDown, tbSearchMiddle.MouseDown, tbSearchLicensing.MouseDown, tbSearchLast.MouseDown, tbSearchInsurance.MouseDown, tbSearchHighwayTax.MouseDown, tbSearchGross.MouseDown, tbSearchFuelTax.MouseDown, tbSearchFuel.MouseDown, tbSearchFood.MouseDown, tbSearchFirst.MouseDown, tbSearchFees.MouseDown, tbSearchCashAdvances.MouseDown
        If sender.SelectedText = "" Then
            sender.SelectAll()
        Else
            sender.SelectionLength = 0
        End If
    End Sub

    Private Sub AllTextBoxesSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearchWorkmansComp.TextChanged, tbSearchTruckPayment.TextChanged, tbSearchTotalDeductions.TextChanged, tbSearchTires.TextChanged, tbSearchService.TextChanged, tbSearchPhonePayment.TextChanged, tbSearchParts.TextChanged, tbSearchNetPay.TextChanged, tbSearchMotel.TextChanged, tbSearchMiscellaneous.TextChanged, tbSearchMiddle.TextChanged, tbSearchLicensing.TextChanged, tbSearchLast.TextChanged, tbSearchInsurance.TextChanged, tbSearchHighwayTax.TextChanged, tbSearchGross.TextChanged, tbSearchFuelTax.TextChanged, tbSearchFuel.TextChanged, tbSearchFood.TextChanged, tbSearchFirst.TextChanged, tbSearchFees.TextChanged, tbSearchCashAdvances.TextChanged
        Dim numArray() As String = {"1", "2", "3", "4", "5", "6", "7", "8", "9"}
        Dim ifgross As Boolean

        For Each ctrl As Control In Me.GroupBox1.Controls
            If TypeOf ctrl Is TextBox Then
                For i As Integer = 0 To (numArray.Length - 1)
                    If ctrl.Text.Contains(numArray(i)) Then
                        btnSearch.Enabled = True
                        'ifgross = True
                        Return
                    End If
                Next
            End If
        Next

        If tbSearchLast.Text = "" And tbSearchFirst.Text = "" _
        And tbSearchMiddle.Text = "" And cbSearchPayDate.CheckState = _
        CheckState.Unchecked And ifgross = False Then
            btnSearch.Enabled = False
        Else
            btnSearch.Enabled = True
        End If
    End Sub
#End Region

#Region "Subs and Functions"
    Private Sub Search()
        Dim lf As New List(Of DBEngine.LoadRecord.Field)
        Dim sColl As New List(Of String)

        If cbSearchPayDate.CheckState = CheckState.Checked Then
            sColl.Add(dtpSearchPayDate.Value.ToShortDateString)
            lf.Add(DBEngine.LoadRecord.Field.PayDate)
        End If
        If tbSearchLast.Text <> "" Then
            sColl.Add(tbSearchLast.Text)
            lf.Add(DBEngine.LoadRecord.Field.LastName)
        End If
        If tbSearchFirst.Text <> "" Then
            sColl.Add(tbSearchFirst.Text)
            lf.Add(DBEngine.LoadRecord.Field.FirstName)
        End If
        If tbSearchMiddle.Text <> "" Then
            sColl.Add(tbSearchMiddle.Text)
            lf.Add(DBEngine.LoadRecord.Field.MiddleName)
        End If
        If tbSearchGross.Text <> "" And tbSearchGross.Text <> "0.00" Then
            sColl.Add(tbSearchGross.Text)
            lf.Add(DBEngine.LoadRecord.Field.Gross)
        End If
        If tbSearchNetPay.Text <> "" And tbSearchNetPay.Text <> "0.00" Then
            sColl.Add(tbSearchNetPay.Text)
            lf.Add(DBEngine.LoadRecord.Field.Net)
        End If
        If tbSearchTotalDeductions.Text <> "" And tbSearchTotalDeductions.Text <> "0.00" Then
            sColl.Add(tbSearchTotalDeductions.Text)
            lf.Add(DBEngine.LoadRecord.Field.TotalDeductions)
        End If
        If tbSearchCashAdvances.Text <> "" And tbSearchCashAdvances.Text <> "0.00" Then
            sColl.Add(tbSearchCashAdvances.Text)
            lf.Add(DBEngine.LoadRecord.Field.CashAdvances)
        End If
        If tbSearchFood.Text <> "" And tbSearchFood.Text <> "0.00" Then
            sColl.Add(tbSearchFood.Text)
            lf.Add(DBEngine.LoadRecord.Field.Food)
        End If
        If tbSearchFuel.Text <> "" And tbSearchFuel.Text <> "0.00" Then
            sColl.Add(tbSearchFuel.Text)
            lf.Add(DBEngine.LoadRecord.Field.Fuel)
        End If
        If tbSearchMotel.Text <> "" And tbSearchMotel.Text <> "0.00" Then
            sColl.Add(tbSearchMotel.Text)
            lf.Add(DBEngine.LoadRecord.Field.Motel)
        End If
        If tbSearchTires.Text <> "" And tbSearchTires.Text <> "0.00" Then
            sColl.Add(tbSearchTires.Text)
            lf.Add(DBEngine.LoadRecord.Field.Tires)
        End If
        If tbSearchParts.Text <> "" And tbSearchParts.Text <> "0.00" Then
            sColl.Add(tbSearchParts.Text)
            lf.Add(DBEngine.LoadRecord.Field.Parts)
        End If
        If tbSearchService.Text <> "" And tbSearchService.Text <> "0.00" Then
            sColl.Add(tbSearchService.Text)
            lf.Add(DBEngine.LoadRecord.Field.Service)
        End If
        If tbSearchMiscellaneous.Text <> "" And tbSearchMiscellaneous.Text <> "0.00" Then
            sColl.Add(tbSearchMiscellaneous.Text)
            lf.Add(DBEngine.LoadRecord.Field.Miscellaneous)
        End If
        If tbSearchHighwayTax.Text <> "" And tbSearchHighwayTax.Text <> "0.00" Then
            sColl.Add(tbSearchHighwayTax.Text)
            lf.Add(DBEngine.LoadRecord.Field.HighwayTax)
        End If
        If tbSearchFuelTax.Text <> "" And tbSearchFuelTax.Text <> "0.00" Then
            sColl.Add(tbSearchFuelTax.Text)
            lf.Add(DBEngine.LoadRecord.Field.FuelTax)
        End If
        If tbSearchLicensing.Text <> "" And tbSearchLicensing.Text <> "0.00" Then
            sColl.Add(tbSearchLicensing.Text)
            lf.Add(DBEngine.LoadRecord.Field.Licensing)
        End If
        If tbSearchInsurance.Text <> "" And tbSearchInsurance.Text <> "0.00" Then
            sColl.Add(tbSearchInsurance.Text)
            lf.Add(DBEngine.LoadRecord.Field.Insurance)
        End If
        If tbSearchWorkmansComp.Text <> "" And tbSearchWorkmansComp.Text <> "0.00" Then
            sColl.Add(tbSearchWorkmansComp.Text)
            lf.Add(DBEngine.LoadRecord.Field.WorkmansComp)
        End If
        If tbSearchTruckPayment.Text <> "" And tbSearchTruckPayment.Text <> "0.00" Then
            sColl.Add(tbSearchTruckPayment.Text)
            lf.Add(DBEngine.LoadRecord.Field.TruckPayment)
        End If
        If tbSearchPhonePayment.Text <> "" And tbSearchPhonePayment.Text <> "0.00" Then
            sColl.Add(tbSearchPhonePayment.Text)
            lf.Add(DBEngine.LoadRecord.Field.PhonePayment)
        End If
        If tbSearchFees.Text <> "" And tbSearchFees.Text <> "0.00" Then
            sColl.Add(tbSearchFees.Text)
            lf.Add(DBEngine.LoadRecord.Field.Fees)
        End If

        If lf.Count > 0 Then
            MainForm.matchingloadList.Clear()
            MainForm.matchingloadList = MainForm._dbEngine.Search(MainForm.loadList, lf, sColl)

            If MainForm.matchingloadList.Count > 0 Then
                Dim lvi As ListViewItem
                Dim lvsi As New ListViewItem.ListViewSubItem
                Dim i As Integer
                Dim subItems(23) As String

                SearchForm.ListView1.Items.Clear()
                For Each lr As DBEngine.LoadRecord In MainForm.matchingloadList
                    lvi = New ListViewItem
                    With lr
                        subItems(0) = .RecordNumber
                        subItems(1) = .PayDate
                        subItems(2) = .LastName
                        subItems(3) = .FirstName
                        subItems(4) = .MiddleName
                        subItems(5) = .GrossPay
                        subItems(6) = .NetPay
                        subItems(7) = .TotalDeductions
                        subItems(8) = .CashAdvances
                        subItems(9) = .Food
                        subItems(10) = .Fuel
                        subItems(11) = .Motel
                        subItems(12) = .Tires
                        subItems(13) = .Parts
                        subItems(14) = .Service
                        subItems(15) = .Miscellaneous
                        subItems(16) = .HighwayTax
                        subItems(17) = .FuelTax
                        subItems(18) = .Licensing
                        subItems(19) = .Insurance
                        subItems(20) = .WorkmansComp
                        subItems(21) = .TruckPayment
                        subItems(22) = .PhonePayment
                        subItems(23) = .Fees

                        For i = 1 To 23
                            lvi.Text = subItems(0)
                            lvi.SubItems.Add(subItems(i))
                        Next
                        SearchForm.ListView1.Items.Add(lvi)
                    End With
                Next
                SearchForm.ShowDialog()
            Else
                InfoForm.lblInfo.Text = "No matching records were found."
                InfoForm.ShowDialog()
            End If
        Else
            InfoForm.lblInfo.Text = "No matching records were found."
            InfoForm.ShowDialog()
        End If
    End Sub
#End Region

End Class
