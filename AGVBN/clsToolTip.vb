Option Explicit On
Imports System.Drawing

Public Class clsToolTip

    Private mp_oControl As ActiveGanttVBNCtl
    Private mp_lLeft As Integer
    Private mp_lTop As Integer
    Private mp_lWidth As Integer
    Private mp_lHeight As Integer
    Private mp_sText As String
    Private mp_bVisible As Boolean
    Private mp_bBackupDCActive As Boolean
    Private mp_lBackupBitmap As Bitmap
    Private mp_oFont As Font
    Private mp_lBackupLeft As Integer
    Private mp_lBackupTop As Integer
    Private mp_lBackupRight As Integer
    Private mp_lBackupBottom As Integer
    Private mp_bAutomaticSizing As Boolean = False
    Private mp_clrBackColor As Color = Color.LightYellow
    Private mp_clrForeColor As Color = Color.Black
    Private mp_clrBorderColor As Color = Color.Black

    Friend Sub New(ByVal Value As ActiveGanttVBNCtl)
        mp_oControl = Value
        mp_oFont = New Font("Tahoma", 8)
    End Sub

    Public Property Font() As Font
        Get
            Return mp_oFont
        End Get
        Set(ByVal Value As Font)
            mp_oFont = Value
        End Set
    End Property

    Public Property BackColor() As Color
        Get
            Return mp_clrBackColor
        End Get
        Set(ByVal Value As Color)
            mp_clrBackColor = Value
        End Set
    End Property

    Public Property ForeColor() As Color
        Get
            Return mp_clrForeColor
        End Get
        Set(ByVal Value As Color)
            mp_clrForeColor = Value
        End Set
    End Property

    Public Property BorderColor() As Color
        Get
            Return mp_clrBorderColor
        End Get
        Set(ByVal Value As Color)
            mp_clrBorderColor = Value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return mp_sText
        End Get
        Set(ByVal Value As String)
            mp_sText = Value
            If mp_bAutomaticSizing = True Then
                Dim lControlGraphics As Graphics = Nothing
                Dim oSize As SizeF = New SizeF(0, 0)
                lControlGraphics = mp_oControl.GetGraphicsObject()
                oSize = lControlGraphics.MeasureString(mp_sText, mp_oFont)
                mp_lWidth = System.Convert.ToInt32(oSize.Width)
                mp_lHeight = System.Convert.ToInt32(oSize.Height)
            End If
        End Set
    End Property

    Public Property AutomaticSizing() As Boolean
        Get
            Return mp_bAutomaticSizing
        End Get
        Set(ByVal Value As Boolean)
            mp_bAutomaticSizing = Value
        End Set
    End Property

    Public Property Left() As Integer
        Get
            Return mp_lLeft
        End Get
        Set(ByVal Value As Integer)
            mp_lLeft = Value
        End Set
    End Property

    Public ReadOnly Property Right() As Integer
        Get
            Return mp_lLeft + mp_lWidth
        End Get
    End Property

    Public Property Top() As Integer
        Get
            Return mp_lTop
        End Get
        Set(ByVal Value As Integer)
            mp_lTop = Value
        End Set
    End Property

    Public ReadOnly Property Bottom() As Integer
        Get
            Return mp_lTop + mp_lHeight
        End Get
    End Property

    Public Property Width() As Integer
        Get
            Return mp_lWidth
        End Get
        Set(ByVal Value As Integer)
            mp_lWidth = Value
        End Set
    End Property

    Public Property Height() As Integer
        Get
            Return mp_lHeight
        End Get
        Set(ByVal Value As Integer)
            mp_lHeight = Value
        End Set
    End Property

    Public Property Visible() As Boolean
        Get
            Return mp_bVisible
        End Get
        Set(ByVal Value As Boolean)
            Dim lControlGraphics As Graphics = Nothing
            Dim lControlHDC As IntPtr = New IntPtr()
            mp_bVisible = Value
            If (mp_bBackupDCActive = True) Then
                RestoreBackupDC()
            End If
            If (mp_lWidth = 0 Or mp_lHeight = 0) Then
                mp_bVisible = False
            End If
            If (mp_bVisible = True) Then
                Dim oPen As New Pen(Color.Black)
                lControlGraphics = mp_oControl.GetGraphicsObject()
                mp_lBackupBitmap = New Bitmap(mp_lWidth, mp_lHeight, lControlGraphics)
                lControlHDC = lControlGraphics.GetHdc()
                mp_lBackupLeft = mp_lLeft
                mp_lBackupTop = mp_lTop
                mp_lBackupRight = mp_lLeft + mp_lWidth
                mp_lBackupBottom = mp_lTop + mp_lHeight
                lControlGraphics.ReleaseHdc(lControlHDC)
                lControlGraphics.FillRectangle(New SolidBrush(mp_clrBackColor), mp_lLeft, mp_lTop, mp_lWidth, mp_lHeight)
                lControlGraphics.DrawLine(oPen, mp_lLeft, mp_lTop, mp_lLeft + mp_lWidth - 1, mp_lTop)
                lControlGraphics.DrawLine(oPen, mp_lLeft + mp_lWidth - 1, mp_lTop, mp_lLeft + mp_lWidth - 1, mp_lTop + mp_lHeight - 1)
                lControlGraphics.DrawLine(oPen, mp_lLeft, mp_lTop, mp_lLeft, mp_lTop + mp_lHeight - 1)
                lControlGraphics.DrawLine(oPen, mp_lLeft, mp_lTop + mp_lHeight - 1, mp_lLeft + mp_lWidth - 1, mp_lTop + mp_lHeight - 1)
                mp_oControl.clsG.mp_oToolTipGraphics = lControlGraphics
                mp_oControl.clsG.bToolTipGraphics = True
                mp_oControl.clsG.ClipRegion(mp_lLeft, mp_lTop, Right - 1, Bottom - 1, False)
                Select Case mp_oControl.ToolTipEventArgs.ToolTipType
                    Case E_TOOLTIPTYPE.TPT_HOVER
                        mp_oControl.ToolTipEventArgs.Graphics = lControlGraphics
                        mp_oControl.ToolTipEventArgs.CustomDraw = False
                        mp_oControl.FireOnMouseHoverToolTipDraw(mp_oControl.ToolTipEventArgs.EventTarget)
                    Case E_TOOLTIPTYPE.TPT_MOVEMENT
                        mp_oControl.ToolTipEventArgs.Graphics = lControlGraphics
                        mp_oControl.ToolTipEventArgs.CustomDraw = False
                        mp_oControl.FireOnMouseMoveToolTipDraw(mp_oControl.ToolTipEventArgs.Operation)
                End Select
                mp_oControl.clsG.ClearClipRegion()
                mp_oControl.clsG.bToolTipGraphics = False
                If mp_oControl.ToolTipEventArgs.CustomDraw = False Then
                    lControlGraphics.DrawString(mp_sText, mp_oFont, New SolidBrush(mp_clrForeColor), mp_lLeft, mp_lTop)
                End If
                lControlGraphics.Dispose()
                mp_bBackupDCActive = True
            End If
        End Set
    End Property

    Private Sub RestoreBackupDC()
        Dim lControlGraphics As Graphics = Nothing
        lControlGraphics = mp_oControl.GetGraphicsObject()
        If mp_bVisible = True Then
            Dim oRect As Rectangle = New Rectangle(0, 0, 0, 0)
            oRect.X = mp_lLeft
            oRect.Y = mp_lTop
            oRect.Width = mp_lWidth
            oRect.Height = mp_lHeight
            lControlGraphics.ExcludeClip(oRect)
        End If
        lControlGraphics.DrawImage(mp_oControl.GetBitmap(), 0, 0)
        mp_bBackupDCActive = False
    End Sub

End Class
