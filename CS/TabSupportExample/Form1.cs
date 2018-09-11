using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using System;
using System.Windows.Forms;

namespace TabSupportExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dashboardViewer1.Dashboard = CreateSimpleDashboard();
        }

        private Dashboard CreateSimpleDashboard()
        {
            Dashboard dashboard = new Dashboard();
            DashboardObjectDataSource dataSource = new DashboardObjectDataSource(DataGenerator.GenerateTestData());
            dashboard.DataSources.Add(dataSource);

            GridDashboardItem gridItem = new GridDashboardItem() { ComponentName = "grid1" };
            gridItem.DataSource = dataSource;
            gridItem.Columns.Add(new GridDimensionColumn(new Dimension("Country")));
            gridItem.Columns.Add(new GridMeasureColumn(new Measure("Sales")));

            PieDashboardItem pieItem = new PieDashboardItem() { ComponentName = "pie1" };
            pieItem.DataSource = dataSource;
            pieItem.Values.Add(new Measure("Sales"));
            pieItem.Arguments.Add(new Dimension("Country"));

            dashboard.Items.AddRange(gridItem, pieItem);

            dashboard.SaveToXml("test_dashboard.xml");
            return dashboard;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            DashboardObjectDataSource dataSource = new DashboardObjectDataSource(DataGenerator.GenerateTestData());
            dashboard.DataSources.Add(dataSource);

            dashboard.Items.Add(DashboardItemGenerator.GenerateCardItem(dataSource, "card1"));
            dashboard.Items.Add(DashboardItemGenerator.GenerateGridItem(dataSource, "grid1"));
            dashboard.Items.Add(DashboardItemGenerator.GeneratePieItem(dataSource, "pie1"));
            dashboard.Items.Add(DashboardItemGenerator.GenerateListBoxItem(dataSource, "list1"));

            TabContainerDashboardItem tabContainer = new TabContainerDashboardItem();
            tabContainer.TabPages.Add(new DashboardTabPage() { Name = "Tab Page One", ComponentName = "page1" });
            tabContainer.TabPages["page1"].AddRange(dashboard.Items["grid1"], dashboard.Items["pie1"]);

            DashboardTabPage secondTabPage = tabContainer.CreateTabPage();
            secondTabPage.Name = "Tab Page Two";
            secondTabPage.Add(dashboard.Items["list1"]);
            secondTabPage.ShowItemAsTabPage = true;

            dashboard.Items.Add(tabContainer);

            dashboardViewer1.Dashboard = dashboard;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = dashboardViewer1.Dashboard;

            dashboard.Items["card1"].ParentContainer = dashboard.Items["list1"].ParentContainer;

            dashboard.Items.ForEach(delegate (DashboardItem item)
            {
                if (item is PieDashboardItem)
                {
                    ((PieDashboardItem)item).PieType = PieType.Donut;
                }
            });

        }
    }
}
