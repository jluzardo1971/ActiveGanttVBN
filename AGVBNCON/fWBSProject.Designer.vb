<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fWBSProject
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fWBSProject))
        Me.imgTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ActiveGanttVBNCtl1 = New AGVBN.ActiveGanttVBNCtl
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSaveXML = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLoadXML = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem
        Me.treeviewPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCheckBoxes = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuImages = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPlusMinusSigns = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFullColumnSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTreeLines = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdSaveXML = New System.Windows.Forms.ToolStripButton
        Me.cmdLoadXML = New System.Windows.Forms.ToolStripButton
        Me.cmdPrint = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdZoomIn = New System.Windows.Forms.ToolStripButton
        Me.cmdZoomOut = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdBluePercentages = New System.Windows.Forms.ToolStripButton
        Me.cmdGreenPercentages = New System.Windows.Forms.ToolStripButton
        Me.cmdRedPercentages = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdProperties = New System.Windows.Forms.ToolStripButton
        Me.cmdCheck = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdToolTips = New System.Windows.Forms.ToolStripButton
        Me.cmdHelp = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgTreeView
        '
        Me.imgTreeView.ImageStream = CType(resources.GetObject("imgTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.imgTreeView.Images.SetKeyName(0, "")
        Me.imgTreeView.Images.SetKeyName(1, "")
        Me.imgTreeView.Images.SetKeyName(2, "")
        Me.imgTreeView.Images.SetKeyName(3, "")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ActiveGanttVBNCtl1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(736, 384)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'ActiveGanttVBNCtl1
        '
        Me.ActiveGanttVBNCtl1.AddMode = AGVBN.E_ADDMODE.AT_TASKADD
        Me.ActiveGanttVBNCtl1.AllowAdd = True
        Me.ActiveGanttVBNCtl1.AllowColumnMove = True
        Me.ActiveGanttVBNCtl1.AllowColumnSize = True
        Me.ActiveGanttVBNCtl1.AllowEdit = True
        Me.ActiveGanttVBNCtl1.AllowPredecessorAdd = True
        Me.ActiveGanttVBNCtl1.AllowRowMove = True
        Me.ActiveGanttVBNCtl1.AllowRowSize = True
        Me.ActiveGanttVBNCtl1.AllowSplitterMove = True
        Me.ActiveGanttVBNCtl1.AllowTimeLineScroll = True
        Me.ActiveGanttVBNCtl1.BackColor = System.Drawing.Color.White
        Me.ActiveGanttVBNCtl1.ControlTag = ""
        Me.ActiveGanttVBNCtl1.Culture = New System.Globalization.CultureInfo("en-US")
        Me.ActiveGanttVBNCtl1.CurrentLayer = "0"
        Me.ActiveGanttVBNCtl1.CurrentView = "0"
        Me.ActiveGanttVBNCtl1.DoubleBuffering = True
        Me.ActiveGanttVBNCtl1.EnforcePredecessors = False
        Me.ActiveGanttVBNCtl1.ErrorReports = AGVBN.E_REPORTERRORS.RE_MSGBOX
        Me.ActiveGanttVBNCtl1.Image = Nothing
        Me.ActiveGanttVBNCtl1.ImageTag = ""
        Me.ActiveGanttVBNCtl1.LayerEnableObjects = AGVBN.E_LAYEROBJECTENABLE.EC_INCURRENTLAYERONLY
        Me.ActiveGanttVBNCtl1.Location = New System.Drawing.Point(8, 16)
        Me.ActiveGanttVBNCtl1.MinColumnWidth = 5
        Me.ActiveGanttVBNCtl1.MinRowHeight = 5
        Me.ActiveGanttVBNCtl1.Name = "ActiveGanttVBNCtl1"
        Me.ActiveGanttVBNCtl1.PredecessorMode = AGVBN.E_PREDECESSORMODE.PM_CREATEWARNINGFLAG
        Me.ActiveGanttVBNCtl1.ScrollBarBehaviour = AGVBN.E_SCROLLBEHAVIOUR.SB_HIDE
        Me.ActiveGanttVBNCtl1.SelectedCellIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedColumnIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedPercentageIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedPredecessorIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedRowIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedTaskIndex = 0
        Me.ActiveGanttVBNCtl1.Size = New System.Drawing.Size(720, 360)
        Me.ActiveGanttVBNCtl1.StyleIndex = ""
        Me.ActiveGanttVBNCtl1.TabIndex = 0
        Me.ActiveGanttVBNCtl1.TierAppearanceScope = AGVBN.E_TIERAPPEARANCESCOPE.TAS_CONTROL
        Me.ActiveGanttVBNCtl1.TierFormatScope = AGVBN.E_TIERFORMATSCOPE.TFS_CONTROL
        Me.ActiveGanttVBNCtl1.TimeBlockBehaviour = AGVBN.E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS
        Me.ActiveGanttVBNCtl1.TreeviewColumnIndex = 0
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "doc1"
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.treeviewPropertiesToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.menuStrip1.TabIndex = 12
        Me.menuStrip1.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSaveXML, Me.mnuLoadXML, Me.mnuPrint, Me.toolStripSeparator1, Me.mnuClose})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileToolStripMenuItem.Text = "File"
        '
        'mnuSaveXML
        '
        Me.mnuSaveXML.Image = CType(resources.GetObject("mnuSaveXML.Image"), System.Drawing.Image)
        Me.mnuSaveXML.Name = "mnuSaveXML"
        Me.mnuSaveXML.Size = New System.Drawing.Size(148, 22)
        Me.mnuSaveXML.Text = "Save as XML..."
        '
        'mnuLoadXML
        '
        Me.mnuLoadXML.Image = CType(resources.GetObject("mnuLoadXML.Image"), System.Drawing.Image)
        Me.mnuLoadXML.Name = "mnuLoadXML"
        Me.mnuLoadXML.Size = New System.Drawing.Size(148, 22)
        Me.mnuLoadXML.Text = "Load XML..."
        '
        'mnuPrint
        '
        Me.mnuPrint.Image = CType(resources.GetObject("mnuPrint.Image"), System.Drawing.Image)
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(148, 22)
        Me.mnuPrint.Text = "Print..."
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(145, 6)
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(148, 22)
        Me.mnuClose.Text = "Close"
        '
        'treeviewPropertiesToolStripMenuItem
        '
        Me.treeviewPropertiesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCheckBoxes, Me.mnuImages, Me.mnuPlusMinusSigns, Me.mnuFullColumnSelect, Me.mnuTreeLines})
        Me.treeviewPropertiesToolStripMenuItem.Name = "treeviewPropertiesToolStripMenuItem"
        Me.treeviewPropertiesToolStripMenuItem.Size = New System.Drawing.Size(122, 20)
        Me.treeviewPropertiesToolStripMenuItem.Text = "Treeview Properties"
        '
        'mnuCheckBoxes
        '
        Me.mnuCheckBoxes.Checked = True
        Me.mnuCheckBoxes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuCheckBoxes.Name = "mnuCheckBoxes"
        Me.mnuCheckBoxes.Size = New System.Drawing.Size(165, 22)
        Me.mnuCheckBoxes.Text = "CheckBoxes"
        '
        'mnuImages
        '
        Me.mnuImages.Checked = True
        Me.mnuImages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuImages.Name = "mnuImages"
        Me.mnuImages.Size = New System.Drawing.Size(165, 22)
        Me.mnuImages.Text = "Images"
        '
        'mnuPlusMinusSigns
        '
        Me.mnuPlusMinusSigns.Checked = True
        Me.mnuPlusMinusSigns.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuPlusMinusSigns.Name = "mnuPlusMinusSigns"
        Me.mnuPlusMinusSigns.Size = New System.Drawing.Size(165, 22)
        Me.mnuPlusMinusSigns.Text = "Plus/Minus Signs"
        '
        'mnuFullColumnSelect
        '
        Me.mnuFullColumnSelect.Checked = True
        Me.mnuFullColumnSelect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuFullColumnSelect.Name = "mnuFullColumnSelect"
        Me.mnuFullColumnSelect.Size = New System.Drawing.Size(165, 22)
        Me.mnuFullColumnSelect.Text = "FullColumnSelect"
        '
        'mnuTreeLines
        '
        Me.mnuTreeLines.Checked = True
        Me.mnuTreeLines.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuTreeLines.Name = "mnuTreeLines"
        Me.mnuTreeLines.Size = New System.Drawing.Size(165, 22)
        Me.mnuTreeLines.Text = "TreeLines"
        '
        'toolStrip1
        '
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdSaveXML, Me.cmdLoadXML, Me.cmdPrint, Me.toolStripSeparator2, Me.cmdZoomIn, Me.cmdZoomOut, Me.toolStripSeparator3, Me.cmdBluePercentages, Me.cmdGreenPercentages, Me.cmdRedPercentages, Me.ToolStripSeparator5, Me.cmdProperties, Me.cmdCheck, Me.toolStripSeparator4, Me.cmdToolTips, Me.cmdHelp})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(792, 25)
        Me.toolStrip1.TabIndex = 13
        Me.toolStrip1.Text = "toolStrip1"
        '
        'cmdSaveXML
        '
        Me.cmdSaveXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSaveXML.Image = CType(resources.GetObject("cmdSaveXML.Image"), System.Drawing.Image)
        Me.cmdSaveXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSaveXML.Name = "cmdSaveXML"
        Me.cmdSaveXML.Size = New System.Drawing.Size(23, 22)
        Me.cmdSaveXML.Text = "toolStripButton1"
        Me.cmdSaveXML.ToolTipText = "Save as XML"
        '
        'cmdLoadXML
        '
        Me.cmdLoadXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLoadXML.Image = CType(resources.GetObject("cmdLoadXML.Image"), System.Drawing.Image)
        Me.cmdLoadXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdLoadXML.Name = "cmdLoadXML"
        Me.cmdLoadXML.Size = New System.Drawing.Size(23, 22)
        Me.cmdLoadXML.Text = "toolStripButton2"
        Me.cmdLoadXML.ToolTipText = "Load XML"
        '
        'cmdPrint
        '
        Me.cmdPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(23, 22)
        Me.cmdPrint.Text = "toolStripButton3"
        Me.cmdPrint.ToolTipText = "Print"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdZoomIn
        '
        Me.cmdZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdZoomIn.Image = CType(resources.GetObject("cmdZoomIn.Image"), System.Drawing.Image)
        Me.cmdZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdZoomIn.Name = "cmdZoomIn"
        Me.cmdZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.cmdZoomIn.Text = "toolStripButton4"
        Me.cmdZoomIn.ToolTipText = "Zoom in"
        '
        'cmdZoomOut
        '
        Me.cmdZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdZoomOut.Image = CType(resources.GetObject("cmdZoomOut.Image"), System.Drawing.Image)
        Me.cmdZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdZoomOut.Name = "cmdZoomOut"
        Me.cmdZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.cmdZoomOut.Text = "toolStripButton5"
        Me.cmdZoomOut.ToolTipText = "Zoom out"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'cmdBluePercentages
        '
        Me.cmdBluePercentages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdBluePercentages.Image = CType(resources.GetObject("cmdBluePercentages.Image"), System.Drawing.Image)
        Me.cmdBluePercentages.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdBluePercentages.Name = "cmdBluePercentages"
        Me.cmdBluePercentages.Size = New System.Drawing.Size(23, 22)
        Me.cmdBluePercentages.Text = "toolStripButton6"
        Me.cmdBluePercentages.ToolTipText = "Toggle blue percentages"
        '
        'cmdGreenPercentages
        '
        Me.cmdGreenPercentages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdGreenPercentages.Image = CType(resources.GetObject("cmdGreenPercentages.Image"), System.Drawing.Image)
        Me.cmdGreenPercentages.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdGreenPercentages.Name = "cmdGreenPercentages"
        Me.cmdGreenPercentages.Size = New System.Drawing.Size(23, 22)
        Me.cmdGreenPercentages.Text = "toolStripButton7"
        Me.cmdGreenPercentages.ToolTipText = "Toggle green percentages"
        '
        'cmdRedPercentages
        '
        Me.cmdRedPercentages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRedPercentages.Image = CType(resources.GetObject("cmdRedPercentages.Image"), System.Drawing.Image)
        Me.cmdRedPercentages.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRedPercentages.Name = "cmdRedPercentages"
        Me.cmdRedPercentages.Size = New System.Drawing.Size(23, 22)
        Me.cmdRedPercentages.Text = "toolStripButton8"
        Me.cmdRedPercentages.ToolTipText = "Toggle red percentages"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'cmdProperties
        '
        Me.cmdProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdProperties.Image = CType(resources.GetObject("cmdProperties.Image"), System.Drawing.Image)
        Me.cmdProperties.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdProperties.Name = "cmdProperties"
        Me.cmdProperties.Size = New System.Drawing.Size(23, 22)
        Me.cmdProperties.Text = "ToolStripButton2"
        Me.cmdProperties.ToolTipText = "Properties"
        '
        'cmdCheck
        '
        Me.cmdCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdCheck.Image = CType(resources.GetObject("cmdCheck.Image"), System.Drawing.Image)
        Me.cmdCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCheck.Name = "cmdCheck"
        Me.cmdCheck.Size = New System.Drawing.Size(23, 22)
        Me.cmdCheck.Text = "ToolStripButton1"
        Me.cmdCheck.ToolTipText = "CheckPredecessors"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'cmdToolTips
        '
        Me.cmdToolTips.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdToolTips.Image = CType(resources.GetObject("cmdToolTips.Image"), System.Drawing.Image)
        Me.cmdToolTips.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdToolTips.Name = "cmdToolTips"
        Me.cmdToolTips.Size = New System.Drawing.Size(23, 22)
        Me.cmdToolTips.Text = "toolStripButton9"
        Me.cmdToolTips.ToolTipText = "Toggle tooltips"
        '
        'cmdHelp
        '
        Me.cmdHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdHelp.Image = CType(resources.GetObject("cmdHelp.Image"), System.Drawing.Image)
        Me.cmdHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(23, 22)
        Me.cmdHelp.Text = "toolStripButton10"
        Me.cmdHelp.ToolTipText = "Help"
        '
        'fWBSProject
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 635)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fWBSProject"
        Me.Text = "fWBSProject"
        Me.GroupBox1.ResumeLayout(False)
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuSaveXML As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuLoadXML As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents treeviewPropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuCheckBoxes As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuImages As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuPlusMinusSigns As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFullColumnSelect As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents cmdSaveXML As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdLoadXML As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmdZoomIn As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdZoomOut As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmdBluePercentages As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdGreenPercentages As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdRedPercentages As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmdToolTips As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdProperties As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents imgTreeView As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ActiveGanttVBNCtl1 As AGVBN.ActiveGanttVBNCtl
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuTreeLines As System.Windows.Forms.ToolStripMenuItem

End Class
