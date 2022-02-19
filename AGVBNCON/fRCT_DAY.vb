Imports AGVBN

Public Class fRCT_DAY

    Private Sub fRCT_DAY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ActiveGanttVBNCtl1.Left = 10
        ActiveGanttVBNCtl1.Top = 15
        ActiveGanttVBNCtl1.Width = Me.Width - 50
        ActiveGanttVBNCtl1.Height = Me.Height - 50

        Dim oView As clsView
        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_MINUTE, 10, E_TIERTYPE.ST_MONTH, E_TIERTYPE.ST_DAYOFWEEK, E_TIERTYPE.ST_DAYOFWEEK, "View1")
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TickMarkArea.Visible = False

        ActiveGanttVBNCtl1.CurrentView = "View1"

        Dim i As Integer
        For i = 1 To 50
            ActiveGanttVBNCtl1.Rows.Add("K" & i.ToString())
        Next

        Dim oTimeBlock As clsTimeBlock

        oTimeBlock = ActiveGanttVBNCtl1.TimeBlocks.Add("TB_OutOfOfficeHours")
        oTimeBlock.NonWorking = True
        oTimeBlock.BaseDate = New AGVBN.DateTime(2000, 1, 1, 18, 0, 0)
        oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR
        oTimeBlock.DurationFactor = 13
        oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING
        oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY

        oTimeBlock = ActiveGanttVBNCtl1.TimeBlocks.Add("TB_LunchBreak")
        oTimeBlock.NonWorking = True
        oTimeBlock.BaseDate = New AGVBN.DateTime(2000, 1, 1, 12, 0, 0)
        oTimeBlock.DurationInterval = E_INTERVAL.IL_MINUTE
        oTimeBlock.DurationFactor = 90
        oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING
        oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY
    End Sub
End Class