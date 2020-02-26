using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppForBuildCordova
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeWindow();
        }

        void InitializeWindow()
        {
            comboBoxAppList.Items.AddRange(Data.instance.GetProjectsString());
            comboBoxAppList.SelectedIndex = 0;
        }

        void RefreshInfoBox()
        {
            App app = Data.instance.GetApp();
            label_info.Text = "" +
                "Путь: " + app.project.path + "\n" +
                "Байер: " + app.buyer.name + "\n" +
                //"short: " + app. + "\n" +
                "Название: " + app.name + "\n" +
                "package_name: " + app.package_name + "\n" +
                "version_code: " + app.version_code + "\n" +
                "version: " + app.version + "\n" +
                "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ComboBoxAppList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.instance.SetProject(comboBoxAppList.SelectedIndex);
            comboBoxBuyerList.Items.Clear();
            comboBoxAppName.Items.Clear();
            comboBoxBuyerList.Items.AddRange(Data.instance.GetBuyersString());
        }

        private void ComboBoxBuyerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.instance.SetBuyer(comboBoxBuyerList.SelectedIndex);
            comboBoxAppName.Items.Clear();
            comboBoxAppName.Items.AddRange(Data.instance.GetAppsString());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AppConfig config = new AppConfig();
            if (config.ChangeConfigFile())
            {
                CommandControl terminal = new CommandControl();
                terminal.BuildApk(Done);
            }
        }

        //void Done(object sender, EventArgs e)
        void Done()
        {
            MessageBox.Show("Done");
        }

        private void ComboBoxAppName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.instance.SetApp(comboBoxAppName.SelectedIndex);
            RefreshInfoBox();
        }
    }
}
