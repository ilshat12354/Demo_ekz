using System;
using System.Windows;

namespace demo
{
    /// <summary>
    /// Логика взаимодействия для HigherSessionForm.xaml
    /// </summary>
    public partial class HigherSessionForm : Window
    {
        public HigherSessionForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            order ord = new order();

            ord.order_id = DateTime.Now.Second * 1000;
            ord.create_data = DateTime.Now;
            ord.create_time = DateTime.Now.TimeOfDay;
            ord.client_id = Int32.Parse(clid.Text);
            ord.offers = offs.Text;
            ord.status = "В прокате";
            ord.offer_time = Int32.Parse(tm.Text);

            using (DEMOekzEntities demo = new DEMOekzEntities())
            {
                demo.order.Add(ord);
                demo.SaveChanges();
            }
        }
    }
}
