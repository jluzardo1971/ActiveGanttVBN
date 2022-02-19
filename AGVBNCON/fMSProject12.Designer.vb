<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMSProject12
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMSProject12))
        Me.ActiveGanttVBNCtl1 = New AGVBN.ActiveGanttVBNCtl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadMSProject2007XMLFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveMSProject2007XMLFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdLoadXML = New System.Windows.Forms.ToolStripButton
        Me.cmdSaveXML = New System.Windows.Forms.ToolStripButton
        Me.cmdPrint = New System.Windows.Forms.ToolStripButton
        Me.cmdIndent = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdZoomIn = New System.Windows.Forms.ToolStripButton
        Me.cmdZoomOut = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ActiveGanttVBNCtl1.Location = New System.Drawing.Point(16, 24)
        Me.ActiveGanttVBNCtl1.MinColumnWidth = 5
        Me.ActiveGanttVBNCtl1.MinRowHeight = 5
        Me.ActiveGanttVBNCtl1.Name = "ActiveGanttVBNCtl1"
        Me.ActiveGanttVBNCtl1.ScrollBarBehaviour = AGVBN.E_SCROLLBEHAVIOUR.SB_HIDE
        Me.ActiveGanttVBNCtl1.SelectedCellIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedColumnIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedPercentageIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedRowIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedTaskIndex = 0
        Me.ActiveGanttVBNCtl1.Size = New System.Drawing.Size(507, 256)
        Me.ActiveGanttVBNCtl1.TabIndex = 1
        Me.ActiveGanttVBNCtl1.TimeBlockBehaviour = AGVBN.E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ActiveGanttVBNCtl1)
        Me.GroupBox1.Location = New System.Drawing.Point(40, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 304)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(640, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadMSProject2007XMLFileToolStripMenuItem, Me.SaveMSProject2007XMLFileToolStripMenuItem, Me.ToolStripSeparator1, Me.PrintToolStripMenuItem, Me.ToolStripSeparator2, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LoadMSProject2007XMLFileToolStripMenuItem
        '
        Me.LoadMSProject2007XMLFileToolStripMenuItem.Image = CType(resources.GetObject("LoadMSProject2007XMLFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LoadMSProject2007XMLFileToolStripMenuItem.Name = "LoadMSProject2007XMLFileToolStripMenuItem"
        Me.LoadMSProject2007XMLFileToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.LoadMSProject2007XMLFileToolStripMenuItem.Text = "Load MS-Project 2007 XML File..."
        '
        'SaveMSProject2007XMLFileToolStripMenuItem
        '
        Me.SaveMSProject2007XMLFileToolStripMenuItem.Image = CType(resources.GetObject("SaveMSProject2007XMLFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveMSProject2007XMLFileToolStripMenuItem.Name = "SaveMSProject2007XMLFileToolStripMenuItem"
        Me.SaveMSProject2007XMLFileToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.SaveMSProject2007XMLFileToolStripMenuItem.Text = "Save MS-Project 2007 XML File..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(234, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.PrintToolStripMenuItem.Text = "Print..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(234, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "projectnote2003.gif")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdLoadXML, Me.cmdSaveXML, Me.cmdPrint, Me.cmdIndent, Me.ToolStripSeparator3, Me.cmdZoomIn, Me.cmdZoomOut})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(640, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdLoadXML
        '
        Me.cmdLoadXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLoadXML.Image = CType(resources.GetObject("cmdLoadXML.Image"), System.Drawing.Image)
        Me.cmdLoadXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdLoadXML.Name = "cmdLoadXML"
        Me.cmdLoadXML.Size = New System.Drawing.Size(23, 22)
        Me.cmdLoadXML.Text = "ToolStripButton1"
        Me.cmdLoadXML.ToolTipText = "Load MS-Project 2007 XML File"
        '
        'cmdSaveXML
        '
        Me.cmdSaveXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSaveXML.Image = CType(resources.GetObject("cmdSaveXML.Image"), System.Drawing.Image)
        Me.cmdSaveXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSaveXML.Name = "cmdSaveXML"
        Me.cmdSaveXML.Size = New System.Drawing.Size(23, 22)
        Me.cmdSaveXML.Text = "ToolStripButton2"
        Me.cmdSaveXML.ToolTipText = "Save MS-Project 2007 XML File"
        '
        'cmdPrint
        '
        Me.cmdPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(23, 22)
        Me.cmdPrint.Text = "ToolStripButton1"
        '
        'cmdIndent
        '
        Me.cmdIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdIndent.Image = CType(resources.GetObject("cmdIndent.Image"), System.Drawing.Image)
        Me.cmdIndent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdIndent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdIndent.Name = "cmdIndent"
        Me.cmdIndent.Size = New System.Drawing.Size(23, 22)
        Me.cmdIndent.Text = "ToolStripButton1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'cmdZoomIn
        '
        Me.cmdZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdZoomIn.Image = CType(resources.GetObject("cmdZoomIn.Image"), System.Drawing.Image)
        Me.cmdZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdZoomIn.Name = "cmdZoomIn"
        Me.cmdZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.cmdZoomIn.Text = "Zoom In"
        '
        'cmdZoomOut
        '
        Me.cmdZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdZoomOut.Image = CType(resources.GetObject("cmdZoomOut.Image"), System.Drawing.Image)
        Me.cmdZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdZoomOut.Name = "cmdZoomOut"
        Me.cmdZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.cmdZoomOut.Text = "Zoom Out"
        '
        'fMSProject12
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 453)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "fMSProject12"
        Me.Text = "Project 2007 Integration"
        Me.GroupBox1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ActiveGanttVBNCtl1 As AGVBN.ActiveGanttVBNCtl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadMSProject2007XMLFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveMSProject2007XMLFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdLoadXML As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdSaveXML As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdIndent As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdZoomOut As System.Windows.Forms.ToolStripButton
End Class