using System;
using System.Windows;

namespace demo
{
    public partial class AddClient : Window
    {
        private string wo;

        public AddClient(string whereOpened)
        {
            InitializeComponent();
            wo = whereOpened;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client newClient = new client();
            newClient.fio = fio.Text;
            newClient.series = Int32.Parse(ser.Text);
            newClient.number = Int32.Parse(num.Text);
            newClient.address = addr.Text;
            newClient.birthday = calnd.SelectedDate.Value;
            newClient.email = eml.Text;
            newClient.password = pass.Text;

            using (DEMOekzEntities demka = new DEMOekzEntities())
            {
                demka.client.Add(newClient);
                demka.SaveChanges();
            }

            if (wo.Equals("buyer"))
            {
                BuyerForm buyer = new BuyerForm();
                this.Hide();
                buyer.Show();
            }
            else
            {
                MessageBox.Show("Pizdec");
            }

        }
    }
}
