Option Explicit On 

Public Class clsPrinter

    Private mp_oControl As ActiveGanttVBNCtl
    Private mp_dtPrintAreaStartDate As AGVBN.DateTime
    Private mp_dtPrintAreaEndDate As AGVBN.DateTime
    Private mp_dtPrintStartDateBuffer As AGVBN.DateTime
    Private mp_oView As clsView

    Friend Sub New(ByVal Value As ActiveGanttVBNCtl)
        mp_oControl = Value
    End Sub

    Public Sub Initialize(ByVal StartDate As AGVBN.DateTime, ByVal EndDate As AGVBN.DateTime, Optional ByVal ControlHeight As Integer = -1)
        Const CorrectionFactor As Integer = 5

        mp_oView = mp_oControl.CurrentViewObject
        mp_dtPrintAreaStartDate = StartDate
        mp_dtPrintAreaEndDate = EndDate
        mp_oControl.clsG.CustomWidth = mp_oControl.MathLib.DateTimeDiff(mp_oView.Interval, StartDate, EndDate) / mp_oView.Factor + CorrectionFactor
        mp_oControl.clsG.CustomWidth = mp_oControl.clsG.CustomWidth + mp_oControl.Splitter.Right
        If ControlHeight = -1 Then
            mp_oControl.clsG.CustomHeight = mp_oControl.Rows.Height + (mp_oControl.Rows.Count * 1) + mp_oControl.CurrentViewObject.ClientArea.Top + mp_oControl.mt_BorderThickness
            If mp_oControl.clsG.CustomHeight < mp_oControl.f_Height Then
                mp_oControl.clsG.CustomHeight = mp_oControl.f_Height
            End If
        Else
            mp_oControl.clsG.CustomHeight = mp_oControl.f_Height
        End If
        If mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Enabled = False Then
            mp_dtPrintStartDateBuffer = mp_oView.TimeLine.StartDate
            mp_oView.TimeLine.f_StartDate = mp_dtPrintAreaStartDate
        Else
            mp_dtPrintStartDateBuffer = mp_oView.TimeLine.TimeLineScrollBar.StartDate
            mp_oView.TimeLine.TimeLineScrollBar.StartDate = mp_dtPrintAreaStartDate
        End If
    End Sub

    Public Sub Terminate()
        If mp_oControl.CurrentViewObject.TimeLine.TimeLineScrollBar.Enabled = False Then
            mp_oView.TimeLine.f_StartDate = mp_dtPrintStartDateBuffer
        Else
            mp_oView.TimeLine.TimeLineScrollBar.StartDate = mp_dtPrintStartDateBuffer
        End If
    End Sub

    Public Sub PrintControl(ByRef oGraphics As Graphics, ByVal XOrigin As Integer, ByVal YOrigin As Integer, ByVal XOriginExtents As Integer, ByVal YOriginExtents As Integer, ByVal MarginX As Integer, ByVal MarginY As Integer, ByVal DestScale As Integer)
        Dim oBuffImage As New Bitmap(mp_oControl.MathLib.RoundDouble(PrintAreaWidth * DestScale / 100), mp_oControl.MathLib.RoundDouble(PrintAreaHeight * DestScale / 100), Imaging.PixelFormat.Format24bppRgb)
        Dim oBuffGraphics As Graphics
        Dim oBrush As New SolidBrush(mp_oControl.BackColor)
        Dim oOriginRect As Rectangle
        Dim oDestRect As Rectangle
        oBuffGraphics = Graphics.FromImage(oBuffImage)
        oBuffGraphics.ScaleTransform(DestScale / 100, DestScale / 100)
        oBuffGraphics.FillRectangle(oBrush, 0, 0, mp_oControl.MathLib.RoundDouble(PrintAreaWidth * DestScale / 100), mp_oControl.MathLib.RoundDouble(PrintAreaHeight * DestScale / 100))
        mp_oControl.clsG.CustomPrinting = True
        mp_oControl.mp_PositionScrollBars()
        mp_oControl.clsG.CustomDC = oBuffGraphics
        mp_oControl.f_Draw()
        oOriginRect.X = XOrigin
        oOriginRect.Y = YOrigin
        oOriginRect.Width = (XOriginExtents * DestScale / 100)
        oOriginRect.Height = (YOriginExtents * DestScale / 100)
        oDestRect.X = MarginX
        oDestRect.Y = MarginY
        oDestRect.Width = (XOriginExtents * DestScale / 100)
        oDestRect.Height = (YOriginExtents * DestScale / 100)
        oGraphics.DrawImage(oBuffImage, oDestRect, oOriginRect, Drawing.GraphicsUnit.Pixel)
        mp_oControl.clsG.CustomPrinting = False
        mp_oControl.mp_PositionScrollBars()
    End Sub

    Public ReadOnly Property PrintAreaEndDate() As AGVBN.DateTime
        Get
            Return mp_dtPrintAreaEndDate
        End Get
    End Property

    Public ReadOnly Property PrintAreaStartDate() As AGVBN.DateTime
        Get
            Return mp_dtPrintAreaStartDate
        End Get
    End Property

    Public ReadOnly Property PrintAreaWidth() As Integer
        Get
            Return mp_oControl.clsG.CustomWidth
        End Get
    End Property

    Public ReadOnly Property PrintAreaHeight() As Integer
        Get
            Return mp_oControl.clsG.CustomHeight
        End Get
    End Property

End Class
