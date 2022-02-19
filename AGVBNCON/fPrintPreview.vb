Option Explicit On
Option Strict On


Partial Public Class fPrintPreview
    Inherits System.Windows.Forms.Form

    Public mp_oParent As fPrintDialog
    Private mp_lPageNumber As Integer
    Private mp_oBitmap As System.Drawing.Bitmap
    Private mp_oGraphics As Graphics

    Private mp_lPhysicalOffsetX As Integer
    Private mp_lPhysicalOffsetY As Integer
    Private mp_lPhysicalWidth As Integer
    Private mp_lPhysicalHeight As Integer

    Private Const PHYSICALOFFSETX As Integer = 112  '  Physical Printable Area x margin
    Private Const PHYSICALOFFSETY As Integer = 113 '  Physical Printable Area y margin
    Private Const LOGPIXELSX As Integer = 88

    '  Logical pixels/inch in X
    Private Const LOGPIXELSY As Integer = 90        '  Logical pixels/inch in Y
    Private Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc As IntPtr, ByVal nIndex As Integer) As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
    End Sub

    Private Sub fPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = Owner.Left
        Me.Top = Owner.Top
        mp_lPageNumber = 1
        WritePageNumber()
        WriteXMargin()
        WriteYMargin()
        Dim oGraphics As System.Drawing.Graphics
        Dim oPrinterGraphics As System.Drawing.Graphics

        oGraphics = Me.CreateGraphics
        oPrinterGraphics = mp_oParent.mp_oPrinter.PrinterSettings.CreateMeasurementGraphics()

        Dim iDpiX As Integer = CType(oPrinterGraphics.DpiX, System.Int32)
        Dim iDpiY As Integer = CType(oPrinterGraphics.DpiY, System.Int32)
        Dim lPrinterHdc As IntPtr = oPrinterGraphics.GetHdc()
        If (mp_oParent.cboOrientation.SelectedIndex = 0) Then
            mp_lPhysicalOffsetX = CType(GetDeviceCaps(lPrinterHdc, PHYSICALOFFSETX) / iDpiX * oGraphics.DpiX, System.Int32)
            mp_lPhysicalOffsetY = CType(GetDeviceCaps(lPrinterHdc, PHYSICALOFFSETY) / iDpiY * oGraphics.DpiY, System.Int32)
            mp_lPhysicalWidth = CType((mp_oParent.mp_oPrinter.DefaultPageSettings.PaperSize.Width() / 100) * oGraphics.DpiX, System.Int32)
            mp_lPhysicalHeight = CType((mp_oParent.mp_oPrinter.DefaultPageSettings.PaperSize.Height() / 100) * oGraphics.DpiY, System.Int32)
        Else
            mp_lPhysicalOffsetY = CType(GetDeviceCaps(lPrinterHdc, PHYSICALOFFSETX) / iDpiX * oGraphics.DpiX, System.Int32)
            mp_lPhysicalOffsetX = CType(GetDeviceCaps(lPrinterHdc, PHYSICALOFFSETY) / iDpiY * oGraphics.DpiY, System.Int32)
            mp_lPhysicalHeight = CType((mp_oParent.mp_oPrinter.DefaultPageSettings.PaperSize.Width() / 100) * oGraphics.DpiX, System.Int32)
            mp_lPhysicalWidth = CType((mp_oParent.mp_oPrinter.DefaultPageSettings.PaperSize.Height() / 100) * oGraphics.DpiY, System.Int32)
        End If
        oPrinterGraphics.ReleaseHdc(lPrinterHdc)

        m_HScroll.Minimum = 0
        m_HScroll.Maximum = mp_lPhysicalWidth + 500
        m_HScroll.LargeChange = 500
        m_HScroll.SmallChange = 50
        m_HScroll.Value = 0

        m_VScroll.Minimum = 0
        m_VScroll.Maximum = mp_lPhysicalHeight + 500
        m_VScroll.LargeChange = 500
        m_VScroll.SmallChange = 50
        m_VScroll.Value = 0

        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub WritePageNumber()
        lblPageNumber.Text = "Page: " & mp_lPageNumber & " of " & mp_oParent.TotalPages
    End Sub

    Private Sub WriteXMargin()
        lblXMargin.Text = "X-Margin = " & mp_oParent.XMargin
    End Sub

    Private Sub WriteYMargin()
        lblYMargin.Text = "Y-Margin = " & mp_oParent.YMargin
    End Sub

    Private Sub Draw()

        Dim lIncrement As Integer = 0
        Dim lInch As Integer = 0
        Dim lHdc As IntPtr
        Dim X As Integer = 0
        Dim Y As Integer = 0
        Dim sCaption As String = ""
        Dim Points(1) As Point
        Dim oFont As New System.Drawing.Font("Arial", 8)
        Dim oPen As New System.Drawing.Pen(Color.Black)


        Dim oClientRect As Rectangle

        oClientRect = Me.ClientRectangle()


        Dim lDialogWidth As Integer = 0
        Dim lDialogHeight As Integer = 0
        Dim lToolbarHeight As Integer = 25



        lDialogWidth = (oClientRect.Right - oClientRect.Left)
        lDialogHeight = (oClientRect.Bottom - oClientRect.Top)



        '// Position Controls

        m_VScroll.Left = lDialogWidth - 17
        m_VScroll.Top = 25
        m_VScroll.Width = 17
        m_VScroll.Height = lDialogHeight - 17 - 25

        m_HScroll.Left = 0
        m_HScroll.Top = lDialogHeight - 17
        m_HScroll.Width = lDialogWidth - 17
        m_HScroll.Height = 17

        cmdScrollBarsSeparator.Left = lDialogWidth - 17
        cmdScrollBarsSeparator.Top = lDialogHeight - 17
        cmdScrollBarsSeparator.Width = 17
        cmdScrollBarsSeparator.Height = 17

        mp_oGraphics.Clear(Color.White)
        lHdc = mp_oGraphics.GetHdc()
        lIncrement = CType(GetDeviceCaps(lHdc, LOGPIXELSX) / 16, System.Int32)
        lInch = GetDeviceCaps(lHdc, LOGPIXELSX)
        mp_oGraphics.ReleaseHdc(lHdc)
        mp_oGraphics.FillRectangle(New System.Drawing.SolidBrush(Color.DarkGray), 0, 0, lDialogWidth, lDialogHeight)
        mp_oGraphics.FillRectangle(New System.Drawing.SolidBrush(Color.White), mp_oParent.m_lXPreviewMargin - m_HScroll.Value, mp_oParent.m_lYPreviewMargin - m_VScroll.Value, mp_lPhysicalWidth, mp_lPhysicalHeight)

        mp_oParent.PrintControl(mp_oGraphics, mp_lPageNumber, False, mp_lPhysicalOffsetX, mp_lPhysicalOffsetY, m_HScroll.Value, m_VScroll.Value)

        '//Horizontal Ruler
        mp_oGraphics.FillRectangle(New System.Drawing.SolidBrush(Color.LightGray), 0, 25, lDialogWidth, 25)
        For X = mp_oParent.m_lXPreviewMargin To mp_lPhysicalWidth + mp_oParent.m_lXPreviewMargin Step lIncrement
            Points(0).X = X - m_HScroll.Value
            If ((X - mp_oParent.m_lXPreviewMargin) Mod 96 = 0) Then
                sCaption = CType((X - mp_oParent.m_lXPreviewMargin) / lInch, System.String)
                mp_oGraphics.DrawString(sCaption, oFont, New System.Drawing.SolidBrush(Color.Black), X - m_HScroll.Value, lToolbarHeight)
                Points(0).Y = 14 + lToolbarHeight
            ElseIf ((X - mp_oParent.m_lXPreviewMargin) Mod 48 = 0) Then
                Points(0).Y = 16 + lToolbarHeight
            ElseIf ((X - mp_oParent.m_lXPreviewMargin) Mod 24 = 0) Then
                Points(0).Y = 18 + lToolbarHeight
            Else
                Points(0).Y = 20 + lToolbarHeight
            End If
            Points(1).X = X - m_HScroll.Value
            Points(1).Y = 25 + lToolbarHeight
            mp_oGraphics.DrawPolygon(oPen, Points)
        Next X


        mp_oGraphics.FillRectangle(New System.Drawing.SolidBrush(Color.LightGray), 0, 0, 25, lDialogHeight)


        For Y = mp_oParent.m_lYPreviewMargin To mp_lPhysicalHeight + mp_oParent.m_lYPreviewMargin Step lIncrement
            If ((Y - mp_oParent.m_lYPreviewMargin) Mod 96 = 0) Then
                sCaption = CType((Y - mp_oParent.m_lYPreviewMargin) / lInch, System.String)
                mp_oGraphics.DrawString(sCaption, oFont, New System.Drawing.SolidBrush(Color.Black), 0, Y - m_VScroll.Value)
                Points(0).X = 14
            ElseIf ((Y - mp_oParent.m_lYPreviewMargin) Mod 48 = 0) Then
                Points(0).X = 16
            ElseIf ((Y - mp_oParent.m_lYPreviewMargin) Mod 24 = 0) Then
                Points(0).X = 18
            Else
                Points(0).X = 20
            End If
            Points(0).Y = Y - m_VScroll.Value
            Points(1).X = 25
            Points(1).Y = Y - m_VScroll.Value
            mp_oGraphics.DrawPolygon(oPen, Points)
        Next Y

        mp_oGraphics.FillRectangle(New System.Drawing.SolidBrush(Color.LightGray), 0, 0, 25, 25)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        mp_oBitmap = New System.Drawing.Bitmap(Me.Width, Me.Height)
        mp_oGraphics = System.Drawing.Graphics.FromImage(mp_oBitmap)
        Draw()
        e.Graphics.DrawImage(mp_oBitmap, 0, 0)
    End Sub


    Private Sub mp_lVScroll_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles m_VScroll.Scroll
        Me.Invalidate()
    End Sub

    Private Sub mp_lHScroll_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles m_HScroll.Scroll
        Me.Invalidate()
    End Sub

    Private Sub fPrint_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub cmdPreviousPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousPage.Click
        If mp_lPageNumber > 1 Then
            mp_lPageNumber = mp_lPageNumber - 1
        End If
        WritePageNumber()
        Me.Invalidate()
    End Sub

    Private Sub cmdNextPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextPage.Click
        If mp_lPageNumber < mp_oParent.TotalPages Then
            mp_lPageNumber = mp_lPageNumber + 1
        End If
        WritePageNumber()
        Me.Invalidate()
    End Sub

    Private Sub cmdXMarginPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXMarginPlus.Click
        mp_oParent.XMargin = mp_oParent.XMargin + 10
        WriteXMargin()
        Me.Invalidate()
    End Sub

    Private Sub cmdXMarginMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXMarginMinus.Click
        mp_oParent.XMargin = mp_oParent.XMargin - 10
        WriteXMargin()
        Me.Invalidate()
    End Sub

    Private Sub cmdYMarginPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYMarginPlus.Click
        mp_oParent.YMargin = mp_oParent.YMargin + 10
        WriteYMargin()
        Me.Invalidate()
    End Sub

    Private Sub cmdYMarginMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYMarginMinus.Click
        mp_oParent.YMargin = mp_oParent.YMargin - 10
        WriteYMargin()
        Me.Invalidate()
    End Sub
End Class