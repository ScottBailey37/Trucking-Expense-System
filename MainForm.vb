
Imports System.IO
'Imports System.Globalization
Imports DBEngine.DBEngine

Public Class MainForm

    Friend _dbEngine As New DBEngine.DBEngine
    Private dbPath As String = My.Application.Info.DirectoryPath + "\TruckingDB.txt"
    Friend loadList As New List(Of DBEngine.LoadRecord)
    Friend matchingloadList As New List(Of DBEngine.LoadRecord)
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False
    Private numberEntered As Boolean = False
    Friend currentRecord As Integer
    Private IsRecordSaved As Boolean = True
    Friend driver As String


    Friend Enum ReportType
        Annual
        January
        February
        March
        April
        May
        June
        July
        August
        September
        October
        November
        December
    End Enum

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        lblRecDate.Text = ""
        Label23.Text = "Trucking Expense System v" + My.Application.Info.Version.ToString
        Me.DoubleBuffered = True

        _dbEngine.CreateDatabase(dbPath)
        loadList = _dbEngine.GetRecords(dbPath)
        'allLoadList = loadList

        UpdateFields(currentRecord, loadList)
        UpdateControls(Me, loadList)
    End Sub


#Region "Control Events"
    ''' <summary>
    ''' This event occurs after the KeyDown event and can be used
    ''' to prevent characters from entering the control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MoneyTextBoxes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbWorkmansComp.KeyPress, tbTruckPayment.KeyPress, tbTires.KeyPress, tbService.KeyPress, tbHighwayTax.KeyPress, tbPhonePayment.KeyPress, tbParts.KeyPress, tbFees.KeyPress, tbMiscellaneous.KeyPress, tbLicensing.KeyPress, tbInsurance.KeyPress, tbFuelTax.KeyPress, tbFuel.KeyPress, tbFood.KeyPress, tbCashAdvances.KeyPress, tbTotalDeductions.KeyPress, tbNetPay.KeyPress, tbGrossPay.KeyPress, tbSearchGross.KeyPress, tbMotel.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            Console.Beep()
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Handle the KeyDown event to determine the type of character entered into the control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MoneyTextBoxes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbWorkmansComp.KeyDown, tbTruckPayment.KeyDown, tbTires.KeyDown, tbService.KeyDown, tbHighwayTax.KeyDown, tbPhonePayment.KeyDown, tbParts.KeyDown, tbFees.KeyDown, tbMiscellaneous.KeyDown, tbLicensing.KeyDown, tbInsurance.KeyDown, tbFuelTax.KeyDown, tbFuel.KeyDown, tbFood.KeyDown, tbCashAdvances.KeyDown, tbTotalDeductions.KeyDown, tbNetPay.KeyDown, tbGrossPay.KeyDown, tbSearchGross.KeyDown, tbMotel.KeyDown
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

    Private Sub MoneyTextBoxes_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbWorkmansComp.Leave, tbTruckPayment.Leave, tbTotalDeductions.Leave, tbTires.Leave, tbService.Leave, tbHighwayTax.Leave, tbPhonePayment.Leave, tbParts.Leave, tbFees.Leave, tbNetPay.Leave, tbMiscellaneous.Leave, tbLicensing.Leave, tbInsurance.Leave, tbGrossPay.Leave, tbFuelTax.Leave, tbFuel.Leave, tbFood.Leave, tbCashAdvances.Leave, tbMotel.Leave
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

        If sender.Name <> "tbNetPay" Then
            If sender.name <> "tbTotalDeductions" Then
                sender.BackColor = SystemColors.Window
            End If
        End If

        sender.SelectionLength = 0

        Dim sumDed As Double = SumDeductions()
        Dim net As Double = (CDbl(tbGrossPay.Text) - sumDed)

        If CStr(net).StartsWith("-") Then
            tbNetPay.ForeColor = Color.Red
        Else
            tbNetPay.ForeColor = Color.Black
        End If
        tbNetPay.Text = Format(net, Fmt)
        tbTotalDeductions.Text = Format(sumDed, Fmt)
    End Sub

    Private Sub MoneyTextBoxes_Layout(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles tbWorkmansComp.Layout, tbTruckPayment.Layout, tbTotalDeductions.Layout, tbTires.Layout, tbService.Layout, tbHighwayTax.Layout, tbPhonePayment.Layout, tbParts.Layout, tbFees.Layout, tbNetPay.Layout, tbMiscellaneous.Layout, tbLicensing.Layout, tbInsurance.Layout, tbGrossPay.Layout, tbFuelTax.Layout, tbFuel.Layout, tbFood.Layout, tbCashAdvances.Layout, tbSearchGross.Layout, tbMotel.Layout
        sender.text = "0.00"
    End Sub

    Private Sub AllTextBoxes_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbWorkmansComp.Enter, tbTruckPayment.Enter, tbTotalDeductions.Enter, tbTires.Enter, tbService.Enter, tbHighwayTax.Enter, tbPhonePayment.Enter, tbParts.Enter, tbFees.Enter, tbNetPay.Enter, tbMiscellaneous.Enter, tbMiddleName.Enter, tbLicensing.Enter, tbLastName.Enter, tbInsurance.Enter, tbGrossPay.Enter, tbFuelTax.Enter, tbFuel.Enter, tbFood.Enter, tbFirstName.Enter, tbCashAdvances.Enter, tbSearchLast.Enter, tbSearchFirst.Enter, tbSearchMiddle.Enter, tbSearchGross.Enter, tbMotel.Enter
        If sender.name <> "tbNetPay" Then
            If sender.name <> "tbTotalDeductions" Then
                sender.BackColor = Color.LightSteelBlue
                If sender.text = "0.00" Then
                    sender.text = ""
                Else
                    sender.SelectAll()
                End If
            End If
        End If
    End Sub

    Private Sub Names_Leave(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles tbMiddleName.Leave, tbLastName.Leave, tbFirstName.Leave, tbSearchLast.Leave, tbSearchFirst.Leave, tbSearchMiddle.Leave
        sender.BackColor = SystemColors.Window
        sender.SelectionLength = 0
    End Sub

    Private Sub AllTextBoxes_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbWorkmansComp.MouseDown, tbTruckPayment.MouseDown, tbTotalDeductions.MouseDown, tbTires.MouseDown, tbService.MouseDown, tbHighwayTax.MouseDown, tbPhonePayment.MouseDown, tbParts.MouseDown, tbFees.MouseDown, tbNetPay.MouseDown, tbMiscellaneous.MouseDown, tbMiddleName.MouseDown, tbLicensing.MouseDown, tbLastName.MouseDown, tbInsurance.MouseDown, tbGrossPay.MouseDown, tbFuelTax.MouseDown, tbFuel.MouseDown, tbFood.MouseDown, tbFirstName.MouseDown, tbCashAdvances.MouseDown, tbSearchLast.MouseDown, tbSearchFirst.MouseDown, tbSearchMiddle.MouseDown, tbMotel.MouseDown
        If sender.SelectedText = "" Then
            sender.SelectAll()
        Else
            sender.SelectionLength = 0
        End If
    End Sub

    Private Sub Names_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbMiddleName.KeyDown, tbLastName.KeyDown, tbFirstName.KeyDown, tbSearchLast.KeyDown, tbSearchFirst.KeyDown, tbSearchMiddle.KeyDown
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

    Private Sub Names_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbMiddleName.KeyPress, tbLastName.KeyPress, tbFirstName.KeyPress, tbSearchLast.KeyPress, tbSearchFirst.KeyPress, tbSearchMiddle.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If numberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            Console.Beep()
            e.Handled = True
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        IsRecordSaved = False
        UpdateControls(sender, loadList)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If IsRecordSaved = False Then
            ExitForm.lblInfo.Text = "Do you want to save?"
            Dim result As DialogResult
            result = ExitForm.ShowDialog

            If result = Windows.Forms.DialogResult.No Then
                Me.Close()
            End If
            If result = Windows.Forms.DialogResult.Yes Then
                If VerifyLoadRecord() Then
                    Me.Close()
                End If
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If IsRecordSaved = False Then
            If VerifyLoadRecord() Then
                IsRecordSaved = True
                lblRecDate.Show()
                UpdateControls(sender, loadList)
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        currentRecord = 0
        UpdateFields(currentRecord, loadList)
        UpdateControls(sender, loadList)
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        If currentRecord <> 0 Then
            currentRecord -= 1
            UpdateFields(currentRecord, loadList)
        End If
        UpdateControls(sender, loadList)
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click
        If currentRecord < (loadList.Count - 1) Then
            currentRecord += 1
            UpdateFields(currentRecord, loadList)
        End If
        UpdateControls(sender, loadList)
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        currentRecord = (loadList.Count - 1)
        UpdateFields(currentRecord, loadList)
        UpdateControls(sender, loadList)
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        IsRecordSaved = False
        UpdateControls(sender, loadList)
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        DeleteForm.lblInfo.Text = "Delete this record?"
        DeleteForm.Text = "Delete"
        Dim result As Windows.Forms.DialogResult = DeleteForm.ShowDialog

        If result = Windows.Forms.DialogResult.Yes Then
            _dbEngine.DeleteRecord(dbPath, loadList, currentRecord)

            If currentRecord > 0 And loadList.Count = 1 Then
                currentRecord = 0
            ElseIf currentRecord > 0 And loadList.Count > 1 Then
                currentRecord = (currentRecord - 1)
            End If

            UpdateFields(currentRecord, loadList)
            UpdateControls(sender, loadList)
        End If
    End Sub

    Private Sub BindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorSaveItem.Click
        If IsRecordSaved = False Then
            If VerifyLoadRecord() Then
                IsRecordSaved = True
                lblRecDate.Show()
                UpdateControls(sender, loadList)
            End If
        End If
    End Sub

    Private Sub BindingNavigatorCancelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorCancelItem.Click
        UpdateControls(sender, loadList)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub tbSearchGross_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearchGross.Leave
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

    Private Sub SearchTextBoxes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearchMiddle.TextChanged, tbSearchLast.TextChanged, tbSearchGross.TextChanged, tbSearchFirst.TextChanged
        Dim numArray() As String = {"1", "2", "3", "4", "5", "6", "7", "8", "9"}
        Dim ifgross As Boolean

        If tbSearchGross.Text <> "" Then
            For i As Integer = 0 To (numArray.Length - 1)
                If tbSearchGross.Text.Contains(numArray(i)) Then
                    btnSearch.Enabled = True
                    ifgross = True
                    Return
                End If
            Next
        End If

        If tbSearchLast.Text = "" And tbSearchFirst.Text = "" _
        And tbSearchMiddle.Text = "" And cbSearchPayDate.CheckState = _
        CheckState.Unchecked And ifgross = False Then
            btnSearch.Enabled = False
        Else
            btnSearch.Enabled = True
        End If
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

        End If

    End Sub

    Private Sub KevinLeeBaileyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KevinLeeBaileyToolStripMenuItem.Click
        driver = "Kevin Lee Bailey"
        Dim _loadlist As New List(Of DBEngine.LoadRecord)
        Dim _dbengine As New DBEngine.DBEngine
        Dim fields As New List(Of DBEngine.LoadRecord.Field)
        Dim searchString As New List(Of String)

        fields.Add(DBEngine.LoadRecord.Field.FirstName)
        searchString.Add("Kevin")

        _loadlist = _dbengine.Search(loadList, fields, searchString)

        Dim year As String = ""
        Dim years As New List(Of String)
        For i As Integer = 0 To _loadlist.Count - 1
            year = _loadlist(i).PayDate.Substring(_loadlist(i).PayDate.Length - 4, 4)

            years.Add(year)
        Next
        If year = "" Then
            year = Date.Now.ToShortDateString.Substring(Date.Now.ToShortDateString.Length - 4, 4)
        End If
        For Each yr As String In years
            If Not AnnualSelect.cbSelectYear.Items.Contains(yr) Then
                AnnualSelect.cbSelectYear.Items.Add(yr)
            End If
        Next
        AnnualSelect.cbSelectYear.SelectedIndex = 0
        AnnualSelect.year = AnnualSelect.cbSelectYear.Items(0)
        AnnualSelect.ShowDialog()

        If AnnualSelect.DialogResult = Windows.Forms.DialogResult.OK Then
            AnnualReport(_loadlist, AnnualSelect.year)
        End If
    End Sub

    Private Sub RonnieBaileyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RonnieBaileyToolStripMenuItem.Click
        driver = "Ronnie Bailey"
        Dim _loadlist As New List(Of DBEngine.LoadRecord)
        Dim _dbengine As New DBEngine.DBEngine
        Dim fields As New List(Of DBEngine.LoadRecord.Field)
        Dim searchString As New List(Of String)

        fields.Add(DBEngine.LoadRecord.Field.FirstName)
        searchString.Add("Ronnie")

        _loadlist = _dbengine.Search(loadList, fields, searchString)

        Dim year As String = ""
        Dim years As New List(Of String)
        For i As Integer = 0 To _loadlist.Count - 1
            year = _loadlist(i).PayDate.Substring(_loadlist(i).PayDate.Length - 4, 4)

            years.Add(year)
        Next
        If year = "" Then
            year = Date.Now.ToShortDateString.Substring(Date.Now.ToShortDateString.Length - 4, 4)
        End If
        For Each yr As String In years
            If Not AnnualSelect.cbSelectYear.Items.Contains(yr) Then
                AnnualSelect.cbSelectYear.Items.Add(yr)
            End If
        Next
        AnnualSelect.cbSelectYear.SelectedIndex = 0
        AnnualSelect.year = AnnualSelect.cbSelectYear.Items(0)
        AnnualSelect.ShowDialog()

        If AnnualSelect.DialogResult = Windows.Forms.DialogResult.OK Then
            AnnualReport(_loadlist, AnnualSelect.year)
        End If
    End Sub

    Private Sub BindingNavigatorEditItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorEditItem.Click
        Edit((currentRecord + 1), loadList)
    End Sub
#End Region

#Region "Subs and Functions"
    Private Function VerifyLoadRecord() As Boolean
        If tbLastName.Text = "" Then
            InfoForm.lblInfo.Text = "You must enter a last name."
            InfoForm.ShowDialog()
            Return False
        End If
        If tbFirstName.Text = "" Then
            InfoForm.lblInfo.Text = "You must enter a first name."
            InfoForm.ShowDialog()
            Return False
        End If
        If tbGrossPay.Text = "0.00" OrElse tbGrossPay.Text = "" Then
            InfoForm.lblInfo.Text = "You must enter a gross amount."
            InfoForm.ShowDialog()
            Return False
        End If

        For Each ctrl As Control In GroupBox3.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Name <> "tbNotes" Then
                    If ctrl.Text = "" Then
                        ctrl.Text = "0.00"
                    End If
                End If
            End If
        Next

        Dim _loadRecord As New DBEngine.LoadRecord

        Dim Fmt As String = "###,###,##0.00"
        Dim d As Double
        Dim net As Double
        Dim deductions As Double

        deductions = SumDeductions()

        net = CDbl(tbGrossPay.Text) - (deductions)

        With _loadRecord
            .RecordNumber = CStr(loadList.Count + 1)
            .RecordDate = Format(Today, "d")
            .PayDate = dtpPayDate.Value.ToShortDateString
            .LastName = tbLastName.Text
            .FirstName = tbFirstName.Text
            .MiddleName = tbMiddleName.Text
            .Notes = tbNotes.Text

            d = CDbl(tbGrossPay.Text)
            .GrossPay = Format(d, Fmt)

            d = CDbl(net)
            .NetPay = Format(d, Fmt)

            d = CDbl(deductions)
            .TotalDeductions = Format(d, Fmt)

            d = CDbl(tbCashAdvances.Text)
            .CashAdvances = Format(d, Fmt)

            d = CDbl(tbFood.Text)
            .Food = Format(d, Fmt)

            d = CDbl(tbFuel.Text)
            .Fuel = Format(d, Fmt)

            d = CDbl(tbMotel.Text)
            .Motel = Format(d, Fmt)

            d = CDbl(tbTires.Text)
            .Tires = Format(d, Fmt)

            d = CDbl(tbParts.Text)
            .Parts = Format(d, Fmt)

            d = CDbl(tbService.Text)
            .Service = Format(d, Fmt)

            d = CDbl(tbMiscellaneous.Text)
            .Miscellaneous = Format(d, Fmt)

            d = CDbl(tbHighwayTax.Text)
            .HighwayTax = Format(d, Fmt)

            d = CDbl(tbFuelTax.Text)
            .FuelTax = Format(d, Fmt)

            d = CDbl(tbLicensing.Text)
            .Licensing = Format(d, Fmt)

            d = CDbl(tbInsurance.Text)
            .Insurance = Format(d, Fmt)

            d = CDbl(tbWorkmansComp.Text)
            .WorkmansComp = Format(d, Fmt)

            d = CDbl(tbTruckPayment.Text)
            .TruckPayment = Format(d, Fmt)

            d = CDbl(tbPhonePayment.Text)
            .PhonePayment = Format(d, Fmt)

            d = CDbl(tbFees.Text)
            .Fees = Format(d, Fmt)
        End With

        _dbEngine.SaveRecord(dbPath, _loadRecord)

        'Add the record to the list
        loadList.Add(_loadRecord)
        currentRecord = (loadList.Count - 1)

        UpdateFields(currentRecord, loadList)
        Return True
    End Function

    Private Function SumDeductions() As Double
        Dim dArray(15) As Double
        Dim sum As Double

        If tbCashAdvances.Text <> "" Then
            dArray(0) = CDbl(tbCashAdvances.Text)
        Else
            dArray(0) = CDbl("0.00")
        End If

        If tbFood.Text <> "" Then
            dArray(1) = CDbl(tbFood.Text)
        Else
            dArray(1) = CDbl("0.00")
        End If

        If tbFuel.Text <> "" Then
            dArray(2) = CDbl(tbFuel.Text)
        Else
            dArray(2) = CDbl("0.00")
        End If

        If tbMotel.Text <> "" Then
            dArray(3) = CDbl(tbMotel.Text)
        Else
            dArray(3) = CDbl("0.00")
        End If

        If tbTires.Text <> "" Then
            dArray(4) = CDbl(tbTires.Text)
        Else
            dArray(4) = CDbl("0.00")
        End If

        If tbParts.Text <> "" Then
            dArray(5) = CDbl(tbParts.Text)
        Else
            dArray(5) = CDbl("0.00")
        End If

        If tbService.Text <> "" Then
            dArray(6) = CDbl(tbService.Text)
        Else
            dArray(6) = CDbl("0.00")
        End If

        If tbMiscellaneous.Text <> "" Then
            dArray(7) = CDbl(tbMiscellaneous.Text)
        Else
            dArray(7) = CDbl("0.00")
        End If

        If tbHighwayTax.Text <> "" Then
            dArray(8) = CDbl(tbHighwayTax.Text)
        Else
            dArray(8) = CDbl("0.00")
        End If

        If tbFuelTax.Text <> "" Then
            dArray(9) = CDbl(tbFuelTax.Text)
        Else
            dArray(9) = CDbl("0.00")
        End If

        If tbLicensing.Text <> "" Then
            dArray(10) = CDbl(tbLicensing.Text)
        Else
            dArray(10) = CDbl("0.00")
        End If

        If tbInsurance.Text <> "" Then
            dArray(11) = CDbl(tbInsurance.Text)
        Else
            dArray(11) = CDbl("0.00")
        End If

        If tbWorkmansComp.Text <> "" Then
            dArray(12) = CDbl(tbWorkmansComp.Text)
        Else
            dArray(12) = CDbl("0.00")
        End If

        If tbTruckPayment.Text <> "" Then
            dArray(13) = CDbl(tbTruckPayment.Text)
        Else
            dArray(13) = CDbl("0.00")
        End If

        If tbPhonePayment.Text <> "" Then
            dArray(14) = CDbl(tbPhonePayment.Text)
        Else
            dArray(14) = CDbl("0.00")
        End If

        If tbFees.Text <> "" Then
            dArray(15) = CDbl(tbFees.Text)
        Else
            dArray(15) = CDbl("0.00")
        End If

        For i As Integer = 0 To dArray.Length - 1
            sum = (sum + dArray(i))
        Next
        Return sum
    End Function

    Private Sub NewRecord()
        lblRecDate.Text = Format(Today, "d")
        dtpPayDate.Value = Format(Today, "d")
        tbLastName.Text = ""
        tbFirstName.Text = ""
        tbMiddleName.Text = ""
        tbGrossPay.Text = "0.00"
        tbNetPay.Text = "0.00"
        tbTotalDeductions.Text = "0.00"
        tbCashAdvances.Text = "0.00"
        tbFood.Text = "0.00"
        tbFuel.Text = "0.00"
        tbMotel.Text = "0.00"
        tbTires.Text = "0.00"
        tbParts.Text = "0.00"
        tbService.Text = "0.00"
        tbMiscellaneous.Text = "0.00"
        tbHighwayTax.Text = "0.00"
        tbFuelTax.Text = "0.00"
        tbLicensing.Text = "0.00"
        tbInsurance.Text = "0.00"
        tbWorkmansComp.Text = "0.00"
        tbTruckPayment.Text = "0.00"
        tbPhonePayment.Text = "0.00"
        tbFees.Text = "0.00"
        tbNotes.Text = ""

        tbNetPay.ForeColor = Color.Black
    End Sub

    Friend Sub UpdateControls(ByVal sender As System.Object, ByVal _loadlist As List(Of DBEngine.LoadRecord))
        If _loadlist.Count = 0 Then
            Me.AnnualToolStripMenuItem.Enabled = False
        Else
            Me.AnnualToolStripMenuItem.Enabled = True
        End If
        If sender.Name = "MainForm" Then
            Me.BindingNavigatorAddNewItem.Enabled = True
            Me.SaveToolStripMenuItem.Enabled = False
            Me.BindingNavigatorSaveItem.Enabled = False
            If _loadlist.Count > 0 Then
                Me.BindingNavigatorEditItem.Enabled = True
            Else
                Me.BindingNavigatorEditItem.Enabled = False
            End If
            If _loadlist.Count = 1 Then
                Me.BindingNavigatorMoveFirstItem.Enabled = False
                Me.BindingNavigatorMovePreviousItem.Enabled = False
                Me.BindingNavigatorPositionItem.Enabled = True
                Me.BindingNavigatorCountItem.Enabled = True
                Me.BindingNavigatorMoveNextItem.Enabled = False
                Me.BindingNavigatorMoveLastItem.Enabled = False
                Me.BindingNavigatorDeleteItem.Enabled = True
                Me.BindingNavigatorSaveItem.Enabled = False
                Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
                Return
            End If
            If _loadlist.Count > 1 Then
                Me.BindingNavigatorPositionItem.Enabled = True
                Me.BindingNavigatorCountItem.Enabled = True
                Me.BindingNavigatorMoveNextItem.Enabled = True
                Me.BindingNavigatorMoveLastItem.Enabled = True
                Me.BindingNavigatorDeleteItem.Enabled = True
                Me.BindingNavigatorSaveItem.Enabled = False
                Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
                Return
            End If
        End If
        If sender.name = "BindingNavigatorMoveFirstItem" Then
            Me.BindingNavigatorMoveFirstItem.Enabled = False
            Me.BindingNavigatorMovePreviousItem.Enabled = False
            Me.BindingNavigatorMoveNextItem.Enabled = True
            Me.BindingNavigatorMoveLastItem.Enabled = True
            Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
            Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
            Return
        End If

        If sender.Name = "BindingNavigatorMovePreviousItem" Then
            Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
            Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
            If currentRecord = 0 Then
                Me.BindingNavigatorMoveFirstItem.Enabled = False
                Me.BindingNavigatorMovePreviousItem.Enabled = False
                Me.BindingNavigatorMoveNextItem.Enabled = True
                Me.BindingNavigatorMoveLastItem.Enabled = True
            Else
                Me.BindingNavigatorMoveNextItem.Enabled = True
                Me.BindingNavigatorMoveLastItem.Enabled = True
                Me.BindingNavigatorMovePreviousItem.Enabled = True
                Me.BindingNavigatorMoveFirstItem.Enabled = True
            End If
            Return
        End If

        If sender.Name = "BindingNavigatorMoveNextItem" Then
            Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
            Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
            If currentRecord = (_loadlist.Count - 1) Then
                Me.BindingNavigatorMoveNextItem.Enabled = False
                Me.BindingNavigatorMoveLastItem.Enabled = False
                Me.BindingNavigatorMovePreviousItem.Enabled = True
                Me.BindingNavigatorMoveFirstItem.Enabled = True
            Else
                Me.BindingNavigatorMovePreviousItem.Enabled = True
                Me.BindingNavigatorMoveFirstItem.Enabled = True
                Me.BindingNavigatorMoveNextItem.Enabled = True
                Me.BindingNavigatorMoveLastItem.Enabled = True
            End If
            Return
        End If

        If sender.name = "BindingNavigatorMoveLastItem" Then
            Me.BindingNavigatorMoveLastItem.Enabled = False
            Me.BindingNavigatorMoveNextItem.Enabled = False
            Me.BindingNavigatorMovePreviousItem.Enabled = True
            Me.BindingNavigatorMoveFirstItem.Enabled = True
            Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
            Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
            Return
        End If

        If sender.Name = "BindingNavigatorAddNewItem" Then
            Me.GroupBox4.Enabled = False
            Me.BindingNavigatorMoveFirstItem.Enabled = False
            Me.BindingNavigatorMovePreviousItem.Enabled = False
            Me.BindingNavigatorMoveNextItem.Enabled = False
            Me.BindingNavigatorMoveLastItem.Enabled = False
            Me.BindingNavigatorAddNewItem.Enabled = False
            Me.AddToolStripMenuItem.Enabled = False
            Me.SaveToolStripMenuItem.Enabled = True
            Me.BindingNavigatorDeleteItem.Enabled = False
            Me.BindingNavigatorSaveItem.Enabled = True
            Me.BindingNavigatorCancelItem.Enabled = True
            Me.BindingNavigatorCancelItem.Text = "Cancel"
            Me.BindingNavigatorPositionItem.Enabled = False
            Me.BindingNavigatorCountItem.Enabled = False
            Me.BindingNavigatorPositionItem.Text = "0"
            Me.BindingNavigatorCountItem.Text = "of [0]"
            Me.BindingNavigatorEditItem.Enabled = False
            lblRecDate.Hide()
            tbLastName.Focus()
            IsRecordSaved = False

            NewRecord()
            Return
        End If

        If sender.Name = "BindingNavigatorDeleteItem" Then
            Me.BindingNavigatorSaveItem.Enabled = False
            Me.BindingNavigatorAddNewItem.Enabled = True
            If _loadlist.Count > 0 Then
                Me.BindingNavigatorEditItem.Enabled = True
            Else
                Me.BindingNavigatorEditItem.Enabled = False
            End If
            If _loadlist.Count = 0 Then
                Me.lblRecDate.Hide()
                Me.BindingNavigatorMoveFirstItem.Enabled = False
                Me.BindingNavigatorMovePreviousItem.Enabled = False
                Me.BindingNavigatorPositionItem.Enabled = False
                Me.BindingNavigatorCountItem.Enabled = False
                Me.BindingNavigatorMoveNextItem.Enabled = False
                Me.BindingNavigatorMoveLastItem.Enabled = False
                Me.BindingNavigatorAddNewItem.Enabled = True
                Me.BindingNavigatorDeleteItem.Enabled = False
                Me.BindingNavigatorSaveItem.Enabled = False
                Me.BindingNavigatorCancelItem.Enabled = False
                Me.BindingNavigatorPositionItem.Text = "0"
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
            End If
            If _loadlist.Count = 1 Then
                Me.BindingNavigatorMoveFirstItem.Enabled = False
                Me.BindingNavigatorMovePreviousItem.Enabled = False
                Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
                Me.BindingNavigatorMoveNextItem.Enabled = False
                Me.BindingNavigatorMoveLastItem.Enabled = False
                Me.BindingNavigatorAddNewItem.Enabled = True
                Me.BindingNavigatorSaveItem.Enabled = False
                Me.BindingNavigatorCancelItem.Enabled = False
            End If
            If _loadlist.Count > 1 Then
                If currentRecord = (_loadlist.Count - 1) Then
                    Me.BindingNavigatorMoveNextItem.Enabled = False
                    Me.BindingNavigatorMoveLastItem.Enabled = False
                    Me.BindingNavigatorMovePreviousItem.Enabled = True
                    Me.BindingNavigatorMoveFirstItem.Enabled = True
                End If
                If currentRecord = 0 Then
                    Me.BindingNavigatorMoveFirstItem.Enabled = False
                    Me.BindingNavigatorMovePreviousItem.Enabled = False
                    Me.BindingNavigatorMoveNextItem.Enabled = True
                    Me.BindingNavigatorMoveLastItem.Enabled = True
                End If
                If currentRecord > 0 And currentRecord < (_loadlist.Count - 1) Then
                    Me.BindingNavigatorMoveNextItem.Enabled = True
                    Me.BindingNavigatorMoveLastItem.Enabled = True
                    Me.BindingNavigatorMovePreviousItem.Enabled = True
                    Me.BindingNavigatorMoveFirstItem.Enabled = True
                End If

                Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
            End If
            Return
        End If

        If sender.Name = "BindingNavigatorSaveItem" Then
            Me.GroupBox4.Enabled = True
            Me.BindingNavigatorCancelItem.Text = ""
            Me.BindingNavigatorCancelItem.Enabled = False
            Me.BindingNavigatorSaveItem.Enabled = False
            Me.SaveToolStripMenuItem.Enabled = False
            Me.AddToolStripMenuItem.Enabled = True
            Me.BindingNavigatorAddNewItem.Enabled = True
            Me.BindingNavigatorDeleteItem.Enabled = True
            Me.BindingNavigatorPositionItem.Enabled = True
            Me.BindingNavigatorCountItem.Enabled = True
            Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
            Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"

            If _loadlist.Count > 0 Then
                Me.BindingNavigatorEditItem.Enabled = True
            End If

            IsRecordSaved = True
            lblRecDate.Show()
            If _loadlist.Count = 1 Then
                Me.BindingNavigatorMoveFirstItem.Enabled = False
                Me.BindingNavigatorMovePreviousItem.Enabled = False
                Me.BindingNavigatorMoveNextItem.Enabled = False
                Me.BindingNavigatorMoveLastItem.Enabled = False
            End If
            If _loadlist.Count > 1 Then
                If currentRecord = (_loadlist.Count - 1) Then
                    Me.BindingNavigatorMoveNextItem.Enabled = False
                    Me.BindingNavigatorMoveLastItem.Enabled = False
                    Me.BindingNavigatorMovePreviousItem.Enabled = True
                    Me.BindingNavigatorMoveFirstItem.Enabled = True
                End If
                If currentRecord = 0 Then
                    Me.BindingNavigatorMoveFirstItem.Enabled = False
                    Me.BindingNavigatorMovePreviousItem.Enabled = False
                    Me.BindingNavigatorMoveNextItem.Enabled = True
                    Me.BindingNavigatorMoveLastItem.Enabled = True
                End If
            End If
            Return
        End If

        If sender.name = "BindingNavigatorCancelItem" Then
            IsRecordSaved = True
            Me.GroupBox4.Enabled = True
            Me.BindingNavigatorCancelItem.Enabled = False
            Me.BindingNavigatorCancelItem.Text = ""
            Me.SaveToolStripMenuItem.Enabled = False
            Me.BindingNavigatorSaveItem.Enabled = False
            Me.AddToolStripMenuItem.Enabled = True
            Me.BindingNavigatorAddNewItem.Enabled = True
            If _loadlist.Count > 0 Then
                Me.BindingNavigatorEditItem.Enabled = True
                Me.BindingNavigatorDeleteItem.Enabled = True
            End If

            If currentRecord < (_loadlist.Count - 1) Then
                Me.BindingNavigatorMoveLastItem.Enabled = True
                Me.BindingNavigatorMoveNextItem.Enabled = True
            End If
            If currentRecord > 0 Then
                Me.BindingNavigatorMovePreviousItem.Enabled = True
                Me.BindingNavigatorMoveFirstItem.Enabled = True
            End If
            If _loadlist.Count > 0 Then
                Me.BindingNavigatorPositionItem.Enabled = True
                Me.BindingNavigatorCountItem.Enabled = True
                Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
            End If

            UpdateFields(currentRecord, _loadlist)
            Return
        End If

        If sender.name = "AddToolStripMenuItem" Then
            Me.GroupBox4.Enabled = False
            Me.BindingNavigatorMoveFirstItem.Enabled = False
            Me.BindingNavigatorMovePreviousItem.Enabled = False
            Me.BindingNavigatorMoveNextItem.Enabled = False
            Me.BindingNavigatorMoveLastItem.Enabled = False
            Me.AddToolStripMenuItem.Enabled = False
            Me.SaveToolStripMenuItem.Enabled = True
            Me.BindingNavigatorAddNewItem.Enabled = False
            Me.BindingNavigatorDeleteItem.Enabled = False
            Me.BindingNavigatorSaveItem.Enabled = True
            Me.BindingNavigatorCancelItem.Enabled = True
            Me.BindingNavigatorCancelItem.Text = "Cancel"
            Me.BindingNavigatorPositionItem.Enabled = False
            Me.BindingNavigatorCountItem.Enabled = False
            Me.BindingNavigatorPositionItem.Text = "0"
            Me.BindingNavigatorCountItem.Text = "of [0]"
            Me.BindingNavigatorEditItem.Enabled = False
            lblRecDate.Hide()
            tbLastName.Focus()
            IsRecordSaved = False

            NewRecord()
            Return
        End If
        If sender.name = "SaveToolStripMenuItem" Then
            Me.GroupBox4.Enabled = True
            Me.BindingNavigatorCancelItem.Text = ""
            Me.BindingNavigatorCancelItem.Enabled = False
            Me.SaveToolStripMenuItem.Enabled = False
            Me.AddToolStripMenuItem.Enabled = True
            Me.BindingNavigatorSaveItem.Enabled = False
            Me.BindingNavigatorAddNewItem.Enabled = True
            Me.BindingNavigatorDeleteItem.Enabled = True
            Me.BindingNavigatorPositionItem.Enabled = True
            Me.BindingNavigatorCountItem.Enabled = True
            Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
            Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"

            If _loadlist.Count > 0 Then
                Me.BindingNavigatorEditItem.Enabled = True
            End If

            IsRecordSaved = True
            lblRecDate.Show()
            If _loadlist.Count = 1 Then
                Me.BindingNavigatorMoveFirstItem.Enabled = False
                Me.BindingNavigatorMovePreviousItem.Enabled = False
                Me.BindingNavigatorMoveNextItem.Enabled = False
                Me.BindingNavigatorMoveLastItem.Enabled = False
            End If
            If _loadlist.Count > 1 Then
                If currentRecord = (_loadlist.Count - 1) Then
                    Me.BindingNavigatorMoveNextItem.Enabled = False
                    Me.BindingNavigatorMoveLastItem.Enabled = False
                    Me.BindingNavigatorMovePreviousItem.Enabled = True
                    Me.BindingNavigatorMoveFirstItem.Enabled = True
                End If
                If currentRecord = 0 Then
                    Me.BindingNavigatorMoveFirstItem.Enabled = False
                    Me.BindingNavigatorMovePreviousItem.Enabled = False
                    Me.BindingNavigatorMoveNextItem.Enabled = True
                    Me.BindingNavigatorMoveLastItem.Enabled = True
                End If
            End If
            Return
        End If

        If sender.Name = "ListView1" OrElse sender.name = "OK_Button" Then
            Me.BindingNavigatorAddNewItem.Enabled = True
            Me.AddToolStripMenuItem.Enabled = True
            Me.SaveToolStripMenuItem.Enabled = False
            Me.BindingNavigatorSaveItem.Enabled = False
            Me.BindingNavigatorEditItem.Enabled = True

            If _loadlist.Count = 1 Then
                Me.BindingNavigatorMoveFirstItem.Enabled = False
                Me.BindingNavigatorMovePreviousItem.Enabled = False
                Me.BindingNavigatorPositionItem.Enabled = True
                Me.BindingNavigatorCountItem.Enabled = True
                Me.BindingNavigatorMoveNextItem.Enabled = False
                Me.BindingNavigatorMoveLastItem.Enabled = False
                Me.BindingNavigatorDeleteItem.Enabled = True
                Me.BindingNavigatorPositionItem.Text = "1"
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
                Return
            End If
            If _loadlist.Count > 1 And currentRecord > 0 And currentRecord < (loadList.Count - 1) Then
                Me.BindingNavigatorPositionItem.Enabled = True
                Me.BindingNavigatorCountItem.Enabled = True
                Me.BindingNavigatorMoveFirstItem.Enabled = True
                Me.BindingNavigatorMovePreviousItem.Enabled = True
                Me.BindingNavigatorMoveNextItem.Enabled = True
                Me.BindingNavigatorMoveLastItem.Enabled = True
                Me.BindingNavigatorDeleteItem.Enabled = True
                Me.BindingNavigatorEditItem.Enabled = True
                Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
                Return
            End If
            If loadList.Count > 1 And currentRecord > 0 And currentRecord = (loadList.Count - 1) Then
                Me.BindingNavigatorPositionItem.Enabled = True
                Me.BindingNavigatorCountItem.Enabled = True
                Me.BindingNavigatorMoveFirstItem.Enabled = True
                Me.BindingNavigatorMovePreviousItem.Enabled = True
                Me.BindingNavigatorMoveNextItem.Enabled = False
                Me.BindingNavigatorMoveLastItem.Enabled = False
                Me.BindingNavigatorDeleteItem.Enabled = True
                Me.BindingNavigatorEditItem.Enabled = True
                Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
                Return
            End If
            If _loadlist.Count > 1 And currentRecord = 0 Then
                Me.BindingNavigatorPositionItem.Enabled = True
                Me.BindingNavigatorCountItem.Enabled = True
                Me.BindingNavigatorMoveFirstItem.Enabled = False
                Me.BindingNavigatorMovePreviousItem.Enabled = False
                Me.BindingNavigatorMoveNextItem.Enabled = True
                Me.BindingNavigatorMoveLastItem.Enabled = True
                Me.BindingNavigatorDeleteItem.Enabled = True
                Me.BindingNavigatorEditItem.Enabled = True
                Me.BindingNavigatorPositionItem.Text = (currentRecord + 1).ToString
                Me.BindingNavigatorCountItem.Text = "of [" + _loadlist.Count.ToString + "]"
                Return
            End If
        End If
        If sender.name = "BindingNavigatorEditItem" Then

        End If
    End Sub

    Friend Sub UpdateFields(ByVal _currentrecord As Integer, ByVal _loadlist As List(Of DBEngine.LoadRecord))
        If _loadlist.Count = 0 Then
            NewRecord()
        Else
            With _loadlist(_currentrecord)
                lblRecDate.Text = "Added:  " + .RecordDate
                dtpPayDate.Text = .PayDate
                tbLastName.Text = .LastName
                tbFirstName.Text = .FirstName
                tbMiddleName.Text = .MiddleName
                tbGrossPay.Text = .GrossPay
                tbNetPay.Text = .NetPay
                tbTotalDeductions.Text = .TotalDeductions
                tbCashAdvances.Text = .CashAdvances
                tbFood.Text = .Food
                tbFuel.Text = .Fuel
                tbMotel.Text = .Motel
                tbTires.Text = .Tires
                tbParts.Text = .Parts
                tbService.Text = .Service
                tbMiscellaneous.Text = .Miscellaneous
                tbHighwayTax.Text = .HighwayTax
                tbFuelTax.Text = .FuelTax
                tbLicensing.Text = .Licensing
                tbInsurance.Text = .Insurance
                tbWorkmansComp.Text = .WorkmansComp
                tbTruckPayment.Text = .TruckPayment
                tbPhonePayment.Text = .PhonePayment
                tbFees.Text = .Fees
                tbNotes.Text = .Notes

                If tbNetPay.Text.StartsWith("-") Then
                    tbNetPay.ForeColor = Color.Red
                Else
                    tbNetPay.ForeColor = Color.Black
                End If
            End With
            lblRecDate.Show()
        End If
    End Sub

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

        If lf.Count > 0 Then
            matchingloadList.Clear()

            matchingloadList.Clear()
            matchingloadList = _dbEngine.Search(loadList, lf, sColl)

            If matchingloadList.Count > 0 Then
                Dim lvi As ListViewItem
                Dim lvsi As New ListViewItem.ListViewSubItem
                Dim i As Integer
                Dim subItems(23) As String

                SearchForm.ListView1.Items.Clear()
                For Each lr As DBEngine.LoadRecord In matchingloadList
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

    Private Sub AnnualReport(ByVal LoadListToTotal As List(Of DBEngine.LoadRecord), ByVal year As String)
        Dim _loadlist As New List(Of DBEngine.LoadRecord)
        'Dim lr As New DBEngine.LoadRecord
        Dim Fmt As String = "###,###,##0.00"
        Dim months() As String = {"January", "February", "March", _
        "April", "May", "June", "July", "August", "September", _
        "October", "November", "December"}
        Dim subItems(18) As String
        Dim i As Integer
        Dim lvi As New ListViewItem

        ReportForm.ListView1.Items.Clear()

        For Each lr As DBEngine.LoadRecord In LoadListToTotal
            'year = lr.PayDate.Substring(lr.PayDate.Length - 4, 4)
            If lr.PayDate.Substring(lr.PayDate.Length - 4, 4) = year Then
                _loadlist.Add(lr)
            End If
        Next
        'Get the annual report
        _loadlist = _dbEngine.AnnualReport(_loadlist) 'LoadListToTotal


        'Add 12 listview items for the twelve months in a year
        For i = 0 To 11
            lvi = New ListViewItem
            lvi.Text = months(i)
            ReportForm.ListView1.Items.Add(lvi)
        Next
        'Add a blank listview item for clarity
        lvi = New ListViewItem
        ReportForm.ListView1.Items.Add(lvi)
        'And add a listview item for the totals
        lvi = New ListViewItem
        ReportForm.ListView1.Items.Add(lvi)


        For i = 0 To 11
            With _loadlist.Item(i)
                'Assign text to all subitems
                subItems(0) = .GrossPay
                subItems(1) = .NetPay
                subItems(2) = .TotalDeductions
                subItems(3) = .CashAdvances
                subItems(4) = .Food
                subItems(5) = .Fuel
                subItems(6) = .Motel
                subItems(7) = .Tires
                subItems(8) = .Parts
                subItems(9) = .Service
                subItems(10) = .Miscellaneous
                subItems(11) = .HighwayTax
                subItems(12) = .FuelTax
                subItems(13) = .Licensing
                subItems(14) = .WorkmansComp
                subItems(15) = .Insurance
                subItems(16) = .TruckPayment
                subItems(17) = .PhonePayment
                subItems(18) = .Fees

                'For each month add all loadrecord fields as subitems
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(0))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(1))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(2))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(3))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(4))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(5))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(6))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(7))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(8))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(9))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(10))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(11))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(12))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(13))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(14))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(15))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(16))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(17))
                ReportForm.ListView1.Items.Item(i).SubItems.Add(subItems(18))
            End With
        Next

        With _loadlist.Item(12)
            'The 'Totals' listview item
            ReportForm.ListView1.Items.Item(13).Text = "Total"
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.GrossPay)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.NetPay)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.TotalDeductions)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.CashAdvances)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Food)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Fuel)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Motel)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Tires)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Parts)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Service)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Miscellaneous)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.HighwayTax)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.FuelTax)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Licensing)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.WorkmansComp)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Insurance)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.TruckPayment)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.PhonePayment)
            ReportForm.ListView1.Items.Item(13).SubItems.Add(.Fees)
        End With

        ReportForm.ListView1.Items.Item(13).BackColor = Color.Silver

        'Set the driver name
        If driver <> "" Then
            ReportForm.lblDriver.Text = driver
        Else
            ReportForm.lblDriver.Text = "Unknown"
        End If
        ReportForm.lblYear.Text = year
        ReportForm.ShowDialog()
    End Sub

    Private Function Edit(ByVal recnum As Integer, ByVal _loadlist As List(Of DBEngine.LoadRecord)) As Boolean
        If tbLastName.Text = "" Then
            InfoForm.lblInfo.Text = "You must enter a last name."
            InfoForm.ShowDialog()
            Return False
        End If
        If tbFirstName.Text = "" Then
            InfoForm.lblInfo.Text = "You must enter a first name."
            InfoForm.ShowDialog()
            Return False
        End If
        If tbGrossPay.Text = "0.00" OrElse tbGrossPay.Text = "" Then
            InfoForm.lblInfo.Text = "You must enter a gross amount."
            InfoForm.ShowDialog()
            Return False
        End If

        For Each ctrl As Control In GroupBox3.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Name <> "tbNotes" Then
                    If ctrl.Text = "" Then
                        ctrl.Text = "0.00"
                    End If
                End If
            End If
        Next

        DeleteForm.Text = "Edit"
        DeleteForm.lblInfo.Text = "Edit this record?"
        Dim result As Windows.Forms.DialogResult = DeleteForm.ShowDialog
        If result = Windows.Forms.DialogResult.Yes Then
            Dim lr As New DBEngine.LoadRecord
            Dim Fmt As String = "###,###,##0.00"
            Dim d As Double
            Dim net As Double
            Dim deductions As Double

            deductions = SumDeductions()

            net = CDbl(tbGrossPay.Text) - (deductions)

            With lr
                .RecordNumber = CStr(recnum) 'CStr(_loadlist.Count + 1)
                .RecordDate = Format(Today, "d")
                .PayDate = dtpPayDate.Value.ToShortDateString
                .LastName = tbLastName.Text
                .FirstName = tbFirstName.Text
                .MiddleName = tbMiddleName.Text
                .Notes = tbNotes.Text

                d = CDbl(tbGrossPay.Text)
                .GrossPay = Format(d, Fmt)

                d = CDbl(net)
                .NetPay = Format(d, Fmt)

                d = CDbl(deductions)
                .TotalDeductions = Format(d, Fmt)

                d = CDbl(tbCashAdvances.Text)
                .CashAdvances = Format(d, Fmt)

                d = CDbl(tbFood.Text)
                .Food = Format(d, Fmt)

                d = CDbl(tbFuel.Text)
                .Fuel = Format(d, Fmt)

                d = CDbl(tbMotel.Text)
                .Motel = Format(d, Fmt)

                d = CDbl(tbTires.Text)
                .Tires = Format(d, Fmt)

                d = CDbl(tbParts.Text)
                .Parts = Format(d, Fmt)

                d = CDbl(tbService.Text)
                .Service = Format(d, Fmt)

                d = CDbl(tbMiscellaneous.Text)
                .Miscellaneous = Format(d, Fmt)

                d = CDbl(tbHighwayTax.Text)
                .HighwayTax = Format(d, Fmt)

                d = CDbl(tbFuelTax.Text)
                .FuelTax = Format(d, Fmt)

                d = CDbl(tbLicensing.Text)
                .Licensing = Format(d, Fmt)

                d = CDbl(tbInsurance.Text)
                .Insurance = Format(d, Fmt)

                d = CDbl(tbWorkmansComp.Text)
                .WorkmansComp = Format(d, Fmt)

                d = CDbl(tbTruckPayment.Text)
                .TruckPayment = Format(d, Fmt)

                d = CDbl(tbPhonePayment.Text)
                .PhonePayment = Format(d, Fmt)

                d = CDbl(tbFees.Text)
                .Fees = Format(d, Fmt)
            End With

            _dbEngine.EditRecord(dbPath, _loadlist, currentRecord, lr)
            UpdateFields(currentRecord, _loadlist)
        End If

        Return True
    End Function

#End Region


    Private Sub btnAdvancedSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvancedSearch.Click
        For Each ctrl As Control In AdvancedSearch.GroupBox1.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Name <> "tbSearchLast" And ctrl.Name <> "tbSearchFirst" _
                And ctrl.Name <> "tbSearchMiddle" Then
                    ctrl.Text = "0.00"
                End If
            End If
        Next
        AdvancedSearch.cbSearchPayDate.CheckState = Me.cbSearchPayDate.CheckState
        AdvancedSearch.dtpSearchPayDate.Value = Me.dtpSearchPayDate.Value
        AdvancedSearch.tbSearchLast.Text = Me.tbSearchLast.Text
        AdvancedSearch.tbSearchFirst.Text = Me.tbSearchFirst.Text

        AdvancedSearch.ShowDialog()
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        'Dim localByName As Process() = Process.GetProcessesByName("calc")

        'If localByName.Length = 0 Then
        Microsoft.VisualBasic.Shell(My.Application.Info.DirectoryPath + "\calculator.exe")
        'End If

    End Sub


End Class 'Form1 