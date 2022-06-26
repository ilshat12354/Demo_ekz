using System;
using System.Windows;

namespace demo
{
    /// <summary>
    /// Логика взаимодействия для BuyerForm.xaml
    /// </summary>
    public partial class BuyerForm : Window
    {
        public BuyerForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DEMOekzEntities demka = new DEMOekzEntities())
            {
                foreach (client cl in demka.client)
                {
                    if (cl.fio.Trim().Contains(srnm.Text.Trim()))
                    {
                        res.Content = (cl.client_id).ToString();
                        break;
                    }
                    else
                    {
                        res.Content = "Результат: ";
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddClient add = new AddClient("buyer");
            this.Hide();
            add.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            order ord = new order();

            ord.order_id = DateTime.Now.Second * 1000;
            ord.create_data = DateTime.Now;
            ord.create_time = DateTime.Now.TimeOfDay;
            ord.client_id = Int32.Parse(clid.Text);
            ord.offers = offs.Text;
            ord.status = "В прокате";
            ord.offer_time = Int32.Parse(tm.Text);

            using (DEMOekzEntities demka = new DEMOekzEntities())
            {
                demka.order.Add(ord);
                demka.SaveChanges();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }
    }
}
