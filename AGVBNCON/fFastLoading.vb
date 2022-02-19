Imports AGVBN

Public Class fFastLoading

    Private Sub fFastLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        ActiveGanttVBNCtl1.Columns.Add("Tasks", "", 200, "")
        ActiveGanttVBNCtl1.TreeviewColumnIndex = 1
        ActiveGanttVBNCtl1.Rows.BeginLoad(False)
        ActiveGanttVBNCtl1.Tasks.BeginLoad(False)
        Dim lCurrentDepth As Integer = 0
        For i = 0 To 5000
            Dim oRow As clsRow
            Dim oTask As clsTask
            oRow = ActiveGanttVBNCtl1.Rows.Load("K" & i.ToString)
            oTask = ActiveGanttVBNCtl1.Tasks.Load("K" & i.ToString(), "K" & i.ToString)
            oRow.Text = "Task K" & i.ToString()
            oRow.MergeCells = True
            oRow.Node.Depth = lCurrentDepth
            oTask.Text = "K" & i.ToString()
            oTask.StartDate = ActiveGanttVBNCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, GetRnd(0, 5), AGVBN.DateTime.Now)
            oTask.EndDate = ActiveGanttVBNCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, GetRnd(2, 7), oTask.StartDate)
            lCurrentDepth = lCurrentDepth + GetRnd(-1, 2)
            If lCurrentDepth < 0 Then
                lCurrentDepth = 0
            End If
        Next
        ActiveGanttVBNCtl1.Tasks.EndLoad()
        ActiveGanttVBNCtl1.Rows.EndLoad()
        ActiveGanttVBNCtl1.Rows.BeginLoad(True)
        ActiveGanttVBNCtl1.Tasks.BeginLoad(True)
        For i = 5001 To 10000
            Dim oRow As clsRow
            Dim oTask As clsTask
            oRow = ActiveGanttVBNCtl1.Rows.Load("KL" & i.ToString)
            oTask = ActiveGanttVBNCtl1.Tasks.Load("KL" & i.ToString, "KL" & i.ToString)
            oRow.Text = "Task KL" & i.ToString()
            oRow.MergeCells = True
            oTask.Text = "KL" & i.ToString()
            oTask.StartDate = ActiveGanttVBNCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, GetRnd(0, 5), AGVBN.DateTime.Now)
            oTask.EndDate = ActiveGanttVBNCtl1.MathLib.DateTimeAdd(E_INTERVAL.IL_HOUR, GetRnd(2, 7), oTask.StartDate)
        Next
        ActiveGanttVBNCtl1.Tasks.EndLoad()
        ActiveGanttVBNCtl1.Rows.EndLoad()
        ActiveGanttVBNCtl1.Redraw()
    End Sub
End Class