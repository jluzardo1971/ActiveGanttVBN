<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fWBSPProperties
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cboPredecessorMode = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkEnforcePredecessors = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkEnforcePredecessors)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboPredecessorMode)
        Me.Panel1.Location = New System.Drawing.Point(7, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(371, 70)
        Me.Panel1.TabIndex = 0
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(294, 84)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(84, 28)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cboPredecessorMode
        '
        Me.cboPredecessorMode.FormattingEnabled = True
        Me.cboPredecessorMode.Items.AddRange(New Object() {"PM_FORCE", "PM_CREATEWARNINGFLAG", "PM_RAISEEVENT"})
        Me.cboPredecessorMode.Location = New System.Drawing.Point(154, 35)
        Me.cboPredecessorMode.Name = "cboPredecessorMode"
        Me.cboPredecessorMode.Size = New System.Drawing.Size(203, 21)
        Me.cboPredecessorMode.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PredecessorMode:"
        '
        'chkEnforcePredecessors
        '
        Me.chkEnforcePredecessors.AutoSize = True
        Me.chkEnforcePredecessors.Location = New System.Drawing.Point(7, 7)
        Me.chkEnforcePredecessors.Name = "chkEnforcePredecessors"
        Me.chkEnforcePredecessors.Size = New System.Drawing.Size(127, 17)
        Me.chkEnforcePredecessors.TabIndex = 2
        Me.chkEnforcePredecessors.Text = "EnforcePredecessors"
        Me.chkEnforcePredecessors.UseVisualStyleBackColor = True
        '
        'fWBSPProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 119)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fWBSPProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Properties"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboPredecessorMode As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents chkEnforcePredecessors As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
