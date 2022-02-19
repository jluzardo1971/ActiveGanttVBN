<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fMain))
        Me.picBanner = New System.Windows.Forms.PictureBox
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.imgTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.imgBanner = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.cmdExit = New System.Windows.Forms.Button
        CType(Me.picBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'picBanner
        '
        Me.picBanner.Image = CType(resources.GetObject("picBanner.Image"), System.Drawing.Image)
        Me.picBanner.Location = New System.Drawing.Point(8, 0)
        Me.picBanner.Name = "picBanner"
        Me.picBanner.Size = New System.Drawing.Size(784, 65)
        Me.picBanner.TabIndex = 0
        Me.picBanner.TabStop = False
        '
        'lblCopyright
        '
        Me.lblCopyright.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblCopyright.Location = New System.Drawing.Point(8, 536)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(664, 16)
        Me.lblCopyright.TabIndex = 1
        Me.lblCopyright.Text = "Copyright ©2002-2009 The Source Code Store LLC. All Rights Reserved. All trademar" & _
            "ks are property of their legal owner."
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgTreeView
        '
        Me.imgTreeView.ImageStream = CType(resources.GetObject("imgTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.imgTreeView.Images.SetKeyName(0, "")
        Me.imgTreeView.Images.SetKeyName(1, "")
        Me.imgTreeView.Images.SetKeyName(2, "")
        Me.imgTreeView.Images.SetKeyName(3, "")
        Me.imgTreeView.Images.SetKeyName(4, "")
        Me.imgTreeView.Images.SetKeyName(5, "")
        Me.imgTreeView.Images.SetKeyName(6, "onlinedocumentation.png")
        Me.imgTreeView.Images.SetKeyName(7, "localCHMdocumentation.png")
        Me.imgTreeView.Images.SetKeyName(8, "getting_started.png")
        '
        'imgBanner
        '
        Me.imgBanner.ImageStream = CType(resources.GetObject("imgBanner.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgBanner.TransparentColor = System.Drawing.Color.Transparent
        Me.imgBanner.Images.SetKeyName(0, "")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TreeView1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 464)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'TreeView1
        '
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.imgTreeView
        Me.TreeView1.Location = New System.Drawing.Point(8, 16)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(760, 440)
        Me.TreeView1.TabIndex = 0
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(680, 536)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(104, 24)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        '
        'fMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(794, 573)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.picBanner)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fMain"
        CType(Me.picBanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents picBanner As System.Windows.Forms.PictureBox
    Friend WithEvents imgTreeView As System.Windows.Forms.ImageList
    Friend WithEvents imgBanner As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView

End Class
