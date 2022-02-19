Imports AGVBN

Public Class fDurationTasks

    Private Sub fDurationTasks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ActiveGanttVBNCtl1.Left = 10
        ActiveGanttVBNCtl1.Top = 15
        ActiveGanttVBNCtl1.Width = Me.Width - 50
        ActiveGanttVBNCtl1.Height = Me.Height - 50

        ActiveGanttVBNCtl1.AddMode = E_ADDMODE.AT_DURATION_BOTH
        ActiveGanttVBNCtl1.AddDurationInterval = E_INTERVAL.IL_HOUR

        Dim oView As clsView
        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_MINUTE, 10, E_TIERTYPE.ST_MONTH, E_TIERTYPE.ST_DAYOFWEEK, E_TIERTYPE.ST_DAYOFWEEK, "View1")
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TickMarkArea.Visible = False

        ActiveGanttVBNCtl1.CurrentView = "View1"

        Dim i As Integer
        For i = 0 To 110
            ActiveGanttVBNCtl1.Rows.Add("K" & i.ToString())
        Next

        Dim oTimeBlock As clsTimeBlock

        '//Note: non-working overlapping TimeBlock objects are combined for duration calculation purposes.


        '// TimeBlock starts at 6:00pm and ends on 7:00am next day (13 Hours)
        '// This TimeBlock is repeated every day.
        oTimeBlock = ActiveGanttVBNCtl1.TimeBlocks.Add("TB_OutOfOfficeHours")
        oTimeBlock.NonWorking = True
        oTimeBlock.BaseDate = New AGVBN.DateTime(2000, 1, 1, 18, 0, 0)
        oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR
        oTimeBlock.DurationFactor = 13
        oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING
        oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY

        '// TimeBlock starts at 12:00pm (noon) and ends at 1:30pm (90 Minutes)
        '// This TimeBlock is repeated every day. 
        oTimeBlock = ActiveGanttVBNCtl1.TimeBlocks.Add("TB_LunchBreak")
        oTimeBlock.NonWorking = True
        oTimeBlock.BaseDate = New AGVBN.DateTime(2000, 1, 1, 12, 0, 0)
        oTimeBlock.DurationInterval = E_INTERVAL.IL_MINUTE
        oTimeBlock.DurationFactor = 90
        oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING
        oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_DAY

        '// Timeblock starts at 12:00am Saturday and ends on 12:00am Monday (48 Hours)
        '// This TimeBlock is repeated every week.
        oTimeBlock = ActiveGanttVBNCtl1.TimeBlocks.Add("TB_Weekend")
        oTimeBlock.NonWorking = True
        oTimeBlock.BaseDate = New AGVBN.DateTime(2000, 1, 1, 0, 0, 0)
        oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR
        oTimeBlock.DurationFactor = 48
        oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING
        oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_WEEK
        oTimeBlock.BaseWeekDay = E_WEEKDAY.WD_SATURDAY

        '// Arbitrary holiday that starts at 12:00am January 8th and ends on 12:00am January 9th (24 hours)
        '// This TimeBlock is repeated every year.
        oTimeBlock = ActiveGanttVBNCtl1.TimeBlocks.Add("TB_Jan8")
        oTimeBlock.NonWorking = True
        oTimeBlock.BaseDate = New AGVBN.DateTime(2000, 1, 8, 0, 0, 0)
        oTimeBlock.DurationInterval = E_INTERVAL.IL_HOUR
        oTimeBlock.DurationFactor = 24
        oTimeBlock.TimeBlockType = E_TIMEBLOCKTYPE.TBT_RECURRING
        oTimeBlock.RecurringType = E_RECURRINGTYPE.RCT_YEAR

        ActiveGanttVBNCtl1.TimeBlocks.IntervalStart = New AGVBN.DateTime(2012, 1, 1)
        ActiveGanttVBNCtl1.TimeBlocks.IntervalEnd = New AGVBN.DateTime(2023, 6, 1)
        ActiveGanttVBNCtl1.TimeBlocks.IntervalType = E_TBINTERVALTYPE.TBIT_MANUAL
        ActiveGanttVBNCtl1.TimeBlocks.CalculateInterval()


        Dim oTask As clsTask
        For i = 0 To 100
            oTask = ActiveGanttVBNCtl1.Tasks.DAdd("K" & i, New AGVBN.DateTime(2013, 1, 1), E_INTERVAL.IL_HOUR, i, i.ToString(), "", "", "0")

            Dim dtStartDate As AGVBN.DateTime
            Dim dtEndDate As AGVBN.DateTime

            dtStartDate = oTask.StartDate
            dtEndDate = oTask.EndDate

            Dim lDuration As Integer
            lDuration = ActiveGanttVBNCtl1.MathLib.CalculateDuration(dtStartDate, dtEndDate, oTask.DurationInterval)
            If lDuration <> oTask.DurationFactor Then
                Debug.WriteLine("Error: " & i)
                Debug.WriteLine("  Task Duration Factor: " & oTask.DurationFactor)
                Debug.WriteLine("  Calculated Duration: " & lDuration)
                Debug.WriteLine("  Task:")
                Debug.WriteLine("    " & oTask.StartDate.ToString("yyyy/MM/dd HH:mm:ss"))
                Debug.WriteLine("    " & oTask.EndDate.ToString("yyyy/MM/dd HH:mm:ss"))
                Debug.WriteLine("  Calculated:")
                Debug.WriteLine("    " & dtStartDate.ToString("yyyy/MM/dd HH:mm:ss"))
                Debug.WriteLine("    " & dtEndDate.ToString("yyyy/MM/dd HH:mm:ss"))
            End If

        Next

        ActiveGanttVBNCtl1.CurrentViewObject.TimeLine.Position(New AGVBN.DateTime(2013, 1, 1))
    End Sub
End Class