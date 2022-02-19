Option Explicit On
Option Strict On

Partial Public Class fMain
    Inherits System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        Me.Text = "The Source Code Store - ActiveGantt Schedule Control - Main Screen"
        lblCopyright.Text = "Copyright ©2002-" & DateTime.Now.Year.ToString() & " The Source Code Store LLC. All Rights Reserved. All trademarks are property of their legal owner."
        lblCopyright.BackColor = System.Drawing.ColorTranslator.FromOle(&H905100)
        lblCopyright.ForeColor = System.Drawing.Color.Beige
        TreeView1.ImageList = imgTreeView
        TreeView1.Font = New System.Drawing.Font("Tahoma", 9)

        AddTitleNode("AGEX", "ActiveGantt Examples:", 4, 5)

        AddNode("AGEX", "GanttCharts", "Gantt Charts:", 4, 5)

        AddNode("GanttCharts", "WBS", "Work Breakdown Structure (WBS) Project Management Examples:", 4, 5)
        AddNode("WBS", "WBSProject", "No data source (32bit and 64bit compatible)", 2, 2)
        AddNode("WBS", "WBSProjectXML", "XML data source (32bit and 64bit compatible)", 2, 2)
        AddNode("WBS", "WBSProjectAccess", "Microsoft Access data source (32bit compatible only)", 2, 2)

        AddNode("GanttCharts", "MSPI", "Microsoft Project Integration Examples (32bit and 64bit compatible):", 4, 5)
        AddNode("MSPI", "Project2003", "Demonstrates how ActiveGantt integrates with MS Project 2003 (using XML Files and the MSP2003 Integration Library)", 2, 2)
        AddNode("MSPI", "Project2007", "Demonstrates how ActiveGantt integrates with MS Project 2007 (using XML Files and the MSP2007 Integration Library)", 2, 2)
        AddNode("MSPI", "Project2010", "Demonstrates how ActiveGantt integrates with MS Project 2010 (using XML Files and the MSP2010 Integration Library)", 2, 2)

        AddNode("AGEX", "Schedules", "Schedules and Rosters:", 4, 5)

        AddNode("Schedules", "VRFC", "Vehicle Rental/Fleet Control Roster Examples:", 4, 5)
        AddNode("VRFC", "CarRental", "No data source (32bit and 64bit compatible)", 2, 2)
        AddNode("VRFC", "CarRentalXML", "XML data source (32bit and 64bit compatible)", 2, 2)
        AddNode("VRFC", "CarRentalAccess", "Microsoft Access data source (32bit compatible only)", 2, 2)

        AddNode("AGEX", "OTHER", "Other examples:", 4, 5)
        AddNode("OTHER", "FastLoad", "Fast Loading of Row and Task objects", 2, 2)
        AddNode("OTHER", "CustomDrawing", "Custom Drawing", 2, 2)
        AddNode("OTHER", "SortRows", "Sort Rows", 2, 2)
        AddNode("OTHER", "MillisecondInterval", "5 Millisecond Interval View", 2, 2)

        AddNode("OTHER", "TimeBlocks", "TimeBlocks and Duration Tasks:", 4, 5)
        AddNode("TimeBlocks", "RCT_DAY", "Daily Recurrent TimeBlocks", 2, 2)
        AddNode("TimeBlocks", "RCT_WEEK", "Weekly Recurrent TimeBlocks", 2, 2)
        AddNode("TimeBlocks", "RCT_MONTH", "Monthly Recurrent TimeBlocks", 2, 2)
        AddNode("TimeBlocks", "RCT_YEAR", "Yearly Recurrent TimeBlocks", 2, 2)
        AddNode("TimeBlocks", "DurationTasks", "Duration Tasks (can skip over non-working TimeBlock intervals)", 2, 2)

        AddTitleNode("HLP", "Help", 7, 7)
        AddNode("HLP", "GS_VBN", "How to create a simple Windows Forms application using the ActiveGanttVBN component", 3, 3)
        AddNode("HLP", "LocalDocumentation", "ActiveGanttVBN Local Documentation", 7, 7)
        AddNode("HLP", "OnlineDocumentation", "ActiveGanttVBN Online Documentation", 6, 6)
        AddNode("HLP", "BugReport", "Submit a Bug Report", 3, 3)
        AddNode("HLP", "Request", "Request Further Explanations, Code Samples and Submit Technical Queries", 6, 6)

        AddTitleNode("SCS", "The Source Code Store LLC - Website (http://www.sourcecodestore.com/)", 3, 3)
        AddNode("SCS", "OnlineStore", "Online Store - Purchase ActiveGantt Online", 3, 3)
        AddNode("SCS", "ContactUs", "Contact Us (use this form for non technical queries only)", 3, 3)

        TreeView1.ExpandAll()
        Dim oNode As TreeNode = FindTreeNode("OTHER", Nothing)
        oNode.Collapse()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Function FindTreeNode(ByVal sKey As String, ByRef oNodes As TreeNodeCollection) As TreeNode
        If oNodes Is Nothing Then
            oNodes = TreeView1.Nodes
        End If
        Dim oNode As TreeNode
        Dim oReturnNode As TreeNode = Nothing
        For Each oNode In oNodes
            If oNode.Name = sKey Then
                oReturnNode = oNode
                Return oReturnNode
            End If
            If oNode.Nodes.Count > 0 Then
                oReturnNode = FindTreeNode(sKey, oNode.Nodes)
                If Not oReturnNode Is Nothing Then
                    Return oReturnNode
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub AddTitleNode(ByVal sKey As String, ByVal sText As String, ByVal ImageIndex As Integer, ByVal SelectedImageIndex As Integer)
        Dim oNode As New System.Windows.Forms.TreeNode()
        oNode.Name = sKey
        oNode.Text = sText
        oNode.ImageIndex = ImageIndex
        oNode.SelectedImageIndex = SelectedImageIndex
        oNode.Tag = sKey
        TreeView1.Nodes.Add(oNode)
    End Sub

    Private Sub AddNode(ByVal sParentKey As String, ByVal sKey As String, ByVal sText As String, ByVal ImageIndex As Integer, ByVal SelectedImageIndex As Integer)
        Dim oNode As New System.Windows.Forms.TreeNode()
        Dim oParentNode As System.Windows.Forms.TreeNode()
        oNode.Name = sKey
        oNode.Text = sText
        oNode.ImageIndex = ImageIndex
        oNode.SelectedImageIndex = SelectedImageIndex
        oNode.Tag = sKey
        oParentNode = TreeView1.Nodes.Find(sParentKey, True)
        oParentNode(0).Nodes.Add(oNode)
    End Sub

    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick
        Dim sSelectedTag As String = TreeView1.SelectedNode.Tag.ToString()
        Select Case sSelectedTag
            Case "WBSProject"
                Dim oForm As New fWBSProject(E_DATASOURCETYPE.DST_NONE)
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "WBSProjectXML"
                Dim oForm As New fWBSProject(E_DATASOURCETYPE.DST_XML)
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "WBSProjectAccess"
                Dim oForm As New fWBSProject(E_DATASOURCETYPE.DST_ACCESS)
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "CarRental"
                Dim oForm As New fCarRental(E_DATASOURCETYPE.DST_NONE)
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "CarRentalXML"
                Dim oForm As New fCarRental(E_DATASOURCETYPE.DST_XML)
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "CarRentalAccess"
                Dim oForm As New fCarRental(E_DATASOURCETYPE.DST_ACCESS)
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "Project2003"
                Dim oForm As New fMSProject11()
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "Project2007"
                Dim oForm As New fMSProject12()
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "Project2010"
                Dim oForm As New fMSProject14()
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "FastLoad"
                Dim oForm As New fFastLoading
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "CustomDrawing"
                Dim oForm As New fCustomDrawing
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "SortRows"
                Dim oForm As New fSortRows
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "MillisecondInterval"
                Dim oForm As New fMillisecondInterval
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "DurationTasks"
                Dim oForm As New fDurationTasks
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "RCT_DAY"
                Dim oForm As New fRCT_DAY
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "RCT_WEEK"
                Dim oForm As New fRCT_WEEK
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "RCT_MONTH"
                Dim oForm As New fRCT_MONTH
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "RCT_YEAR"
                Dim oForm As New fRCT_YEAR
                Me.Cursor = Cursors.WaitCursor
                oForm.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            Case "SCS"
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start("http://www.sourcecodestore.com/")
                Me.Cursor = Cursors.Default
            Case "GS_VBN"
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start("http://www.sourcecodestore.com/Article.aspx?ID=11#Create")
                Me.Cursor = Cursors.Default
            Case "OnlineStore"
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start("http://www.sourcecodestore.com/OnlineStore/")
                Me.Cursor = Cursors.Default
            Case "OnlineDocumentation"
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start("http://www.sourcecodestore.com/Documentation/DOCFrameset.aspx?PN=AG&PL=VBN")
                Me.Cursor = Cursors.Default
            Case "LocalDocumentation"
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start(g_GetAppLocation() & "\AGVBN.chm")
                Me.Cursor = Cursors.Default
            Case "BugReport"
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start("http://www.sourcecodestore.com/Support/Report.aspx?T=1")
                Me.Cursor = Cursors.Default
            Case "Request"
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start("http://www.sourcecodestore.com/Support/Report.aspx?T=2")
                Me.Cursor = Cursors.Default
            Case "ContactUs"
                Me.Cursor = Cursors.WaitCursor
                System.Diagnostics.Process.Start("http://www.sourcecodestore.com/contactus.aspx")
                Me.Cursor = Cursors.Default
        End Select
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub
End Class




