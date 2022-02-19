Option Explicit On

Imports AGVBN
Imports System.Data.OleDb

Partial Public Class fCarRentalVehicle
    Inherits System.Windows.Forms.Form

    Private mp_yDialogMode As PRG_DIALOGMODE
    Private mp_oParent As fCarRental
    Private mp_sRowID As String
    '// XML
    Private mp_otb_CR_ACRISS_Codes1 As DataTable
    Private mp_otb_CR_ACRISS_Codes2 As DataTable
    Private mp_otb_CR_ACRISS_Codes3 As DataTable
    Private mp_otb_CR_ACRISS_Codes4 As DataTable

    Friend Sub New(ByVal yDialogMode As PRG_DIALOGMODE, ByRef oParent As fCarRental, ByVal sRowID As String)
        MyBase.New()
        InitializeComponent()
        mp_yDialogMode = yDialogMode
        mp_oParent = oParent
        mp_sRowID = sRowID
    End Sub

    Private Sub fCarRentalVehicle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = CType(((Owner.Width - Me.Width) / 2) + Owner.Left, System.Int32)
        Me.Top = CType(((Owner.Height - Me.Height) / 2) + Owner.Top, System.Int32)
        If mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            g_DST_ACCESS_FillComboBox(drpCarTypeID, "SELECT * FROM tb_CR_Car_Types", "lCarTypeID", "sDescription")
            g_DST_ACCESS_FillComboBox(drpACRISS1, "SELECT * FROM tb_CR_ACRISS_Codes WHERE [Position] = 1", "Letter", "Description")
            g_DST_ACCESS_FillComboBox(drpACRISS2, "SELECT * FROM tb_CR_ACRISS_Codes WHERE [Position] = 2", "Letter", "Description")
            g_DST_ACCESS_FillComboBox(drpACRISS3, "SELECT * FROM tb_CR_ACRISS_Codes WHERE [Position] = 3", "Letter", "Description")
            g_DST_ACCESS_FillComboBox(drpACRISS4, "SELECT * FROM tb_CR_ACRISS_Codes WHERE [Position] = 4", "Letter", "Description")
        ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
            g_DST_XML_FillComboBox(drpCarTypeID, mp_oParent.mp_otb_CR_Car_Types.Tables(1), "lCarTypeID", "sDescription")
            mp_otb_CR_ACRISS_Codes1 = mp_oParent.mp_otb_CR_ACRISS_Codes.Tables(1).Copy
            mp_otb_CR_ACRISS_Codes2 = mp_oParent.mp_otb_CR_ACRISS_Codes.Tables(1).Copy
            mp_otb_CR_ACRISS_Codes3 = mp_oParent.mp_otb_CR_ACRISS_Codes.Tables(1).Copy
            mp_otb_CR_ACRISS_Codes4 = mp_oParent.mp_otb_CR_ACRISS_Codes.Tables(1).Copy
            g_DST_XML_FillComboBox(drpACRISS1, mp_otb_CR_ACRISS_Codes1, "Letter", "Description", "Position = 1")
            g_DST_XML_FillComboBox(drpACRISS2, mp_otb_CR_ACRISS_Codes2, "Letter", "Description", "Position = 2")
            g_DST_XML_FillComboBox(drpACRISS3, mp_otb_CR_ACRISS_Codes3, "Letter", "Description", "Position = 3")
            g_DST_XML_FillComboBox(drpACRISS4, mp_otb_CR_ACRISS_Codes4, "Letter", "Description", "Position = 4")
        ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_NONE Then
            g_DST_NONE_FillComboBox(drpCarTypeID, mp_oParent.mp_otb_CR_Car_Types.Tables(0), "lCarTypeID", "sDescription")
            mp_otb_CR_ACRISS_Codes1 = mp_oParent.mp_otb_CR_ACRISS_Codes.Tables(0).Copy
            mp_otb_CR_ACRISS_Codes2 = mp_oParent.mp_otb_CR_ACRISS_Codes.Tables(0).Copy
            mp_otb_CR_ACRISS_Codes3 = mp_oParent.mp_otb_CR_ACRISS_Codes.Tables(0).Copy
            mp_otb_CR_ACRISS_Codes4 = mp_oParent.mp_otb_CR_ACRISS_Codes.Tables(0).Copy
            g_DST_NONE_FillComboBox(drpACRISS1, mp_otb_CR_ACRISS_Codes1, "Letter", "Description", "Position = 1")
            g_DST_NONE_FillComboBox(drpACRISS2, mp_otb_CR_ACRISS_Codes2, "Letter", "Description", "Position = 2")
            g_DST_NONE_FillComboBox(drpACRISS3, mp_otb_CR_ACRISS_Codes3, "Letter", "Description", "Position = 3")
            g_DST_NONE_FillComboBox(drpACRISS4, mp_otb_CR_ACRISS_Codes4, "Letter", "Description", "Position = 4")
        End If
        If mp_yDialogMode = PRG_DIALOGMODE.DM_ADD Then
            Me.Text = "Add New Vehicle"
            txtLicensePlates.Text = g_GenerateRandomLicense()
            drpCarTypeID.SelectedIndex = GetRnd(1, 48)
        Else
            Dim oDataRow As DataRow = Nothing
            Me.Text = "Edit Vehicle"

            Dim sACRISSCode As String = ""

            If mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
                Dim oDB As clsDB = Nothing
                oDB = New clsDB()
                oDB.InitReader("SELECT * FROM tb_CR_Rows WHERE lRowID = " & mp_sRowID)
                oDB.Read(txtLicensePlates.Text, "sLicensePlates")
                oDB.Read(drpCarTypeID, "lCarTypeID")
                oDB.Read(txtNotes, "sNotes")
                oDB.Read(txtRate, "cRate")
                sACRISSCode = oDB.Read("sACRISSCode")
                oDB.CloseReader()
            ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_XML Then
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(1).Rows.Find(mp_sRowID)
                txtLicensePlates.Text = DirectCast(oDataRow("sLicensePlates"), System.String)
                drpCarTypeID.SelectedValue = oDataRow("lCarTypeID")
                txtNotes.Text = DirectCast(oDataRow("sNotes"), System.String)
                txtRate.Text = CType(oDataRow("cRate"), System.String)
                sACRISSCode = DirectCast(oDataRow("sACRISSCode"), System.String)
            ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_NONE Then
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(0).Rows.Find(mp_sRowID)
                txtLicensePlates.Text = DirectCast(oDataRow("sLicensePlates"), System.String)
                drpCarTypeID.SelectedValue = oDataRow("lCarTypeID")
                txtNotes.Text = DirectCast(oDataRow("sNotes"), System.String)
                txtRate.Text = CType(oDataRow("cRate"), System.String)
                sACRISSCode = DirectCast(oDataRow("sACRISSCode"), System.String)
            End If
            UpdatePicture()
            UpdateACRISSCode(sACRISSCode)
        End If
    End Sub

    Private Sub UpdateACRISSCode(ByVal sACRISSCode As String)
        drpACRISS1.SelectedValue = sACRISSCode.Substring(0, 1)
        drpACRISS2.SelectedValue = sACRISSCode.Substring(1, 1)
        drpACRISS3.SelectedValue = sACRISSCode.Substring(2, 1)
        drpACRISS4.SelectedValue = sACRISSCode.Substring(3, 1)
        lblACRISS1.Text = sACRISSCode.Substring(0, 1)
        lblACRISS2.Text = sACRISSCode.Substring(1, 1)
        lblACRISS3.Text = sACRISSCode.Substring(2, 1)
        lblACRISS4.Text = sACRISSCode.Substring(3, 1)
    End Sub

    Private Sub UpdatePicture()
        If g_GetComboBoxSelectedItem(drpCarTypeID, "sDescription") = "" Then
            Return
        End If
        picMake.Image = Image.FromFile(g_GetAppLocation() & "\CarRental\Big\" & g_GetComboBoxSelectedItem(drpCarTypeID, "sDescription") & ".jpg")
    End Sub

    Private Sub drpCarTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCarTypeID.SelectedValueChanged
        Dim sACRISSCode As String = ""
        UpdatePicture()
        sACRISSCode = g_GetComboBoxSelectedItem(drpCarTypeID, "sACRISSCode")
        UpdateACRISSCode(sACRISSCode)
        txtRate.Text = g_GetComboBoxSelectedItem(drpCarTypeID, "cStdRate")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim oRow As AGVBN.clsRow = Nothing
        Dim oDataRow As DataRow = Nothing
        If mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_ACCESS Then
            Dim oDB As clsDB = Nothing
            oDB = New clsDB()
            oDB.AddParameter("lDepth", 1, clsDB.ParamType.PT_NUMERIC)
            oDB.AddParameter("sLicensePlates", txtLicensePlates.Text, clsDB.ParamType.PT_STRING)
            oDB.AddParameter("lCarTypeID", g_GetComboBoxSelectedItem(drpCarTypeID, "lCarTypeID"), clsDB.ParamType.PT_NUMERIC)
            oDB.AddParameter("sNotes", txtNotes.Text, clsDB.ParamType.PT_STRING)
            oDB.AddParameter("cRate", txtRate.Text, clsDB.ParamType.PT_NUMERIC)
            oDB.AddParameter("sACRISSCode", lblACRISS1.Text & lblACRISS2.Text & lblACRISS3.Text & lblACRISS4.Text, clsDB.ParamType.PT_STRING)
            If mp_yDialogMode = PRG_DIALOGMODE.DM_ADD Then
                oDB.AddParameter("lOrder", mp_oParent.ActiveGanttVBNCtl1.Rows.Count() + 1, clsDB.ParamType.PT_NUMERIC)
                mp_sRowID = "K" & oDB.ExecuteInsert("tb_CR_Rows")
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Add(mp_sRowID)
                oRow.Node.Depth = 1
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
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Add(mp_sRowID)
                oRow.Node.Depth = 1
                mp_oParent.ActiveGanttVBNCtl1.Rows.UpdateTree()
                mp_oParent.mp_otb_CR_Rows.Tables(1).Rows.Add(oDataRow)
            Else
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(1).Rows.Find(mp_sRowID)
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Item("K" & mp_sRowID)
            End If
            oDataRow("lDepth") = 1
            oDataRow("sLicensePlates") = txtLicensePlates.Text
            oDataRow("lCarTypeID") = g_GetComboBoxSelectedItem(drpCarTypeID, "lCarTypeID")
            oDataRow("sNotes") = txtNotes.Text
            oDataRow("cRate") = txtRate.Text
            oDataRow("sACRISSCode") = lblACRISS1.Text & lblACRISS2.Text & lblACRISS3.Text & lblACRISS4.Text
            mp_oParent.mp_otb_CR_Rows.WriteXml(g_GetAppLocation() & "\CR_XML\tb_CR_Rows.xml")
        ElseIf mp_oParent.mp_yDataSourceType = E_DATASOURCETYPE.DST_NONE Then
            If mp_yDialogMode = PRG_DIALOGMODE.DM_ADD Then
                Dim lRowID As Integer = 0
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(0).NewRow()
                lRowID = g_DST_NONE_AutoIncrementValue(mp_oParent.mp_otb_CR_Rows, "lRowID")
                oDataRow("lRowID") = lRowID
                mp_sRowID = "K" & lRowID.ToString()
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Add(mp_sRowID)
                oRow.Node.Depth = 1
                mp_oParent.ActiveGanttVBNCtl1.Rows.UpdateTree()
                mp_oParent.mp_otb_CR_Rows.Tables(0).Rows.Add(oDataRow)
            Else
                oDataRow = mp_oParent.mp_otb_CR_Rows.Tables(0).Rows.Find(mp_sRowID)
                oRow = mp_oParent.ActiveGanttVBNCtl1.Rows.Item("K" & mp_sRowID)
            End If
            oDataRow("lDepth") = 1
            oDataRow("sLicensePlates") = txtLicensePlates.Text
            oDataRow("lCarTypeID") = g_GetComboBoxSelectedItem(drpCarTypeID, "lCarTypeID")
            oDataRow("sNotes") = txtNotes.Text
            oDataRow("cRate") = txtRate.Text
            oDataRow("sACRISSCode") = lblACRISS1.Text & lblACRISS2.Text & lblACRISS3.Text & lblACRISS4.Text
        End If

        oRow.Cells.Item("1").Text = txtLicensePlates.Text
        oRow.Cells.Item("2").Image = Image.FromFile(g_GetAppLocation() & "\CarRental\Small\" & g_GetComboBoxSelectedItem(drpCarTypeID, "sDescription") & ".jpg")
        oRow.Cells.Item("3").Text = g_GetComboBoxSelectedItem(drpCarTypeID, "sDescription") & vbCrLf & lblACRISS1.Text & lblACRISS2.Text & lblACRISS3.Text & lblACRISS4.Text & " - " & txtRate.Text & " USD"
        oRow.Tag = lblACRISS1.Text & lblACRISS2.Text & lblACRISS3.Text & lblACRISS4.Text & "|" & txtRate.Text & "|" & g_GetComboBoxSelectedItem(drpCarTypeID, "lCarTypeID")
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

    Private Sub drpACRISS1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpACRISS1.SelectedValueChanged
        lblACRISS1.Text = g_GetComboBoxSelectedItem(drpACRISS1, "Letter")
    End Sub

    Private Sub drpACRISS2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpACRISS2.SelectedValueChanged
        lblACRISS2.Text = g_GetComboBoxSelectedItem(drpACRISS2, "Letter")
    End Sub

    Private Sub drpACRISS3_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpACRISS3.SelectedValueChanged
        lblACRISS3.Text = g_GetComboBoxSelectedItem(drpACRISS3, "Letter")
    End Sub

    Private Sub drpACRISS4_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpACRISS4.SelectedValueChanged
        lblACRISS4.Text = g_GetComboBoxSelectedItem(drpACRISS4, "Letter")
    End Sub


End Class