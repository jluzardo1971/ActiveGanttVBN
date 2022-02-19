Public Class fWBSPProperties

    Dim mp_oParent As fWBSProject

    Friend Sub New(ByVal oParent As fWBSProject)
        InitializeComponent()
        mp_oParent = oParent
    End Sub

    Private Sub fWBSPProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkEnforcePredecessors.Checked = mp_oParent.ActiveGanttVBNCtl1.EnforcePredecessors
        cboPredecessorMode.SelectedIndex = System.Convert.ToInt32(mp_oParent.ActiveGanttVBNCtl1.PredecessorMode)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        mp_oParent.ActiveGanttVBNCtl1.EnforcePredecessors = chkEnforcePredecessors.Checked
        mp_oParent.ActiveGanttVBNCtl1.PredecessorMode = DirectCast(System.Convert.ToInt32(cboPredecessorMode.SelectedIndex), AGVBN.E_PREDECESSORMODE)
        mp_oParent.ActiveGanttVBNCtl1.Redraw()
        Me.Close()
    End Sub

End Class