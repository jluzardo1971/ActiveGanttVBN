Option Explicit On

Imports System.Data.OleDb
Imports AGVBN

Partial Friend Class fWBSProject
    Inherits System.Windows.Forms.Form

    Private mp_dtStartDate As AGVBN.DateTime
    Private mp_dtEndDate As AGVBN.DateTime
    Private Const mp_sFontName As String = "Tahoma"
    Friend mp_yDataSourceType As E_DATASOURCETYPE
    '//XML
    Friend mp_otb_GuysStThomas As DataSet
    Friend mp_otb_GuysStThomas_Predecessors As DataSet

    Private mp_bBluePercentagesVisible As Boolean = True
    Private mp_bGreenPercentagesVisible As Boolean = True
    Private mp_bRedPercentagesVisible As Boolean = True

#Region "Constructors"

    Public Sub New(ByVal yDataSourceType As E_DATASOURCETYPE)
        MyBase.New()
        InitializeComponent()
        mp_yDataSourceType = yDataSourceType
    End Sub

#End Region

#Region "Form Loaded"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        mp_dtStartDate = New AGVBN.DateTime()
        mp_dtEndDate = New AGVBN.DateTime()
        Dim dtStartDate As AGVBN.DateTime = New AGVBN.DateTime()

        Me.Text = "Work Breakdown Structure (WBS) Project Management Example - "
        If mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            Me.Text = Me.Text & "Microsoft Access data source (32bit compatible only) - "
        ElseIf mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
            Me.Text = Me.Text & "XML data source (32bit and 64bit compatible) - "
        ElseIf mp_yDataSourceType = E_DATASOURCETYPE.DST_NONE Then
            Me.Text = Me.Text & "No data source (32bit and 64bit compatible) - "
        End If
        Me.Text = Me.Text & "ActiveGanttVBN Version: " & ActiveGanttVBNCtl1.Version
        Me.Left = Owner.Left
        Me.Top = Owner.Top

        Dim oStyle As clsStyle = Nothing
        Dim oView As clsView = Nothing

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ControlStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.BorderColor = Color.FromArgb(255, 100, 145, 204)
        oStyle.BackColor = Color.FromArgb(255, 240, 240, 240)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ScrollBar")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 150, 150, 150)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ArrowButtons")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 150, 150, 150)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ThumbButtonH")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.StartGradientColor = Color.FromArgb(255, 240, 240, 240)
        oStyle.EndGradientColor = Color.FromArgb(255, 165, 186, 207)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ThumbButtonV")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL
        oStyle.StartGradientColor = Color.FromArgb(255, 240, 240, 240)
        oStyle.EndGradientColor = Color.FromArgb(255, 165, 186, 207)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ThumbButtonHP")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.StartGradientColor = Color.FromArgb(255, 165, 186, 207)
        oStyle.EndGradientColor = Color.FromArgb(255, 240, 240, 240)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ThumbButtonVP")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_HORIZONTAL
        oStyle.StartGradientColor = Color.FromArgb(255, 165, 186, 207)
        oStyle.EndGradientColor = Color.FromArgb(255, 240, 240, 240)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 138, 145, 153)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ColumnStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.StartGradientColor = Color.FromArgb(255, 179, 206, 235)
        oStyle.EndGradientColor = Color.FromArgb(255, 161, 193, 232)
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.CustomBorderStyle.Left = False
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Right = True
        oStyle.CustomBorderStyle.Bottom = True
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.BorderColor = Color.FromArgb(255, 100, 145, 204)

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ScrollBarSeparatorStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.BorderColor = Color.FromArgb(255, 150, 150, 150)

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
        oStyle.StartGradientColor = Color.FromArgb(255, 179, 206, 235)
        oStyle.EndGradientColor = Color.FromArgb(255, 161, 193, 232)
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.BackColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_NONE

        oStyle = ActiveGanttVBNCtl1.Styles.Add("NodeRegular")
        oStyle.Font = New Font(mp_sFontName, 8, FontStyle.Regular)
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.White
        oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False

        oStyle = ActiveGanttVBNCtl1.Styles.Add("NodeRegularChecked")
        oStyle.Font = New Font(mp_sFontName, 8, FontStyle.Regular)
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.LightSteelBlue
        oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False

        oStyle = ActiveGanttVBNCtl1.Styles.Add("NodeBold")
        oStyle.Font = New Font(mp_sFontName, 8, FontStyle.Bold)
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.White
        oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False

        oStyle = ActiveGanttVBNCtl1.Styles.Add("NodeBoldChecked")
        oStyle.Font = New Font(mp_sFontName, 8, FontStyle.Bold)
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.LightSteelBlue
        oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ClientAreaChecked")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID
        oStyle.BackColor = Color.LightSteelBlue

        oStyle = ActiveGanttVBNCtl1.Styles.Add("NormalTask")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.BackColor = Color.FromArgb(255, 100, 145, 204)
        oStyle.BorderColor = Color.Blue
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.SelectionRectangleStyle.OffsetTop = 0
        oStyle.SelectionRectangleStyle.OffsetLeft = 0
        oStyle.SelectionRectangleStyle.OffsetRight = 0
        oStyle.SelectionRectangleStyle.OffsetBottom = 0
        oStyle.OffsetTop = 5
        oStyle.OffsetBottom = 10
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.StartGradientColor = Color.White
        oStyle.EndGradientColor = Color.FromArgb(255, 100, 145, 204)
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.PredecessorStyle.LineColor = Color.FromArgb(255, 100, 145, 204)
        oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND

        oStyle = ActiveGanttVBNCtl1.Styles.Add("NormalTaskWarning")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.BackColor = Color.FromArgb(255, 100, 145, 204)
        oStyle.BorderColor = Color.Red
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.SelectionRectangleStyle.OffsetTop = 0
        oStyle.SelectionRectangleStyle.OffsetLeft = 0
        oStyle.SelectionRectangleStyle.OffsetRight = 0
        oStyle.SelectionRectangleStyle.OffsetBottom = 0
        oStyle.OffsetTop = 5
        oStyle.OffsetBottom = 10
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.StartGradientColor = Color.White
        oStyle.EndGradientColor = Color.FromArgb(255, 100, 145, 204)
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.PredecessorStyle.LineColor = Color.Red
        oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND

        oStyle = ActiveGanttVBNCtl1.Styles.Add("SelectedPredecessor")
        oStyle.PredecessorStyle.LineColor = Color.Green

        oStyle = ActiveGanttVBNCtl1.Styles.Add("GreenSummary")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.BackColor = Color.Green
        oStyle.BorderColor = Color.Green
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.SelectionRectangleStyle.OffsetTop = 0
        oStyle.SelectionRectangleStyle.OffsetLeft = 0
        oStyle.SelectionRectangleStyle.OffsetRight = 0
        oStyle.SelectionRectangleStyle.OffsetBottom = 0
        oStyle.OffsetTop = 5
        oStyle.OffsetBottom = 10
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.StartGradientColor = Color.White
        oStyle.EndGradientColor = Color.Green
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND
        oStyle.SelectionRectangleStyle.Visible = False
        oStyle.TaskStyle.EndFillColor = Color.Green
        oStyle.TaskStyle.EndBorderColor = Color.Green
        oStyle.TaskStyle.StartFillColor = Color.Green
        oStyle.TaskStyle.StartBorderColor = Color.Green
        oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN
        oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN
        oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED

        oStyle = ActiveGanttVBNCtl1.Styles.Add("RedSummary")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.BackColor = Color.Red
        oStyle.BorderColor = Color.Red
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.OffsetTop = 5
        oStyle.OffsetBottom = 10
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_GRADIENT
        oStyle.StartGradientColor = Color.White
        oStyle.EndGradientColor = Color.Red
        oStyle.GradientFillMode = GRE_GRADIENTFILLMODE.GDT_VERTICAL
        oStyle.MilestoneStyle.ShapeIndex = GRE_FIGURETYPE.FT_DIAMOND
        oStyle.SelectionRectangleStyle.Visible = False
        oStyle.TaskStyle.EndFillColor = Color.Red
        oStyle.TaskStyle.EndBorderColor = Color.Red
        oStyle.TaskStyle.StartFillColor = Color.Red
        oStyle.TaskStyle.StartBorderColor = Color.Red
        oStyle.TaskStyle.StartShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN
        oStyle.TaskStyle.EndShapeIndex = GRE_FIGURETYPE.FT_PROJECTDOWN
        oStyle.FillMode = GRE_FILLMODE.FM_UPPERHALFFILLED

        oStyle = ActiveGanttVBNCtl1.Styles.Add("BluePercentages")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.BackColor = Color.Blue
        oStyle.BorderColor = Color.Blue
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.SelectionRectangleStyle.OffsetTop = 0
        oStyle.SelectionRectangleStyle.OffsetLeft = 0
        oStyle.SelectionRectangleStyle.OffsetRight = 0
        oStyle.SelectionRectangleStyle.OffsetBottom = 0
        oStyle.OffsetTop = 8
        oStyle.OffsetBottom = 4
        oStyle.SelectionRectangleStyle.Visible = True
        oStyle.TextVisible = False
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID

        oStyle = ActiveGanttVBNCtl1.Styles.Add("GreenPercentages")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.BackColor = Color.Green
        oStyle.BorderColor = Color.Green
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.SelectionRectangleStyle.OffsetTop = 0
        oStyle.SelectionRectangleStyle.OffsetLeft = 0
        oStyle.SelectionRectangleStyle.OffsetRight = 0
        oStyle.SelectionRectangleStyle.OffsetBottom = 0
        oStyle.OffsetTop = 5
        oStyle.OffsetBottom = 5
        oStyle.SelectionRectangleStyle.Visible = False
        oStyle.TextVisible = False
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID

        oStyle = ActiveGanttVBNCtl1.Styles.Add("RedPercentages")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.BackColor = Color.Red
        oStyle.BorderColor = Color.Red
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.SelectionRectangleStyle.OffsetTop = 0
        oStyle.SelectionRectangleStyle.OffsetLeft = 0
        oStyle.SelectionRectangleStyle.OffsetRight = 0
        oStyle.SelectionRectangleStyle.OffsetBottom = 0
        oStyle.OffsetTop = 5
        oStyle.OffsetBottom = 5
        oStyle.SelectionRectangleStyle.Visible = False
        oStyle.TextVisible = False
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID

        oStyle = ActiveGanttVBNCtl1.Styles.Add("InvisiblePercentages")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.Placement = E_PLACEMENT.PLC_OFFSETPLACEMENT
        oStyle.BackColor = Color.White
        oStyle.BorderColor = Color.White
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_SINGLE
        oStyle.SelectionRectangleStyle.OffsetTop = 0
        oStyle.SelectionRectangleStyle.OffsetLeft = 0
        oStyle.SelectionRectangleStyle.OffsetRight = 0
        oStyle.SelectionRectangleStyle.OffsetBottom = 0
        oStyle.OffsetTop = 5
        oStyle.OffsetBottom = 5
        oStyle.SelectionRectangleStyle.Visible = False
        oStyle.TextVisible = False
        oStyle.BackgroundMode = GRE_BACKGROUNDMODE.FP_SOLID

        oStyle = ActiveGanttVBNCtl1.Styles.Add("ClientAreaStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackColor = Color.White
        oStyle.BorderColor = Color.FromArgb(255, 197, 206, 216)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False
        oStyle.CustomBorderStyle.Right = False

        oStyle = ActiveGanttVBNCtl1.Styles.Add("CellStyleKeyColumn")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackColor = Color.White
        oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False
        oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT
        oStyle.TextXMargin = 4

        oStyle = ActiveGanttVBNCtl1.Styles.Add("CellStyle")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackColor = Color.White
        oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False

        oStyle = ActiveGanttVBNCtl1.Styles.Add("CellStyleKeyColumnChecked")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackColor = Color.LightSteelBlue
        oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False
        oStyle.TextAlignmentHorizontal = GRE_HORIZONTALALIGNMENT.HAL_RIGHT
        oStyle.TextXMargin = 4

        oStyle = ActiveGanttVBNCtl1.Styles.Add("CellStyleChecked")
        oStyle.Appearance = E_STYLEAPPEARANCE.SA_FLAT
        oStyle.BackColor = Color.LightSteelBlue
        oStyle.BorderColor = Color.FromArgb(255, 192, 192, 192)
        oStyle.BorderStyle = GRE_BORDERSTYLE.SBR_CUSTOM
        oStyle.CustomBorderStyle.Top = False
        oStyle.CustomBorderStyle.Left = False

        ActiveGanttVBNCtl1.ControlTag = "WBSProject"
        ActiveGanttVBNCtl1.StyleIndex = "ControlStyle"
        ActiveGanttVBNCtl1.ScrollBarSeparator.StyleIndex = "ScrollBarSeparatorStyle"
        ActiveGanttVBNCtl1.AllowRowMove = True
        ActiveGanttVBNCtl1.AllowRowSize = True
        ActiveGanttVBNCtl1.AddMode = E_ADDMODE.AT_BOTH

        Dim oColumn As clsColumn

        oColumn = ActiveGanttVBNCtl1.Columns.Add("ID", "", 30, "")
        oColumn.StyleIndex = "ColumnStyle"
        oColumn.AllowTextEdit = True

        oColumn = ActiveGanttVBNCtl1.Columns.Add("Task Name", "", 300, "")
        oColumn.StyleIndex = "ColumnStyle"
        oColumn.AllowTextEdit = True

        oColumn = ActiveGanttVBNCtl1.Columns.Add("StartDate", "", 125, "")
        oColumn.StyleIndex = "ColumnStyle"
        oColumn.AllowTextEdit = True

        oColumn = ActiveGanttVBNCtl1.Columns.Add("EndDate", "", 125, "")
        oColumn.StyleIndex = "ColumnStyle"
        oColumn.AllowTextEdit = True

        ActiveGanttVBNCtl1.TreeviewColumnIndex = 2

        ActiveGanttVBNCtl1.Treeview.Images = True
        ActiveGanttVBNCtl1.Treeview.CheckBoxes = True
        ActiveGanttVBNCtl1.Treeview.FullColumnSelect = True
        ActiveGanttVBNCtl1.Treeview.PlusMinusBorderColor = Color.FromArgb(255, 100, 145, 204)
        ActiveGanttVBNCtl1.Treeview.PlusMinusSignColor = Color.FromArgb(255, 100, 145, 204)
        ActiveGanttVBNCtl1.Treeview.CheckBoxBorderColor = Color.FromArgb(255, 100, 145, 204)
        ActiveGanttVBNCtl1.Treeview.TreeLineColor = Color.FromArgb(255, 100, 145, 204)

        ActiveGanttVBNCtl1.ToolTip.Font = New Font(mp_sFontName, 8, FontStyle.Regular)

        ActiveGanttVBNCtl1.Splitter.Type = E_SPLITTERTYPE.SA_USERDEFINED
        ActiveGanttVBNCtl1.Splitter.Width = 1
        ActiveGanttVBNCtl1.Splitter.SetColor(1, Color.FromArgb(255, 100, 145, 204))
        ActiveGanttVBNCtl1.Splitter.Position = 255

        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.TimerInterval = 50
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonV"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonVP"
        ActiveGanttVBNCtl1.VerticalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonV"

        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP"
        ActiveGanttVBNCtl1.HorizontalScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH"

        If mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            Access_LoadTasks()
        ElseIf mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
            XML_LoadTasks()
        ElseIf mp_yDataSourceType = E_DATASOURCETYPE.DST_NONE Then
            NoDataSource_LoadTasks()
        End If
        ActiveGanttVBNCtl1.Rows.UpdateTree()

        '// Start one month before the first task:
        dtStartDate = ActiveGanttVBNCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_MONTH, -1, mp_dtStartDate)

        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_HOUR, 24, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM)
        oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER
        oView.TimeLine.TierArea.UpperTier.Factor = 1
        oView.TimeLine.TierArea.UpperTier.Height = 17
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH
        oView.TimeLine.TierArea.LowerTier.Factor = 1
        oView.TimeLine.TierArea.LowerTier.Height = 17
        oView.TimeLine.TickMarkArea.Visible = False
        oView.TimeLine.TimeLineScrollBar.StartDate = dtStartDate
        oView.TimeLine.TimeLineScrollBar.Enabled = True
        oView.TimeLine.TimeLineScrollBar.Visible = False
        oView.TimeLine.TimeLineScrollBar.ScrollBar.StyleIndex = "ScrollBar"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.NormalStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.PressedStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ArrowButtons.DisabledStyleIndex = "ArrowButtons"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH"
        oView.TimeLine.StyleIndex = "TimeLine"
        oView.ClientArea.DetectConflicts = False

        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_HOUR, 12, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM)
        oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER
        oView.TimeLine.TierArea.UpperTier.Factor = 1
        oView.TimeLine.TierArea.UpperTier.Height = 17
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH
        oView.TimeLine.TierArea.LowerTier.Factor = 1
        oView.TimeLine.TierArea.LowerTier.Height = 17
        oView.TimeLine.TickMarkArea.Visible = False
        oView.TimeLine.TimeLineScrollBar.StartDate = dtStartDate
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
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH"
        oView.TimeLine.StyleIndex = "TimeLine"
        oView.ClientArea.DetectConflicts = False

        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_HOUR, 6, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_CUSTOM)
        oView.TimeLine.TierArea.UpperTier.Interval = E_INTERVAL.IL_QUARTER
        oView.TimeLine.TierArea.UpperTier.Factor = 1
        oView.TimeLine.TierArea.UpperTier.Height = 17
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TierArea.LowerTier.Interval = E_INTERVAL.IL_MONTH
        oView.TimeLine.TierArea.LowerTier.Factor = 1
        oView.TimeLine.TierArea.LowerTier.Height = 17
        oView.TimeLine.TickMarkArea.Visible = False
        oView.TimeLine.TimeLineScrollBar.StartDate = dtStartDate
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
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.NormalStyleIndex = "ThumbButtonH"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.PressedStyleIndex = "ThumbButtonHP"
        oView.TimeLine.TimeLineScrollBar.ScrollBar.ThumbButton.DisabledStyleIndex = "ThumbButtonH"
        oView.TimeLine.StyleIndex = "TimeLine"
        oView.ClientArea.DetectConflicts = False

        ActiveGanttVBNCtl1.CurrentView = "2"


        ActiveGanttVBNCtl1.Redraw()

        Me.WindowState = FormWindowState.Maximized
    End Sub

#End Region

#Region "Form Resizing"

    Private Sub fWBSProject_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        GroupBox1.Left = 8
        GroupBox1.Top = 60
        GroupBox1.Width = Me.Width - 30
        GroupBox1.Height = Me.Height - 130
        ActiveGanttVBNCtl1.Left = 10
        ActiveGanttVBNCtl1.Top = 15
        ActiveGanttVBNCtl1.Width = Me.Width - 50
        ActiveGanttVBNCtl1.Height = Me.Height - 155
    End Sub

#End Region

#Region "ActiveGantt Event Handlers"

    Private Sub ActiveGanttVBNCtl1_CustomTierDraw(ByVal sender As Object, ByVal e As AGVBN.CustomTierDrawEventArgs) Handles ActiveGanttVBNCtl1.CustomTierDraw
        If e.TierPosition = E_TIERPOSITION.SP_LOWER Then
            e.StyleIndex = "TimeLineTiers"
            e.Text = e.StartDate.ToString("MMM")
        ElseIf e.TierPosition = E_TIERPOSITION.SP_UPPER Then
            e.StyleIndex = "TimeLineTiers"
            e.Text = e.StartDate.Year() & " Q" & e.StartDate.Quarter()
        End If
    End Sub

    Private Sub ActiveGanttVBNCtl1_NodeChecked(ByVal sender As Object, ByVal e As NodeEventArgs) Handles ActiveGanttVBNCtl1.NodeChecked
        Dim oRow As clsRow
        oRow = ActiveGanttVBNCtl1.Rows.Item(e.Index.ToString())
        If oRow.Node.Checked = True Then
            oRow.ClientAreaStyleIndex = "ClientAreaChecked"
            oRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumnChecked"
            oRow.Cells.Item("3").StyleIndex = "CellStyleChecked"
            oRow.Cells.Item("4").StyleIndex = "CellStyleChecked"
            If oRow.Node.StyleIndex = "NodeBold" Then
                oRow.Node.StyleIndex = "NodeBoldChecked"
            Else
                oRow.Node.StyleIndex = "NodeRegularChecked"
            End If
        Else
            oRow.ClientAreaStyleIndex = "ClientAreaStyle"
            oRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumn"
            oRow.Cells.Item("3").StyleIndex = "CellStyle"
            oRow.Cells.Item("4").StyleIndex = "CellStyle"
            If oRow.Node.StyleIndex = "NodeBoldChecked" Then
                oRow.Node.StyleIndex = "NodeBold"
            Else
                oRow.Node.StyleIndex = "NodeRegular"
            End If
        End If
    End Sub

    Private Sub ActiveGanttVBNCtl1_ControlMouseDown(ByVal sender As Object, ByVal e As AGVBN.MouseEventArgs) Handles ActiveGanttVBNCtl1.ControlMouseDown
        If (e.EventTarget = E_EVENTTARGET.EVT_TASK Or e.EventTarget = E_EVENTTARGET.EVT_SELECTEDTASK) And e.Button = E_MOUSEBUTTONS.BTN_RIGHT Then
            Dim oForm As fWBSProjectTaskView
            oForm = New fWBSProjectTaskView(Me, ActiveGanttVBNCtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y))
            oForm.ShowDialog(Me)
            e.Cancel = True
        End If
    End Sub

    Private Sub ActiveGanttVBNCtl1_ObjectAdded(ByVal sender As Object, ByVal e As AGVBN.ObjectAddedEventArgs) Handles ActiveGanttVBNCtl1.ObjectAdded
        Select Case e.EventTarget
            Case E_EVENTTARGET.EVT_TASK, E_EVENTTARGET.EVT_MILESTONE
                Dim oTask As AGVBN.clsTask = Nothing
                oTask = GetTaskByRowKey(ActiveGanttVBNCtl1.Tasks.Item(e.TaskIndex.ToString()).RowKey)
                oTask.StartDate = ActiveGanttVBNCtl1.Tasks.Item(e.TaskIndex.ToString()).StartDate
                oTask.EndDate = ActiveGanttVBNCtl1.Tasks.Item(e.TaskIndex.ToString()).EndDate
                UpdateTask(oTask.Index)
                ActiveGanttVBNCtl1.Tasks.Remove(e.TaskIndex.ToString())
            Case E_EVENTTARGET.EVT_PREDECESSOR
                ActiveGanttVBNCtl1.Predecessors.Item(e.PredecessorObjectIndex.ToString()).StyleIndex = "NormalTask"
                ActiveGanttVBNCtl1.Predecessors.Item(e.PredecessorObjectIndex.ToString()).WarningStyleIndex = "NormalTaskWarning"
                ActiveGanttVBNCtl1.Predecessors.Item(e.PredecessorObjectIndex.ToString()).SelectedStyleIndex = "SelectedPredecessor"
                InsertPredecessor(e.PredecessorTaskKey, e.TaskKey, e.PredecessorType)
        End Select
    End Sub

    Private Sub ActiveGanttVBNCtl1_CompleteObjectMove(ByVal sender As Object, ByVal e As ObjectStateChangedEventArgs) Handles ActiveGanttVBNCtl1.CompleteObjectMove
        Select Case e.EventTarget
            Case E_EVENTTARGET.EVT_TASK
                UpdateTask(e.Index)
        End Select
    End Sub

    Private Sub ActiveGanttVBNCtl1_CompleteObjectSize(ByVal sender As Object, ByVal e As ObjectStateChangedEventArgs) Handles ActiveGanttVBNCtl1.CompleteObjectSize
        Select Case e.EventTarget
            Case E_EVENTTARGET.EVT_TASK
                UpdateTask(e.Index)
            Case E_EVENTTARGET.EVT_PERCENTAGE
                Dim lTaskIndex As Integer = 0
                lTaskIndex = ActiveGanttVBNCtl1.Tasks.Item(ActiveGanttVBNCtl1.Percentages.Item(e.Index.ToString()).TaskKey).Index
                UpdateTask(lTaskIndex)
        End Select
    End Sub

    Private Sub ActiveGanttVBNCtl1_ToolTipOnMouseHover(ByVal sender As Object, ByVal e As AGVBN.ToolTipEventArgs) Handles ActiveGanttVBNCtl1.ToolTipOnMouseHover
        Select Case e.EventTarget
            Case E_EVENTTARGET.EVT_TASK, E_EVENTTARGET.EVT_SELECTEDTASK, E_EVENTTARGET.EVT_PERCENTAGE, E_EVENTTARGET.EVT_SELECTEDPERCENTAGE
                TaskToolTipCalculateDim(e)
                Return
        End Select
        ActiveGanttVBNCtl1.ToolTip.Visible = False
    End Sub

    Private Sub ActiveGanttVBNCtl1_OnMouseHoverToolTipDraw(ByVal sender As Object, ByVal e As AGVBN.ToolTipEventArgs) Handles ActiveGanttVBNCtl1.OnMouseHoverToolTipDraw
        Select Case e.EventTarget
            Case E_EVENTTARGET.EVT_TASK, E_EVENTTARGET.EVT_SELECTEDTASK, E_EVENTTARGET.EVT_PERCENTAGE, E_EVENTTARGET.EVT_SELECTEDPERCENTAGE
                TaskToolTipDraw(e)
                e.CustomDraw = True
                Return
        End Select
    End Sub

    Private Sub ActiveGanttVBNCtl1_ToolTipOnMouseMove(ByVal sender As Object, ByVal e As AGVBN.ToolTipEventArgs) Handles ActiveGanttVBNCtl1.ToolTipOnMouseMove
        Select Case e.Operation
            Case E_OPERATION.EO_PERCENTAGESIZING, E_OPERATION.EO_TASKMOVEMENT, E_OPERATION.EO_TASKSTRETCHLEFT, E_OPERATION.EO_TASKSTRETCHRIGHT
                TaskToolTipCalculateDim(e)
                Return
        End Select
        ActiveGanttVBNCtl1.ToolTip.Visible = False
    End Sub

    Private Sub ActiveGanttVBNCtl1_OnMouseMoveToolTipDraw(ByVal sender As Object, ByVal e As AGVBN.ToolTipEventArgs) Handles ActiveGanttVBNCtl1.OnMouseMoveToolTipDraw
        Select Case e.Operation
            Case E_OPERATION.EO_PERCENTAGESIZING, E_OPERATION.EO_TASKMOVEMENT, E_OPERATION.EO_TASKSTRETCHLEFT, E_OPERATION.EO_TASKSTRETCHRIGHT
                TaskToolTipDraw(e)
                e.CustomDraw = True
                Return
        End Select
    End Sub

    Private Sub ActiveGanttVBNCtl1_ControlMouseWheel(ByVal sender As System.Object, ByVal e As AGVBN.MouseWheelEventArgs) Handles ActiveGanttVBNCtl1.ControlMouseWheel
        If (e.Delta = 0) Or (ActiveGanttVBNCtl1.VerticalScrollBar.Visible = False) Then
            Return
        End If
        Dim lDelta As Integer = System.Convert.ToInt32(-(e.Delta / 100))
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

    Private Sub ActiveGanttVBNCtl1_EndTextEdit(ByVal sender As Object, ByVal e As AGVBN.TextEditEventArgs) Handles ActiveGanttVBNCtl1.EndTextEdit
        If mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            If e.ObjectType = E_TEXTOBJECTTYPE.TOT_NODE Then
                Using oConn As New OleDbConnection(g_DST_ACCESS_GetConnectionString())
                    Dim oRow As clsRow
                    Dim sRowKey As String
                    oRow = ActiveGanttVBNCtl1.Rows.Item(e.ObjectIndex)
                    sRowKey = oRow.Key
                    sRowKey = sRowKey.Replace("K", "")
                    Dim oCmd As OleDbCommand = Nothing
                    Dim sSQL As String = "UPDATE tb_GuysStThomas SET Description='" & e.Text & "' WHERE ID = " & sRowKey
                    oConn.Open()
                    oCmd = New OleDbCommand(sSQL, oConn)
                    oCmd.ExecuteNonQuery()
                    oConn.Close()
                End Using
            End If
        End If
    End Sub

#End Region

#Region "Tooltips"

    Private Sub TaskToolTipCalculateDim(ByVal e As AGVBN.ToolTipEventArgs)
        Dim Index As Integer = ActiveGanttVBNCtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y)
        Dim oToolTip As clsToolTip = ActiveGanttVBNCtl1.ToolTip
        Dim sRowKey As String = ""
        If Index = -1 Then
            sRowKey = ActiveGanttVBNCtl1.Rows.Item(ActiveGanttVBNCtl1.MathLib.GetRowIndexByPosition(e.Y).ToString()).Key
        Else
            sRowKey = ActiveGanttVBNCtl1.Tasks.Item(Index.ToString()).RowKey
        End If
        Dim sRowText As String = ActiveGanttVBNCtl1.Rows.Item(sRowKey).Text
        Dim TextFlags As New System.Drawing.StringFormat()
        Dim oSize As System.Drawing.SizeF = Nothing
        TextFlags.Alignment = StringAlignment.Center
        oSize = ActiveGanttVBNCtl1.Drawing.GraphicsInfo.MeasureString(sRowText, ActiveGanttVBNCtl1.ToolTip.Font, 300 - 18)
        oToolTip.AutomaticSizing = False
        oToolTip.Left = e.X + 20
        oToolTip.Top = CType(e.Y - (oSize.Height + 60) - 20, System.Int32)
        oToolTip.Width = 300
        oToolTip.Height = CType(oSize.Height + 60, System.Int32)
        If ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Width < oToolTip.Width Then
            oToolTip.Visible = False
            Return
        End If
        If ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Height < oToolTip.Height Then
            oToolTip.Visible = False
            Return
        End If
        If oToolTip.Left < ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Left Then
            oToolTip.Left = ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Left
        End If
        If oToolTip.Top < ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Top Then
            oToolTip.Top = ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Top
        End If
        If ActiveGanttVBNCtl1.ToolTip.Left + ActiveGanttVBNCtl1.ToolTip.Width > ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Right Then
            ActiveGanttVBNCtl1.ToolTip.Left = ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Right - oToolTip.Width
        End If
        If oToolTip.Top + oToolTip.Height > ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Bottom Then
            oToolTip.Top = ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Bottom - oToolTip.Height
        End If
        oToolTip.Visible = True
    End Sub

    Private Sub TaskToolTipDraw(ByVal e As AGVBN.ToolTipEventArgs)
        Dim Index As Integer = 0
        Dim sRowKey As String = ""
        Dim sTaskKey As String = ""
        Dim dtStartDate As AGVBN.DateTime = New AGVBN.DateTime()
        Dim dtEndDate As AGVBN.DateTime = New AGVBN.DateTime()
        Dim fPercentage As Single = 0
        Dim oPercentage As clsPercentage = Nothing
        Dim oTask As clsTask = Nothing
        If e.ToolTipType = E_TOOLTIPTYPE.TPT_HOVER Then
            Index = ActiveGanttVBNCtl1.MathLib.GetTaskIndexByPosition(e.X, e.Y)
            If Index < 1 Then
                Return
            End If
            oTask = ActiveGanttVBNCtl1.Tasks.Item(Index.ToString())
            sRowKey = oTask.RowKey
            dtStartDate = oTask.StartDate
            dtEndDate = oTask.EndDate
            sTaskKey = oTask.Key
            oPercentage = GetPercentageByTaskKey(sTaskKey)
            If Not oPercentage Is Nothing Then
                fPercentage = GetPercentageByTaskKey(sTaskKey).Percent * 100
            End If
        Else
            Index = e.TaskIndex
            If e.Operation = E_OPERATION.EO_TASKMOVEMENT Then
                sRowKey = ActiveGanttVBNCtl1.Rows.Item(e.InitialRowIndex.ToString()).Key
            Else
                sRowKey = ActiveGanttVBNCtl1.Rows.Item(e.RowIndex.ToString()).Key
            End If
            dtStartDate = e.StartDate
            dtEndDate = e.EndDate
            sTaskKey = ActiveGanttVBNCtl1.Tasks.Item(Index.ToString()).Key
            If e.Operation = E_OPERATION.EO_PERCENTAGESIZING Then
                fPercentage = CType((e.X - e.XStart) / (e.XEnd - e.XStart) * 100, System.Single)
            Else
                If Not oPercentage Is Nothing Then
                    fPercentage = oPercentage.Percent * 100
                End If
            End If
        End If
        Dim sStartDate As String = dtStartDate.ToString("ddd MMM d, yyyy")
        Dim sEndDate As String = dtEndDate.ToString("ddd MMM d, yyyy")
        Dim sFrom As String = "From: " & sStartDate & " To " & sEndDate
        Dim sDuration As String = "Duration: " & ActiveGanttVBNCtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_DAY, dtStartDate, dtEndDate) & " days"
        Dim sRowText As String = ActiveGanttVBNCtl1.Rows.Item(sRowKey).Text
        Dim sPercentage As String = fPercentage.ToString("00.00")
        Dim TextFlags As New System.Drawing.StringFormat()
        Dim oImage As System.Drawing.Image = ActiveGanttVBNCtl1.Rows.Item(sRowKey).Node.Image
        Dim oSize As System.Drawing.SizeF = Nothing
        TextFlags.Alignment = StringAlignment.Center
        oSize = e.Graphics.MeasureString(sRowText, ActiveGanttVBNCtl1.ToolTip.Font, e.X2 - (e.X1 + 18))
        ActiveGanttVBNCtl1.Drawing.PaintImage(oImage, e.X1 + 2, e.Y1 + 2, e.X1 + 17, e.Y1 + 17)
        ActiveGanttVBNCtl1.Drawing.DrawText(e.X1 + 18, e.Y1, e.X2, e.Y2, sRowText, TextFlags, Color.Black, ActiveGanttVBNCtl1.ToolTip.Font)
        ActiveGanttVBNCtl1.Drawing.DrawLine(e.X1, CType(e.Y1 + oSize.Height + 6, System.Int32), e.X2, CType(e.Y1 + oSize.Height + 6, System.Int32), Color.Black, GRE_LINEDRAWSTYLE.LDS_SOLID, 2)
        ActiveGanttVBNCtl1.Drawing.DrawAlignedText(e.X1 + 2, CType(e.Y1 + oSize.Height + 10, System.Int32), e.X1 + 300, CType(e.Y1 + oSize.Height + 25, System.Int32), sDuration, GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_CENTER, Color.Black, ActiveGanttVBNCtl1.ToolTip.Font)
        ActiveGanttVBNCtl1.Drawing.DrawAlignedText(e.X1 + 2, CType(e.Y1 + oSize.Height + 25, System.Int32), e.X1 + 300, CType(e.Y1 + oSize.Height + 40, System.Int32), sFrom, GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_CENTER, Color.Black, ActiveGanttVBNCtl1.ToolTip.Font)
        ActiveGanttVBNCtl1.Drawing.DrawAlignedText(e.X1 + 2, CType(e.Y1 + oSize.Height + 40, System.Int32), e.X1 + 300, CType(e.Y1 + oSize.Height + 55, System.Int32), "Percent Completed: " & sPercentage & "%", GRE_HORIZONTALALIGNMENT.HAL_LEFT, GRE_VERTICALALIGNMENT.VAL_CENTER, Color.Black, ActiveGanttVBNCtl1.ToolTip.Font)
    End Sub

#End Region

#Region "Form Properties"

#End Region

#Region "Functions"

    Private Sub UpdateTask(ByVal Index As Integer)
        Dim oPercentage As AGVBN.clsPercentage = GetPercentageByTaskKey(ActiveGanttVBNCtl1.Tasks.Item(Index.ToString()).Key)
        Dim oTask As clsTask
        oTask = ActiveGanttVBNCtl1.Tasks.Item(Index.ToString())
        SetTaskGridColumns(oTask)
        Dim sRowKey As String = oTask.RowKey
        Dim dtStartDate As AGVBN.DateTime = oTask.StartDate
        Dim dtEndDate As AGVBN.DateTime = oTask.EndDate
        Dim oNode As AGVBN.clsNode = ActiveGanttVBNCtl1.Rows.Item(sRowKey).Node
        If mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            Using oConn As New OleDbConnection(g_DST_ACCESS_GetConnectionString())
                Dim oCmd As OleDbCommand = Nothing
                Dim sSQL As String = "UPDATE tb_GuysStThomas SET " & _
                "StartDate = " & g_DST_ACCESS_ConvertDate(dtStartDate) & _
                ", EndDate = " & g_DST_ACCESS_ConvertDate(dtEndDate) & _
                ", PercentCompleted = " & oPercentage.Percent & _
                " WHERE ID = " & sRowKey.Replace("K", "")
                oConn.Open()
                oCmd = New OleDbCommand(sSQL, oConn)
                oCmd.ExecuteNonQuery()
                oConn.Close()
            End Using
        ElseIf mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
            Dim oDataRow As DataRow = Nothing
            oDataRow = mp_otb_GuysStThomas.Tables(1).Rows.Find(sRowKey.Replace("K", ""))
            oDataRow("StartDate") = dtStartDate.DateTimePart
            oDataRow("EndDate") = dtEndDate.DateTimePart
            oDataRow("PercentCompleted") = oPercentage.Percent
            mp_otb_GuysStThomas.WriteXml(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas.xml")
        End If
        UpdateSummary(oNode)
    End Sub

    Private Sub InsertPredecessor(ByVal PredecessorKey As String, ByVal SuccessorKey As String, ByVal PredecessorType As E_CONSTRAINTTYPE)
        If mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            Using oConn As New OleDbConnection(g_DST_ACCESS_GetConnectionString())
                Dim oCmd As OleDbCommand = Nothing
                PredecessorKey = PredecessorKey.Replace("T", "")
                SuccessorKey = SuccessorKey.Replace("T", "")
                Dim sSQL As String = "INSERT INTO tb_GuysStThomas_Predecessors (lPredecessorID, lSuccessorID, yType) VALUES (" & PredecessorKey.Replace("T", "") & "," & SuccessorKey.Replace("T", "") & "," & PredecessorType & ")"
                oConn.Open()
                oCmd = New OleDbCommand(sSQL, oConn)
                oCmd.ExecuteNonQuery()
                oConn.Close()
            End Using
        ElseIf mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
            Dim oDataRow As DataRow = Nothing
            Dim oLastRow As DataRow = Nothing
            oLastRow = mp_otb_GuysStThomas_Predecessors.Tables(1).Rows(mp_otb_GuysStThomas_Predecessors.Tables(1).Rows.Count - 1)
            oDataRow = mp_otb_GuysStThomas_Predecessors.Tables(1).NewRow()
            oDataRow("lID") = DirectCast(oLastRow.Item("ID"), System.Int32) + 1
            oDataRow("lPredecessorID") = PredecessorKey.Replace("T", "")
            oDataRow("lSuccessorID") = SuccessorKey.Replace("T", "")
            oDataRow("yType") = PredecessorType
            mp_otb_GuysStThomas_Predecessors.Tables(1).Rows.Add(oDataRow)
            mp_otb_GuysStThomas_Predecessors.WriteXml(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas_Predecessors.xml")
        End If
    End Sub

    Private Sub UpdateSummary(ByRef oNode As AGVBN.clsNode)
        Dim oConn As OleDbConnection = Nothing
        Dim oCmd As OleDbCommand = Nothing
        Dim sSQL As String = ""
        Dim oParentNode As AGVBN.clsNode = Nothing
        Dim oSummaryTask As AGVBN.clsTask = Nothing
        Dim oSummaryPercentage As AGVBN.clsPercentage = Nothing
        If mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            oConn = New OleDbConnection(g_DST_ACCESS_GetConnectionString())
            oConn.Open()
        End If
        oParentNode = oNode.Parent
        While Not oParentNode Is Nothing
            oSummaryTask = GetTaskByRowKey(oParentNode.Row.Key)
            oSummaryPercentage = GetPercentageByTaskKey(oSummaryTask.Key)
            If Not oSummaryTask Is Nothing Then
                Dim oChildTask As AGVBN.clsTask = Nothing
                Dim oChildPercentage As AGVBN.clsPercentage = Nothing
                Dim oChildNode As AGVBN.clsNode = Nothing
                Dim dtSumStartDate As AGVBN.DateTime = New AGVBN.DateTime()
                Dim dtSumEndDate As AGVBN.DateTime = New AGVBN.DateTime()
                Dim lPercentagesCount As Integer = 0
                Dim fPercentagesSum As Single = 0
                Dim fPercentageAvg As Single = 0
                oChildNode = oParentNode.Child
                While Not oChildNode Is Nothing
                    oChildTask = GetTaskByRowKey(oChildNode.Row.Key)
                    oChildPercentage = GetPercentageByTaskKey(oChildTask.Key)
                    lPercentagesCount = lPercentagesCount + 1
                    fPercentagesSum = fPercentagesSum + oChildPercentage.Percent
                    If Not oChildTask Is Nothing Then
                        If dtSumStartDate.DateTimePart.Ticks() = 0 Then
                            dtSumStartDate = oChildTask.StartDate
                        Else
                            If oChildTask.StartDate < dtSumStartDate Then
                                dtSumStartDate = oChildTask.StartDate
                            End If
                        End If
                        If dtSumEndDate.DateTimePart.Ticks() = 0 Then
                            dtSumEndDate = oChildTask.EndDate
                        Else
                            If oChildTask.EndDate > dtSumEndDate Then
                                dtSumEndDate = oChildTask.EndDate
                            End If
                        End If
                    End If
                    oChildNode = oChildNode.NextSibling
                End While
                fPercentageAvg = fPercentagesSum / lPercentagesCount
                oSummaryTask.StartDate = dtSumStartDate
                oSummaryTask.EndDate = dtSumEndDate
                SetTaskGridColumns(oSummaryTask)
                oSummaryPercentage.Percent = fPercentageAvg
                If mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
                    sSQL = "UPDATE tb_GuysStThomas SET " & _
                    "StartDate = " & g_DST_ACCESS_ConvertDate(dtSumStartDate) & _
                    ", EndDate = " & g_DST_ACCESS_ConvertDate(dtSumEndDate) & _
                    ", PercentCompleted = " & oSummaryPercentage.Percent & _
                    " WHERE ID = " & oSummaryTask.RowKey.Replace("K", "")
                    oCmd = New OleDbCommand(sSQL, oConn)
                    oCmd.ExecuteNonQuery()
                ElseIf mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
                    Dim oDataRow As DataRow = Nothing
                    oDataRow = mp_otb_GuysStThomas.Tables(1).Rows.Find(oSummaryTask.RowKey.Replace("K", ""))
                    oDataRow("StartDate") = dtSumStartDate.DateTimePart
                    oDataRow("EndDate") = dtSumEndDate.DateTimePart
                    oDataRow("PercentCompleted") = oSummaryPercentage.Percent
                    mp_otb_GuysStThomas.WriteXml(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas.xml")
                End If
            End If
            oParentNode = oParentNode.Parent
        End While

        If mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            oConn.Close()
        End If

    End Sub

    Private Function GetTaskByRowKey(ByVal sRowKey As String) As AGVBN.clsTask
        Dim i As Integer = 0
        Dim oTask As AGVBN.clsTask = Nothing
        For i = 1 To ActiveGanttVBNCtl1.Tasks.Count
            oTask = ActiveGanttVBNCtl1.Tasks.Item(i.ToString())
            If oTask.RowKey = sRowKey Then
                Return oTask
            End If
        Next
        Return Nothing
    End Function

    Private Function GetPercentageByTaskKey(ByVal sTaskKey As String) As AGVBN.clsPercentage
        Dim i As Integer = 0
        Dim oPercentage As AGVBN.clsPercentage = Nothing
        For i = 1 To ActiveGanttVBNCtl1.Percentages.Count
            oPercentage = ActiveGanttVBNCtl1.Percentages.Item(i.ToString())
            If oPercentage.TaskKey = sTaskKey Then
                Return oPercentage
            End If
        Next
        Return Nothing
    End Function

#End Region

#Region "Toolbar Buttons"

    Private Sub cmdSaveXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveXML.Click
        SaveXML()
    End Sub

    Private Sub cmdLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadXML.Click
        LoadXML()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Print()
    End Sub

    Private Sub cmdZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZoomIn.Click
        If CType(ActiveGanttVBNCtl1.CurrentView, System.Int32) < 3 Then
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

    Private Sub cmdBluePercentages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBluePercentages.Click
        Dim i As Integer
        Dim oPercentage As clsPercentage
        mp_bBluePercentagesVisible = Not mp_bBluePercentagesVisible
        For i = 1 To ActiveGanttVBNCtl1.Percentages.Count
            oPercentage = ActiveGanttVBNCtl1.Percentages.Item(i.ToString())
            If oPercentage.StyleIndex = "BluePercentages" Then
                oPercentage.Visible = mp_bBluePercentagesVisible
            End If
        Next
        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub cmdGreenPercentages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGreenPercentages.Click
        Dim i As Integer
        Dim oPercentage As clsPercentage
        mp_bGreenPercentagesVisible = Not mp_bGreenPercentagesVisible
        For i = 1 To ActiveGanttVBNCtl1.Percentages.Count
            oPercentage = ActiveGanttVBNCtl1.Percentages.Item(i.ToString())
            If oPercentage.StyleIndex = "GreenPercentages" Then
                oPercentage.Visible = mp_bGreenPercentagesVisible
            End If
        Next
        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub cmdRedPercentages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRedPercentages.Click
        Dim i As Integer
        Dim oPercentage As clsPercentage
        mp_bRedPercentagesVisible = Not mp_bRedPercentagesVisible
        For i = 1 To ActiveGanttVBNCtl1.Percentages.Count
            oPercentage = ActiveGanttVBNCtl1.Percentages.Item(i.ToString())
            If oPercentage.StyleIndex = "RedPercentages" Then
                oPercentage.Visible = mp_bRedPercentagesVisible
            End If
        Next
        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub cmdProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProperties.Click
        Dim oForm As New fWBSPProperties(Me)
        oForm.ShowDialog()
    End Sub

    Private Sub cmdCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheck.Click
        ActiveGanttVBNCtl1.CheckPredecessors()
        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub cmdToolTips_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolTips.Click
        ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.ToolTipsVisible = Not ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.ToolTipsVisible
        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub cmdHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelp.Click
        Me.Cursor = Cursors.WaitCursor
        System.Diagnostics.Process.Start("http://www.sourcecodestore.com/Article.aspx?ID=17")
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Menu Items"

    Private Sub mnuSaveXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveXML.Click
        SaveXML()
    End Sub

    Private Sub mnuLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadXML.Click
        LoadXML()
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        Print()
    End Sub

    Private Sub mnuClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub mnuCheckBoxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckBoxes.Click
        mnuCheckBoxes.Checked = Not mnuCheckBoxes.Checked
        ActiveGanttVBNCtl1.Treeview.CheckBoxes = mnuCheckBoxes.Checked
        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub mnuImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImages.Click
        mnuImages.Checked = Not mnuImages.Checked
        ActiveGanttVBNCtl1.Treeview.Images = mnuImages.Checked
        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub mnuPlusMinusSigns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPlusMinusSigns.Click
        mnuPlusMinusSigns.Checked = Not mnuPlusMinusSigns.Checked
        ActiveGanttVBNCtl1.Treeview.PlusMinusSigns = mnuPlusMinusSigns.Checked
        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub mnuFullColumnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFullColumnSelect.Click
        mnuFullColumnSelect.Checked = Not mnuFullColumnSelect.Checked
        ActiveGanttVBNCtl1.Treeview.FullColumnSelect = mnuFullColumnSelect.Checked
        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub mnuTreeLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTreeLines.Click
        mnuTreeLines.Checked = Not mnuTreeLines.Checked
        ActiveGanttVBNCtl1.Treeview.TreeLines = mnuTreeLines.Checked
        ActiveGanttVBNCtl1.Redraw()
    End Sub

#End Region

#Region "Toolbar Button & Menu Item Functions"

    Private Sub SaveXML()
        SaveFileDialog1.Title = "Save As XML"
        SaveFileDialog1.FileName = "AGVBN_WBSP"
        SaveFileDialog1.Filter = "XML File|*.xml"
        SaveFileDialog1.OverwritePrompt = True
        If (SaveFileDialog1.ShowDialog(Me) = DialogResult.OK) Then
            ActiveGanttVBNCtl1.WriteXML(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub LoadXML()
        Dim oForm As New fLoadXML()
        oForm.ShowDialog(Me)
    End Sub

    Private Sub Print()
        Dim oForm As New fPrintDialog(ActiveGanttVBNCtl1, New DateTime(2006, 8, 1, 0, 0, 0), New DateTime(2008, 1, 1, 0, 0, 0))
        oForm.ShowDialog(Me)
    End Sub

#End Region

#Region "Load Data"

    Public Sub Access_LoadTasks()
        Dim oRow As clsRow = Nothing
        Dim oTask As clsTask = Nothing
        Using oConn As New OleDbConnection(g_DST_ACCESS_GetConnectionString())
            Dim oCmd As OleDbCommand = Nothing
            Dim oReader As OleDbDataReader = Nothing
            oConn.Open()
            oCmd = New OleDbCommand("SELECT * FROM tb_GuysStThomas", oConn)
            oReader = oCmd.ExecuteReader
            While oReader.Read = True
                oRow = ActiveGanttVBNCtl1.Rows.Add("K" & CType(oReader.Item("ID"), System.String), DirectCast(oReader.Item("Description"), System.String))
                oRow.Cells.Item("1").Text = CType(oReader.Item("ID"), System.String)
                oRow.Cells.Item("1").StyleIndex = "CellStyle"
                oRow.Node.StyleIndex = "CellStyle"
                oRow.Cells.Item("3").StyleIndex = "CellStyle"
                oRow.Cells.Item("4").StyleIndex = "CellStyle"
                oRow.Height = 20
                oRow.ClientAreaStyleIndex = "ClientAreaStyle"
                oRow.Node.AllowTextEdit = True
                If DirectCast(oReader.Item("TaskType"), System.String) = "F" Then
                    If DirectCast(oReader.Item("Depth"), System.Int32) = 0 Then
                        oRow.Node.Image = imgTreeView.Images.Item(0)
                        oRow.Node.ExpandedImage = imgTreeView.Images.Item(1)
                        oRow.Node.StyleIndex = "NodeBold"
                    Else
                        oRow.Node.Image = imgTreeView.Images.Item(2)
                        oRow.Node.StyleIndex = "NodeRegular"
                    End If
                ElseIf DirectCast(oReader.Item("TaskType"), System.String) = "A" Then
                    oRow.Node.StyleIndex = "NodeRegular"
                    oRow.Node.Image = imgTreeView.Images.Item(3)
                    oRow.Node.CheckBoxVisible = True
                End If
                oRow.Node.Depth = DirectCast(oReader.Item("Depth"), System.Int32)
                oRow.Node.ImageVisible = True
                oRow.Node.AllowTextEdit = True
                If (Not IsDBNull(oReader.Item("StartDate")) And Not IsDBNull(oReader.Item("EndDate"))) Then
                    If (mp_dtStartDate.DateTimePart.Ticks() = 0) Then
                        mp_dtStartDate = FromDate(oReader.Item("StartDate"))
                    Else
                        If (FromDate(oReader.Item("StartDate")) < mp_dtStartDate) Then
                            mp_dtStartDate = FromDate(oReader.Item("StartDate"))
                        End If
                    End If
                    If (mp_dtEndDate.DateTimePart.Ticks() = 0) Then
                        mp_dtEndDate = FromDate(oReader.Item("EndDate"))
                    Else
                        If (FromDate(oReader.Item("EndDate")) > mp_dtEndDate) Then
                            mp_dtEndDate = FromDate(oReader.Item("EndDate"))
                        End If
                    End If
                    oTask = ActiveGanttVBNCtl1.Tasks.Add("", "K" & CType(oReader.Item("ID"), System.String), FromDate(oReader.Item("StartDate")), FromDate(oReader.Item("EndDate")), "T" & CType(oReader.Item("ID"), System.String))
                    SetTaskGridColumns(oTask)
                    If DirectCast(oReader.Item("Summary"), System.Boolean) = True Then
                        '// Prevent user from moving/sizing summary tasks
                        oTask.AllowedMovement = E_MOVEMENTTYPE.MT_MOVEMENTDISABLED
                        oTask.AllowStretchLeft = False
                        oTask.AllowStretchRight = False
                        '// Prevent user from adding tasks in these Rows
                        oRow.Container = False
                        '// Apply Summary Style 
                        If oRow.Node.Depth = 0 Then
                            oTask.StyleIndex = "RedSummary"
                            ActiveGanttVBNCtl1.Percentages.Add("T" & CType(oReader.Item("ID"), System.String), "RedPercentages", DirectCast(oReader.Item("PercentCompleted"), System.Single))
                        ElseIf oRow.Node.Depth = 1 Then
                            oTask.StyleIndex = "GreenSummary"
                            ActiveGanttVBNCtl1.Percentages.Add("T" & CType(oReader.Item("ID"), System.String), "GreenPercentages", DirectCast(oReader.Item("PercentCompleted"), System.Single))
                        End If
                        ActiveGanttVBNCtl1.Percentages.Item(ActiveGanttVBNCtl1.Percentages.Count.ToString()).AllowSize = False
                    Else
                        oTask.AllowedMovement = E_MOVEMENTTYPE.MT_RESTRICTEDTOROW
                        oTask.StyleIndex = "NormalTask"
                        oTask.WarningStyleIndex = "NormalTaskWarning"
                        If DirectCast(oReader.Item("HasTasks"), System.Boolean) = False Then
                            oTask.Visible = False
                            '// Prevent user from adding tasks in these rows
                            oRow.Container = False
                            ActiveGanttVBNCtl1.Percentages.Add("T" & CType(oReader.Item("ID"), System.String), "InvisiblePercentages", DirectCast(oReader.Item("PercentCompleted"), System.Single))
                            ActiveGanttVBNCtl1.Percentages.Item(ActiveGanttVBNCtl1.Percentages.Count.ToString()).AllowSize = False
                        Else
                            ActiveGanttVBNCtl1.Percentages.Add("T" & CType(oReader.Item("ID"), System.String), "BluePercentages", DirectCast(oReader.Item("PercentCompleted"), System.Single))
                        End If
                    End If
                End If
            End While
            oReader.Close()
            oCmd = New OleDbCommand("SELECT * FROM tb_GuysStThomas_Predecessors", oConn)
            oReader = oCmd.ExecuteReader
            Do While oReader.Read
                Dim oPredecessor As clsPredecessor
                oPredecessor = ActiveGanttVBNCtl1.Predecessors.Add("T" & oReader.Item("lSuccessorID").ToString(), "T" & oReader.Item("lPredecessorID").ToString(), oReader.Item("yType"), "", "NormalTask")
                oPredecessor.LagFactor = oReader.Item("lLagFactor")
                oPredecessor.LagInterval = oReader.Item("yLagInterval")
                oPredecessor.WarningStyleIndex = "NormalTaskWarning"
                oPredecessor.SelectedStyleIndex = "SelectedPredecessor"
            Loop
            oConn.Close()
        End Using

    End Sub

    Public Sub XML_LoadTasks()
        Dim oRow As clsRow = Nothing
        Dim oTask As clsTask = Nothing
        Dim oKeys_tb_GuysStThomas(0) As DataColumn
        Dim oKeys_tb_GuysStThomas_Predecessors(0) As DataColumn


        mp_otb_GuysStThomas = New DataSet()
        mp_otb_GuysStThomas.ReadXmlSchema(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas.xsd")
        mp_otb_GuysStThomas.ReadXml(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas.xml")
        oKeys_tb_GuysStThomas(0) = mp_otb_GuysStThomas.Tables(1).Columns("ID")
        mp_otb_GuysStThomas.Tables(1).PrimaryKey = oKeys_tb_GuysStThomas

        For Each oDataRow As DataRow In mp_otb_GuysStThomas.Tables(1).Rows
            oRow = ActiveGanttVBNCtl1.Rows.Add("K" & CType(oDataRow("ID"), System.String), DirectCast(oDataRow("Description"), System.String))
            oRow.Cells.Item("1").Text = CType(oDataRow("ID"), System.String)
            oRow.Cells.Item("1").StyleIndex = "CellStyle"
            oRow.Node.StyleIndex = "CellStyle"
            oRow.Cells.Item("3").StyleIndex = "CellStyle"
            oRow.Cells.Item("4").StyleIndex = "CellStyle"
            oRow.Height = 20
            oRow.ClientAreaStyleIndex = "ClientAreaStyle"
            oRow.Node.AllowTextEdit = True
            If DirectCast(oDataRow("TaskType"), System.String) = "F" Then
                If DirectCast(oDataRow("Depth"), System.Int32) = 0 Then
                    oRow.Node.Image = imgTreeView.Images.Item(0)
                    oRow.Node.ExpandedImage = imgTreeView.Images.Item(1)
                    oRow.Node.StyleIndex = "NodeBold"
                Else
                    oRow.Node.Image = imgTreeView.Images.Item(2)
                    oRow.Node.StyleIndex = "NodeRegular"
                End If
            ElseIf DirectCast(oDataRow("TaskType"), System.String) = "A" Then
                oRow.Node.StyleIndex = "NodeRegular"
                oRow.Node.Image = imgTreeView.Images.Item(3)
                oRow.Node.CheckBoxVisible = True
            End If
            oRow.Node.Depth = DirectCast(oDataRow("Depth"), System.Int32)
            oRow.Node.ImageVisible = True

            If (Not IsDBNull(oDataRow("StartDate")) And Not IsDBNull(oDataRow("EndDate"))) Then
                If (mp_dtStartDate.DateTimePart.Ticks() = 0) Then
                    mp_dtStartDate = FromDate(oDataRow("StartDate"))
                Else
                    If (FromDate(oDataRow("StartDate")) < mp_dtStartDate) Then
                        mp_dtStartDate = FromDate(oDataRow("StartDate"))
                    End If
                End If
                If (mp_dtEndDate.DateTimePart.Ticks() = 0) Then
                    mp_dtEndDate = FromDate(oDataRow("EndDate"))
                Else
                    If (FromDate(oDataRow("EndDate")) > mp_dtEndDate) Then
                        mp_dtEndDate = FromDate(oDataRow("EndDate"))
                    End If
                End If
                oTask = ActiveGanttVBNCtl1.Tasks.Add("", "K" & CType(oDataRow("ID"), System.String), FromDate(oDataRow("StartDate")), FromDate(oDataRow("EndDate")), "T" & CType(oDataRow("ID"), System.String))
                SetTaskGridColumns(oTask)
                If DirectCast(oDataRow("Summary"), System.Boolean) = True Then
                    '// Prevent user from moving/sizing summary tasks
                    oTask.AllowedMovement = E_MOVEMENTTYPE.MT_MOVEMENTDISABLED
                    oTask.AllowStretchLeft = False
                    oTask.AllowStretchRight = False
                    '// Prevent user from adding tasks in these Rows
                    oRow.Container = False
                    '// Apply Summary Style 
                    If oRow.Node.Depth = 0 Then
                        oTask.StyleIndex = "RedSummary"
                        ActiveGanttVBNCtl1.Percentages.Add("T" & CType(oDataRow("ID"), System.String), "RedPercentages", DirectCast(oDataRow("PercentCompleted"), System.Single))
                    ElseIf oRow.Node.Depth = 1 Then
                        oTask.StyleIndex = "GreenSummary"
                        ActiveGanttVBNCtl1.Percentages.Add("T" & CType(oDataRow("ID"), System.String), "GreenPercentages", DirectCast(oDataRow("PercentCompleted"), System.Single))
                    End If
                    ActiveGanttVBNCtl1.Percentages.Item(ActiveGanttVBNCtl1.Percentages.Count.ToString()).AllowSize = False
                Else
                    oTask.AllowedMovement = E_MOVEMENTTYPE.MT_RESTRICTEDTOROW
                    oTask.StyleIndex = "NormalTask"
                    oTask.WarningStyleIndex = "NormalTaskWarning"
                    If DirectCast(oDataRow("HasTasks"), System.Boolean) = False Then
                        oTask.Visible = False
                        '// Prevent user from adding tasks in these rows
                        oRow.Container = False
                        ActiveGanttVBNCtl1.Percentages.Add("T" & CType(oDataRow("ID"), System.String), "InvisiblePercentages", DirectCast(oDataRow("PercentCompleted"), System.Single))
                        ActiveGanttVBNCtl1.Percentages.Item(ActiveGanttVBNCtl1.Percentages.Count.ToString()).AllowSize = False
                    Else
                        ActiveGanttVBNCtl1.Percentages.Add("T" & CType(oDataRow("ID"), System.String), "BluePercentages", DirectCast(oDataRow("PercentCompleted"), System.Single))
                    End If
                End If
            End If
        Next

        mp_otb_GuysStThomas_Predecessors = New DataSet()
        mp_otb_GuysStThomas_Predecessors.ReadXmlSchema(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas_Predecessors.xsd")
        mp_otb_GuysStThomas_Predecessors.ReadXml(g_GetAppLocation() & "\HPM_XML\tb_GuysStThomas_Predecessors.xml")
        oKeys_tb_GuysStThomas_Predecessors(0) = mp_otb_GuysStThomas_Predecessors.Tables(1).Columns("ID")
        mp_otb_GuysStThomas_Predecessors.Tables(1).PrimaryKey = oKeys_tb_GuysStThomas_Predecessors

        For Each oDataRow As DataRow In mp_otb_GuysStThomas_Predecessors.Tables(1).Rows
            Dim oPredecessor As clsPredecessor
            oPredecessor = ActiveGanttVBNCtl1.Predecessors.Add("T" & oDataRow("lSuccessorID").ToString(), "T" & oDataRow("lPredecessorID").ToString(), oDataRow("yType"), "", "NormalTask")
            oPredecessor.LagFactor = oDataRow("lLagFactor")
            oPredecessor.LagInterval = oDataRow("yLagInterval")
            oPredecessor.WarningStyleIndex = "NormalTaskWarning"
            oPredecessor.SelectedStyleIndex = "SelectedPredecessor"
        Next



    End Sub

    Public Sub NoDataSource_LoadTasks()
        AddRow_Task(1, 0, "A", "Capital Plan", New DateTime(2007, 3, 8, 12, 0, 0), New DateTime(2007, 10, 19, 0, 0, 0), 0.4, False, True)
        AddRow_Task(2, 0, "F", "Strategic Projects", New DateTime(2006, 11, 1, 12, 0, 0), New DateTime(2007, 9, 14, 0, 0, 0), 0.75, True, True)
        AddRow_Task(3, 1, "F", "Infrastructure Work Team", New DateTime(2007, 2, 1, 12, 0, 0), New DateTime(2007, 9, 5, 0, 0, 0), 0.77, True, True)
        AddRow_Task(4, 2, "A", "Guys Tower Façade Feasability", New DateTime(2007, 2, 1, 12, 0, 0), New DateTime(2007, 8, 1, 0, 0, 0), 0.6, False, True)
        AddRow_Task(5, 2, "A", "East Wing Cladding (inc Ward Refurbisments)", New DateTime(2007, 4, 21, 0, 0, 0), New DateTime(2007, 9, 5, 0, 0, 0), 0.94, False, True)
        AddRow_Task(6, 1, "F", "Modernisation Workstream", New DateTime(2007, 1, 22, 0, 0, 0), New DateTime(2007, 3, 27, 12, 0, 0), 0.72, True, True)
        AddRow_Task(7, 2, "A", "A&E Reconfiguration", New DateTime(2007, 1, 22, 0, 0, 0), New DateTime(2007, 3, 27, 12, 0, 0), 0.69, False, True)
        AddRow_Task(8, 2, "A", "St. Thomas Main Theatres Study", New DateTime(2007, 1, 28, 0, 0, 0), New DateTime(2007, 3, 18, 12, 0, 0), 0.75, False, True)
        AddRow_Task(9, 1, "F", "Ambulatory Workstream", New DateTime(2007, 3, 9, 12, 0, 0), New DateTime(2007, 6, 5, 12, 0, 0), 0.73, True, True)
        AddRow_Task(10, 2, "A", "PET Feasability", New DateTime(2007, 3, 9, 12, 0, 0), New DateTime(2007, 6, 5, 12, 0, 0), 0.73, False, True)
        AddRow_Task(11, 1, "F", "Cancer Workstream", New DateTime(2006, 11, 1, 12, 0, 0), New DateTime(2007, 9, 14, 0, 0, 0), 0.78, True, True)
        AddRow_Task(12, 2, "A", "Redevelopment of Guys Site Incorporating Cancer Feasability", New DateTime(2007, 1, 11, 0, 0, 0), New DateTime(2007, 8, 11, 12, 0, 0), 0.74, False, True)
        AddRow_Task(13, 2, "A", "Radiotherapy and Chemotherapy Center", New DateTime(2006, 11, 1, 12, 0, 0), New DateTime(2007, 3, 30, 12, 0, 0), 0.94, False, True)
        AddRow_Task(14, 2, "A", "Decant Facilities", New DateTime(2007, 5, 24, 12, 0, 0), New DateTime(2007, 9, 14, 0, 0, 0), 0.65, False, True)
        AddRow_Task(15, 0, "F", "Capital Projects", New DateTime(2006, 9, 1, 12, 0, 0), New DateTime(2007, 12, 12, 0, 0, 0), 0.87, True, True)
        AddRow_Task(16, 1, "A", "4th Floor Block & Refurbishment", New DateTime(2006, 9, 1, 12, 0, 0), New DateTime(2007, 2, 1, 0, 0, 0), 0.93, False, True)
        AddRow_Task(17, 1, "A", "Bio Medical Research Center & CRF", New DateTime(2007, 3, 2, 0, 0, 0), New DateTime(2007, 7, 4, 0, 0, 0), 0.91, False, True)
        AddRow_Task(18, 1, "A", "Blundell Ward Relocation Florence + Aston Key", New DateTime(2007, 8, 7, 12, 0, 0), New DateTime(2007, 11, 12, 12, 0, 0), 0.62, False, True)
        AddRow_Task(19, 1, "A", "Bostock Ward Replacement of Water Treatment Plant", New DateTime(2007, 3, 7, 0, 0, 0), New DateTime(2007, 6, 23, 12, 0, 0), 0.84, False, True)
        AddRow_Task(20, 1, "A", "Centralisation Health Record Storage", New DateTime(2007, 6, 22, 0, 0, 0), New DateTime(2007, 11, 12, 0, 0, 0), 0.78, False, True)
        AddRow_Task(21, 1, "A", "ENT & Audiology Suite Phase II", New DateTime(2006, 12, 31, 12, 0, 0), New DateTime(2007, 3, 10, 0, 0, 0), 0.75, False, True)
        AddRow_Task(22, 1, "A", "GLI Structural Monitoring & Repair", New DateTime(2007, 2, 12, 12, 0, 0), New DateTime(2007, 5, 9, 12, 0, 0), 0.91, False, True)
        AddRow_Task(23, 1, "A", "Pathology Labs (Phase 1A)", New DateTime(2007, 4, 2, 0, 0, 0), New DateTime(2007, 10, 23, 0, 0, 0), 0.95, False, True)
        AddRow_Task(24, 1, "A", "Pathology Labs (Phase 2)", New DateTime(2007, 1, 15, 0, 0, 0), New DateTime(2007, 7, 29, 12, 0, 0), 0.92, False, True)
        AddRow_Task(25, 1, "A", "Pathology: NW5 - CSR Haematology & CSR Labs", New DateTime(2007, 4, 9, 0, 0, 0), New DateTime(2007, 9, 5, 0, 0, 0), 0.88, False, True)
        AddRow_Task(26, 1, "A", "Pathology: Haematology Day Care Center Transfer (NW4 to GT4)", New DateTime(2006, 10, 19, 0, 0, 0), New DateTime(2007, 1, 12, 0, 0, 0), 0.85, False, True)
        AddRow_Task(27, 1, "A", "HDR", New DateTime(2007, 6, 1, 0, 0, 0), New DateTime(2007, 9, 3, 0, 0, 0), 0.85, False, True)
        AddRow_Task(28, 1, "A", "Kidney Treatment Center", New DateTime(2007, 6, 25, 0, 0, 0), New DateTime(2007, 11, 18, 0, 0, 0), 0.76, False, True)
        AddRow_Task(29, 1, "A", "Maternity Expansion Business Case", New DateTime(2006, 11, 9, 12, 0, 0), New DateTime(2007, 4, 6, 0, 0, 0), 0.93, False, True)
        AddRow_Task(30, 1, "A", "New Laminar Flow Theatre at Guy's", New DateTime(2007, 4, 25, 12, 0, 0), New DateTime(2007, 11, 29, 12, 0, 0), 0.89, False, True)
        AddRow_Task(31, 1, "A", "North Wing Basement Entance - Phase 2", New DateTime(2007, 9, 7, 0, 0, 0), New DateTime(2007, 11, 30, 0, 0, 0), 0.88, False, True)
        AddRow_Task(32, 1, "A", "Paediatric Neurosciences Feasibility", New DateTime(2006, 11, 29, 0, 0, 0), New DateTime(2007, 2, 10, 0, 0, 0), 0.9, False, True)
        AddRow_Task(33, 1, "A", "Fluroscopy (Imaging 2) at St. Thomas", New DateTime(2007, 1, 24, 0, 0, 0), New DateTime(2007, 6, 8, 12, 0, 0), 0.94, False, True)
        AddRow_Task(34, 1, "A", "Interventional Radiology Suite (Imaging 3) at GT3 Phase 1", New DateTime(2007, 6, 17, 0, 0, 0), New DateTime(2007, 12, 12, 0, 0, 0), 0.91, False, True)
        AddRow_Task(35, 1, "A", "Interventional Radiology Suite (Imaging 3) at GT3 Phase 2", New DateTime(2007, 8, 12, 0, 0, 0), New DateTime(2007, 12, 1, 12, 0, 0), 0.92, False, True)
        AddRow_Task(36, 1, "A", "Imaging: Radiology Environment & Waiting Areas (Imaging 2) Phases 1 & 2", New DateTime(2006, 11, 27, 12, 0, 0), New DateTime(2007, 1, 25, 12, 0, 0), 1.0, False, True)
        AddRow_Task(37, 1, "A", "Imaging: Radiology Environment & Waiting Areas (Imaging 2) Phase 3", New DateTime(2006, 12, 21, 0, 0, 0), New DateTime(2007, 1, 9, 0, 0, 0), 1.0, False, True)
        AddRow_Task(38, 1, "A", "Relocation of Pharmacy Manufacturing & QC Laboratories", New DateTime(2007, 6, 7, 12, 0, 0), New DateTime(2007, 8, 20, 12, 0, 0), 0.93, False, True)
        AddRow_Task(39, 1, "A", "Samaritan Ward - Bone marrow transplant beds", New DateTime(2007, 6, 1, 0, 0, 0), New DateTime(2007, 8, 18, 0, 0, 0), 0.94, False, True)
        AddRow_Task(40, 1, "A", "Sexual Health Relocation", New DateTime(2007, 1, 10, 12, 0, 0), New DateTime(2007, 4, 12, 12, 0, 0), 1.0, False, True)
        AddRow_Task(41, 1, "A", "St. Thomas HV Upgrade", New DateTime(2007, 5, 2, 12, 0, 0), New DateTime(2007, 6, 20, 12, 0, 0), 0.52, False, True)
        AddRow_Task(42, 1, "A", "Ultrasound (Imaging 2) at Guy's", New DateTime(2007, 6, 5, 12, 0, 0), New DateTime(2007, 6, 22, 12, 0, 0), 1.0, False, True)
        AddRow_Task(43, 1, "F", "New Schemes Approved in Year", New DateTime(2006, 11, 15, 12, 0, 0), New DateTime(2007, 9, 4, 12, 0, 0), 0.78, True, True)
        AddRow_Task(44, 2, "A", "Modular Theatres", New DateTime(2006, 11, 15, 12, 0, 0), New DateTime(2007, 1, 1, 12, 0, 0), 0.84, False, True)
        AddRow_Task(45, 2, "A", "ECH - Theatre Ventilation", New DateTime(2006, 12, 24, 0, 0, 0), New DateTime(2007, 9, 4, 12, 0, 0), 0.77, False, True)
        AddRow_Task(46, 2, "A", "Modular Pharmacy Aseptic Unit", New DateTime(2006, 12, 22, 12, 0, 0), New DateTime(2007, 1, 28, 12, 0, 0), 0.82, False, True)
        AddRow_Task(47, 2, "A", "Acute Stroke Unit Bid", New DateTime(2007, 4, 11, 0, 0, 0), New DateTime(2007, 7, 20, 0, 0, 0), 0.74, False, True)
        AddRow_Task(48, 2, "A", "Chemo Centralisation", New DateTime(2006, 12, 26, 0, 0, 0), New DateTime(2007, 3, 30, 0, 0, 0), 0.9, False, True)
        AddRow_Task(49, 2, "A", "Feasability of MRI at Guy's", New DateTime(2007, 5, 12, 0, 0, 0), New DateTime(2007, 7, 25, 0, 0, 0), 0.59, False, True)
        AddRow_Task(50, 0, "F", "Engineering", New DateTime(2006, 10, 17, 0, 0, 0), New DateTime(2007, 9, 15, 12, 0, 0), 0.7, True, True)
        AddRow_Task(51, 1, "A", "Borough Wing Theatre Ductwork and Heater Batteries", New DateTime(2007, 5, 2, 0, 0, 0), New DateTime(2007, 6, 20, 0, 0, 0), 0.85, False, True)
        AddRow_Task(52, 1, "A", "Combined Heat and Power System at Guy's", New DateTime(2007, 1, 20, 12, 0, 0), New DateTime(2007, 4, 15, 12, 0, 0), 0.88, False, True)
        AddRow_Task(53, 1, "A", "Combined Heat and Power System at St. Thomas", New DateTime(2007, 3, 10, 12, 0, 0), New DateTime(2007, 9, 15, 12, 0, 0), 0.74, False, True)
        AddRow_Task(54, 1, "A", "Electrical Power Monitoring", New DateTime(2006, 11, 20, 0, 0, 0), New DateTime(2007, 8, 22, 12, 0, 0), 0.88, False, True)
        AddRow_Task(55, 1, "A", "Guy's Lifts 101-105 (Guys Tower)", New DateTime(2006, 12, 6, 0, 0, 0), New DateTime(2007, 3, 3, 0, 0, 0), 0.88, False, True)
        AddRow_Task(56, 1, "A", "Guy's Lifts 110-114 (Guys Tower)", New DateTime(2007, 5, 15, 12, 0, 0), New DateTime(2007, 7, 1, 12, 0, 0), 0.5, False, True)
        AddRow_Task(57, 1, "A", "Motor Control Panel Refurbishment", New DateTime(2007, 1, 9, 0, 0, 0), New DateTime(2007, 6, 13, 0, 0, 0), 0.7, False, True)
        AddRow_Task(58, 1, "A", "North Wing / Lambeth Wing Air Supply Plants", New DateTime(2007, 1, 13, 0, 0, 0), New DateTime(2007, 4, 19, 0, 0, 0), 0.21, False, True)
        AddRow_Task(59, 1, "A", "North Wing Chiller Replacement", New DateTime(2007, 1, 9, 0, 0, 0), New DateTime(2007, 6, 16, 0, 0, 0), 0.5, False, True)
        AddRow_Task(60, 1, "A", "North Wing Replacement Generator", New DateTime(2006, 12, 10, 12, 0, 0), New DateTime(2007, 6, 11, 0, 0, 0), 0.76, False, True)
        AddRow_Task(61, 1, "A", "NW/LW Riser Refurbishment", New DateTime(2007, 1, 20, 12, 0, 0), New DateTime(2007, 3, 17, 12, 0, 0), 0.5, False, True)
        AddRow_Task(62, 1, "A", "Satchwell BMS Upgrade", New DateTime(2006, 12, 16, 12, 0, 0), New DateTime(2007, 7, 18, 12, 0, 0), 0.91, False, True)
        AddRow_Task(63, 1, "A", "St. Thomas Increase Standby Capacity - Phase 2", New DateTime(2007, 1, 2, 0, 0, 0), New DateTime(2007, 6, 18, 0, 0, 0), 0.8, False, True)
        AddRow_Task(64, 1, "A", "Substation 3 HV Works (St. Thomas)", New DateTime(2007, 2, 27, 0, 0, 0), New DateTime(2007, 8, 10, 12, 0, 0), 0.78, False, True)
        AddRow_Task(65, 1, "A", "TB Electrical Distribution", New DateTime(2006, 10, 17, 0, 0, 0), New DateTime(2007, 6, 29, 12, 0, 0), 0.73, False, True)
        AddRow_Task(66, 1, "A", "Tower Wing Dental Theatre Air Handling Unit", New DateTime(2006, 12, 30, 12, 0, 0), New DateTime(2007, 3, 24, 12, 0, 0), 0.75, False, True)
        AddRow_Task(67, 1, "A", "Tower Wing Recovery Air Handling Unit", New DateTime(2007, 3, 2, 0, 0, 0), New DateTime(2007, 8, 8, 0, 0, 0), 0.7, False, True)
        AddRow_Task(68, 1, "A", "Water Booster Pumps - Phase 1 & 2", New DateTime(2007, 1, 8, 12, 0, 0), New DateTime(2007, 6, 14, 12, 0, 0), 0.64, False, True)
        AddRow_Task(69, 1, "A", "Water Softner - Boiler House", New DateTime(2007, 2, 12, 12, 0, 0), New DateTime(2007, 7, 30, 12, 0, 0), 0.66, False, True)
        AddRow_Task(70, 1, "A", "Energy Efficiency", New DateTime(2007, 3, 31, 12, 0, 0), New DateTime(2007, 9, 4, 12, 0, 0), 0.72, False, True)
        AddRow_Task(71, 0, "F", "PEAT Plan", New DateTime(2006, 11, 5, 0, 0, 0), New DateTime(2008, 1, 21, 0, 0, 0), 0.82, True, True)
        AddRow_Task(72, 1, "A", "Hilliers Ward Refurb St. Thomas", New DateTime(2007, 3, 28, 0, 0, 0), New DateTime(2007, 5, 23, 12, 0, 0), 0.79, False, True)
        AddRow_Task(73, 1, "A", "William Gull Ward St. Thomas", New DateTime(2007, 3, 20, 0, 0, 0), New DateTime(2007, 8, 23, 0, 0, 0), 0.77, False, True)
        AddRow_Task(74, 1, "A", "Henry Ward Day Room", New DateTime(2007, 4, 29, 0, 0, 0), New DateTime(2007, 6, 1, 0, 0, 0), 0.8, False, True)
        AddRow_Task(75, 1, "A", "Sarah Swift Ward", New DateTime(2006, 11, 5, 0, 0, 0), New DateTime(2007, 2, 3, 0, 0, 0), 0.78, False, True)
        AddRow_Task(76, 1, "A", "Victoria Ward", New DateTime(2007, 5, 10, 12, 0, 0), New DateTime(2007, 7, 14, 12, 0, 0), 0.91, False, True)
        AddRow_Task(77, 1, "A", "Appointment Center Staff Toilets", New DateTime(2007, 1, 16, 0, 0, 0), New DateTime(2007, 4, 7, 12, 0, 0), 0.77, False, True)
        AddRow_Task(78, 1, "A", "Page Ward", New DateTime(2007, 5, 19, 12, 0, 0), New DateTime(2007, 7, 16, 12, 0, 0), 0.74, False, True)
        AddRow_Task(79, 1, "A", "Nightingdale Ward - Side Rooms", New DateTime(2007, 2, 18, 0, 0, 0), New DateTime(2007, 4, 28, 0, 0, 0), 0.77, False, True)
        AddRow_Task(80, 1, "A", "Luke Ward - Side Rooms", New DateTime(2007, 11, 14, 12, 0, 0), New DateTime(2007, 12, 31, 12, 0, 0), 0.8, False, True)
        AddRow_Task(81, 1, "A", "Therapies Department - Disabled Toilets", New DateTime(2007, 7, 31, 12, 0, 0), New DateTime(2007, 9, 26, 12, 0, 0), 0.81, False, True)
        AddRow_Task(82, 1, "A", "Northumberland Ward Side Rooms", New DateTime(2007, 4, 18, 0, 0, 0), New DateTime(2007, 6, 6, 0, 0, 0), 0.83, False, True)
        AddRow_Task(83, 1, "A", "General Outpatients", New DateTime(2007, 10, 17, 0, 0, 0), New DateTime(2008, 1, 21, 0, 0, 0), 0.86, False, True)
        AddRow_Task(84, 1, "A", "Rheumatology Clinic", New DateTime(2007, 5, 3, 0, 0, 0), New DateTime(2007, 5, 28, 0, 0, 0), 0.84, False, True)
        AddRow_Task(85, 1, "A", "Diabetes Clinic", New DateTime(2007, 1, 8, 12, 0, 0), New DateTime(2007, 3, 18, 12, 0, 0), 0.86, False, True)
        AddRow_Task(86, 1, "A", "ENT Clinic", New DateTime(2007, 4, 14, 12, 0, 0), New DateTime(2007, 10, 28, 12, 0, 0), 0.91, False, True)
        AddRow_Task(87, 0, "F", "Buildings Improvement Programs", New DateTime(2006, 10, 18, 12, 0, 0), New DateTime(2007, 10, 28, 0, 0, 0), 0.75, True, True)
        AddRow_Task(88, 1, "F", "Environmental Improvement Plan", New DateTime(2006, 10, 18, 12, 0, 0), New DateTime(2007, 10, 28, 0, 0, 0), 0.75, False, False)
        AddRow_Task(89, 2, "A", "Ward Improvementrs", New DateTime(2006, 10, 18, 12, 0, 0), New DateTime(2007, 10, 15, 12, 0, 0), 0.61, False, True)
        AddRow_Task(90, 2, "A", "Outpatient / Clinics", New DateTime(2006, 12, 29, 0, 0, 0), New DateTime(2007, 8, 11, 0, 0, 0), 0.74, False, True)
        AddRow_Task(91, 2, "A", "Circulation Areas", New DateTime(2007, 4, 14, 12, 0, 0), New DateTime(2007, 10, 28, 0, 0, 0), 0.74, False, True)
        AddRow_Task(92, 2, "A", "St. Thomas Main Entrance", New DateTime(2007, 2, 28, 0, 0, 0), New DateTime(2007, 6, 8, 0, 0, 0), 0.76, False, True)
        AddRow_Task(93, 2, "A", "St. Thomas Retail Mall", New DateTime(2007, 1, 1, 0, 0, 0), New DateTime(2007, 2, 6, 0, 0, 0), 0.81, False, True)
        AddRow_Task(94, 2, "A", "Guys Main Entrance Revolving Door", New DateTime(2007, 3, 28, 12, 0, 0), New DateTime(2007, 4, 25, 12, 0, 0), 0.83, False, True)

        AddPredecessor(16, 17, E_CONSTRAINTTYPE.PCT_END_TO_START, 696, E_INTERVAL.IL_HOUR)     '//End-To-Start with lag (down)
        AddPredecessor(13, 5, E_CONSTRAINTTYPE.PCT_END_TO_START, 516, E_INTERVAL.IL_HOUR)      '//End-To-Start with lag (up)
        AddPredecessor(21, 22, E_CONSTRAINTTYPE.PCT_END_TO_START, -612, E_INTERVAL.IL_HOUR)    '//End-To-Start with lead (down)
        AddPredecessor(24, 19, E_CONSTRAINTTYPE.PCT_END_TO_START, -3468, E_INTERVAL.IL_HOUR)   '//End-To-Start with lead (up)

        AddPredecessor(18, 20, E_CONSTRAINTTYPE.PCT_START_TO_END, 2316, E_INTERVAL.IL_HOUR)    '//Start-To-End with lag (down)
        AddPredecessor(29, 26, E_CONSTRAINTTYPE.PCT_START_TO_END, 1524, E_INTERVAL.IL_HOUR)    '//Start-To-End with lag (up)
        AddPredecessor(27, 32, E_CONSTRAINTTYPE.PCT_START_TO_END, -2664, E_INTERVAL.IL_HOUR)   '//Start-To-End with lead (down)
        AddPredecessor(38, 36, E_CONSTRAINTTYPE.PCT_START_TO_END, -3192, E_INTERVAL.IL_HOUR)   '//Start-To-End with lead (up)

        AddPredecessor(12, 14, E_CONSTRAINTTYPE.PCT_START_TO_START, 3204, E_INTERVAL.IL_HOUR)  '//Start-To-Start with lag (down)
        AddPredecessor(48, 47, E_CONSTRAINTTYPE.PCT_START_TO_START, 2544, E_INTERVAL.IL_HOUR)  '//Start-To-Start with lag (up)
        AddPredecessor(52, 55, E_CONSTRAINTTYPE.PCT_START_TO_START, -1092, E_INTERVAL.IL_HOUR) '//Start-To-Start with lead (down)
        AddPredecessor(56, 53, E_CONSTRAINTTYPE.PCT_START_TO_START, -1584, E_INTERVAL.IL_HOUR) '//Start-To-Start with lead (up)

        AddPredecessor(40, 41, E_CONSTRAINTTYPE.PCT_END_TO_END, 1656, E_INTERVAL.IL_HOUR)      '//End-To-End with lag (down)
        AddPredecessor(58, 57, E_CONSTRAINTTYPE.PCT_END_TO_END, 1320, E_INTERVAL.IL_HOUR)      '//End-To-End with lag (up)
        AddPredecessor(62, 63, E_CONSTRAINTTYPE.PCT_END_TO_END, -732, E_INTERVAL.IL_HOUR)      '//End-To-End with lead (down)
        AddPredecessor(67, 65, E_CONSTRAINTTYPE.PCT_END_TO_END, -948, E_INTERVAL.IL_HOUR)      '//End-To-End with lead (up)

    End Sub

    Public Sub AddPredecessor(ByVal lPredecessorID As Integer, ByVal lSuccessorID As Integer, ByVal yType As E_CONSTRAINTTYPE, ByVal lLagFactor As Integer, ByVal yLagInterval As E_INTERVAL)
        Dim oPredecessor As clsPredecessor
        oPredecessor = ActiveGanttVBNCtl1.Predecessors.Add("T" & lSuccessorID.ToString(), "T" & lPredecessorID.ToString(), yType, "", "NormalTask")
        oPredecessor.WarningStyleIndex = "NormalTaskWarning"
        oPredecessor.SelectedStyleIndex = "SelectedPredecessor"
        oPredecessor.LagFactor = lLagFactor
        oPredecessor.LagInterval = yLagInterval
    End Sub

    Public Sub AddRow_Task(ByVal lID As Integer, ByVal lDepth As Integer, ByVal sTaskType As String, ByVal sDescription As String, ByVal dtStartDate As AGVBN.DateTime, ByVal dtEndDate As AGVBN.DateTime, ByVal fPercentCompleted As Single, ByVal bSummary As Boolean, ByVal bHasTasks As Boolean)
        Dim oRow As clsRow = Nothing
        Dim oTask As clsTask = Nothing
        oRow = ActiveGanttVBNCtl1.Rows.Add("K" & lID.ToString(), sDescription)
        oRow.Cells.Item("1").Text = lID.ToString()
        oRow.Cells.Item("1").StyleIndex = "CellStyleKeyColumn"
        oRow.Node.StyleIndex = "CellStyle"
        oRow.Cells.Item("3").StyleIndex = "CellStyle"
        oRow.Cells.Item("4").StyleIndex = "CellStyle"
        oRow.Height = 20
        oRow.ClientAreaStyleIndex = "ClientAreaStyle"
        oRow.Node.AllowTextEdit = True
        If sTaskType = "F" Then
            If lDepth = 0 Then
                oRow.Node.Image = imgTreeView.Images.Item(0)
                oRow.Node.ExpandedImage = imgTreeView.Images.Item(1)
                oRow.Node.StyleIndex = "NodeBold"
            Else
                oRow.Node.Image = imgTreeView.Images.Item(2)
                oRow.Node.StyleIndex = "NodeRegular"
            End If
        ElseIf sTaskType = "A" Then
            oRow.Node.StyleIndex = "NodeRegular"
            oRow.Node.Image = imgTreeView.Images.Item(3)
            oRow.Node.CheckBoxVisible = True
        End If
        oRow.Node.Depth = lDepth
        oRow.Node.ImageVisible = True
        If (mp_dtStartDate.DateTimePart.Ticks() = 0) Then
            mp_dtStartDate = dtStartDate
        Else
            If (dtStartDate < mp_dtStartDate) Then
                mp_dtStartDate = dtStartDate
            End If
        End If
        If (mp_dtEndDate.DateTimePart.Ticks() = 0) Then
            mp_dtEndDate = dtEndDate
        Else
            If (dtEndDate > mp_dtEndDate) Then
                mp_dtEndDate = dtEndDate
            End If
        End If
        oTask = ActiveGanttVBNCtl1.Tasks.Add("", "K" & lID, dtStartDate, dtEndDate, "T" & lID.ToString())
        SetTaskGridColumns(oTask)
        If bSummary = True Then
            '// Prevent user from moving/sizing summary tasks
            oTask.AllowedMovement = E_MOVEMENTTYPE.MT_MOVEMENTDISABLED
            oTask.AllowStretchLeft = False
            oTask.AllowStretchRight = False
            '// Prevent user from adding tasks in these Rows
            oRow.Container = False
            '// Apply Summary Style 
            If oRow.Node.Depth = 0 Then
                oTask.StyleIndex = "RedSummary"
                ActiveGanttVBNCtl1.Percentages.Add("T" & lID.ToString(), "RedPercentages", fPercentCompleted)
            ElseIf oRow.Node.Depth = 1 Then
                oTask.StyleIndex = "GreenSummary"
                ActiveGanttVBNCtl1.Percentages.Add("T" & lID.ToString(), "GreenPercentages", fPercentCompleted)
            End If
            ActiveGanttVBNCtl1.Percentages.Item(ActiveGanttVBNCtl1.Percentages.Count.ToString()).AllowSize = False
        Else
            oTask.AllowedMovement = E_MOVEMENTTYPE.MT_RESTRICTEDTOROW
            oTask.StyleIndex = "NormalTask"
            oTask.WarningStyleIndex = "NormalTaskWarning"
            If bHasTasks = False Then
                oTask.Visible = False
                '// Prevent user from adding tasks in these rows
                oRow.Container = False
                ActiveGanttVBNCtl1.Percentages.Add("T" & lID.ToString(), "InvisiblePercentages", fPercentCompleted)
                ActiveGanttVBNCtl1.Percentages.Item(ActiveGanttVBNCtl1.Percentages.Count.ToString()).AllowSize = False
            Else
                ActiveGanttVBNCtl1.Percentages.Add("T" & lID.ToString(), "BluePercentages", fPercentCompleted)
            End If
        End If
    End Sub

    Private Sub SetTaskGridColumns(ByVal oTask As clsTask)
        oTask.Row.Cells.Item("3").Text = oTask.StartDate.ToString("MM/dd/yyyy")
        oTask.Row.Cells.Item("4").Text = oTask.EndDate.ToString("MM/dd/yyyy")
    End Sub

#End Region

End Class