using System.Collections.Generic;
using System.Windows;

namespace demo
{
    /// <summary>
    /// Логика взаимодействия для AdministratorForm.xaml
    /// </summary>
    public partial class AdministratorForm : Window
    {
        public AdministratorForm()
        {
            InitializeComponent();
            downloadAllEnters();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }

        private void downloadAllEnters()
        {
            List<sys_enter> entersList = new List<sys_enter>();

            using (DEMOekzEntities demka = new DEMOekzEntities())
            {
                foreach (sys_enter enter in demka.sys_enter)
                {
                    entersList.Add(enter);
                }
            }

            enters.ItemsSource = entersList;
        }
    }
}
