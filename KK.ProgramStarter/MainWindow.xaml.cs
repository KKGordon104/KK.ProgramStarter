using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace KK.ProgramStarter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Service.ProgramModel> pmList = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadApps();

        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstPrograms.SelectedValue == null) return;

                string selectedProgramm = lstPrograms.SelectedValue.ToString() ;

                foreach (Service.ProgramModel pm in pmList)
                {
                    if (selectedProgramm == pm.name)
                    {
                        Process.Start(pm.path);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void loadApps()
        {
            try
            {
                pmList = Service.Configuration.getProgramList();
                pmList.OrderBy(x => x.name);
                lstPrograms.Items.Clear();
                foreach (Service.ProgramModel pm in pmList)
                {
                    lstPrograms.Items.Add(pm.name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
