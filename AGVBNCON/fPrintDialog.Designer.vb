<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPrintDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPrintDialog))
        Me.fraPrinter = New System.Windows.Forms.GroupBox
        Me.cboPrinters = New System.Windows.Forms.ComboBox
        Me.lblPrinterNameCaption = New System.Windows.Forms.Label
        Me.fraPageRange = New System.Windows.Forms.GroupBox
        Me.txtEndPage = New System.Windows.Forms.TextBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtStartPage = New System.Windows.Forms.TextBox
        Me.lblFrom = New System.Windows.Forms.Label
        Me.lblNumberOfPages = New System.Windows.Forms.Label
        Me.fraPage = New System.Windows.Forms.GroupBox
        Me.lblPrecent = New System.Windows.Forms.Label
        Me.txtScale = New System.Windows.Forms.TextBox
        Me.lblScale = New System.Windows.Forms.Label
        Me.lblPixelsH = New System.Windows.Forms.Label
        Me.txtPageHeight = New System.Windows.Forms.TextBox
        Me.lblPageHeight = New System.Windows.Forms.Label
        Me.lblPixelsW = New System.Windows.Forms.Label
        Me.txtPageWidth = New System.Windows.Forms.TextBox
        Me.lblPageWidth = New System.Windows.Forms.Label
        Me.fraForm = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtEDSecond = New System.Windows.Forms.TextBox
        Me.txtEDMinute = New System.Windows.Forms.TextBox
        Me.txtEDHour = New System.Windows.Forms.TextBox
        Me.txtEDDay = New System.Windows.Forms.TextBox
        Me.txtEDMonth = New System.Windows.Forms.TextBox
        Me.txtEDYear = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSDSecond = New System.Windows.Forms.TextBox
        Me.txtSDMinute = New System.Windows.Forms.TextBox
        Me.txtSDHour = New System.Windows.Forms.TextBox
        Me.txtSDDay = New System.Windows.Forms.TextBox
        Me.txtSDMonth = New System.Windows.Forms.TextBox
        Me.txtSDYear = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPreview = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboOrientation = New System.Windows.Forms.ComboBox
        Me.fraPrinter.SuspendLayout()
        Me.fraPageRange.SuspendLayout()
        Me.fraPage.SuspendLayout()
        Me.fraForm.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraPrinter
        '
        Me.fraPrinter.Controls.Add(Me.cboPrinters)
        Me.fraPrinter.Controls.Add(Me.lblPrinterNameCaption)
        Me.fraPrinter.Location = New System.Drawing.Point(8, 8)
        Me.fraPrinter.Name = "fraPrinter"
        Me.fraPrinter.Size = New System.Drawing.Size(376, 56)
        Me.fraPrinter.TabIndex = 0
        Me.fraPrinter.TabStop = False
        Me.fraPrinter.Text = "Printer"
        '
        'cboPrinters
        '
        Me.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrinters.Location = New System.Drawing.Point(64, 24)
        Me.cboPrinters.Name = "cboPrinters"
        Me.cboPrinters.Size = New System.Drawing.Size(304, 21)
        Me.cboPrinters.TabIndex = 3
        '
        'lblPrinterNameCaption
        '
        Me.lblPrinterNameCaption.Location = New System.Drawing.Point(8, 24)
        Me.lblPrinterNameCaption.Name = "lblPrinterNameCaption"
        Me.lblPrinterNameCaption.Size = New System.Drawing.Size(56, 16)
        Me.lblPrinterNameCaption.TabIndex = 0
        Me.lblPrinterNameCaption.Text = "Name:"
        '
        'fraPageRange
        '
        Me.fraPageRange.Controls.Add(Me.txtEndPage)
        Me.fraPageRange.Controls.Add(Me.lblTo)
        Me.fraPageRange.Controls.Add(Me.txtStartPage)
        Me.fraPageRange.Controls.Add(Me.lblFrom)
        Me.fraPageRange.Controls.Add(Me.lblNumberOfPages)
        Me.fraPageRange.Location = New System.Drawing.Point(8, 72)
        Me.fraPageRange.Name = "fraPageRange"
        Me.fraPageRange.Size = New System.Drawing.Size(184, 120)
        Me.fraPageRange.TabIndex = 1
        Me.fraPageRange.TabStop = False
        Me.fraPageRange.Text = "Page Range"
        '
        'txtEndPage
        '
        Me.txtEndPage.Location = New System.Drawing.Point(136, 64)
        Me.txtEndPage.Name = "txtEndPage"
        Me.txtEndPage.Size = New System.Drawing.Size(40, 20)
        Me.txtEndPage.TabIndex = 4
        '
        'lblTo
        '
        Me.lblTo.Location = New System.Drawing.Point(104, 64)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(32, 16)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "To:"
        '
        'txtStartPage
        '
        Me.txtStartPage.Location = New System.Drawing.Point(56, 64)
        Me.txtStartPage.Name = "txtStartPage"
        Me.txtStartPage.Size = New System.Drawing.Size(40, 20)
        Me.txtStartPage.TabIndex = 2
        '
        'lblFrom
        '
        Me.lblFrom.Location = New System.Drawing.Point(8, 64)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(48, 16)
        Me.lblFrom.TabIndex = 1
        Me.lblFrom.Text = "From:"
        '
        'lblNumberOfPages
        '
        Me.lblNumberOfPages.Location = New System.Drawing.Point(8, 32)
        Me.lblNumberOfPages.Name = "lblNumberOfPages"
        Me.lblNumberOfPages.Size = New System.Drawing.Size(104, 16)
        Me.lblNumberOfPages.TabIndex = 0
        Me.lblNumberOfPages.Text = "Total Pages:"
        '
        'fraPage
        '
        Me.fraPage.Controls.Add(Me.lblPrecent)
        Me.fraPage.Controls.Add(Me.txtScale)
        Me.fraPage.Controls.Add(Me.lblScale)
        Me.fraPage.Controls.Add(Me.lblPixelsH)
        Me.fraPage.Controls.Add(Me.txtPageHeight)
        Me.fraPage.Controls.Add(Me.lblPageHeight)
        Me.fraPage.Controls.Add(Me.lblPixelsW)
        Me.fraPage.Controls.Add(Me.txtPageWidth)
        Me.fraPage.Controls.Add(Me.lblPageWidth)
        Me.fraPage.Location = New System.Drawing.Point(200, 72)
        Me.fraPage.Name = "fraPage"
        Me.fraPage.Size = New System.Drawing.Size(184, 120)
        Me.fraPage.TabIndex = 2
        Me.fraPage.TabStop = False
        Me.fraPage.Text = "Page"
        '
        'lblPrecent
        '
        Me.lblPrecent.Location = New System.Drawing.Point(120, 88)
        Me.lblPrecent.Name = "lblPrecent"
        Me.lblPrecent.Size = New System.Drawing.Size(24, 16)
        Me.lblPrecent.TabIndex = 8
        Me.lblPrecent.Text = "%"
        '
        'txtScale
        '
        Me.txtScale.Location = New System.Drawing.Point(64, 88)
        Me.txtScale.Name = "txtScale"
        Me.txtScale.Size = New System.Drawing.Size(48, 20)
        Me.txtScale.TabIndex = 7
        '
        'lblScale
        '
        Me.lblScale.Location = New System.Drawing.Point(8, 88)
        Me.lblScale.Name = "lblScale"
        Me.lblScale.Size = New System.Drawing.Size(40, 16)
        Me.lblScale.TabIndex = 6
        Me.lblScale.Text = "Scale:"
        '
        'lblPixelsH
        '
        Me.lblPixelsH.Location = New System.Drawing.Point(120, 56)
        Me.lblPixelsH.Name = "lblPixelsH"
        Me.lblPixelsH.Size = New System.Drawing.Size(40, 16)
        Me.lblPixelsH.TabIndex = 5
        Me.lblPixelsH.Text = "Pixels"
        '
        'txtPageHeight
        '
        Me.txtPageHeight.Location = New System.Drawing.Point(64, 56)
        Me.txtPageHeight.Name = "txtPageHeight"
        Me.txtPageHeight.Size = New System.Drawing.Size(48, 20)
        Me.txtPageHeight.TabIndex = 4
        '
        'lblPageHeight
        '
        Me.lblPageHeight.Location = New System.Drawing.Point(8, 56)
        Me.lblPageHeight.Name = "lblPageHeight"
        Me.lblPageHeight.Size = New System.Drawing.Size(48, 16)
        Me.lblPageHeight.TabIndex = 3
        Me.lblPageHeight.Text = "Height:"
        '
        'lblPixelsW
        '
        Me.lblPixelsW.Location = New System.Drawing.Point(120, 32)
        Me.lblPixelsW.Name = "lblPixelsW"
        Me.lblPixelsW.Size = New System.Drawing.Size(40, 16)
        Me.lblPixelsW.TabIndex = 2
        Me.lblPixelsW.Text = "Pixels"
        '
        'txtPageWidth
        '
        Me.txtPageWidth.Location = New System.Drawing.Point(64, 32)
        Me.txtPageWidth.Name = "txtPageWidth"
        Me.txtPageWidth.Size = New System.Drawing.Size(48, 20)
        Me.txtPageWidth.TabIndex = 1
        '
        'lblPageWidth
        '
        Me.lblPageWidth.Location = New System.Drawing.Point(8, 32)
        Me.lblPageWidth.Name = "lblPageWidth"
        Me.lblPageWidth.Size = New System.Drawing.Size(56, 16)
        Me.lblPageWidth.TabIndex = 0
        Me.lblPageWidth.Text = "Width:"
        '
        'fraForm
        '
        Me.fraForm.Controls.Add(Me.Label13)
        Me.fraForm.Controls.Add(Me.Label14)
        Me.fraForm.Controls.Add(Me.Label15)
        Me.fraForm.Controls.Add(Me.Label16)
        Me.fraForm.Controls.Add(Me.txtEDSecond)
        Me.fraForm.Controls.Add(Me.txtEDMinute)
        Me.fraForm.Controls.Add(Me.txtEDHour)
        Me.fraForm.Controls.Add(Me.txtEDDay)
        Me.fraForm.Controls.Add(Me.txtEDMonth)
        Me.fraForm.Controls.Add(Me.txtEDYear)
        Me.fraForm.Controls.Add(Me.Label12)
        Me.fraForm.Controls.Add(Me.Label11)
        Me.fraForm.Controls.Add(Me.Label10)
        Me.fraForm.Controls.Add(Me.Label9)
        Me.fraForm.Controls.Add(Me.txtSDSecond)
        Me.fraForm.Controls.Add(Me.txtSDMinute)
        Me.fraForm.Controls.Add(Me.txtSDHour)
        Me.fraForm.Controls.Add(Me.txtSDDay)
        Me.fraForm.Controls.Add(Me.txtSDMonth)
        Me.fraForm.Controls.Add(Me.txtSDYear)
        Me.fraForm.Controls.Add(Me.Label8)
        Me.fraForm.Controls.Add(Me.Label7)
        Me.fraForm.Controls.Add(Me.Label6)
        Me.fraForm.Controls.Add(Me.Label5)
        Me.fraForm.Controls.Add(Me.Label4)
        Me.fraForm.Controls.Add(Me.Label3)
        Me.fraForm.Controls.Add(Me.Label2)
        Me.fraForm.Controls.Add(Me.Label1)
        Me.fraForm.Location = New System.Drawing.Point(8, 240)
        Me.fraForm.Name = "fraForm"
        Me.fraForm.Size = New System.Drawing.Size(376, 104)
        Me.fraForm.TabIndex = 3
        Me.fraForm.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(312, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 16)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(264, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 16)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(168, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(13, 16)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "/"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(120, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(13, 16)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "/"
        '
        'txtEDSecond
        '
        Me.txtEDSecond.Location = New System.Drawing.Point(328, 64)
        Me.txtEDSecond.Name = "txtEDSecond"
        Me.txtEDSecond.Size = New System.Drawing.Size(32, 20)
        Me.txtEDSecond.TabIndex = 22
        Me.txtEDSecond.Text = "60"
        '
        'txtEDMinute
        '
        Me.txtEDMinute.Location = New System.Drawing.Point(280, 64)
        Me.txtEDMinute.Name = "txtEDMinute"
        Me.txtEDMinute.Size = New System.Drawing.Size(32, 20)
        Me.txtEDMinute.TabIndex = 21
        Me.txtEDMinute.Text = "60"
        '
        'txtEDHour
        '
        Me.txtEDHour.Location = New System.Drawing.Point(232, 64)
        Me.txtEDHour.Name = "txtEDHour"
        Me.txtEDHour.Size = New System.Drawing.Size(32, 20)
        Me.txtEDHour.TabIndex = 20
        Me.txtEDHour.Text = "24"
        '
        'txtEDDay
        '
        Me.txtEDDay.Location = New System.Drawing.Point(184, 64)
        Me.txtEDDay.Name = "txtEDDay"
        Me.txtEDDay.Size = New System.Drawing.Size(32, 20)
        Me.txtEDDay.TabIndex = 19
        Me.txtEDDay.Text = "30"
        '
        'txtEDMonth
        '
        Me.txtEDMonth.Location = New System.Drawing.Point(136, 64)
        Me.txtEDMonth.Name = "txtEDMonth"
        Me.txtEDMonth.Size = New System.Drawing.Size(32, 20)
        Me.txtEDMonth.TabIndex = 18
        Me.txtEDMonth.Text = "12"
        '
        'txtEDYear
        '
        Me.txtEDYear.Location = New System.Drawing.Point(80, 64)
        Me.txtEDYear.Name = "txtEDYear"
        Me.txtEDYear.Size = New System.Drawing.Size(40, 20)
        Me.txtEDYear.TabIndex = 17
        Me.txtEDYear.Text = "2010"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(312, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 16)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(264, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 16)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(168, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 16)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "/"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(120, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "/"
        '
        'txtSDSecond
        '
        Me.txtSDSecond.Location = New System.Drawing.Point(328, 32)
        Me.txtSDSecond.Name = "txtSDSecond"
        Me.txtSDSecond.Size = New System.Drawing.Size(32, 20)
        Me.txtSDSecond.TabIndex = 13
        Me.txtSDSecond.Text = "60"
        '
        'txtSDMinute
        '
        Me.txtSDMinute.Location = New System.Drawing.Point(280, 32)
        Me.txtSDMinute.Name = "txtSDMinute"
        Me.txtSDMinute.Size = New System.Drawing.Size(32, 20)
        Me.txtSDMinute.TabIndex = 12
        Me.txtSDMinute.Text = "60"
        '
        'txtSDHour
        '
        Me.txtSDHour.Location = New System.Drawing.Point(232, 32)
        Me.txtSDHour.Name = "txtSDHour"
        Me.txtSDHour.Size = New System.Drawing.Size(32, 20)
        Me.txtSDHour.TabIndex = 11
        Me.txtSDHour.Text = "24"
        '
        'txtSDDay
        '
        Me.txtSDDay.Location = New System.Drawing.Point(184, 32)
        Me.txtSDDay.Name = "txtSDDay"
        Me.txtSDDay.Size = New System.Drawing.Size(32, 20)
        Me.txtSDDay.TabIndex = 10
        Me.txtSDDay.Text = "30"
        '
        'txtSDMonth
        '
        Me.txtSDMonth.Location = New System.Drawing.Point(136, 32)
        Me.txtSDMonth.Name = "txtSDMonth"
        Me.txtSDMonth.Size = New System.Drawing.Size(32, 20)
        Me.txtSDMonth.TabIndex = 9
        Me.txtSDMonth.Text = "12"
        '
        'txtSDYear
        '
        Me.txtSDYear.Location = New System.Drawing.Point(80, 32)
        Me.txtSDYear.Name = "txtSDYear"
        Me.txtSDYear.Size = New System.Drawing.Size(40, 20)
        Me.txtSDYear.TabIndex = 8
        Me.txtSDYear.Text = "2010"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(328, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "ss"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(280, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "mm"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(232, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "hh"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(184, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "DD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "MM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "YYYY"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "End Date:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Start Date:"
        '
        'cmdPreview
        '
        Me.cmdPreview.Location = New System.Drawing.Point(176, 352)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.Size = New System.Drawing.Size(104, 24)
        Me.cmdPreview.TabIndex = 1
        Me.cmdPreview.Text = "Preview..."
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(288, 352)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(96, 24)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(72, 352)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(96, 23)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Text = "OK"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboOrientation)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 40)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Orientation"
        '
        'cboOrientation
        '
        Me.cboOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrientation.Items.AddRange(New Object() {"Portrait", "Landscape"})
        Me.cboOrientation.Location = New System.Drawing.Point(8, 16)
        Me.cboOrientation.Name = "cboOrientation"
        Me.cboOrientation.Size = New System.Drawing.Size(360, 21)
        Me.cboOrientation.TabIndex = 0
        '
        'fPrintDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(392, 383)
        Me.Controls.Add(Me.cmdPreview)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.fraForm)
        Me.Controls.Add(Me.fraPage)
        Me.Controls.Add(Me.fraPageRange)
        Me.Controls.Add(Me.fraPrinter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fPrintDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Printer Settings"
        Me.fraPrinter.ResumeLayout(False)
        Me.fraPageRange.ResumeLayout(False)
        Me.fraPageRange.PerformLayout()
        Me.fraPage.ResumeLayout(False)
        Me.fraPage.PerformLayout()
        Me.fraForm.ResumeLayout(False)
        Me.fraForm.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSDYear As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtEDSecond As System.Windows.Forms.TextBox
    Friend WithEvents txtEDMinute As System.Windows.Forms.TextBox
    Friend WithEvents txtEDHour As System.Windows.Forms.TextBox
    Friend WithEvents txtEDDay As System.Windows.Forms.TextBox
    Friend WithEvents txtEDMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtEDYear As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSDSecond As System.Windows.Forms.TextBox
    Friend WithEvents txtSDMinute As System.Windows.Forms.TextBox
    Friend WithEvents txtSDHour As System.Windows.Forms.TextBox
    Friend WithEvents txtSDDay As System.Windows.Forms.TextBox
    Friend WithEvents txtSDMonth As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents fraPrinter As System.Windows.Forms.GroupBox
    Friend WithEvents fraPageRange As System.Windows.Forms.GroupBox
    Friend WithEvents txtEndPage As System.Windows.Forms.TextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtStartPage As System.Windows.Forms.TextBox
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblNumberOfPages As System.Windows.Forms.Label
    Friend WithEvents fraPage As System.Windows.Forms.GroupBox
    Friend WithEvents lblPixelsH As System.Windows.Forms.Label
    Friend WithEvents txtPageHeight As System.Windows.Forms.TextBox
    Friend WithEvents lblPageHeight As System.Windows.Forms.Label
    Friend WithEvents lblPixelsW As System.Windows.Forms.Label
    Friend WithEvents txtPageWidth As System.Windows.Forms.TextBox
    Friend WithEvents lblPageWidth As System.Windows.Forms.Label
    Friend WithEvents fraForm As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPreview As System.Windows.Forms.Button
    Friend WithEvents lblPrinterNameCaption As System.Windows.Forms.Label
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents lblScale As System.Windows.Forms.Label
    Friend WithEvents txtScale As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecent As System.Windows.Forms.Label
    Friend WithEvents cboPrinters As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboOrientation As System.Windows.Forms.ComboBox

End Class
