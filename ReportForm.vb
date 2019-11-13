Imports System.Windows.Forms
Imports Microsoft

Public Class ReportForm

    Friend ReportType As MainForm.ReportType


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        PrintPreviewDialog1.Document = PrintDocument1
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim d As String = Date.Now.ToShortDateString
        Dim s As String = Space(72) + "Trucking Expense System" + " v" + My.Application.Info.Version.ToString '+ Chr(13)
        Dim s1 As String = MainForm.driver
        Dim fontFamily As String = "Arial" 'Microsoft Sans Serif

        Me.ReportType = MainForm.ReportType.Annual

        'Dim year As String = ""
        'Dim years As New List(Of String)
        'For i As Integer = 0 To MainForm.loadList.Count - 1
        '    year = MainForm.loadList(i).PayDate.Substring(MainForm.loadList(i).PayDate.Length - 4, 4)

        '    'year = year.Substring(year.Length - 4, 4)
        '    years.Add(year)
        'Next
        'If year = "" Then
        '    year = Date.Now.ToShortDateString.Substring(Date.Now.ToShortDateString.Length - 4, 4)
        'End If

        'Draw name
        e.Graphics.DrawString(s1, New Font( _
        fontFamily, 20, FontStyle.Regular), Brushes.Black, 75, 90)

        'Draw Report type
        If Me.ReportType = MainForm.ReportType.Annual Then
            e.Graphics.DrawString(Me.lblYear.Text, New Font( _
            fontFamily, 20, FontStyle.Regular), Brushes.Black, 700, 90)
        Else
            e.Graphics.DrawString(Date.Now.ToShortDateString, New Font( _
            fontFamily, 20, FontStyle.Regular), Brushes.Black, 575, 90)
        End If

        e.Graphics.FillRectangle(Brushes.Gainsboro, 75, 180, 685, 30)
        e.Graphics.DrawRectangle(Pens.Black, 75, 180, 685, 30)

        'Draw header
        e.Graphics.DrawString("Month" & Space(20) & "Gross" & Space(13) & "Net" & Space(13) & "Deductions", New Font( _
       fontFamily, 18, FontStyle.Bold), Brushes.Black, 75, 180)

        'Draw header line
        Dim MyPen As New Pen(Color.Black, 2)
        e.Graphics.DrawLine(MyPen, 75, 208, 760, 208)

        Dim Months() As String = {"January", "February", "March", "April", "May", _
        "June", "July", "August", "September", "October", "November", "December"}
        Dim line As String = ""
        Dim x As Integer = 75
        Dim y As Integer = 215
        Dim rectX As Integer
        Dim rectY As Integer
        For i As Integer = 0 To (Months.Length - 1)
            rectX = x
            rectY = y

            Select Case i
                Case 0, 2, 4, 6, 8, 10
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectX, rectY, 685, 30)
                Case 1, 3, 5, 7, 9, 11
                    e.Graphics.FillRectangle(Brushes.LightGray, rectX, rectY, 685, 30)
            End Select


            line = (Months(i))
            e.Graphics.DrawString(line, New Font( _
            fontFamily, 18, FontStyle.Regular), Brushes.Black, x, y)

            x += 220
            line = ListView1.Items(i).SubItems(1).Text
            e.Graphics.DrawString(line, New Font( _
            fontFamily, 18, FontStyle.Regular), Brushes.Black, x, y)

            x += 170
            line = ListView1.Items(i).SubItems(2).Text
            e.Graphics.DrawString(line, New Font( _
            fontFamily, 18, FontStyle.Regular), Brushes.Black, x, y)

            x += 170
            line = ListView1.Items(i).SubItems(3).Text
            e.Graphics.DrawString(line, New Font( _
            fontFamily, 18, FontStyle.Regular), Brushes.Black, x, y)

            x = 75
            y += 30
        Next

        y += 60
        e.Graphics.FillRectangle(Brushes.LightGray, x, y, 685, 30)
        e.Graphics.DrawString("Total", New Font( _
       fontFamily, 18, FontStyle.Bold), Brushes.Black, x, y)
        x += 220
        For i As Integer = 1 To 3 'ListView1.Items(13).SubItems.Count
            line = ListView1.Items(13).SubItems(i).Text
            e.Graphics.DrawString(line, New Font( _
           fontFamily, 18, FontStyle.Bold), Brushes.Black, x, y)
            x += 170
        Next

        'Draw date and program name/version
        e.Graphics.DrawString(d + s, New Font( _
        fontFamily, 12, FontStyle.Regular), Brushes.Black, 75, e.PageBounds.Bottom - 48)
        e.Graphics.DrawLine(Pens.Black, 75, e.PageBounds.Bottom - 50, 765, e.PageBounds.Bottom - 50)

        'Dim g As Graphics = ListView1.CreateGraphics
        'Dim bmp As New Bitmap(675, 520, g)
        'ListView1.DrawToBitmap(bmp, New Rectangle(75, 115, ListView1.DisplayRectangle.Width + 5, ListView1.DisplayRectangle.Height + 5)) ') '675, 520))

        'e.Graphics.DrawImage(bmp, 0, 0)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub ReportForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        lblDriver.Text = ""
        MainForm.driver = ""
    End Sub
End Class
