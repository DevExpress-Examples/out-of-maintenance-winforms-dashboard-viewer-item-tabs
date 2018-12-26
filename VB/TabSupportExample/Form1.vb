Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWin
Imports DevExpress.XtraEditors
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace TabSupportExample
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Private tabTimer As New Timer()
        Private timedTabContainerName As String
        Public Sub New()
            InitializeComponent()
            AddHandler dashboardViewer1.CustomizeDashboardItemCaption, AddressOf DashboardViewer1_CustomizeDashboardItemCaption
            dashboardViewer1.Dashboard = CreateSimpleDashboard()
        End Sub

        Private Sub btnCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreate.Click
            Dim dashboard As New Dashboard()
            Dim dataSource As New DashboardObjectDataSource(DataGenerator.GenerateTestData())
            dashboard.DataSources.Add(dataSource)

            dashboard.Items.Add(DashboardItemGenerator.GenerateCardItem(dataSource, "card1"))
            dashboard.Items.Add(DashboardItemGenerator.GenerateGridItem(dataSource, "grid1"))
            dashboard.Items.Add(DashboardItemGenerator.GeneratePieItem(dataSource, "pie1"))
            dashboard.Items.Add(DashboardItemGenerator.GenerateListBoxItem(dataSource, "list1"))

            Dim tabContainer As New TabContainerDashboardItem()
            tabContainer.ComponentName = "tabContainer1"
            tabContainer.TabPages.Add(New DashboardTabPage() With { _
                .Name = "Tab Page One", _
                .ComponentName = "page1" _
            })
            tabContainer.TabPages("page1").AddRange(dashboard.Items("grid1"), dashboard.Items("pie1"))

            Dim secondTabPage As DashboardTabPage = tabContainer.CreateTabPage()
            secondTabPage.Name = "Tab Page Two"
            secondTabPage.Add(dashboard.Items("list1"))
            secondTabPage.ShowItemAsTabPage = True

            dashboard.Items.Add(tabContainer)

            dashboard.RebuildLayout()
            ' Adjust the dashboard layout.
            dashboard.LayoutRoot.FindRecursive(dashboard.Items("grid1")).Weight = 40
            dashboard.LayoutRoot.FindRecursive(dashboard.Items("pie1")).Weight = 60
            Dim rootGroup As DashboardLayoutGroup = TryCast(dashboard.LayoutRoot.ChildNodes(0), DashboardLayoutGroup)
            rootGroup.Orientation = DashboardLayoutGroupOrientation.Horizontal

            dashboardViewer1.Dashboard = dashboard

            btnModify.Enabled = True
            toggleSwitchTimer.Enabled = True
        End Sub

        Private Sub btnModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModify.Click
            Dim dashboard As Dashboard = dashboardViewer1.Dashboard

            ' Move the card1 item to a tab page containing the list1 item.
            dashboard.Items("card1").ParentContainer = dashboard.Items("list1").ParentContainer
            ' Reorder tab pages.
            Dim tabContainer As TabContainerDashboardItem = TryCast(dashboard.Items("tabContainer1"), TabContainerDashboardItem)
            Dim tabPage As DashboardTabPage = tabContainer.TabPages(0)
            tabContainer.TabPages.Remove(tabPage)
            tabContainer.TabPages.Insert(1, tabPage)

            dashboard.Items.ForEach(Sub(item As DashboardItem)
                If TypeOf item Is PieDashboardItem Then
                    CType(item, PieDashboardItem).PieType = PieType.Donut
                End If
            End Sub)
        End Sub


        Private Sub TabTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
            If timedTabContainerName IsNot Nothing Then
                Dim selectedIndex As Integer = dashboardViewer1.GetSelectedTabPageIndex(timedTabContainerName)
                Dim pageCount As Integer = CType(dashboardViewer1.Dashboard.Items(timedTabContainerName), TabContainerDashboardItem).TabPages.Count
                selectedIndex += 1
                dashboardViewer1.SetSelectedTabPage(timedTabContainerName, selectedIndex Mod pageCount)
            End If
        End Sub

        Private Sub toggleSwitchTimer_Toggled(ByVal sender As Object, ByVal e As EventArgs) Handles toggleSwitchTimer.Toggled
            If DirectCast(sender, ToggleSwitch).IsOn Then
                timedTabContainerName = dashboardViewer1.Dashboard.Items.FindFirst(Function(x) TypeOf x Is TabContainerDashboardItem).ComponentName
                tabTimer.Interval = 2000
                AddHandler tabTimer.Tick, AddressOf TabTimer_Tick
                tabTimer.Start()
            Else
                tabTimer.Stop()
            End If
        End Sub

        Private Function CreateSimpleDashboard() As Dashboard
            Dim dashboard As New Dashboard()
            Dim dataSource As New DashboardObjectDataSource(DataGenerator.GenerateTestData())
            dashboard.DataSources.Add(dataSource)

            Dim gridItem As New GridDashboardItem() With {.ComponentName = "grid1"}
            gridItem.DataSource = dataSource
            gridItem.Columns.Add(New GridDimensionColumn(New Dimension("Country")))
            gridItem.Columns.Add(New GridMeasureColumn(New Measure("Sales")))

            Dim pieItem As New PieDashboardItem() With {.ComponentName = "pie1"}
            pieItem.DataSource = dataSource
            pieItem.Values.Add(New Measure("Sales"))
            pieItem.Arguments.Add(New Dimension("Country"))

            dashboard.Items.AddRange(gridItem, pieItem)
            Return dashboard
        End Function

        Private Sub DashboardViewer1_CustomizeDashboardItemCaption(ByVal sender As Object, ByVal e As CustomizeDashboardItemCaptionEventArgs)
            Dim dashboard As Dashboard = DirectCast(sender, DashboardViewer).Dashboard

            e.Items.Add(New DashboardToolbarItem(String.Empty, New Action(Of DashboardToolbarItemClickEventArgs)(Sub(args)
                MessageBox.Show(e.DashboardItemName, "Dashboard Item Component Name")
                DirectCast(sender, DashboardViewer).SaveDashboardLayout("test_dashboard_layout.xml")
            End Sub)) With {.ButtonImage = Image.FromFile("Support_16x16.png")})
        End Sub


    End Class
End Namespace
