Option Explicit On 

Friend Class fAbout
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Friend Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents fraForm As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblSales As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTechnicalSupport As System.Windows.Forms.LinkLabel
    Friend WithEvents lblRegister As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSalesText As System.Windows.Forms.Label
    Friend WithEvents lblTechnicalSupportText As System.Windows.Forms.Label
    Friend WithEvents lblRegisterText As System.Windows.Forms.Label
    Friend WithEvents lblURL As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTitle1 As System.Windows.Forms.Label
    Friend WithEvents lblTitle2 As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fAbout))
        Me.cmdOK = New System.Windows.Forms.Button
        Me.fraForm = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblSales = New System.Windows.Forms.LinkLabel
        Me.lblTechnicalSupport = New System.Windows.Forms.LinkLabel
        Me.lblRegister = New System.Windows.Forms.LinkLabel
        Me.lblSalesText = New System.Windows.Forms.Label
        Me.lblTechnicalSupportText = New System.Windows.Forms.Label
        Me.lblRegisterText = New System.Windows.Forms.Label
        Me.lblURL = New System.Windows.Forms.LinkLabel
        Me.lblTitle1 = New System.Windows.Forms.Label
        Me.lblTitle2 = New System.Windows.Forms.Label
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.fraForm.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(272, 184)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(88, 24)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "&OK"
        '
        'fraForm
        '
        Me.fraForm.Controls.Add(Me.PictureBox1)
        Me.fraForm.Controls.Add(Me.lblSales)
        Me.fraForm.Controls.Add(Me.lblTechnicalSupport)
        Me.fraForm.Controls.Add(Me.lblRegister)
        Me.fraForm.Controls.Add(Me.lblSalesText)
        Me.fraForm.Controls.Add(Me.lblTechnicalSupportText)
        Me.fraForm.Controls.Add(Me.lblRegisterText)
        Me.fraForm.Controls.Add(Me.lblURL)
        Me.fraForm.Controls.Add(Me.lblTitle1)
        Me.fraForm.Controls.Add(Me.lblTitle2)
        Me.fraForm.Controls.Add(Me.lblCopyright)
        Me.fraForm.Location = New System.Drawing.Point(8, 8)
        Me.fraForm.Name = "fraForm"
        Me.fraForm.Size = New System.Drawing.Size(352, 168)
        Me.fraForm.TabIndex = 5
        Me.fraForm.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'lblSales
        '
        Me.lblSales.Location = New System.Drawing.Point(144, 144)
        Me.lblSales.Name = "lblSales"
        Me.lblSales.Size = New System.Drawing.Size(152, 16)
        Me.lblSales.TabIndex = 9
        Me.lblSales.TabStop = True
        Me.lblSales.Text = "sales@sourcecodestore.com"
        '
        'lblTechnicalSupport
        '
        Me.lblTechnicalSupport.Location = New System.Drawing.Point(144, 128)
        Me.lblTechnicalSupport.Name = "lblTechnicalSupport"
        Me.lblTechnicalSupport.Size = New System.Drawing.Size(192, 16)
        Me.lblTechnicalSupport.TabIndex = 8
        Me.lblTechnicalSupport.TabStop = True
        Me.lblTechnicalSupport.Text = "support@sourcecodestore.com"
        '
        'lblRegister
        '
        Me.lblRegister.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegister.Location = New System.Drawing.Point(144, 112)
        Me.lblRegister.Name = "lblRegister"
        Me.lblRegister.Size = New System.Drawing.Size(176, 16)
        Me.lblRegister.TabIndex = 7
        Me.lblRegister.TabStop = True
        Me.lblRegister.Text = "Secure Online Order Form"
        '
        'lblSalesText
        '
        Me.lblSalesText.Location = New System.Drawing.Point(16, 144)
        Me.lblSalesText.Name = "lblSalesText"
        Me.lblSalesText.Size = New System.Drawing.Size(40, 16)
        Me.lblSalesText.TabIndex = 6
        Me.lblSalesText.Text = "Sales:"
        '
        'lblTechnicalSupportText
        '
        Me.lblTechnicalSupportText.Location = New System.Drawing.Point(16, 128)
        Me.lblTechnicalSupportText.Name = "lblTechnicalSupportText"
        Me.lblTechnicalSupportText.Size = New System.Drawing.Size(112, 16)
        Me.lblTechnicalSupportText.TabIndex = 5
        Me.lblTechnicalSupportText.Text = "Technical Support:"
        '
        'lblRegisterText
        '
        Me.lblRegisterText.Location = New System.Drawing.Point(16, 112)
        Me.lblRegisterText.Name = "lblRegisterText"
        Me.lblRegisterText.Size = New System.Drawing.Size(64, 16)
        Me.lblRegisterText.TabIndex = 4
        Me.lblRegisterText.Text = "Register:"
        '
        'lblURL
        '
        Me.lblURL.Location = New System.Drawing.Point(72, 80)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(232, 16)
        Me.lblURL.TabIndex = 3
        Me.lblURL.TabStop = True
        Me.lblURL.Text = "http://www.sourcecodestore.com"
        Me.lblURL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle1.Location = New System.Drawing.Point(48, 24)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(296, 16)
        Me.lblTitle1.TabIndex = 0
        Me.lblTitle1.Text = "ActiveGanttVBN Scheduler Control, Version 2.0"
        '
        'lblTitle2
        '
        Me.lblTitle2.Location = New System.Drawing.Point(48, 40)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(232, 16)
        Me.lblTitle2.TabIndex = 1
        Me.lblTitle2.Text = ".NET Windows Form Control (VB.NET)"
        '
        'lblCopyright
        '
        Me.lblCopyright.Location = New System.Drawing.Point(48, 56)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(296, 16)
        Me.lblCopyright.TabIndex = 2
        Me.lblCopyright.Text = "Copyright © 2002-2009, The Source Code Store LLC"
        '
        'fAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 213)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.fraForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.fraForm.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Sub lblURL_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblURL.LinkClicked
        lblURL.LinkVisited = True
        System.Diagnostics.Process.Start(lblURL.Text)
    End Sub

    Private Sub lblTechnicalSupport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblTechnicalSupport.LinkClicked
        lblTechnicalSupport.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.sourcecodestore.com/Support/default.aspx")
    End Sub

    Private Sub lblSales_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblSales.LinkClicked
        lblSales.LinkVisited = True
        System.Diagnostics.Process.Start("mailto:" & lblSales.Text)
    End Sub

    Private Sub lblRegister_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblRegister.LinkClicked
        lblRegister.LinkVisited = True
        System.Diagnostics.Process.Start(lblRegister.Tag)
    End Sub


    Private Sub fAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ai As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        lblTitle1.Text = "ActiveGantt Scheduler Control, Version " & ai.GetName.Version().ToString()
        lblURL.Text = "http://www.sourcecodestore.com"
        lblTechnicalSupport.Text = "Technical Support Page"
        lblSales.Text = "sales@sourcecodestore.com"
        lblRegister.Tag = "http://www.sourcecodestore.com/OnlineStore/default.aspx"
        lblCopyright.Text = "Copyright © 2002-" & System.DateTime.Now.Year.ToString() & ",  The Source Code Store LLC"
    End Sub
End Class
