Option Explicit On

Imports AGVBN

Partial Public Class fCarRentalBranch
    Inherits System.Windows.Forms.Form

    Private mp_yDialogMode As PRG_DIALOGMODE
    Private mp_oParent As fCarRental
    Private mp_sRowID As String

    Friend Sub New(ByVal yDialogMode As PRG_DIALOGMODE, ByRef oParent As fCarRental, ByVal sRowID As String)
        MyBase.New()
        InitializeComponent()
        mp_yDialogMode = yDialogMode
        mp_oParent = oParent
        mp_sRowID = sRowID
    End Sub

    Private Sub fCarRentalBranch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = CType(((Owner.Width - Me.Width) / 2) + Owner.Left, System.Int32)
        Me.Top = CType(((Owner.Height - Me.Height) / 2) + Owner.Top, System.Int32)
        If mp_yDialogMode = PRG_DIALOGMODE.DM_ADD Then
            Me.Text = "Add New Branch"
            Dim sCityName As String = ""
            Dim sStateName As String = ""
            Dim lID As Integer = 0
            g_GenerateRandomCity(sCityName, sStateName, lID, mp_oParent.mp_yDataSourceType)
            txtCity.Text = sCityName
            txtBranchName.Text = sCityName
            txtState.Text = sStateName
            txtPhone.Text = g_GenerateRandomPhone("")
            txtManagerName.Text = g_GenerateRandomName(False, mp_oParent.mp_yDataSourceType)
            txtManagerMobile.Text = g_GenerateRandomPhone(txtPhone.Text.Substring(0, 5))
            txtAddress.Text = g_GenerateRandomAddress(mp_oParent.mp_yDataSourceType)
            txtZIP.Text = g_GenerateRandomZIP()
        Else
            Dim oDataRow As DataRow = Nothing
            Me.Text = "Edit Branch"
            If mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
                Dim oDB As clsDB = Nothing
                oDB = New clsDB()
                oDB.InitReader("SELECT * FROM tb_CR_Rows WHERE lRowID = " & mp_sRowID)
                oDB.Read(txtCity, "sCity")
                oDB.Read(txtBranchName, "sBranchName")
                oDB.Read(txtState, "sState")
                oDB.Read(txtPhone, "sPhone")
                oDB.Read(txtManagerName, "sManagerName")
                oDB.Read(txtManagerMobile, "sManagerMobile")
                oDB.Read(txtAddress, "sAddress")
                oDB.Read(txtZIP, "sZIP")
                oDB.CloseReader()
            ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(1).Rows.Find(mp_sRowID)
                txtCity.Text = DirectCast(oDataRow("sCity"), System.String)
                txtBranchName.Text = DirectCast(oDataRow("sBranchName"), System.String)
                txtState.Text = DirectCast(oDataRow("sState"), System.String)
                txtPhone.Text = DirectCast(oDataRow("sPhone"), System.String)
                txtManagerName.Text = DirectCast(oDataRow("sManagerName"), System.String)
                txtManagerMobile.Text = DirectCast(oDataRow("sManagerMobile"), System.String)
                txtAddress.Text = DirectCast(oDataRow("sAddress"), System.String)
                txtZIP.Text = DirectCast(oDataRow("sZIP"), System.String)
            ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_NONE Then
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(0).Rows.Find(mp_sRowID)
                txtCity.Text = DirectCast(oDataRow("sCity"), System.String)
                txtBranchName.Text = DirectCast(oDataRow("sBranchName"), System.String)
                txtState.Text = DirectCast(oDataRow("sState"), System.String)
                txtPhone.Text = DirectCast(oDataRow("sPhone"), System.String)
                txtManagerName.Text = DirectCast(oDataRow("sManagerName"), System.String)
                txtManagerMobile.Text = DirectCast(oDataRow("sManagerMobile"), System.String)
                txtAddress.Text = DirectCast(oDataRow("sAddress"), System.String)
                txtZIP.Text = DirectCast(oDataRow("sZIP"), System.String)
            End If
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim oRow As clsRow = Nothing
        Dim oDataRow As DataRow = Nothing
        If mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            Dim oDB As clsDB = Nothing
            oDB = New clsDB()
            oDB.AddParameter("lDepth", 0, clsDB.ParamType.PT_NUMERIC)
            oDB.AddParameter("sCity", txtCity.Text, clsDB.ParamType.PT_STRING)
            oDB.AddParameter("sBranchName", txtBranchName.Text, clsDB.ParamType.PT_STRING)
            oDB.AddParameter("sState", txtState.Text, clsDB.ParamType.PT_STRING)
            oDB.AddParameter("sPhone", txtPhone.Text, clsDB.ParamType.PT_STRING)
            oDB.AddParameter("sManagerName", txtManagerName.Text, clsDB.ParamType.PT_STRING)
            oDB.AddParameter("sManagerMobile", txtManagerMobile.Text, clsDB.ParamType.PT_STRING)
            oDB.AddParameter("sAddress", txtAddress.Text, clsDB.ParamType.PT_STRING)
            oDB.AddParameter("sZIP", txtZIP.Text, clsDB.ParamType.PT_STRING)
            If mp_yDialogMode = PRG_DIALOGMODE.DM_ADD Then
                oDB.AddParameter("lOrder", mp_oParent.ActiveGanttVBNCtl1.Rows.Count() + 1, clsDB.ParamType.PT_NUMERIC)
                mp_sRowID = "K" & oDB.ExecuteInsert("tb_CR_Rows")
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Add(mp_sRowID)
                oRow.Node.Depth = 0
                mp_oParent.ActiveGanttVBNCtl1.Rows.UpdateTree()
            Else
                oDB.ExecuteUpdate("tb_CR_Rows", "lRowID = " & mp_sRowID)
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Item("K" & mp_sRowID)
            End If
        ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
            If mp_yDialogMode = PRG_DIALOGMODE.DM_ADD Then
                Dim lRowID As Integer = 0
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(1).NewRow()
                lRowID = g_DST_XML_AutoIncrementValue(mp_oParent.mp_otb_CR_Rows, "lRowID")
                oDataRow("lRowID") = lRowID
                mp_sRowID = "K" & lRowID.ToString()
                oDataRow("lOrder") = mp_oParent.ActiveGanttVBNCtl1.Rows.Count() + 1
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Add(mp_sRowID)
                oRow.Node.Depth = 0
                mp_oParent.ActiveGanttVBNCtl1.Rows.UpdateTree()
                mp_oParent.mp_otb_CR_Rows.Tables(1).Rows.Add(oDataRow)
            Else
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(1).Rows.Find(mp_sRowID)
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Item("K" & mp_sRowID)
            End If
            oDataRow("lDepth") = 0
            oDataRow("sCity") = txtCity.Text
            oDataRow("sBranchName") = txtBranchName.Text
            oDataRow("sState") = txtState.Text
            oDataRow("sPhone") = txtPhone.Text
            oDataRow("sManagerName") = txtManagerName.Text
            oDataRow("sManagerMobile") = txtManagerMobile.Text
            oDataRow("sAddress") = txtAddress.Text
            oDataRow("sZIP") = txtZIP.Text
            mp_oParent.mp_otb_CR_Rows.WriteXml(g_GetAppLocation() & "\CR_XML\tb_CR_Rows.xml")
        ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_NONE Then
            If mp_yDialogMode = PRG_DIALOGMODE.DM_ADD Then
                Dim lRowID As Integer = 0
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(0).NewRow()
                lRowID = g_DST_NONE_AutoIncrementValue(mp_oParent.mp_otb_CR_Rows, "lRowID")
                oDataRow("lRowID") = lRowID
                mp_sRowID = "K" & lRowID.ToString()
                oDataRow("lOrder") = mp_oParent.ActiveGanttVBNCtl1.Rows.Count() + 1
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Add(mp_sRowID)
                oRow.Node.Depth = 0
                mp_oParent.ActiveGanttVBNCtl1.Rows.UpdateTree()
                mp_oParent.mp_otb_CR_Rows.Tables(0).Rows.Add(oDataRow)
            Else
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(0).Rows.Find(mp_sRowID)
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Item("K" & mp_sRowID)
            End If
            oDataRow("lDepth") = 0
            oDataRow("sCity") = txtCity.Text
            oDataRow("sBranchName") = txtBranchName.Text
            oDataRow("sState") = txtState.Text
            oDataRow("sPhone") = txtPhone.Text
            oDataRow("sManagerName") = txtManagerName.Text
            oDataRow("sManagerMobile") = txtManagerMobile.Text
            oDataRow("sAddress") = txtAddress.Text
            oDataRow("sZIP") = txtZIP.Text
        End If
        oRow.Text = txtBranchName.Text & ", " & txtState.Text & vbCrLf & "Phone: " & txtPhone.Text
        oRow.MergeCells = True
        oRow.Container = False
        oRow.StyleIndex = "Branch"
        oRow.ClientAreaStyleIndex = "BranchCA"
        oRow.UseNodeImages = True
        oRow.Node.ExpandedImage = Image.FromFile(g_GetAppLocation() & "\CarRental\minus.jpg")
        oRow.Node.Image = Image.FromFile(g_GetAppLocation() & "\CarRental\plus.jpg")
        oRow.AllowMove = False
        oRow.AllowSize = False
        If mp_yDialogMode = PRG_DIALOGMODE.DM_ADD Then
            Dim l As Integer
            l = System.Math.Floor(mp_oParent.ActiveGanttVBNCtl1.CurrentViewObject.ClientArea.Height / 41)
            If ((mp_oParent.ActiveGanttVBNCtl1.Rows.Count - l + 2) > 0) Then
                mp_oParent.ActiveGanttVBNCtl1.VerticalScrollBar.Value = (mp_oParent.ActiveGanttVBNCtl1.Rows.Count - l + 2)
            End If
        End If
        mp_oParent.ActiveGanttVBNCtl1.Redraw()
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub


End Class