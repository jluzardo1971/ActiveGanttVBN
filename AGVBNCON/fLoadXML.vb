Option Explicit On
Option Strict On

Imports AGVBN

Partial Public Class fLoadXML
    Inherits System.Windows.Forms.Form

    Private bLoaded As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub fLoadXML_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub mnuLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadXML.Click
        LoadXML()
    End Sub

    Private Sub mnuSaveXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveXML.Click
        SaveXML()
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub cmdLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadXML.Click
        LoadXML()
    End Sub

    Private Sub cmdSaveXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveXML.Click
        SaveXML()
    End Sub

    Private Sub LoadXML()
        OpenFileDialog1.Title = "Open XML"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*"
        If (OpenFileDialog1.ShowDialog(Me) = DialogResult.OK) Then
            ActiveGanttVBNCtl1.ReadXML(OpenFileDialog1.FileName)
            bLoaded = True
            ActiveGanttVBNCtl1.Redraw()
        End If
    End Sub

    Private Sub SaveXML()
        SaveFileDialog1.Title = "Save As XML"
        If ActiveGanttVBNCtl1.ControlTag = "WBSProject" Then
            SaveFileDialog1.FileName = "AGVBN_WBSP"
        ElseIf ActiveGanttVBNCtl1.ControlTag = "CarRental" Then
            SaveFileDialog1.FileName = "AGVBN_CR"
        End If
        SaveFileDialog1.Filter = "XML File|*.xml"
        SaveFileDialog1.OverwritePrompt = True
        If (SaveFileDialog1.ShowDialog(Me) = DialogResult.OK) Then
            ActiveGanttVBNCtl1.WriteXML(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub ActiveGanttVBNCtl1_CustomTierDraw(ByVal sender As System.Object, ByVal e As AGVBN.CustomTierDrawEventArgs) Handles ActiveGanttVBNCtl1.CustomTierDraw
        If bLoaded = False Then
            Return
        End If
        If ActiveGanttVBNCtl1.ControlTag = "WBSProject" Then
            If e.TierPosition = E_TIERPOSITION.SP_LOWER Then
                e.StyleIndex = "TimeLineTiers"
                e.Text = e.StartDate.ToString("MMM")
            ElseIf e.TierPosition = E_TIERPOSITION.SP_UPPER Then
                e.StyleIndex = "TimeLineTiers"
                e.Text = e.StartDate.Year() & " Q" & e.StartDate.Quarter()
            End If
        ElseIf ActiveGanttVBNCtl1.ControlTag = "CarRental" Then
            If e.Interval = E_INTERVAL.IL_HOUR And e.Factor = 12 Then
                e.Text = e.StartDate.ToString("tt").ToUpper()
                e.StyleIndex = "TimeLine"
            End If
            If e.Interval = E_INTERVAL.IL_MONTH And e.Factor = 1 Then
                e.Text = e.StartDate.ToString("MMMM yyyy")
                e.StyleIndex = "TimeLineVA"
            End If
            If e.Interval = E_INTERVAL.IL_DAY And e.Factor = 1 Then
                e.Text = e.StartDate.ToString("ddd d")
                e.StyleIndex = "TimeLine"
            End If
        End If
    End Sub

    Private Sub fLoadXML_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        GroupBox1.Left = 8
        GroupBox1.Top = 60
        GroupBox1.Width = Me.Width - 30
        GroupBox1.Height = Me.Height - 130
        ActiveGanttVBNCtl1.Left = 10
        ActiveGanttVBNCtl1.Top = 15
        ActiveGanttVBNCtl1.Width = Me.Width - 50
        ActiveGanttVBNCtl1.Height = Me.Height - 155
    End Sub

End Class