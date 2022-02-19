Option Explicit On

Imports AGVBN


Partial Public Class fPrintDialog
    Inherits System.Windows.Forms.Form


    Private mp_dtStartDate As AGVBN.DateTime
    Private mp_dtEndDate As AGVBN.DateTime
    Private mp_lColumns As Integer
    Private mp_lRows As Integer
    Private mp_lPageNumber As Integer
    Private mp_lXMargin As Integer
    Private mp_lYMargin As Integer
    Private mp_oControl As AGVBN.ActiveGanttVBNCtl
    Public mp_oPrinter As New System.Drawing.Printing.PrintDocument()
    Private mp_lRow As Integer
    Private mp_lColumn As Integer
    Private mp_lPageWidth As Integer
    Private mp_lPageHeight As Integer
    Public m_lXPreviewMargin As Integer
    Public m_lYPreviewMargin As Integer
    Private mp_bLoaded As Boolean = False

    Public Sub New(ByRef oControl As ActiveGanttVBNCtl)
        MyBase.New()
        InitializeComponent()
        mp_oControl = oControl
        mp_dtStartDate = New AGVBN.DateTime()
        mp_dtEndDate = New AGVBN.DateTime()
    End Sub

    Public Sub New(ByRef oControl As ActiveGanttVBNCtl, ByVal dtStartDate As AGVBN.DateTime, ByVal dtEndDate As AGVBN.DateTime)
        MyBase.New()
        InitializeComponent()
        mp_oControl = oControl
        mp_dtStartDate = dtStartDate
        mp_dtEndDate = dtEndDate
    End Sub

    Private Sub fPrintDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler mp_oPrinter.PrintPage, AddressOf Me.mp_oPrinter_PrintPage
        Dim lIndex As Integer = 0
        Dim sDefaultPrinter As String = mp_oPrinter.PrinterSettings.PrinterName
        For lIndex = 0 To System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
            cboPrinters.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters.Item(lIndex))
            If (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Item(lIndex) = sDefaultPrinter) Then
                cboPrinters.SelectedIndex = lIndex
            End If
        Next lIndex
        If mp_oPrinter.DefaultPageSettings.Landscape = False Then
            cboOrientation.SelectedIndex = 0
        Else
            cboOrientation.SelectedIndex = 1
        End If
        mp_lXMargin = 50
        mp_lYMargin = 50
        m_lXPreviewMargin = 100
        m_lYPreviewMargin = 100

        If mp_dtStartDate.DateTimePart.Ticks = 0 Then
            mp_dtStartDate = mp_oControl.CurrentViewObject.TimeLine.StartDate
        End If
        If mp_dtEndDate.DateTimePart.Ticks = 0 Then
            mp_dtEndDate = mp_oControl.CurrentViewObject.TimeLine.EndDate
        End If

        txtSDYear.Text = mp_dtStartDate.Year.ToString()
        txtSDMonth.Text = mp_dtStartDate.Month.ToString()
        txtSDDay.Text = mp_dtStartDate.Day.ToString()
        txtSDHour.Text = mp_dtStartDate.Hour.ToString()
        txtSDMinute.Text = mp_dtStartDate.Minute.ToString()
        txtSDSecond.Text = mp_dtStartDate.Second.ToString()

        txtEDYear.Text = mp_dtEndDate.Year.ToString()
        txtEDMonth.Text = mp_dtEndDate.Month.ToString()
        txtEDDay.Text = mp_dtEndDate.Day.ToString()
        txtEDHour.Text = mp_dtEndDate.Hour.ToString()
        txtEDMinute.Text = mp_dtEndDate.Minute.ToString()
        txtEDSecond.Text = mp_dtEndDate.Second.ToString()


        txtPageHeight.Text = "920"
        txtPageWidth.Text = "692"
        txtScale.Text = "100"
        txtStartPage.Text = "1"
        txtEndPage.Text = TotalPages.ToString()

        mp_bLoaded = True
        Recalculate()


    End Sub



    Private Sub txtScale_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScale.TextChanged
        lblNumberOfPages.Text = "Total Pages: " & TotalPages
        txtEndPage.Text = TotalPages.ToString()
    End Sub

    Public ReadOnly Property StartPage() As Integer
        Get
            If txtStartPage.Text.Trim.Length = 0 Then
                Return 1
                Exit Property
            End If
            Return CType(txtStartPage.Text, System.Int32)
        End Get
    End Property

    Public ReadOnly Property EndPage() As Integer
        Get
            If txtEndPage.Text.Trim.Length() = 0 Then
                Return 1
                Exit Property
            End If
            Return CType(txtEndPage.Text, System.Int32)
        End Get
    End Property

    Public ReadOnly Property PageWidth() As Integer
        Get
            If txtPageWidth.Text.Trim.Length() = 0 Then
                Return 0
                Exit Property
            End If
            Return CType(txtPageWidth.Text, System.Int32)
        End Get
    End Property

    Public ReadOnly Property PageHeight() As Integer
        Get
            If txtPageHeight.Text.Trim.Length() = 0 Then
                Return 0
                Exit Property
            End If
            Return CType(txtPageHeight.Text, System.Int32)
        End Get
    End Property

    Public ReadOnly Property PagesInXDirection() As Integer
        Get
            If PageWidth = 0 Then
                Return 0
                Exit Property
            End If
            Return CType(System.Math.Abs(Int(-(mp_oControl.Printer.PrintAreaWidth / (PageWidth * (100 / Scale()))))), System.Int32)
        End Get
    End Property

    Public ReadOnly Property PagesInYDirection() As Integer
        Get
            If PageHeight = 0 Then
                Return 0
                Exit Property
            End If
            Return CType(System.Math.Abs(Int(-(mp_oControl.Printer.PrintAreaHeight / (PageHeight * (100 / Scale()))))), System.Int32)
        End Get
    End Property

    Public ReadOnly Property TotalPages() As Integer
        Get
            Return PagesInXDirection * PagesInYDirection
        End Get
    End Property

    Public Shadows ReadOnly Property Scale() As Integer
        Get
            If txtScale.Text.Trim.Length() = 0 Then
                Return 100
                Exit Property
            End If
            Return CType(txtScale.Text, System.Int32)
        End Get
    End Property

    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        If InitializePrinter() = True Then
            Dim oForm As New fPrintPreview()
            oForm.mp_oParent = Me
            mp_oControl.CurrentViewObject.ClientArea.FirstVisibleRow = 1
            oForm.ShowDialog(Me)
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If InitializePrinter() = True Then
            Dim i As Integer = 0
            Dim oDummy As System.Drawing.Graphics = Nothing
            mp_oControl.CurrentViewObject.ClientArea.FirstVisibleRow = 1
            For i = StartPage To EndPage
                PrintControl(oDummy, i, True)
            Next i
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub mp_oPrinter_PrintPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        mp_oControl.Printer.PrintControl(ev.Graphics, (mp_lColumn - 1) * PageWidth, (mp_lRow - 1) * PageHeight, mp_lPageWidth, mp_lPageHeight, XMargin, YMargin, Scale)
    End Sub

    Public Sub PrintControl(ByVal oGraphics As System.Drawing.Graphics, ByVal lPageNumber As Integer, ByVal ToPrinter As Boolean, Optional ByVal lPhysicalOffsetX As Long = 0, Optional ByVal lPhysicalOffsetY As Long = 0, Optional ByVal lHScrollPos As Long = 0, Optional ByVal lVScrollPos As Long = 0)
        mp_lRow = CType(System.Math.Abs(Int(-(lPageNumber / PagesInXDirection))), System.Int32)
        mp_lColumn = lPageNumber - ((mp_lRow - 1) * PagesInXDirection)
        If ((mp_lColumn - 1) * PageWidth) + PageWidth > mp_oControl.Printer.PrintAreaWidth Then
            mp_lPageWidth = mp_oControl.Printer.PrintAreaWidth - ((mp_lColumn - 1) * PageWidth)
        Else
            mp_lPageWidth = PageWidth
        End If
        If ((mp_lRow - 1) * PageHeight) + PageHeight > mp_oControl.Printer.PrintAreaHeight Then
            mp_lPageHeight = mp_oControl.Printer.PrintAreaHeight - ((mp_lRow - 1) * PageHeight)
        Else
            mp_lPageHeight = PageHeight
        End If
        Dim lXMargin As Integer = 0
        Dim lYMargin As Integer = 0
        If ToPrinter = True Then
            mp_oPrinter.Print()
        Else
            lXMargin = CType((XMargin + m_lXPreviewMargin + lPhysicalOffsetX - lHScrollPos) * 100 / Scale(), System.Int32)
            lYMargin = CType((YMargin + m_lYPreviewMargin + lPhysicalOffsetY - lVScrollPos) * 100 / Scale(), System.Int32)
            mp_oControl.Printer.PrintControl(oGraphics, (mp_lColumn - 1) * PageWidth, (mp_lRow - 1) * PageHeight, mp_lPageWidth, mp_lPageHeight, lXMargin, lYMargin, Scale)
        End If
    End Sub

    Public Property XMargin() As Integer
        Get
            Return mp_lXMargin
        End Get
        Set(ByVal vNewValue As Integer)
            mp_lXMargin = vNewValue
        End Set
    End Property

    Public Property YMargin() As Integer
        Get
            Return mp_lYMargin
        End Get
        Set(ByVal vNewValue As Integer)
            mp_lYMargin = vNewValue
        End Set
    End Property

    Private Sub cboPrinters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrinters.SelectedIndexChanged
        mp_oPrinter.PrinterSettings.PrinterName = CType(cboPrinters.Items(cboPrinters.SelectedIndex), System.String)
    End Sub

    Private Sub cboOrientation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrientation.SelectedIndexChanged
        If cboOrientation.SelectedIndex = 0 Then
            mp_oPrinter.DefaultPageSettings.Landscape = False
        Else
            mp_oPrinter.DefaultPageSettings.Landscape = True
        End If
    End Sub

    Private Function InitializePrinter() As Boolean
        mp_dtStartDate = New DateTime(GetTextNum(txtSDYear, 0), GetTextNum(txtSDMonth, 0), GetTextNum(txtSDDay, 0), GetTextNum(txtSDHour, 0), GetTextNum(txtSDMinute, 0), GetTextNum(txtSDSecond, 0))
        mp_dtEndDate = New DateTime(GetTextNum(txtEDYear, 0), GetTextNum(txtEDMonth, 0), GetTextNum(txtEDDay, 0), GetTextNum(txtEDHour, 0), GetTextNum(txtEDMinute, 0), GetTextNum(txtEDSecond, 0))
        If mp_dtStartDate.DateTimePart.Ticks = 0 Then
            Return False
        End If
        If mp_dtEndDate.DateTimePart.Ticks = 0 Then
            Return False
        End If
        If mp_dtEndDate <= mp_dtStartDate Then
            MessageBox.Show("The end date cannot be smaller than or equal to the start date.")
            Return False
        End If
        If PageWidth = 0 Then
            MessageBox.Show("The page width must be greater than zero.")
            Return False
        End If
        If PageHeight = 0 Then
            MessageBox.Show("The page height must be greater than zero.")
            Return False
        End If
        mp_oControl.Printer.Initialize(mp_dtStartDate, mp_dtEndDate, -1)
        Return True
    End Function

    Private Sub txtSDYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSDYear.TextChanged
        Recalculate()
    End Sub

    Private Sub txtSDMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSDMonth.TextChanged
        Recalculate()
    End Sub

    Private Sub txtSDDay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSDDay.TextChanged
        Recalculate()
    End Sub

    Private Sub txtSDHour_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSDHour.TextChanged
        Recalculate()
    End Sub

    Private Sub txtSDMinute_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSDMinute.TextChanged
        Recalculate()
    End Sub

    Private Sub txtSDSecond_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSDSecond.TextChanged
        Recalculate()
    End Sub

    Private Sub txtEDYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEDYear.TextChanged
        Recalculate()
    End Sub

    Private Sub txtEDMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEDMonth.TextChanged
        Recalculate()
    End Sub

    Private Sub txtEDDay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEDDay.TextChanged
        Recalculate()
    End Sub

    Private Sub txtEDHour_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEDHour.TextChanged
        Recalculate()
    End Sub

    Private Sub txtEDMinute_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEDMinute.TextChanged
        Recalculate()
    End Sub

    Private Sub txtEDSecond_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEDSecond.TextChanged
        Recalculate()
    End Sub

    Private Sub txtPageHeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPageHeight.TextChanged
        Recalculate()
    End Sub

    Private Sub txtPageWidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPageWidth.TextChanged
        Recalculate()
    End Sub

    Private Sub Recalculate()
        If (mp_bLoaded = False) Then
            Return
        End If
        If (InitializePrinter() = True) Then
            lblNumberOfPages.Text = "Total Pages: " & TotalPages
            txtEndPage.Text = TotalPages
        End If
    End Sub

End Class