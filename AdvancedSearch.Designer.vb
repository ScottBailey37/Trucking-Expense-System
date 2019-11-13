<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancedSearch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.tbSearchTotalDeductions = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.tbSearchNetPay = New System.Windows.Forms.TextBox
        Me.cbSearchPayDate = New System.Windows.Forms.CheckBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.tbSearchFirst = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.tbSearchGross = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.dtpSearchPayDate = New System.Windows.Forms.DateTimePicker
        Me.Label22 = New System.Windows.Forms.Label
        Me.tbSearchLast = New System.Windows.Forms.TextBox
        Me.tbSearchMiddle = New System.Windows.Forms.TextBox
        Me.tbSearchMotel = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.tbSearchParts = New System.Windows.Forms.TextBox
        Me.tbSearchInsurance = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.tbSearchFees = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.tbSearchPhonePayment = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.tbSearchTruckPayment = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.tbSearchWorkmansComp = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.tbSearchLicensing = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbSearchFuelTax = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbSearchHighwayTax = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbSearchMiscellaneous = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbSearchService = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbSearchTires = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbSearchFuel = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbSearchFood = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbSearchCashAdvances = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnSearch, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(547, 465)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(206, 49)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSearch.Enabled = False
        Me.btnSearch.Location = New System.Drawing.Point(3, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(97, 43)
        Me.btnSearch.TabIndex = 23
        Me.btnSearch.Text = "Search"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(106, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(97, 43)
        Me.Cancel_Button.TabIndex = 24
        Me.Cancel_Button.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.tbSearchTotalDeductions)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.tbSearchNetPay)
        Me.GroupBox1.Controls.Add(Me.cbSearchPayDate)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.tbSearchFirst)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.tbSearchGross)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.dtpSearchPayDate)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.tbSearchLast)
        Me.GroupBox1.Controls.Add(Me.tbSearchMiddle)
        Me.GroupBox1.Controls.Add(Me.tbSearchMotel)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.tbSearchParts)
        Me.GroupBox1.Controls.Add(Me.tbSearchInsurance)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.tbSearchFees)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.tbSearchPhonePayment)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.tbSearchTruckPayment)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.tbSearchWorkmansComp)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.tbSearchLicensing)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tbSearchFuelTax)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.tbSearchHighwayTax)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tbSearchMiscellaneous)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbSearchService)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbSearchTires)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbSearchFuel)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbSearchFood)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbSearchCashAdvances)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 445)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Advanced Search"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(379, 122)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 24)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Net"
        '
        'tbSearchTotalDeductions
        '
        Me.tbSearchTotalDeductions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchTotalDeductions.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearchTotalDeductions.Location = New System.Drawing.Point(563, 149)
        Me.tbSearchTotalDeductions.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSearchTotalDeductions.Name = "tbSearchTotalDeductions"
        Me.tbSearchTotalDeductions.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchTotalDeductions.TabIndex = 6
        Me.tbSearchTotalDeductions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(564, 121)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(151, 24)
        Me.Label17.TabIndex = 94
        Me.Label17.Text = "Total Deductions"
        '
        'tbSearchNetPay
        '
        Me.tbSearchNetPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchNetPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearchNetPay.Location = New System.Drawing.Point(379, 149)
        Me.tbSearchNetPay.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSearchNetPay.Name = "tbSearchNetPay"
        Me.tbSearchNetPay.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchNetPay.TabIndex = 5
        Me.tbSearchNetPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbSearchPayDate
        '
        Me.cbSearchPayDate.AutoSize = True
        Me.cbSearchPayDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearchPayDate.Location = New System.Drawing.Point(286, 69)
        Me.cbSearchPayDate.Name = "cbSearchPayDate"
        Me.cbSearchPayDate.Size = New System.Drawing.Size(15, 14)
        Me.cbSearchPayDate.TabIndex = 82
        Me.cbSearchPayDate.TabStop = False
        Me.cbSearchPayDate.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(381, 59)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(43, 24)
        Me.Label20.TabIndex = 86
        Me.Label20.Text = "Last"
        '
        'tbSearchFirst
        '
        Me.tbSearchFirst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearchFirst.Location = New System.Drawing.Point(563, 86)
        Me.tbSearchFirst.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSearchFirst.Name = "tbSearchFirst"
        Me.tbSearchFirst.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchFirst.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(563, 59)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 24)
        Me.Label21.TabIndex = 87
        Me.Label21.Text = "First"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(15, 33)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 24)
        Me.Label24.TabIndex = 89
        Me.Label24.Text = "Pay Date"
        '
        'tbSearchGross
        '
        Me.tbSearchGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearchGross.Location = New System.Drawing.Point(199, 149)
        Me.tbSearchGross.Name = "tbSearchGross"
        Me.tbSearchGross.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchGross.TabIndex = 4
        Me.tbSearchGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(199, 123)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(59, 24)
        Me.Label25.TabIndex = 90
        Me.Label25.Text = "Gross"
        '
        'dtpSearchPayDate
        '
        Me.dtpSearchPayDate.CustomFormat = "ddd dd MMM yyyy"
        Me.dtpSearchPayDate.Enabled = False
        Me.dtpSearchPayDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSearchPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchPayDate.Location = New System.Drawing.Point(15, 61)
        Me.dtpSearchPayDate.Name = "dtpSearchPayDate"
        Me.dtpSearchPayDate.Size = New System.Drawing.Size(265, 29)
        Me.dtpSearchPayDate.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(15, 121)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 24)
        Me.Label22.TabIndex = 88
        Me.Label22.Text = "Middle"
        '
        'tbSearchLast
        '
        Me.tbSearchLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearchLast.Location = New System.Drawing.Point(381, 86)
        Me.tbSearchLast.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSearchLast.Name = "tbSearchLast"
        Me.tbSearchLast.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchLast.TabIndex = 1
        '
        'tbSearchMiddle
        '
        Me.tbSearchMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchMiddle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearchMiddle.Location = New System.Drawing.Point(15, 149)
        Me.tbSearchMiddle.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSearchMiddle.Name = "tbSearchMiddle"
        Me.tbSearchMiddle.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchMiddle.TabIndex = 3
        '
        'tbSearchMotel
        '
        Me.tbSearchMotel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchMotel.HideSelection = False
        Me.tbSearchMotel.Location = New System.Drawing.Point(563, 405)
        Me.tbSearchMotel.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchMotel.Name = "tbSearchMotel"
        Me.tbSearchMotel.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchMotel.TabIndex = 22
        Me.tbSearchMotel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(562, 377)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 24)
        Me.Label26.TabIndex = 79
        Me.Label26.Text = "Motel"
        '
        'tbSearchParts
        '
        Me.tbSearchParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchParts.HideSelection = False
        Me.tbSearchParts.Location = New System.Drawing.Point(199, 277)
        Me.tbSearchParts.Margin = New System.Windows.Forms.Padding(4)
        Me.tbSearchParts.Name = "tbSearchParts"
        Me.tbSearchParts.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchParts.TabIndex = 12
        Me.tbSearchParts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbSearchInsurance
        '
        Me.tbSearchInsurance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchInsurance.HideSelection = False
        Me.tbSearchInsurance.Location = New System.Drawing.Point(563, 341)
        Me.tbSearchInsurance.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchInsurance.Name = "tbSearchInsurance"
        Me.tbSearchInsurance.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchInsurance.TabIndex = 18
        Me.tbSearchInsurance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(562, 312)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 24)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Insurance"
        '
        'tbSearchFees
        '
        Me.tbSearchFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchFees.HideSelection = False
        Me.tbSearchFees.Location = New System.Drawing.Point(381, 405)
        Me.tbSearchFees.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchFees.Name = "tbSearchFees"
        Me.tbSearchFees.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchFees.TabIndex = 21
        Me.tbSearchFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(380, 377)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 24)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Fees"
        '
        'tbSearchPhonePayment
        '
        Me.tbSearchPhonePayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchPhonePayment.HideSelection = False
        Me.tbSearchPhonePayment.Location = New System.Drawing.Point(199, 405)
        Me.tbSearchPhonePayment.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchPhonePayment.Name = "tbSearchPhonePayment"
        Me.tbSearchPhonePayment.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchPhonePayment.TabIndex = 20
        Me.tbSearchPhonePayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(200, 377)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 24)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "Phone Payment"
        '
        'tbSearchTruckPayment
        '
        Me.tbSearchTruckPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchTruckPayment.HideSelection = False
        Me.tbSearchTruckPayment.Location = New System.Drawing.Point(15, 405)
        Me.tbSearchTruckPayment.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchTruckPayment.Name = "tbSearchTruckPayment"
        Me.tbSearchTruckPayment.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchTruckPayment.TabIndex = 19
        Me.tbSearchTruckPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 375)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 24)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Truck Payment"
        '
        'tbSearchWorkmansComp
        '
        Me.tbSearchWorkmansComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchWorkmansComp.HideSelection = False
        Me.tbSearchWorkmansComp.Location = New System.Drawing.Point(563, 277)
        Me.tbSearchWorkmansComp.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchWorkmansComp.Name = "tbSearchWorkmansComp"
        Me.tbSearchWorkmansComp.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchWorkmansComp.TabIndex = 14
        Me.tbSearchWorkmansComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(562, 247)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(161, 24)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "Workmans Comp."
        '
        'tbSearchLicensing
        '
        Me.tbSearchLicensing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchLicensing.HideSelection = False
        Me.tbSearchLicensing.Location = New System.Drawing.Point(563, 213)
        Me.tbSearchLicensing.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchLicensing.Name = "tbSearchLicensing"
        Me.tbSearchLicensing.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchLicensing.TabIndex = 10
        Me.tbSearchLicensing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(562, 182)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 24)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Licensing"
        '
        'tbSearchFuelTax
        '
        Me.tbSearchFuelTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchFuelTax.HideSelection = False
        Me.tbSearchFuelTax.Location = New System.Drawing.Point(381, 341)
        Me.tbSearchFuelTax.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchFuelTax.Name = "tbSearchFuelTax"
        Me.tbSearchFuelTax.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchFuelTax.TabIndex = 17
        Me.tbSearchFuelTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(380, 312)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 24)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Fuel Tax"
        '
        'tbSearchHighwayTax
        '
        Me.tbSearchHighwayTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchHighwayTax.HideSelection = False
        Me.tbSearchHighwayTax.Location = New System.Drawing.Point(381, 277)
        Me.tbSearchHighwayTax.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchHighwayTax.Name = "tbSearchHighwayTax"
        Me.tbSearchHighwayTax.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchHighwayTax.TabIndex = 13
        Me.tbSearchHighwayTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(380, 247)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 24)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Highway Tax"
        '
        'tbSearchMiscellaneous
        '
        Me.tbSearchMiscellaneous.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchMiscellaneous.HideSelection = False
        Me.tbSearchMiscellaneous.Location = New System.Drawing.Point(381, 213)
        Me.tbSearchMiscellaneous.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchMiscellaneous.Name = "tbSearchMiscellaneous"
        Me.tbSearchMiscellaneous.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchMiscellaneous.TabIndex = 9
        Me.tbSearchMiscellaneous.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(380, 182)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 24)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Miscellaneous"
        '
        'tbSearchService
        '
        Me.tbSearchService.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchService.HideSelection = False
        Me.tbSearchService.Location = New System.Drawing.Point(199, 341)
        Me.tbSearchService.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchService.Name = "tbSearchService"
        Me.tbSearchService.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchService.TabIndex = 16
        Me.tbSearchService.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(199, 312)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 24)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Service"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(200, 247)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 24)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Parts"
        '
        'tbSearchTires
        '
        Me.tbSearchTires.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchTires.HideSelection = False
        Me.tbSearchTires.Location = New System.Drawing.Point(199, 213)
        Me.tbSearchTires.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchTires.Name = "tbSearchTires"
        Me.tbSearchTires.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchTires.TabIndex = 8
        Me.tbSearchTires.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 182)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 24)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Tires"
        '
        'tbSearchFuel
        '
        Me.tbSearchFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchFuel.HideSelection = False
        Me.tbSearchFuel.Location = New System.Drawing.Point(15, 341)
        Me.tbSearchFuel.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchFuel.Name = "tbSearchFuel"
        Me.tbSearchFuel.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchFuel.TabIndex = 15
        Me.tbSearchFuel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 311)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 24)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Fuel"
        '
        'tbSearchFood
        '
        Me.tbSearchFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchFood.HideSelection = False
        Me.tbSearchFood.Location = New System.Drawing.Point(15, 277)
        Me.tbSearchFood.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchFood.Name = "tbSearchFood"
        Me.tbSearchFood.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchFood.TabIndex = 11
        Me.tbSearchFood.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 247)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 24)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Food"
        '
        'tbSearchCashAdvances
        '
        Me.tbSearchCashAdvances.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSearchCashAdvances.HideSelection = False
        Me.tbSearchCashAdvances.Location = New System.Drawing.Point(15, 213)
        Me.tbSearchCashAdvances.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.tbSearchCashAdvances.Name = "tbSearchCashAdvances"
        Me.tbSearchCashAdvances.Size = New System.Drawing.Size(168, 29)
        Me.tbSearchCashAdvances.TabIndex = 7
        Me.tbSearchCashAdvances.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 183)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 24)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Cash Advances"
        '
        'AdvancedSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(776, 526)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdvancedSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Advanced Search"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbSearchMotel As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents tbSearchParts As System.Windows.Forms.TextBox
    Friend WithEvents tbSearchInsurance As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbSearchFees As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbSearchPhonePayment As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbSearchTruckPayment As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbSearchWorkmansComp As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbSearchLicensing As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbSearchFuelTax As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbSearchHighwayTax As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbSearchMiscellaneous As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbSearchService As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbSearchTires As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbSearchFuel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbSearchFood As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbSearchCashAdvances As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbSearchPayDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbSearchFirst As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbSearchGross As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dtpSearchPayDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbSearchLast As System.Windows.Forms.TextBox
    Friend WithEvents tbSearchMiddle As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbSearchTotalDeductions As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbSearchNetPay As System.Windows.Forms.TextBox

End Class
