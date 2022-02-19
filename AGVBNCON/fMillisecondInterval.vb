Imports AGVBN


Public Class fMillisecondInterval

    Private Sub fMillisecondInterval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oView As clsView
        oView = ActiveGanttVBNCtl1.Views.Add(E_INTERVAL.IL_MILLISECOND, 5, E_TIERTYPE.ST_MINUTE, E_TIERTYPE.ST_CUSTOM, E_TIERTYPE.ST_SECOND, "MSI")
        oView.TimeLine.TickMarkArea.Visible = False
        oView.TimeLine.TierArea.MiddleTier.Visible = False
        oView.TimeLine.TierArea.TierFormat.MinuteIntervalFormat = "MMM dd, yyyy hh:mm tt"
        oView.TimeLine.Position(New AGVBN.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, System.DateTime.Now.Minute, 58))

        ActiveGanttVBNCtl1.CurrentView = "MSI"

        Dim i As Integer
        ActiveGanttVBNCtl1.Columns.Add("", "C1", 125, "")
        For i = 1 To 10
            Dim oRow As clsRow
            oRow = ActiveGanttVBNCtl1.Rows.Add("K" & i.ToString, "K" & i.ToString(), True, True, "")
        Next
    End Sub

    Private Sub ActiveGanttVBNCtl1_CompleteObjectMove(ByVal sender As Object, ByVal e As AGVBN.ObjectStateChangedEventArgs) Handles ActiveGanttVBNCtl1.CompleteObjectMove
        If e.EventTarget = E_EVENTTARGET.EVT_TASK Then
            Dim oTask As clsTask
            Dim sText As String
            oTask = ActiveGanttVBNCtl1.Tasks.Item(e.Index.ToString())
            sText = ActiveGanttVBNCtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_MILLISECOND, oTask.StartDate, oTask.EndDate).ToString()
            oTask.Text = sText & "ms"
        End If
    End Sub

    Private Sub ActiveGanttVBNCtl1_CompleteObjectSize(ByVal sender As Object, ByVal e As AGVBN.ObjectStateChangedEventArgs) Handles ActiveGanttVBNCtl1.CompleteObjectSize
        If e.EventTarget = E_EVENTTARGET.EVT_TASK Then
            Dim oTask As clsTask
            Dim sText As String
            oTask = ActiveGanttVBNCtl1.Tasks.Item(e.Index.ToString())
            sText = ActiveGanttVBNCtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_MILLISECOND, oTask.StartDate, oTask.EndDate).ToString()
            oTask.Text = sText & "ms"
        End If
    End Sub

    Private Sub ActiveGanttVBNCtl1_ObjectAdded(ByVal sender As Object, ByVal e As AGVBN.ObjectAddedEventArgs) Handles ActiveGanttVBNCtl1.ObjectAdded
        If e.EventTarget = E_EVENTTARGET.EVT_TASK Then
            Dim oTask As clsTask
            Dim sText As String
            oTask = ActiveGanttVBNCtl1.Tasks.Item(e.TaskIndex.ToString())
            sText = ActiveGanttVBNCtl1.MathLib.DateTimeDiff(E_INTERVAL.IL_MILLISECOND, oTask.StartDate, oTask.EndDate).ToString()
            oTask.Text = sText & "ms"
        End If
    End Sub

End Class