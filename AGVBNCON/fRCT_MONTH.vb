Imports AGVBN

Public Class fRCT_MONTH

    Private Sub fRCT_MONTH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ActiveGanttVBNCtl1.Left = 10
        ActiveGanttVBNCtl1.Top = 15
        ActiveGanttVBNCtl1.Width = Me.Width - 50
        ActiveGanttVBNCtl1.Height = Me.Height - 50

        Dim oView As clsView
        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_HOUR, 1, E_TIERTYPE.ST_MONTH, E_TIERTYPE.ST_DAYOFWEEK, E_TIERTYPE.ST_DAYOFWEEK, "View1")
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TickMarkArea.Visible = False
        ActiveGanttVBNCtl1.TierFormatScope = E_TIERFORMATSCOPE.TFS_CONTROL
        ActiveGanttVBNCtl1.TierFormat.DayOfWeekIntervalFormat = "dd"

        ActiveGanttVBNCtl1.CurrentView = "View1"

        Dim i As Integer
        For i = 1 To 50
            ActiveGanttVBNCtl1.Rows.Add("K" & i.ToString())
        Next

        Dim oTimeBlock As clsTimeBlock
        Dim dtDate As AGVBN.DateTime
        dtDate = New AGVBN.DateTime(2000, 1, 1, 0, 0, 0)

        oTimeBlock = ActiveGanttVBNCtl1.TimeBlocks.Add("TimeBlock1")
        oTimeBlock.BaseDate = dtDate
        oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR
        oTimeBlock.DurationFactor = -48
        oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING
        oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_MONTH

    End Sub
End Class