<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPrintPreview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPrintPreview))
        Me.m_HScroll = New System.Windows.Forms.HScrollBar
        Me.m_VScroll = New System.Windows.Forms.VScrollBar
        Me.cmdScrollBarsSeparator = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdPreviousPage = New System.Windows.Forms.ToolStripButton
        Me.cmdNextPage = New System.Windows.Forms.ToolStripButton
        Me.lblPageNumber = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lblXMargin = New System.Windows.Forms.ToolStripTextBox
        Me.cmdXMarginPlus = New System.Windows.Forms.ToolStripButton
        Me.cmdXMarginMinus = New System.Windows.Forms.ToolStripButton
        Me.lblYMargin = New System.Windows.Forms.ToolStripTextBox
        Me.cmdYMarginPlus = New System.Windows.Forms.ToolStripButton
        Me.cmdYMarginMinus = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'm_HScroll
        '
        Me.m_HScroll.Location = New System.Drawing.Point(0, 456)
        Me.m_HScroll.Name = "m_HScroll"
        Me.m_HScroll.Size = New System.Drawing.Size(648, 16)
        Me.m_HScroll.TabIndex = 1
        '
        'm_VScroll
        '
        Me.m_VScroll.Location = New System.Drawing.Point(648, 0)
        Me.m_VScroll.Name = "m_VScroll"
        Me.m_VScroll.Size = New System.Drawing.Size(16, 456)
        Me.m_VScroll.TabIndex = 2
        '
        'cmdScrollBarsSeparator
        '
        Me.cmdScrollBarsSeparator.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdScrollBarsSeparator.Location = New System.Drawing.Point(648, 456)
        Me.cmdScrollBarsSeparator.Name = "cmdScrollBarsSeparator"
        Me.cmdScrollBarsSeparator.Size = New System.Drawing.Size(16, 16)
        Me.cmdScrollBarsSeparator.TabIndex = 3
        Me.cmdScrollBarsSeparator.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdPreviousPage, Me.cmdNextPage, Me.lblPageNumber, Me.ToolStripSeparator1, Me.lblXMargin, Me.cmdXMarginPlus, Me.cmdXMarginMinus, Me.lblYMargin, Me.cmdYMarginPlus, Me.cmdYMarginMinus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(664, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdPreviousPage
        '
        Me.cmdPreviousPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPreviousPage.Image = CType(resources.GetObject("cmdPreviousPage.Image"), System.Drawing.Image)
        Me.cmdPreviousPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPreviousPage.Name = "cmdPreviousPage"
        Me.cmdPreviousPage.Size = New System.Drawing.Size(23, 22)
        Me.cmdPreviousPage.Text = "ToolStripButton1"
        '
        'cmdNextPage
        '
        Me.cmdNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNextPage.Image = CType(resources.GetObject("cmdNextPage.Image"), System.Drawing.Image)
        Me.cmdNextPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdNextPage.Name = "cmdNextPage"
        Me.cmdNextPage.Size = New System.Drawing.Size(23, 22)
        Me.cmdNextPage.Text = "ToolStripButton2"
        '
        'lblPageNumber
        '
        Me.lblPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPageNumber.Name = "lblPageNumber"
        Me.lblPageNumber.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblXMargin
        '
        Me.lblXMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblXMargin.Name = "lblXMargin"
        Me.lblXMargin.Size = New System.Drawing.Size(100, 25)
        '
        'cmdXMarginPlus
        '
        Me.cmdXMarginPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdXMarginPlus.Image = CType(resources.GetObject("cmdXMarginPlus.Image"), System.Drawing.Image)
        Me.cmdXMarginPlus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdXMarginPlus.Name = "cmdXMarginPlus"
        Me.cmdXMarginPlus.Size = New System.Drawing.Size(23, 22)
        Me.cmdXMarginPlus.Text = "ToolStripButton3"
        '
        'cmdXMarginMinus
        '
        Me.cmdXMarginMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdXMarginMinus.Image = CType(resources.GetObject("cmdXMarginMinus.Image"), System.Drawing.Image)
        Me.cmdXMarginMinus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdXMarginMinus.Name = "cmdXMarginMinus"
        Me.cmdXMarginMinus.Size = New System.Drawing.Size(23, 22)
        Me.cmdXMarginMinus.Text = "ToolStripButton4"
        '
        'lblYMargin
        '
        Me.lblYMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYMargin.Name = "lblYMargin"
        Me.lblYMargin.Size = New System.Drawing.Size(100, 25)
        '
        'cmdYMarginPlus
        '
        Me.cmdYMarginPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdYMarginPlus.Image = CType(resources.GetObject("cmdYMarginPlus.Image"), System.Drawing.Image)
        Me.cmdYMarginPlus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdYMarginPlus.Name = "cmdYMarginPlus"
        Me.cmdYMarginPlus.Size = New System.Drawing.Size(23, 22)
        Me.cmdYMarginPlus.Text = "ToolStripButton5"
        '
        'cmdYMarginMinus
        '
        Me.cmdYMarginMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdYMarginMinus.Image = CType(resources.GetObject("cmdYMarginMinus.Image"), System.Drawing.Image)
        Me.cmdYMarginMinus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdYMarginMinus.Name = "cmdYMarginMinus"
        Me.cmdYMarginMinus.Size = New System.Drawing.Size(23, 22)
        Me.cmdYMarginMinus.Text = "ToolStripButton6"
        '
        'fPrintPreview
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(664, 543)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cmdScrollBarsSeparator)
        Me.Controls.Add(Me.m_VScroll)
        Me.Controls.Add(Me.m_HScroll)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fPrintPreview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdPreviousPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNextPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPageNumber As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lblXMargin As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents cmdXMarginPlus As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdXMarginMinus As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblYMargin As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents cmdYMarginPlus As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdYMarginMinus As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdScrollBarsSeparator As System.Windows.Forms.Button
    Friend WithEvents m_HScroll As System.Windows.Forms.HScrollBar
    Friend WithEvents m_VScroll As System.Windows.Forms.VScrollBar

End Class
