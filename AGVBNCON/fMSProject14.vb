Option Explicit On
Option Strict On

Imports AGVBN

Public Class fMSProject14

    Private oMP14 As MSP2010.MP14
    Private mp_lControlDraw As Integer = 0
    Private mp_lControlRedrawn As Integer = 0
    Private Const mp_sFontName As String = "Tahoma"

#Region "Constructors"

#End Region

#Region "Form Loaded"

    Private Sub fMSProject14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "The Source Code Store - ActiveGantt Scheduler Control Version " & ActiveGanttVBNCtl1.Version & " - Microsoft Project 2010 integration using XML Files and the MSP2010 Integration Library"
        Me.Left = Owner.Left
        Me.Top = Owner.Top

        InitializeAG()
        ActiveGanttVBNCtl1.Redraw()

        Me.WindowState = FormWindowState.Maximized
    End Sub

#End Region

#Region "Form Resizing"

    Private Sub fMSProject14_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Left = 8
        GroupBox1.Top = 60
        GroupBox1.Width = Me.Width - 30
        GroupBox1.Height = Me.Height - 130
        ActiveGanttVBNCtl1.Left = 10
        ActiveGanttVBNCtl1.Top = 15
        ActiveGanttVBNCtl1.Width = Me.Width - 50
        ActiveGanttVBNCtl1.Height = Me.Height - 155
        ActiveGanttVBNCtl1.VerticalScrollBar.LargeChange = ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.LastVisibleRow - ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.FirstVisibleRow
    End Sub

#End Region

#Region "ActiveGantt Event Handlers"

    Private Sub ActiveGanttVBNCtl1_CustomTierDraw(ByVal sender As System.Object, ByVal e As AGVBN.CustomTierDrawEventArgs) Handles ActiveGanttVBNCtl1.CustomTierDraw
        If e.TierPosition = E_TIERPOSITION.SP_UPPER Then
            e.StyleIndex = "TimeLineTiers"
            If CType(ActiveGanttVBNCtl1.CurrentView, System.Int32) <= 4 Then
                e.Text = e.StartDate.Year() & " Q" & e.StartDate.Quarter()
            Else
                e.Text = e.StartDate.ToString("MMMM, yyyy")
            End If
        ElseIf e.TierPosition = E_TIERPOSITION.SP_LOWER Then
            e.StyleIndex = "TimeLineTiers"
            If CType(ActiveGanttVBNCtl1.CurrentView, System.Int32) <= 4 Then
                e.Text = e.StartDate.ToString("MMM")
            Else
                e.Text = e.StartDate.ToString("ddd")
            End If
        End If
    End Sub

    Private Sub ActiveGanttVBNCtl1_ControlMouseWheel(ByVal sender As System.Object, ByVal e As AGVBN.MouseWheelEventArgs) Handles ActiveGanttVBNCtl1.ControlMouseWheel
        If (e.Delta = 0) Or (ActiveGanttVBNCtl1.VerticalScrollBar.Visible = False) Then
            Return
        End If
        Dim lDelta As Integer = System.Convert.ToInt32(-(e.Delta / 50))
        Dim lInitialValue As Integer = ActiveGanttVBNCtl1.VerticalScrollBar.Value
        If (ActiveGanttVBNCtl1.VerticalScrollBar.Value + lDelta < 1) Then
            ActiveGanttVBNCtl1.VerticalScrollBar.Value = 1
        ElseIf (((ActiveGanttVBNCtl1.VerticalScrollBar.Value + lDelta) > ActiveGanttVBNCtl1.VerticalScrollBar.Max)) Then
            ActiveGanttVBNCtl1.VerticalScrollBar.Value = ActiveGanttVBNCtl1.VerticalScrollBar.Max
        Else
            ActiveGanttVBNCtl1.VerticalScrollBar.Value = ActiveGanttVBNCtl1.VerticalScrollBar.Value + lDelta
        End If
        ActiveGanttVBNCtl1.Redraw()
    End Sub

#End Region

#Region "Functions"

    Private Sub InitializeAG()

        Dim oStyle As clsStyle = Nothing
        Dim oView As clsView = Nothing

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ScrollBar")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 150, 158, 168)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ArrowButtons")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 150, 158, 168)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ThumbButton")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("TimeLineTiers")
        oStyle.Font = New Font(mp_sFontName, 7, FontStyle.Regular)
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_TRANSPARENT
        oStyle.CustomBorderStyle.Left = True
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Right = False
        oStyle.CustomBorderStyle.Bottom = True
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("TimeLine")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.StartGradientColor = Color.FromArgb(255, 197, 206, 216)
        oStyle.EndGradientColor = Color.White
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ColumnStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.StartGradientColor = Color.FromArgb(255, 197, 206, 216)
        oStyle.EndGradientColor = Color.White
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Left = False
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Right = True
        oStyle.CustomBorderStyle.Bottom = True
        oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("TaskStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.FromArgb(255, 199, 200, 255)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 148, 152, 179)
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.SelectionRectangleStyle.OffsetTop = 0
        oStyle.SelectionRectangleStyle.OffsetLeft = 0
        oStyle.SelectionRectangleStyle.OffsetRight = 0
        oStyle.SelectionRectangleStyle.OffsetBottom = 0
        oStyle.TextPlacement = E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT
        oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT
        oStyle.TextXMargin = 10
        oStyle.OffsetTop = 5
        oStyle.OffsetBottom = 10
        oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 180, 194, 209)
        oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND
        oStyle.MilestoneStyle.FillColor = Color.FromArgb(255, 199, 200, 255)
        oStyle.MilestoneStyle.BorderColor = Color.FromArgb(255, 148, 152, 179)
        oStyle.TextEditBackColor = Color.Blue
        oStyle.PredecessorStyle.XOffset = 4
        oStyle.PredecessorStyle.YOffset = 4

        oStyle = ActiveGanttVBNCtl1.Styles.Add("SummaryStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackColor = Color.Black
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE
        oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.OffsetTop = 5
        oStyle.OffsetBottom = 10
        oStyle.SelectionRectangleStyle.OffsetTop = 0
        oStyle.SelectionRectangleStyle.OffsetLeft = 0
        oStyle.SelectionRectangleStyle.OffsetRight = 0
        oStyle.SelectionRectangleStyle.OffsetBottom = 0
        oStyle.TextPlacement = E_TEXTPLACEMENT.SCP_EXTERIORPLACEMENT
        oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT
        oStyle.TextXMargin = 10
        oStyle.PredecessorStyle.LineColor = Color.Black
        oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN
        oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN

        oStyle = ActiveGanttVBNCtl1.Styles.Add("NodeStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackColor = Color.White
        oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False

        oStyle = ActiveGanttVBNCtl1.Styles.Add("CellStyleKeyColumn")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackColor = Color.White
        oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False
        oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT
        oStyle.TextXMargin = 4

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ClientAreaStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE

        ActiveGanttVBNCtl1.AllowRowMove = True
        ActiveGanttVBNCtl1.AllowRowSize = True
        ActiveGanttVBNCtl1.AllowAdd = False
        ActiveGanttVBNCtl1.Style.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        ActiveGanttVBNCtl1.Style.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        ActiveGanttVBNCtl1.Style.BorderColor = Color.FromArgb(255, 197, 206, 216)
        ActiveGanttVBNCtl1.Style.BorderWidth = 1

        ActiveGanttVBNCtl1.Splitter.Type = E_SPLITTERTYPE.SA_USERDEFINED
        ActiveGanttVBNCtl1.Splitter.Width = 1
        ActiveGanttVBNCtl1.Splitter.SetColor(1, Color.FromArgb(255, 197, 206, 216))
        ActiveGanttVBNCtl1.Splitter.Position = 285

        ActiveGanttVBNCtl1.Treeview.Images = True
        ActiveGanttVBNCtl1.Treeview.CheckBoxes = True
        ActiveGanttVBNCtl1.Treeview.FullColumnSelect = True
        ActiveGanttVBNCtl1.Treeview.TreeLines = False
        ActiveGanttVBNCtl1.Treeview.PlusMinusBorderColor = Color.FromArgb(255, 191, 205, 219)

        Dim oColumn As clsColumn

        oColumn = ActiveGanttVBNCtl1.Columns.Add("ID", "", 30, "")
        oColumn.StyleIndex = "ColumnStyle"
        oColumn.AllowTextEdit = True

        oColumn = ActiveGanttVBNCtl1.Columns.Add("Task Name", "", 300, "")
        oColumn.StyleIndex = "ColumnStyle"
        oColumn.AllowTextEdit = True

        ActiveGanttVBNCtl1.TreeviewColumnIndex = 2

        ActiveGanttVBNCtl1.ToolTip.Font = New Font(mp_sFontName, 8, FontStyle.Regular)

        ActiveGanttVBNCtl1.ScrollBarSeparator.StyleIndex = "ScrollBar"

        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.TimerInterval = 50
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButton"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButton"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButton"

        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButton"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButton"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButton"

        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_HOUR, 24, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM)
        oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER
        oView.TimeLine.TierArea.UpperTier.Factor = 1
        oView.TimeLine.TierArea.UpperTier.Height = 17
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH
        oView.TimeLine.TierArea.LowerTier.Factor = 1
        oView.TimeLine.TierArea.LowerTier.Height = 17
        oView.TimeLine.TickMarkArea.Visible = False
        oView.TimeLine.TimeLineScrollBar.StartDate = AGVBN.DateTime.Now
        oView.TimeLine.TimeLineScrollBar.Enabled = True
        oView.TimeLine.TimeLineScrollBar.Visible = False
        oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButton"
        oView.TimeLine.StyleIndex = "TimeLine"
        oView.ClientArea.DetectConflicts = False
        oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216)

        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_HOUR, 12, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM)
        oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER
        oView.TimeLine.TierArea.UpperTier.Factor = 1
        oView.TimeLine.TierArea.UpperTier.Height = 17
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH
        oView.TimeLine.TierArea.LowerTier.Factor = 1
        oView.TimeLine.TierArea.LowerTier.Height = 17
        oView.TimeLine.TickMarkArea.Visible = False
        oView.TimeLine.TimeLineScrollBar.StartDate = AGVBN.DateTime.Now
        oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR
        oView.TimeLine.TimeLineScrollBar.Factor = 1
        oView.TimeLine.TimeLineScrollBar.SmallChange = 12
        oView.TimeLine.TimeLineScrollBar.LargeChange = 240
        oView.TimeLine.TimeLineScrollBar.Max = 2000
        oView.TimeLine.TimeLineScrollBar.Value = 0
        oView.TimeLine.TimeLineScrollBar.Enabled = True
        oView.TimeLine.TimeLineScrollBar.Visible = True
        oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButton"
        oView.TimeLine.StyleIndex = "TimeLine"
        oView.ClientArea.DetectConflicts = False
        oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216)

        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_HOUR, 6, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM)
        oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER
        oView.TimeLine.TierArea.UpperTier.Factor = 1
        oView.TimeLine.TierArea.UpperTier.Height = 17
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH
        oView.TimeLine.TierArea.LowerTier.Factor = 1
        oView.TimeLine.TierArea.LowerTier.Height = 17
        oView.TimeLine.TickMarkArea.Visible = False
        oView.TimeLine.TimeLineScrollBar.StartDate = AGVBN.DateTime.Now
        oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR
        oView.TimeLine.TimeLineScrollBar.Factor = 1
        oView.TimeLine.TimeLineScrollBar.SmallChange = 6
        oView.TimeLine.TimeLineScrollBar.LargeChange = 480
        oView.TimeLine.TimeLineScrollBar.Max = 4000
        oView.TimeLine.TimeLineScrollBar.Value = 0
        oView.TimeLine.TimeLineScrollBar.Enabled = True
        oView.TimeLine.TimeLineScrollBar.Visible = True
        oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButton"
        oView.TimeLine.StyleIndex = "TimeLine"
        oView.ClientArea.DetectConflicts = False
        oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216)

        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_HOUR, 3, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM)
        oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER
        oView.TimeLine.TierArea.UpperTier.Factor = 1
        oView.TimeLine.TierArea.UpperTier.Height = 17
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH
        oView.TimeLine.TierArea.LowerTier.Factor = 1
        oView.TimeLine.TierArea.LowerTier.Height = 17
        oView.TimeLine.TickMarkArea.Visible = False
        oView.TimeLine.TimeLineScrollBar.StartDate = AGVBN.DateTime.Now
        oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR
        oView.TimeLine.TimeLineScrollBar.Factor = 1
        oView.TimeLine.TimeLineScrollBar.SmallChange = 3
        oView.TimeLine.TimeLineScrollBar.LargeChange = 960
        oView.TimeLine.TimeLineScrollBar.Max = 8000
        oView.TimeLine.TimeLineScrollBar.Value = 0
        oView.TimeLine.TimeLineScrollBar.Enabled = True
        oView.TimeLine.TimeLineScrollBar.Visible = True
        oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButton"
        oView.TimeLine.StyleIndex = "TimeLine"
        oView.ClientArea.DetectConflicts = False
        oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216)

        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_HOUR, 1, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM)
        oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_MONTH
        oView.TimeLine.TierArea.UpperTier.Factor = 1
        oView.TimeLine.TierArea.UpperTier.Height = 17
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_DAY
        oView.TimeLine.TierArea.LowerTier.Factor = 1
        oView.TimeLine.TierArea.LowerTier.Height = 17
        oView.TimeLine.TickMarkArea.Visible = False
        oView.TimeLine.TimeLineScrollBar.StartDate = AGVBN.DateTime.Now
        oView.TimeLine.TimeLineScrollBar.Interval = E_INTERVAL.IL_HOUR
        oView.TimeLine.TimeLineScrollBar.Factor = 1
        oView.TimeLine.TimeLineScrollBar.SmallChange = 48
        oView.TimeLine.TimeLineScrollBar.LargeChange = 2880
        oView.TimeLine.TimeLineScrollBar.Max = 24000
        oView.TimeLine.TimeLineScrollBar.Value = 0
        oView.TimeLine.TimeLineScrollBar.Enabled = True
        oView.TimeLine.TimeLineScrollBar.Visible = True
        oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButton"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButton"
        oView.TimeLine.StyleIndex = "TimeLine"
        oView.ClientArea.DetectConflicts = False
        oView.ClientArea.Grid.Color = Color.FromArgb(255, 197, 206, 216)

        ActiveGanttVBNCtl1.CurrentView = "5"

    End Sub

    Private Sub AGSetStartDate(ByVal dtStart As AGVBN.DateTime)
        Dim i As Integer = 0
        For i = 1 To ActiveGanttVBNCtl1.Views.Count
            ActiveGanttVBNCtl1.Views.Item(i.ToString()).TimeLine.TimeLineScrollBar.StartDate = dtStart
        Next
    End Sub

    Private Sub MP14_To_AG()
        Dim oAGTask As clsTask = Nothing
        Dim oAGRow As clsRow = Nothing
        Dim oMPTask As MSP2010.Task = Nothing
        Dim dtStartDate As AGVBN.DateTime = AGVBN.DateTime.Now
        Dim i As Integer = 0
        Dim j As Integer = 0
        '// Load Project Tasks
        For i = 1 To oMP14.oTasks.Count
            oMPTask = oMP14.oTasks.Item(i.ToString())
            oAGRow = ActiveGanttVBNCtl1.Rows.Add("K" & oMPTask.lUID.ToString())
            oAGRow.Cells.Item("1").Text = oMPTask.lUID.ToString()
            oAGRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumn"
            oAGRow.Height = 20
            oAGRow.ClientAreaStyleIndex = "ClientAreaStyle"
            oAGTask = ActiveGanttVBNCtl1.Tasks.Add("", "K" & oMPTask.lUID.ToString(), FromDate(oMPTask.dtStart), FromDate(oMPTask.dtFinish))
            oAGTask.Key = "K" & oMPTask.lUID.ToString()
            oAGTask.AllowedMovement = E_MOVEMENTTYPE.MT_RESTRICTEDTOROW
            oAGTask.AllowTextEdit = True
            If FromDate(oMPTask.dtStart) < dtStartDate Then
                dtStartDate = FromDate(oMPTask.dtStart)
            End If
            If oAGTask.StartDate = oAGTask.EndDate Then
                oAGTask.Text = oAGTask.StartDate.ToString("M/d")
            End If
            oAGRow.Node.Depth = oMPTask.lOutlineLevel
            oAGRow.Node.Text = oMPTask.sName
            oAGRow.Node.AllowTextEdit = True
            oAGRow.Node.StyleIndex = "NodeStyle"
            If oMPTask.sNotes.Length > 0 Then
                oAGRow.Node.Image = ImageList1.Images.Item(0)
                oAGRow.Node.ImageVisible = True
            End If
        Next
        ActiveGanttVBNCtl1.Rows.UpdateTree()
        '// Indent & set Predecessors
        For i = 1 To oMP14.oTasks.Count
            oMPTask = oMP14.oTasks.Item(i.ToString())
            oAGRow = ActiveGanttVBNCtl1.Rows.Item(i.ToString())
            oAGTask = ActiveGanttVBNCtl1.Tasks.Item(i.ToString())
            If oAGRow.Node.Children > 0 Then
                oAGTask.StyleIndex = "SummaryStyle"
            Else
                oAGTask.StyleIndex = "TaskStyle"
            End If
            For j = 1 To oMPTask.oPredecessorLink_C.Count
                Dim oMPPredecessor As MSP2010.TaskPredecessorLink = Nothing
                oMPPredecessor = oMPTask.oPredecessorLink_C.Item(j.ToString())
                ActiveGanttVBNCtl1.Predecessors.Add("K" & oMPTask.lUID.ToString(), "K" & oMPPredecessor.lPredecessorUID.ToString(), GetAGPredecessorType(oMPPredecessor.yType), "", "TaskStyle")
            Next
        Next
        'Assignments
        For i = 1 To oMP14.oAssignments.Count
            Dim oAssignment As MSP2010.Assignment = Nothing
            oAssignment = oMP14.oAssignments.Item(i.ToString())
            oAGTask = ActiveGanttVBNCtl1.Tasks.Item("K" & oAssignment.lTaskUID)
            If oAGTask.StartDate <> oAGTask.EndDate Then
                If oAssignment.lResourceUID > 0 Then
                    If oAGTask.Text.Length = 0 Then
                        oAGTask.Text = oMP14.oResources.Item("K" & oAssignment.lResourceUID).sName
                    Else
                        oAGTask.Text = oAGTask.Text & ", " & oMP14.oResources.Item("K" & oAssignment.lResourceUID).sName
                    End If
                End If
            End If
        Next
        dtStartDate = ActiveGanttVBNCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_DAY, -3, dtStartDate)
        AGSetStartDate(dtStartDate)
    End Sub

    Private Function GetAGPredecessorType(ByVal MPPredecessorType As MSP2010.E_TYPE_5) As AGVBN.E_CONSTRAINTTYPE
        Select Case MPPredecessorType
            Case MSP2010.E_TYPE_5.T_5_FF
                Return AGVBN.E_CONSTRAINTTYPE.PCT_END_TO_END
            Case MSP2010.E_TYPE_5.T_5_FS
                Return AGVBN.E_CONSTRAINTTYPE.PCT_END_TO_START
            Case MSP2010.E_TYPE_5.T_5_SF
                Return AGVBN.E_CONSTRAINTTYPE.PCT_START_TO_END
            Case MSP2010.E_TYPE_5.T_5_SS
                Return AGVBN.E_CONSTRAINTTYPE.PCT_START_TO_START
        End Select
        Return AGVBN.E_CONSTRAINTTYPE.PCT_END_TO_START
    End Function

#End Region

#Region "Toolbar Buttons"

    Private Sub cmdLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadXML.Click
        LoadXML()
    End Sub

    Private Sub cmdSaveXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveXML.Click
        SaveXML()
    End Sub

    Private Sub cmdZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZoomIn.Click
        If CType(ActiveGanttVBNCtl1.CurrentView, System.Int32) < ActiveGanttVBNCtl1.Views.Count Then
            ActiveGanttVBNCtl1.CurrentView = CType(CType(ActiveGanttVBNCtl1.CurrentView, System.Int32) + 1, System.String)
            ActiveGanttVBNCtl1.Redraw()
        End If
    End Sub

    Private Sub cmdZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZoomOut.Click
        If CType(ActiveGanttVBNCtl1.CurrentView, System.Int32) > 1 Then
            ActiveGanttVBNCtl1.CurrentView = CType(CType(ActiveGanttVBNCtl1.CurrentView, System.Int32) - 1, System.String)
            ActiveGanttVBNCtl1.Redraw()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Print()
    End Sub

    Private Sub cmdIndent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIndent.Click
        Indent()
    End Sub

#End Region

#Region "Menu Items"

    Private Sub LoadMSProject2010XMLFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadMSProject2010XMLFileToolStripMenuItem.Click
        LoadXML()
    End Sub

    Private Sub SaveMSProject2010XMLFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMSProject2010XMLFileToolStripMenuItem.Click
        SaveXML()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Print()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

#End Region

#Region "Toolbar Button & Menu Item Functions"

    Private Sub LoadXML()
        oMP14 = New MSP2010.MP14()
        OpenFileDialog1.Title = "Load MS-Project 2010 XML File"
        OpenFileDialog1.InitialDirectory = g_GetAppLocation() & "\MSP2010\"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*"
        If (OpenFileDialog1.ShowDialog(Me) = DialogResult.OK) Then
            If ValidateMSP2010(OpenFileDialog1.FileName) = False Then
                MsgBox("The file selected is not a valid Microsoft Project 2010 XML File.", MsgBoxStyle.OkOnly)
            Else
                Cursor.Current = Cursors.WaitCursor
                ActiveGanttVBNCtl1.Clear()
                oMP14.ReadXML(OpenFileDialog1.FileName)
                Cursor.Current = Cursors.WaitCursor
                InitializeAG()
                MP14_To_AG()
                ActiveGanttVBNCtl1.Redraw()
                ActiveGanttVBNCtl1.VerticalScrollBar.LargeChange = ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.LastVisibleRow - ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.FirstVisibleRow
                ActiveGanttVBNCtl1.Redraw()
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub

    Private Sub SaveXML()

        SaveFileDialog1.Title = "Save As MS-Project 2010 XML File"
        SaveFileDialog1.InitialDirectory = g_GetAppLocation() & "\MSP2010\"
        SaveFileDialog1.Filter = "XML File|*.xml"
        SaveFileDialog1.OverwritePrompt = True
        If (SaveFileDialog1.ShowDialog(Me) = DialogResult.OK) Then
            Me.Cursor = Cursors.WaitCursor
            oMP14.WriteXML(SaveFileDialog1.FileName)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Print()
        Dim oForm As New fPrintDialog(ActiveGanttVBNCtl1)
        oForm.ShowDialog(Me)
    End Sub

    Private Sub Indent()
        OpenFileDialog1.Title = "Load XML File"
        OpenFileDialog1.InitialDirectory = g_GetAppLocation() & "\MSP2010\"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*"
        If (OpenFileDialog1.ShowDialog(Me) = DialogResult.OK) Then
            SaveFileDialog1.Title = "Save XML File As"
            SaveFileDialog1.InitialDirectory = g_GetAppLocation() & "\MSP2010\"
            SaveFileDialog1.Filter = "XML File|*.xml"
            SaveFileDialog1.OverwritePrompt = True
            If (SaveFileDialog1.ShowDialog(Me) = DialogResult.OK) Then
                If (OpenFileDialog1.FileName <> SaveFileDialog1.FileName) Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim xDoc As New System.Xml.XmlDocument
                    xDoc.Load(OpenFileDialog1.FileName)
                    Dim oWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(SaveFileDialog1.FileName, System.Text.Encoding.UTF8)
                    oWriter.IndentChar = ControlChars.Tab
                    oWriter.Formatting = System.Xml.Formatting.Indented
                    xDoc.Save(oWriter)
                    oWriter.Close()
                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Function ValidateMSP2010(ByVal sFileName As String) As Boolean
        Dim sFile As String = g_ReadFile(sFileName)
        If sFile.Contains("<Project ") = False Then
            Return False
        End If
        If sFile.Contains("<SaveVersion>14</SaveVersion>") = False Then
            Return False
        End If
        Return True
    End Function

#End Region

End Class