<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fLoadXML
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fLoadXML))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ActiveGanttVBNCtl1 = New AGVBN.ActiveGanttVBNCtl
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLoadXML = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSaveXML = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdLoadXML = New System.Windows.Forms.ToolStripButton
        Me.cmdSaveXML = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ActiveGanttVBNCtl1)
        Me.GroupBox1.Location = New System.Drawing.Point(48, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 399)
        Me.GroupBox1.TabIndex = 1
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
        Me.ActiveGanttVBNCtl1.ControlTag = ""
        Me.ActiveGanttVBNCtl1.Culture = New System.Globalization.CultureInfo("en-US")
        Me.ActiveGanttVBNCtl1.CurrentLayer = "0"
        Me.ActiveGanttVBNCtl1.CurrentView = "0"
        Me.ActiveGanttVBNCtl1.DoubleBuffering = True
        Me.ActiveGanttVBNCtl1.ErrorReports = AGVBN.E_REPORTERRORS.RE_MSGBOX
        Me.ActiveGanttVBNCtl1.LayerEnableObjects = AGVBN.E_LAYEROBJECTENABLE.EC_INCURRENTLAYERONLY
        Me.ActiveGanttVBNCtl1.Location = New System.Drawing.Point(24, 32)
        Me.ActiveGanttVBNCtl1.MinColumnWidth = 5
        Me.ActiveGanttVBNCtl1.MinRowHeight = 5
        Me.ActiveGanttVBNCtl1.Name = "ActiveGanttVBNCtl1"
        Me.ActiveGanttVBNCtl1.ScrollBarBehaviour = AGVBN.E_SCROLLBEHAVIOUR.SB_HIDE
        Me.ActiveGanttVBNCtl1.SelectedCellIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedColumnIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedPercentageIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedRowIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedTaskIndex = 0
        Me.ActiveGanttVBNCtl1.Size = New System.Drawing.Size(656, 544)
        Me.ActiveGanttVBNCtl1.TabIndex = 2
        Me.ActiveGanttVBNCtl1.TimeBlockBehaviour = AGVBN.E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "doc1"
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(768, 24)
        Me.menuStrip1.TabIndex = 2
        Me.menuStrip1.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLoadXML, Me.mnuSaveXML, Me.toolStripSeparator1, Me.mnuClose})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileToolStripMenuItem.Text = "File"
        '
        'mnuLoadXML
        '
        Me.mnuLoadXML.Name = "mnuLoadXML"
        Me.mnuLoadXML.Size = New System.Drawing.Size(165, 22)
        Me.mnuLoadXML.Text = "Load from XML..."
        '
        'mnuSaveXML
        '
        Me.mnuSaveXML.Name = "mnuSaveXML"
        Me.mnuSaveXML.Size = New System.Drawing.Size(165, 22)
        Me.mnuSaveXML.Text = "Save as XML..."
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(162, 6)
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(165, 22)
        Me.mnuClose.Text = "Close"
        '
        'toolStrip1
        '
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdLoadXML, Me.cmdSaveXML})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(768, 25)
        Me.toolStrip1.TabIndex = 3
        Me.toolStrip1.Text = "toolStrip1"
        '
        'cmdLoadXML
        '
        Me.cmdLoadXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLoadXML.Image = CType(resources.GetObject("cmdLoadXML.Image"), System.Drawing.Image)
        Me.cmdLoadXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdLoadXML.Name = "cmdLoadXML"
        Me.cmdLoadXML.Size = New System.Drawing.Size(23, 22)
        Me.cmdLoadXML.Text = "Save as XML"
        Me.cmdLoadXML.ToolTipText = "Load XML"
        '
        'cmdSaveXML
        '
        Me.cmdSaveXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSaveXML.Image = CType(resources.GetObject("cmdSaveXML.Image"), System.Drawing.Image)
        Me.cmdSaveXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSaveXML.Name = "cmdSaveXML"
        Me.cmdSaveXML.Size = New System.Drawing.Size(23, 22)
        Me.cmdSaveXML.Text = "toolStripButton2"
        Me.cmdSaveXML.ToolTipText = "Save as XML"
        '
        'fLoadXML
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(768, 581)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "fLoadXML"
        Me.Text = "ActiveGanttVBN - Load From XML / Save As XML"
        Me.GroupBox1.ResumeLayout(False)
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ActiveGanttVBNCtl1 As AGVBN.ActiveGanttVBNCtl
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuLoadXML As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuSaveXML As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents cmdLoadXML As System.Windows.Forms.ToolStripButton
    Private WithEvents cmdSaveXML As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
