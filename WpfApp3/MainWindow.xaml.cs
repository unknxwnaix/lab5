using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.sales_dbDataSetTableAdapters;
namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        user_infoTableAdapter user = new user_infoTableAdapter();
        employeesTableAdapter employee = new employeesTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text != null && tb.Text != "" && pb.Password != "" && pb.Password != null)
            {
                bool IsAuth = false;
                var allLogins = user.GetData().Rows;
                for (int i = 0; i < allLogins.Count; i++)
                {
                    if (allLogins[i][2].ToString() == tb.Text && allLogins[i][3].ToString() == pb.Password) 
                    {
                        IsAuth = true;
                        string role = allLogins[i][4].ToString();
                        MessageBox.Show(role);
                        switch (role)
                        {
                            case "admin":
                                admin admin = new admin();
                                admin.Show();
                                break;
                            case "manager":
                                user user = new user();
                                user.Show();
                                break;
                            case "storekeeper":
                                storekeeper storekeeper = new storekeeper();
                                storekeeper.Show();
                                break;
                            case "cashier":
                                сashier cashier = new сashier();
                                cashier.Show();
                                break;
                        }
                        Close();
                    }
                }
                if (!IsAuth) 
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            else
            {
                MessageBox.Show("Ошибка авторизации");
            }
        }
    }
}
