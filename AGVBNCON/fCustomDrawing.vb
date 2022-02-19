Imports AGVBN

Public Class fCustomDrawing


    Private Sub fCustomDrawing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim oColumn As clsColumn
        oColumn = ActiveGanttVBNCtl1.Columns.Add("Column 1", "", 125, "")
        oColumn.AllowTextEdit = True
        oColumn = ActiveGanttVBNCtl1.Columns.Add("Column 2", "", 100, "")
        oColumn.AllowTextEdit = True
        For i = 1 To 10
            ActiveGanttVBNCtl1.Rows.Add("K" & i.ToString(), "Row " & i.ToString() & " (Key: " & "K" & i.ToString() & ")", True, True, "")
        Next

        ActiveGanttVBNCtl1.CurrentViewObject.TimeLine.Position(New DateTime(2011, 11, 21, 0, 0, 0))
        ActiveGanttVBNCtl1.Tasks.Add("Task 1", "K1", New DateTime(2011, 11, 21, 0, 0, 0), New DateTime(2011, 11, 21, 3, 0, 0), "", "", "")
        ActiveGanttVBNCtl1.Tasks.Add("Task 2", "K2", New DateTime(2011, 11, 21, 1, 0, 0), New DateTime(2011, 11, 21, 4, 0, 0), "", "", "")
        ActiveGanttVBNCtl1.Tasks.Add("Task 3", "K3", New DateTime(2011, 11, 21, 2, 0, 0), New DateTime(2011, 11, 21, 5, 0, 0), "", "", "")

        ActiveGanttVBNCtl1.Redraw()
    End Sub

    Private Sub ActiveGanttVBNCtl1_Draw(ByVal sender As System.Object, ByVal e As DrawEventArgs) Handles ActiveGanttVBNCtl1.Draw
        If e.EventTarget = E_EVENTTARGET.EVT_TASK Then
            If ActiveGanttVBNCtl1.SelectedTaskIndex = e.ObjectIndex Then
                e.CustomDraw = True
                Dim oTask As clsTask
                oTask = ActiveGanttVBNCtl1.Tasks.Item(e.ObjectIndex.ToString())
                Dim oFont As New System.Drawing.Font("Arial", 7)
                Dim oTextFlags As New System.Drawing.StringFormat
                oTextFlags.Alignment = StringAlignment.Center
                oTextFlags.LineAlignment = StringAlignment.Center
                ActiveGanttVBNCtl1.Drawing.PaintImage(ImageList1.Images(0), oTask.Left + 40, oTask.Top + 10, oTask.Left + 64, oTask.Top + 34)
                ActiveGanttVBNCtl1.Drawing.DrawLine(oTask.Left, ((oTask.Bottom - oTask.Top) / 2) + oTask.Top, oTask.Right, ((oTask.Bottom - oTask.Top) / 2) + oTask.Top, Color.Green, GRE_LINEDRAWSTYLE.LDS_SOLID, 1)
                ActiveGanttVBNCtl1.Drawing.DrawRectangle(oTask.Left, oTask.Top, oTask.Left + 10, oTask.Top + 10, Color.Red, GRE_LINEDRAWSTYLE.LDS_SOLID, 1)
                ActiveGanttVBNCtl1.Drawing.DrawBorder(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, Color.Blue, GRE_LINEDRAWSTYLE.LDS_SOLID, 2)
                ActiveGanttVBNCtl1.Drawing.DrawAlignedText(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, oTask.Text & " Is Selected", GRE_HORIZONTALALIGNMENT.HAL_RIGHT, GRE_VERTICALALIGNMENT.VAL_BOTTOM, Color.Blue, oFont)
                ActiveGanttVBNCtl1.Drawing.DrawText(oTask.Left, oTask.Top, oTask.Right, oTask.Bottom, "Draw Text", oTextFlags, Color.Red, oFont)
            End If
        End If
    End Sub
End Class