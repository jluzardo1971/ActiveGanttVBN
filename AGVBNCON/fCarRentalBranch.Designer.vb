<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fCarRentalBranch
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtManagerMobile = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtManagerName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtZIP = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBranchName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCity, Me.txtState, Me.GroupBox2, Me.txtZIP, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.txtAddress, Me.txtPhone, Me.Label2, Me.txtBranchName, Me.Label1})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 272)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(104, 72)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(200, 20)
        Me.txtCity.TabIndex = 14
        Me.txtCity.Text = ""
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(104, 96)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(24, 20)
        Me.txtState.TabIndex = 13
        Me.txtState.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtManagerMobile, Me.Label8, Me.txtManagerName, Me.Label7})
        Me.GroupBox2.Location = New System.Drawing.Point(8, 176)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 80)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Manager:"
        '
        'txtManagerMobile
        '
        Me.txtManagerMobile.Location = New System.Drawing.Point(96, 48)
        Me.txtManagerMobile.Name = "txtManagerMobile"
        Me.txtManagerMobile.Size = New System.Drawing.Size(80, 20)
        Me.txtManagerMobile.TabIndex = 3
        Me.txtManagerMobile.Text = ""
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Mobile:"
        '
        'txtManagerName
        '
        Me.txtManagerName.Location = New System.Drawing.Point(96, 24)
        Me.txtManagerName.Name = "txtManagerName"
        Me.txtManagerName.Size = New System.Drawing.Size(304, 20)
        Me.txtManagerName.TabIndex = 1
        Me.txtManagerName.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Name:"
        '
        'txtZIP
        '
        Me.txtZIP.Location = New System.Drawing.Point(104, 120)
        Me.txtZIP.Name = "txtZIP"
        Me.txtZIP.Size = New System.Drawing.Size(40, 20)
        Me.txtZIP.TabIndex = 11
        Me.txtZIP.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "ZIP:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "State:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "City:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Address:"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(104, 48)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(304, 20)
        Me.txtAddress.TabIndex = 4
        Me.txtAddress.Text = ""
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(104, 144)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(80, 20)
        Me.txtPhone.TabIndex = 3
        Me.txtPhone.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Phone:"
        '
        'txtBranchName
        '
        Me.txtBranchName.Location = New System.Drawing.Point(104, 24)
        Me.txtBranchName.Name = "txtBranchName"
        Me.txtBranchName.Size = New System.Drawing.Size(304, 20)
        Me.txtBranchName.TabIndex = 1
        Me.txtBranchName.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Branch Name:"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(336, 288)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(96, 24)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(240, 288)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(88, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        '
        'fCarRentalBranch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 319)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.cmdOK, Me.GroupBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fCarRentalBranch"
        Me.Text = "fCarRentalBranch"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtBranchName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtManagerName As System.Windows.Forms.TextBox
    Friend WithEvents txtManagerMobile As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtZIP As System.Windows.Forms.TextBox


End Class
