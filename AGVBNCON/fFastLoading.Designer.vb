<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fFastLoading
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
        Me.ActiveGanttVBNCtl1 = New AGVBN.ActiveGanttVBNCtl
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ActiveGanttVBNCtl1)
        Me.Panel1.Location = New System.Drawing.Point(4, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(864, 491)
        Me.Panel1.TabIndex = 0
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
        Me.ActiveGanttVBNCtl1.CurrentView = ""
        Me.ActiveGanttVBNCtl1.DoubleBuffering = True
        Me.ActiveGanttVBNCtl1.ErrorReports = AGVBN.E_REPORTERRORS.RE_MSGBOX
        Me.ActiveGanttVBNCtl1.LayerEnableObjects = AGVBN.E_LAYEROBJECTENABLE.EC_INCURRENTLAYERONLY
        Me.ActiveGanttVBNCtl1.Location = New System.Drawing.Point(11, 13)
        Me.ActiveGanttVBNCtl1.MinColumnWidth = 5
        Me.ActiveGanttVBNCtl1.MinRowHeight = 5
        Me.ActiveGanttVBNCtl1.Name = "ActiveGanttVBNCtl1"
        Me.ActiveGanttVBNCtl1.ScrollBarBehaviour = AGVBN.E_SCROLLBEHAVIOUR.SB_HIDE
        Me.ActiveGanttVBNCtl1.SelectedCellIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedColumnIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedPercentageIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedRowIndex = 0
        Me.ActiveGanttVBNCtl1.SelectedTaskIndex = 0
        Me.ActiveGanttVBNCtl1.Size = New System.Drawing.Size(839, 465)
        Me.ActiveGanttVBNCtl1.TabIndex = 0
        Me.ActiveGanttVBNCtl1.TimeBlockBehaviour = AGVBN.E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS
        '
        'fFastLoading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 511)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fFastLoading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fast Loading of Row and Task objects"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ActiveGanttVBNCtl1 As AGVBN.ActiveGanttVBNCtl
End Class
