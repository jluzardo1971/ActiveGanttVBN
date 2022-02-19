Option Explicit On
Option Strict On

Imports AGVBN
Imports System.Data.OleDb

Partial Public Class fWBSProjectTaskView
    Inherits System.Windows.Forms.Form

    Private mp_lTaskIndex As Integer
    Private mp_oParent As fWBSProject

    Friend Sub New(ByRef oParent As fWBSProject, ByVal lTaskIndex As Integer)
        MyBase.New()
        InitializeComponent()
        mp_oParent = oParent
        mp_lTaskIndex = lTaskIndex
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        Me.Left = CType(((Owner.Width - Me.Width) / 2) + Owner.Left, System.Int32)
        Me.Top = CType(((Owner.Height - Me.Height) / 2) + Owner.Top, System.Int32)
        Dim oTask As clsTask = Nothing
        oTask = mp_oParent.ActiveGanttVBNCtl1.Tasks.Item(mp_lTaskIndex.ToString)
        Me.Text = oTask.Row.Text
        txtTaskName.Text = oTask.Row.Text

        DataGrid1.TableStyles.Clear()
        Dim oDataSet As DataSet = Nothing

        If mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            Using oConn As New OleDbConnection(g_DST_ACCESS_GetConnectionString())
                Dim oAdapter As New OleDbDataAdapter()
                oDataSet = New DataSet()
                oAdapter.SelectCommand = New OleDbCommand("SELECT * FROM qry_GuysStThomas_Predecessors WHERE lSuccessorID=" & mp_lTaskIndex, oConn)
                oAdapter.Fill(oDataSet, "qry_GuysStThomas_Predecessors")
                oConn.Close()
            End Using
        ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
            Dim oRows() As DataRow
            Dim oDataRow As DataRow = Nothing
            oDataSet = New DataSet()
            oRows = mp_oParent.mp_otb_GuysStThomas_Predecessors.Tables(1).Select("lSuccessorID = " & mp_lTaskIndex.ToString())
            Dim oDataTable As New DataTable("qry_GuysStThomas_Predecessors")
            oDataTable.Columns.Add("lPredecessorID", Type.GetType("System.Int32"))
            oDataTable.Columns.Add("sDescription", Type.GetType("System.String"))
            oDataTable.Columns.Add("sPredecessorType", Type.GetType("System.String"))
            For Each otb_GuysStThomas_Predecessors_Row As DataRow In oRows
                oDataRow = oDataTable.NewRow()
                oDataRow("sPredecessorID") = otb_GuysStThomas_Predecessors_Row("sPredecessorID")
                oDataRow("sDescription") = mp_oParent.mp_otb_GuysStThomas.Tables(1).Rows.Find(otb_GuysStThomas_Predecessors_Row("lPredecessorID")).Item("sDescription")
                oDataRow("sPredecessorType") = GetPredecessorType(DirectCast(otb_GuysStThomas_Predecessors_Row("yType"), System.Int32))
                oDataTable.Rows.Add(oDataRow)
            Next
            oDataSet.Tables.Add(oDataTable)
        ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_NONE Then
            Dim oDataRow As DataRow = Nothing
            Dim i As Integer = 0
            oDataSet = New DataSet()
            Dim oDataTable As New DataTable("qry_GuysStThomas_Predecessors")
            oDataTable.Columns.Add("sPredecessorID", Type.GetType("System.Int32"))
            oDataTable.Columns.Add("sDescription", Type.GetType("System.String"))
            oDataTable.Columns.Add("sPredecessorType", Type.GetType("System.String"))
            For i = 1 To mp_oParent.ActiveGanttVBNCtl1.Predecessors.Count
                Dim oPredecessor As clsPredecessor = mp_oParent.ActiveGanttVBNCtl1.Predecessors.Item(i.ToString())
                If oPredecessor.SuccessorKey = oTask.Key Then
                    oDataRow = oDataTable.NewRow()
                    oDataRow("lPredecessorID") = oPredecessor.PredecessorKey.Replace("T", "")
                    oDataRow("sDescription") = GetTaskDescriptionByTaskKey(oPredecessor.PredecessorKey)
                    oDataRow("sPredecessorType") = GetPredecessorType(DirectCast(oPredecessor.PredecessorType, System.Int32))
                    oDataTable.Rows.Add(oDataRow)
                End If
            Next
            oDataSet.Tables.Add(oDataTable)
        End If

        Dim oTableStyle As New DataGridTableStyle()
        oTableStyle.MappingName = "qry_GuysStThomas_Predecessors"

        Dim column As New DataGridTextBoxColumn()
        column.MappingName = "lPredecessorID"
        column.HeaderText = "ID"
        column.Width = 40
        column.ReadOnly = True
        oTableStyle.GridColumnStyles.Add(column)

        column = New DataGridTextBoxColumn()
        column.MappingName = "sDescription"
        column.HeaderText = "Predecessor Task Name"
        column.Width = 260
        column.ReadOnly = True
        oTableStyle.GridColumnStyles.Add(column)

        column = New DataGridTextBoxColumn()
        column.MappingName = "sPredecessorType"
        column.HeaderText = "Type"
        column.Width = 100
        column.ReadOnly = True
        oTableStyle.GridColumnStyles.Add(column)

        DataGrid1.TableStyles.Add(oTableStyle)
        DataGrid1.DataSource = oDataSet
        DataGrid1.Expand(-1)
        DataGrid1.NavigateTo(0, "qry_GuysStThomas_Predecessors")
        DataGrid1.Enabled = False
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Function GetPredecessorType(ByVal lType As Integer) As String
        If lType = 0 Then
            Return "End-To-Start (ES)"
        ElseIf lType = 1 Then
            Return "Start-To-Start (SS)"
        ElseIf lType = 2 Then
            Return "End-To-End (EE)"
        ElseIf lType = 3 Then
            Return "Start-To-End (SE)"
        End If
        Return ""
    End Function

    Private Function GetTaskDescriptionByTaskKey(ByVal sTaskKey As String) As String
        Dim i As Integer = 0
        For i = 1 To mp_oParent.ActiveGanttVBNCtl1.Tasks.Count
            If mp_oParent.ActiveGanttVBNCtl1.Tasks.Item(i.ToString()).Key = sTaskKey Then
                Return mp_oParent.ActiveGanttVBNCtl1.Rows.Item(mp_oParent.ActiveGanttVBNCtl1.Tasks.Item(i.ToString()).RowKey).Node.Text
            End If
        Next
        Return ""
    End Function

End Class