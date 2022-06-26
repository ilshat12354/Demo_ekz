using System;
using System.Windows;

namespace demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string worker_login = login.Text;
            string worker_password = password.Text;
            bool entered = false;
            worker wr = null;

            using (DEMOekzEntities demo = new DEMOekzEntities())
            {
                foreach (worker wrkr in demo.worker)
                {
                    if (wrkr.login.Trim().Equals(worker_login.Trim()) && wrkr.password.Trim().Equals(worker_password.Trim()))
                    {
                        wr = wrkr;

                        entered = true;
                        break;
                    }
                }

                if (!entered)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else
                {
                    sys_enter enter = new sys_enter();
                    enter.position = wr.position;
                    enter.fullname = wr.firstname.Trim() + " " + wr.secondname.Trim() + " " + wr.lastname.Trim();
                    enter.login = wr.login;
                    enter.password = wr.password;
                    enter.last_enter = DateTime.Now;
                    enter.result = "Успешно";

                    demo.sys_enter.Add(enter);
                    demo.SaveChanges();

                    if (wr.position.Trim().Equals("Продавец"))
                    {
                        BuyerForm buyerForm = new BuyerForm();
                        this.Hide();
                        buyerForm.Show();
                    }
                    else if (wr.position.Trim().Equals("Администратор"))
                    {
                        AdministratorForm administratorForm = new AdministratorForm();
                        this.Hide();
                        administratorForm.Show();
                    }
                    else
                    {
                        HigherSessionForm higherSessionForm = new HigherSessionForm();
                        this.Hide();
                        higherSessionForm.Show();
                    }
                }
            }
        }
    }
}
