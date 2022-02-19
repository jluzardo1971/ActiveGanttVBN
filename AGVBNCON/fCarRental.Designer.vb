<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCarRental
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fCarRental))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.mnuRowEdit = New System.Windows.Forms.ContextMenu
        Me.mnuEditRow = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuDeleteRow = New System.Windows.Forms.MenuItem
        Me.mnuTaskEdit = New System.Windows.Forms.ContextMenu
        Me.mnuEditTask = New System.Windows.Forms.MenuItem
        Me.mnuConvertToRental = New System.Windows.Forms.MenuItem
        Me.mnuTaskLine = New System.Windows.Forms.MenuItem
        Me.mnuDeleteTask = New System.Windows.Forms.MenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSaveXML = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLoadXML = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdSaveXML = New System.Windows.Forms.ToolStripButton
        Me.cmdLoadXML = New System.Windows.Forms.ToolStripButton
        Me.cmdPrint = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdZoomIn = New System.Windows.Forms.ToolStripButton
        Me.cmdZoomOut = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdAddVehicle = New System.Windows.Forms.ToolStripButton
        Me.cmdAddBranch = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdBack2 = New System.Windows.Forms.ToolStripButton
        Me.cmdBack1 = New System.Windows.Forms.ToolStripButton
        Me.cmdBack0 = New System.Windows.Forms.ToolStripButton
        Me.cmdFwd0 = New System.Windows.Forms.ToolStripButton
        Me.cmdFwd1 = New System.Windows.Forms.ToolStripButton
        Me.cmdFwd2 = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdHelp = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.lblMode = New System.Windows.Forms.ToolStripLabel
        Me.ActiveGanttVBNCtl1 = New AGVBN.ActiveGanttVBNCtl
        Me.GroupBox1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ActiveGanttVBNCtl1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(672, 488)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'mnuRowEdit
        '
        Me.mnuRowEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEditRow, Me.MenuItem2, Me.mnuDeleteRow})
        '
        'mnuEditRow
        '
        Me.mnuEditRow.Index = 0
        Me.mnuEditRow.Text = "Edit"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'mnuDeleteRow
        '
        Me.mnuDeleteRow.Index = 2
        Me.mnuDeleteRow.Text = "Delete"
        '
        'mnuTaskEdit
        '
        Me.mnuTaskEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEditTask, Me.mnuConvertToRental, Me.mnuTaskLine, Me.mnuDeleteTask})
        '
        'mnuEditTask
        '
        Me.mnuEditTask.Index = 0
        Me.mnuEditTask.Text = "Edit"
        '
        'mnuConvertToRental
        '
        Me.mnuConvertToRental.Index = 1
        Me.mnuConvertToRental.Text = "Convert to Rental"
        '
        'mnuTaskLine
        '
        Me.mnuTaskLine.Index = 2
        Me.mnuTaskLine.Text = "-"
        '
        'mnuDeleteTask
        '
        Me.mnuDeleteTask.Index = 3
        Me.mnuDeleteTask.Text = "Delete"
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(872, 24)
        Me.menuStrip1.TabIndex = 3
        Me.menuStrip1.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSaveXML, Me.mnuLoadXML, Me.mnuPrint, Me.toolStripSeparator1, Me.mnuClose})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.fileToolStripMenuItem.Text = "File"
        '
        'mnuSaveXML
        '
        Me.mnuSaveXML.Image = CType(resources.GetObject("mnuSaveXML.Image"), System.Drawing.Image)
        Me.mnuSaveXML.Name = "mnuSaveXML"
        Me.mnuSaveXML.Size = New System.Drawing.Size(150, 22)
        Me.mnuSaveXML.Text = "Save as XML..."
        '
        'mnuLoadXML
        '
        Me.mnuLoadXML.Image = CType(resources.GetObject("mnuLoadXML.Image"), System.Drawing.Image)
        Me.mnuLoadXML.Name = "mnuLoadXML"
        Me.mnuLoadXML.Size = New System.Drawing.Size(150, 22)
        Me.mnuLoadXML.Text = "Load  XML..."
        '
        'mnuPrint
        '
        Me.mnuPrint.Image = CType(resources.GetObject("mnuPrint.Image"), System.Drawing.Image)
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(150, 22)
        Me.mnuPrint.Text = "Print"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(147, 6)
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(150, 22)
        Me.mnuClose.Text = "Close"
        '
        'toolStrip1
        '
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdSaveXML, Me.cmdLoadXML, Me.cmdPrint, Me.toolStripSeparator2, Me.cmdZoomIn, Me.cmdZoomOut, Me.toolStripSeparator3, Me.cmdAddVehicle, Me.cmdAddBranch, Me.toolStripSeparator4, Me.cmdBack2, Me.cmdBack1, Me.cmdBack0, Me.cmdFwd0, Me.cmdFwd1, Me.cmdFwd2, Me.toolStripSeparator5, Me.cmdHelp, Me.toolStripSeparator6, Me.lblMode})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(872, 25)
        Me.toolStrip1.TabIndex = 4
        Me.toolStrip1.Text = "toolStrip1"
        '
        'cmdSaveXML
        '
        Me.cmdSaveXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSaveXML.Image = CType(resources.GetObject("cmdSaveXML.Image"), System.Drawing.Image)
        Me.cmdSaveXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSaveXML.Name = "cmdSaveXML"
        Me.cmdSaveXML.Size = New System.Drawing.Size(23, 22)
        Me.cmdSaveXML.Text = "Save as XML"
        '
        'cmdLoadXML
        '
        Me.cmdLoadXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLoadXML.Image = CType(resources.GetObject("cmdLoadXML.Image"), System.Drawing.Image)
        Me.cmdLoadXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdLoadXML.Name = "cmdLoadXML"
        Me.cmdLoadXML.Size = New System.Drawing.Size(23, 22)
        Me.cmdLoadXML.Text = "Load XML"
        '
        'cmdPrint
        '
        Me.cmdPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(23, 22)
        Me.cmdPrint.Text = "Print"
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
        Me.cmdZoomIn.Text = "Zoom in"
        '
        'cmdZoomOut
        '
        Me.cmdZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdZoomOut.Image = CType(resources.GetObject("cmdZoomOut.Image"), System.Drawing.Image)
        Me.cmdZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdZoomOut.Name = "cmdZoomOut"
        Me.cmdZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.cmdZoomOut.Text = "Zoom out"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'cmdAddVehicle
        '
        Me.cmdAddVehicle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAddVehicle.Image = CType(resources.GetObject("cmdAddVehicle.Image"), System.Drawing.Image)
        Me.cmdAddVehicle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddVehicle.Name = "cmdAddVehicle"
        Me.cmdAddVehicle.Size = New System.Drawing.Size(23, 22)
        Me.cmdAddVehicle.Text = "Add vehicle"
        '
        'cmdAddBranch
        '
        Me.cmdAddBranch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAddBranch.Image = CType(resources.GetObject("cmdAddBranch.Image"), System.Drawing.Image)
        Me.cmdAddBranch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddBranch.Name = "cmdAddBranch"
        Me.cmdAddBranch.Size = New System.Drawing.Size(23, 22)
        Me.cmdAddBranch.Text = "Add branch"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'cmdBack2
        '
        Me.cmdBack2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdBack2.Image = CType(resources.GetObject("cmdBack2.Image"), System.Drawing.Image)
        Me.cmdBack2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdBack2.Name = "cmdBack2"
        Me.cmdBack2.Size = New System.Drawing.Size(23, 22)
        Me.cmdBack2.Text = "toolStripButton8"
        '
        'cmdBack1
        '
        Me.cmdBack1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdBack1.Image = CType(resources.GetObject("cmdBack1.Image"), System.Drawing.Image)
        Me.cmdBack1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdBack1.Name = "cmdBack1"
        Me.cmdBack1.Size = New System.Drawing.Size(23, 22)
        Me.cmdBack1.Text = "toolStripButton9"
        '
        'cmdBack0
        '
        Me.cmdBack0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdBack0.Image = CType(resources.GetObject("cmdBack0.Image"), System.Drawing.Image)
        Me.cmdBack0.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdBack0.Name = "cmdBack0"
        Me.cmdBack0.Size = New System.Drawing.Size(23, 22)
        Me.cmdBack0.Text = "toolStripButton10"
        '
        'cmdFwd0
        '
        Me.cmdFwd0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFwd0.Image = CType(resources.GetObject("cmdFwd0.Image"), System.Drawing.Image)
        Me.cmdFwd0.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdFwd0.Name = "cmdFwd0"
        Me.cmdFwd0.Size = New System.Drawing.Size(23, 22)
        Me.cmdFwd0.Text = "toolStripButton11"
        '
        'cmdFwd1
        '
        Me.cmdFwd1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFwd1.Image = CType(resources.GetObject("cmdFwd1.Image"), System.Drawing.Image)
        Me.cmdFwd1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdFwd1.Name = "cmdFwd1"
        Me.cmdFwd1.Size = New System.Drawing.Size(23, 22)
        Me.cmdFwd1.Text = "toolStripButton12"
        '
        'cmdFwd2
        '
        Me.cmdFwd2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFwd2.Image = CType(resources.GetObject("cmdFwd2.Image"), System.Drawing.Image)
        Me.cmdFwd2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdFwd2.Name = "cmdFwd2"
        Me.cmdFwd2.Size = New System.Drawing.Size(23, 22)
        Me.cmdFwd2.Text = "toolStripButton13"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'cmdHelp
        '
        Me.cmdHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdHelp.Image = CType(resources.GetObject("cmdHelp.Image"), System.Drawing.Image)
        Me.cmdHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(23, 22)
        Me.cmdHelp.Text = "Help"
        '
        'toolStripSeparator6
        '
        Me.toolStripSeparator6.Name = "toolStripSeparator6"
        Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'lblMode
        '
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(44, 22)
        Me.lblMode.Text = "lblMode"
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
        Me.ActiveGanttVBNCtl1.ControlTag = ""
        Me.ActiveGanttVBNCtl1.Culture = New System.Globalization.CultureInfo("en-US")
        Me.ActiveGanttVBNCtl1.CurrentLayer = "0"
        Me.ActiveGanttVBNCtl1.CurrentView = "0"
        Me.ActiveGanttVBNCtl1.DoubleBuffering = True
        Me.ActiveGanttVBNCtl1.ErrorReports = AGVBN.E_REPORTERRORS.RE_MSGBOX
        Me.ActiveGanttVBNCtl1.LayerEnableObjects = AGVBN.E_LAYEROBJECTENABLE.EC_INCURRENTLAYERONLY
        Me.ActiveGanttVBNCtl1.Location = New System.Drawing.Point(16, 16)
        Me.ActiveGanttVBNCtl1.MinColumnWidth = 5
        Me.ActiveGanttVBNCtl1.MinRowHeight = 5
        Me.ActiveGanttVBNCtl1.Name = "ActiveGanttVBNCtl1"
        Me.ActiveGanttVBNCtl1.ScrollBarBehaviour = AGVBN.E_SCROLLBEHAVIOUR.SB_HIDE
        Me.ActiveGanttVBNCtl1.SelectedCellIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedColumnIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedPercentageIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedRowIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedTaskIndex = 0
        Me.ActiveGanttVBNCtl1.Size = New System.Drawing.Size(648, 464)
        Me.ActiveGanttVBNCtl1.TabIndex = 0
        Me.ActiveGanttVBNCtl1.TimeBlockBehaviour = AGVBN.E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS
        '
        'fCarRental
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(872, 541)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fCarRental"
        Me.Text = "fCarRental"
        Me.GroupBox1.ResumeLayout(False)
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ActiveGanttVBNCtl1 As AGVBN.ActiveGanttVBNCtl
    Friend WithEvents mnuRowEdit As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuEditRow As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeleteRow As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTaskEdit As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuEditTask As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeleteTask As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConvertToRental As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTaskLine As System.Windows.Forms.MenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuSaveXML As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuLoadXML As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents cmdSaveXML As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdLoadXML As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmdZoomIn As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdZoomOut As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmdAddVehicle As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdAddBranch As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmdBack2 As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdBack1 As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdBack0 As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdFwd0 As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdFwd1 As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdFwd2 As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmdHelp As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents lblMode As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip


End Class
