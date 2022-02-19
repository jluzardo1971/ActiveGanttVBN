Friend Class clsTextBox
    Inherits System.Windows.Forms.TextBox

    Private mp_oStyle As clsStyle
    Private mp_oControl As ActiveGanttVBNCtl
    Private mp_oColumn As clsColumn
    Private mp_oRow As clsRow
    Private mp_oCell As clsCell
    Private mp_oNode As clsNode
    Private mp_oTask As clsTask
    Private mp_yObjectType As E_TEXTOBJECTTYPE
    Private mp_sText As String
    Private mp_lIndex As Integer
    Private mp_lIndex2 As Integer
    Friend mp_bInitialized As Boolean

    Friend Sub New(ByVal Value As ActiveGanttVBNCtl)
        Me.Parent = Value
        Me.BorderStyle = Windows.Forms.BorderStyle.None
        Me.Visible = False
        Me.Multiline = True
        mp_oControl = Value
        mp_bInitialized = False
    End Sub

    Public ReadOnly Property Initialized() As Boolean
        Get
            Return mp_bInitialized
        End Get
    End Property

    Friend Sub Initialize(ByVal lIndex As Integer, ByVal lIndex2 As Integer, ByVal yObjectType As E_TEXTOBJECTTYPE, ByVal X As Integer, ByVal Y As Integer)
        mp_yObjectType = yObjectType
        mp_lIndex = lIndex
        mp_lIndex2 = lIndex2
        If mp_bInitialized = True Then
            Terminate()
        End If
        mp_oControl.MouseKeyboardEvents.mp_yOperation = E_OPERATION.EO_NONE
        mp_oControl.MouseKeyboardEvents.mp_SetCursor(E_CURSORTYPE.CT_NORMAL)
        Select Case mp_yObjectType
            Case E_TEXTOBJECTTYPE.TOT_COLUMN
                mp_oColumn = mp_oControl.Columns.Item(lIndex)
                Me.Font = mp_oColumn.Style.Font
                Me.Left = mp_oColumn.mp_lTextLeft
                Me.Top = mp_oColumn.mp_lTextTop
                Me.Width = mp_oColumn.mp_lTextRight - mp_oColumn.mp_lTextLeft + 1
                Me.Height = mp_oColumn.mp_lTextBottom - mp_oColumn.mp_lTextTop + 1
                Me.Text = mp_oColumn.Text
                Me.BackColor = mp_oColumn.Style.TextEditBackColor
                Me.ForeColor = mp_oColumn.Style.TextEditForeColor
            Case E_TEXTOBJECTTYPE.TOT_NODE
                mp_oRow = mp_oControl.Rows.Item(lIndex)
                mp_oNode = mp_oRow.Node
                Me.Font = mp_oNode.Style.Font
                Me.Left = mp_oNode.mp_lTextLeft
                Me.Top = mp_oNode.mp_lTextTop
                Me.Width = mp_oNode.mp_lTextRight - mp_oNode.mp_lTextLeft + 1
                Me.Height = mp_oNode.mp_lTextBottom - mp_oNode.mp_lTextTop + 1
                Me.Text = mp_oNode.Text
                Me.BackColor = mp_oNode.Style.TextEditBackColor
                Me.ForeColor = mp_oNode.Style.TextEditForeColor
            Case E_TEXTOBJECTTYPE.TOT_ROW
                mp_oRow = mp_oControl.Rows.Item(lIndex)
                Me.Font = mp_oRow.Style.Font
                Me.Left = mp_oRow.mp_lTextLeft
                Me.Top = mp_oRow.mp_lTextTop
                Me.Width = mp_oRow.mp_lTextRight - mp_oRow.mp_lTextLeft + 1
                Me.Height = mp_oRow.mp_lTextBottom - mp_oRow.mp_lTextTop + 1
                Me.Text = mp_oRow.Text
                Me.BackColor = mp_oRow.Style.TextEditBackColor
                Me.ForeColor = mp_oRow.Style.TextEditForeColor
            Case E_TEXTOBJECTTYPE.TOT_CELL
                mp_oRow = mp_oControl.Rows.Item(lIndex)
                mp_oCell = mp_oRow.Cells.Item(lIndex2)
                Me.Font = mp_oCell.Style.Font
                Me.Left = mp_oCell.mp_lTextLeft
                Me.Top = mp_oCell.mp_lTextTop
                Me.Width = mp_oCell.mp_lTextRight - mp_oCell.mp_lTextLeft + 1
                Me.Height = mp_oCell.mp_lTextBottom - mp_oCell.mp_lTextTop + 1
                Me.Text = mp_oCell.Text
                Me.BackColor = mp_oCell.Style.TextEditBackColor
                Me.ForeColor = mp_oCell.Style.TextEditForeColor
            Case E_TEXTOBJECTTYPE.TOT_TASK
                mp_oTask = mp_oControl.Tasks.Item(lIndex)
                Me.Font = mp_oTask.Style.Font
                Me.Left = mp_oTask.mp_lTextLeft
                Me.Top = mp_oTask.mp_lTextTop
                Me.Width = mp_oTask.mp_lTextRight - mp_oTask.mp_lTextLeft + 1
                Me.Height = mp_oTask.mp_lTextBottom - mp_oTask.mp_lTextTop + 1
                Me.Text = mp_oTask.Text
                Me.BackColor = mp_oTask.Style.TextEditBackColor
                Me.ForeColor = mp_oTask.Style.TextEditForeColor
        End Select

        Me.Visible = True
        If Me.Text.Length > 0 Then
            Dim oPoint As New System.Drawing.Point(X - Me.Left, Y - Me.Top)
            Me.SelectionStart = Me.GetCharIndexFromPosition(oPoint)
            Me.SelectionLength = 0
        End If
        Me.Focus()
        mp_sText = Me.Text
        mp_oControl.TextEditEventArgs.Clear()
        mp_oControl.TextEditEventArgs.ObjectType = mp_yObjectType
        If mp_yObjectType = E_TEXTOBJECTTYPE.TOT_CELL Then
            mp_oControl.TextEditEventArgs.ParentObjectIndex = mp_lIndex
            mp_oControl.TextEditEventArgs.ObjectIndex = mp_lIndex2
        Else
            mp_oControl.TextEditEventArgs.ParentObjectIndex = 0
            mp_oControl.TextEditEventArgs.ObjectIndex = mp_lIndex
        End If
        mp_oControl.TextEditEventArgs.Text = Me.Text
        mp_oControl.FireBeginTextEdit()
        If mp_oControl.TextEditEventArgs.Text <> Me.Text Then
            Me.Text = mp_oControl.TextEditEventArgs.Text
        End If
        mp_bInitialized = True
    End Sub

    Friend Sub Terminate()
        If mp_bInitialized = True Then
            mp_oControl.TextEditEventArgs.Clear()
            mp_oControl.TextEditEventArgs.ObjectType = mp_yObjectType
            If mp_yObjectType = E_TEXTOBJECTTYPE.TOT_CELL Then
                mp_oControl.TextEditEventArgs.ParentObjectIndex = mp_lIndex
                mp_oControl.TextEditEventArgs.ObjectIndex = mp_lIndex2
            Else
                mp_oControl.TextEditEventArgs.ParentObjectIndex = 0
                mp_oControl.TextEditEventArgs.ObjectIndex = mp_lIndex
            End If
            mp_oControl.TextEditEventArgs.Text = Me.Text
            mp_oControl.FireEndTextEdit()
        End If
        mp_bInitialized = False
        Me.Visible = False
    End Sub

    Private Sub clsTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case mp_yObjectType
            Case E_TEXTOBJECTTYPE.TOT_COLUMN
                mp_oColumn.Text = Me.Text
                mp_oControl.Redraw()
                Me.Left = mp_oColumn.mp_lTextLeft
                Me.Top = mp_oColumn.mp_lTextTop
                Me.Width = mp_oColumn.mp_lTextRight - mp_oColumn.mp_lTextLeft + 1
                Me.Height = mp_oColumn.mp_lTextBottom - mp_oColumn.mp_lTextTop + 1
            Case E_TEXTOBJECTTYPE.TOT_NODE
                mp_oNode.Text = Me.Text
                mp_oControl.Redraw()
                Me.Left = mp_oNode.mp_lTextLeft
                Me.Top = mp_oNode.mp_lTextTop
                Me.Width = mp_oNode.mp_lTextRight - mp_oNode.mp_lTextLeft + 1
                Me.Height = mp_oNode.mp_lTextBottom - mp_oNode.mp_lTextTop + 1
            Case E_TEXTOBJECTTYPE.TOT_ROW
                mp_oRow.Text = Me.Text
                mp_oControl.Redraw()
                Me.Left = mp_oRow.mp_lTextLeft
                Me.Top = mp_oRow.mp_lTextTop
                Me.Width = mp_oRow.mp_lTextRight - mp_oRow.mp_lTextLeft + 1
                Me.Height = mp_oRow.mp_lTextBottom - mp_oRow.mp_lTextTop + 1
            Case E_TEXTOBJECTTYPE.TOT_CELL
                mp_oCell.Text = Me.Text
                mp_oControl.Redraw()
                Me.Left = mp_oCell.mp_lTextLeft
                Me.Top = mp_oCell.mp_lTextTop
                Me.Width = mp_oCell.mp_lTextRight - mp_oCell.mp_lTextLeft + 1
                Me.Height = mp_oCell.mp_lTextBottom - mp_oCell.mp_lTextTop + 1
            Case E_TEXTOBJECTTYPE.TOT_TASK
                mp_oTask.Text = Me.Text
                mp_oControl.Redraw()
                Me.Left = mp_oTask.mp_lTextLeft
                Me.Top = mp_oTask.mp_lTextTop
                Me.Width = mp_oTask.mp_lTextRight - mp_oTask.mp_lTextLeft + 1
                Me.Height = mp_oTask.mp_lTextBottom - mp_oTask.mp_lTextTop + 1
        End Select
    End Sub
End Class

