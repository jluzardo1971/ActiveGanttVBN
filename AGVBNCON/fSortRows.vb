Imports AGVBN

Public Class fSortRows

    Private mp_bDescending As Boolean = False

    Private Sub fSortRows_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        ActiveGanttVBNCtl1.Columns.Add("", "C1", 125, "")
        For i = 1 To 10
            Dim si As String
            si = i.ToString
            While si.Length < 2
                si = "0" & si
            End While
            ActiveGanttVBNCtl1.Rows.Add("K" & si, "K" & si, True, True, "")
        Next
    End Sub

    Private Sub cmdSortRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSortRows.Click
        mp_bDescending = Not mp_bDescending
        ActiveGanttVBNCtl1.Rows.SortRows("Text", mp_bDescending, E_SORTTYPE.ES_STRING, -1, -1)
        ActiveGanttVBNCtl1.Redraw()
    End Sub
End Class