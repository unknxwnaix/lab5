using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3.sales_dbDataSetTableAdapters;
namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        roleTableAdapter role = new roleTableAdapter();
        employeesTableAdapter employees = new employeesTableAdapter();
        user_infoTableAdapter user = new user_infoTableAdapter();
        suppliersTableAdapter supplier = new suppliersTableAdapter();
        Regex Regexphone = new Regex(@"^((8 |\+7)[\- ] ?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
        Regex regexmail = new Regex(@"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$");
        Regex regexpassword = new Regex(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
        public admin()
        {
            InitializeComponent();
            FullUpdate();
        }
        public void FullUpdate()
        {
            dg_Role.ItemsSource = role.GetData();
            dg_Emloyee.ItemsSource = employees.GetData();
            dg_User.ItemsSource = user.GetData();
            cbx_User.ItemsSource = employees.GetData();
            cbx_User.DisplayMemberPath = "имя";
            cbx_User.SelectedValuePath = "айди";
            cbx_User3.ItemsSource = role.GetData();
            cbx_User3.DisplayMemberPath = "название";
            cbx_User3.SelectedValuePath = "айди";
            dg_Supplier.ItemsSource = supplier.GetData();
        }

        private void Button_Click_Create_Role(object sender, RoutedEventArgs e)
        {
            if (tb_Role.Text != null && tb_Role.Text != "")
            {
                role.InsertQueryRole(tb_Role.Text);
                dg_Role.ItemsSource = role.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_Role(object sender, RoutedEventArgs e)
        {
            if (dg_Role.SelectedValue != null)
            {
                var value = (dg_Role.SelectedValue as DataRowView).Row[0];
                role.DeleteQueryRole((int)value);
                dg_Role.ItemsSource = role.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_Role(object sender, RoutedEventArgs e)
        {
            if (tb_Role.Text != null && tb_Role.Text != "")
            {
                var value = (dg_Role.SelectedValue as DataRowView).Row[0];
                role.UpdateQueryRole(tb_Role.Text, (int)value);
                dg_Role.ItemsSource = role.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }
        private void dg_Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Role.SelectedValue != null)
                tb_Role.Text = (dg_Role.SelectedValue as DataRowView).Row[1].ToString();
        }

        private void Button_Click_Create_Emloyee(object sender, RoutedEventArgs e)
        {
            if (tb_Emloyee.Text != null && tb_Emloyee.Text != "" && tb_Emloyee1.Text != null && tb_Emloyee1.Text != "" && tb_Emloyee2.Text != null && tb_Emloyee2.Text != "" && tb_Emloyee3.Text != null && tb_Emloyee3.Text != "" && regexmail.IsMatch(tb_Emloyee1.Text) && Regexphone.IsMatch(tb_Emloyee2.Text))
            {
                employees.InsertQueryEmployee(tb_Emloyee.Text, tb_Emloyee1.Text, tb_Emloyee2.Text, tb_Emloyee3.Text);
                dg_Emloyee.ItemsSource = employees.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_Emloyee(object sender, RoutedEventArgs e)
        {
            if (dg_Emloyee.SelectedValue != null)
            {
                var value = (dg_Emloyee.SelectedValue as DataRowView).Row[0];
                employees.DeleteQueryEmployee((int)value);
                dg_Emloyee.ItemsSource = employees.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_Emloyee(object sender, RoutedEventArgs e)
        {
            if (tb_Emloyee.Text != null && tb_Emloyee.Text != "" && tb_Emloyee1.Text != null && tb_Emloyee1.Text != "" && tb_Emloyee2.Text != null && tb_Emloyee2.Text != "" && tb_Emloyee3.Text != null && tb_Emloyee3.Text != "" && dg_Emloyee.SelectedValue != null && regexmail.IsMatch(tb_Emloyee1.Text) && Regexphone.IsMatch(tb_Emloyee2.Text))
            {

                var value = (dg_Emloyee.SelectedValue as DataRowView).Row[0];
                employees.UpdateQueryEmployee(tb_Emloyee.Text, tb_Emloyee1.Text, tb_Emloyee2.Text, tb_Emloyee3.Text, (int)value);
                dg_Emloyee.ItemsSource = employees.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_Emloyee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Emloyee.SelectedValue != null)
            {
                tb_Emloyee.Text = (dg_Emloyee.SelectedValue as DataRowView).Row[1].ToString();
                tb_Emloyee1.Text = (dg_Emloyee.SelectedValue as DataRowView).Row[2].ToString();
                tb_Emloyee2.Text = (dg_Emloyee.SelectedValue as DataRowView).Row[3].ToString();
                tb_Emloyee3.Text = (dg_Emloyee.SelectedValue as DataRowView).Row[4].ToString();
            }
        }

        private void Button_Click_Create_User(object sender, RoutedEventArgs e)
        {
            if (cbx_User.Text != null && cbx_User.Text != "" && tb_User1.Text != null && tb_User1.Text != "" && tb_User2.Text != null && tb_User2.Text != "" && cbx_User3.Text != null && cbx_User3.Text != "" && regexpassword.IsMatch(tb_User2.Text))
            {
                int a = (int)cbx_User.SelectedValue;
                int b = (int)cbx_User3.SelectedValue;
                user.InsertQueryUser(a, tb_User1.Text, tb_User2.Text, b);
                dg_User.ItemsSource = user.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_User(object sender, RoutedEventArgs e)
        {
            if (dg_User.SelectedValue != null)
            {
                var value = (dg_User.SelectedValue as DataRowView).Row[0];
                user.DeleteQueryUser((int)value);
                dg_User.ItemsSource = user.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_User(object sender, RoutedEventArgs e)
        {
            if (cbx_User.Text != null && cbx_User.Text != "" && tb_User1.Text != null && tb_User1.Text != "" && tb_User2.Text != null && tb_User2.Text != "" && cbx_User3.Text != null && cbx_User3.Text != "" && dg_User.SelectedValue != null && regexpassword.IsMatch(tb_User2.Text))
            {
                int a = (int)cbx_User.SelectedValue;
                int b = (int)cbx_User3.SelectedValue;
                var value = (dg_User.SelectedValue as DataRowView).Row[0];
                user.UpdateQueryUser(a, tb_User1.Text, tb_User2.Text, b, (int)value);
                dg_User.ItemsSource = user.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_User_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_User.SelectedValue != null)
            {
                cbx_User.Text = (dg_User.SelectedValue as DataRowView).Row[1].ToString();
                tb_User1.Text = (dg_User.SelectedValue as DataRowView).Row[2].ToString(); 
                tb_User2.Text = (dg_User.SelectedValue as DataRowView).Row[3].ToString();
                cbx_User3.Text = (dg_User.SelectedValue as DataRowView).Row[4].ToString();
            }
        }

        private void Button_Click_Create_Supplier(object sender, RoutedEventArgs e)
        {
            if (tb_Supplier.Text != null && tb_Supplier.Text != "" && tb_Supplier1.Text != null && tb_Supplier1.Text != "" && tb_Supplier2.Text != null && tb_Supplier2.Text != "" && regexmail.IsMatch(tb_Supplier1.Text) && Regexphone.IsMatch(tb_Supplier2.Text))
            {
                supplier.InsertQuerySupplier(tb_Supplier.Text, tb_Supplier1.Text, tb_Supplier2.Text);
                dg_Supplier.ItemsSource = supplier.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Delete_Supplier(object sender, RoutedEventArgs e)
        {
            if (dg_Supplier.SelectedValue != null)
            {
                var value = (dg_Supplier.SelectedValue as DataRowView).Row[0];
                supplier.DeleteQuerySupplier((int)value);
                dg_Supplier.ItemsSource = supplier.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void Button_Click_Update_Supplier(object sender, RoutedEventArgs e)
        {
            if (tb_Supplier.Text != null && tb_Supplier.Text != "" && tb_Supplier1.Text != null && tb_Supplier1.Text != "" && tb_Supplier2.Text != null && tb_Supplier2.Text != "" && dg_Supplier.SelectedValue != null && regexmail.IsMatch(tb_Supplier1.Text) && Regexphone.IsMatch(tb_Supplier2.Text))
            {
                var value = (dg_Supplier.SelectedValue as DataRowView).Row[0];
                supplier.UpdateQuerySupplier(tb_Supplier.Text, tb_Supplier1.Text, tb_Supplier2.Text, (int)value);
                dg_Supplier.ItemsSource = supplier.GetData();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            FullUpdate();
        }

        private void dg_Supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Supplier.SelectedValue != null)
            {
                tb_Supplier.Text = (dg_Supplier.SelectedValue as DataRowView).Row[1].ToString();
                tb_Supplier1.Text = (dg_Supplier.SelectedValue as DataRowView).Row[2].ToString();
                tb_Supplier2.Text = (dg_Supplier.SelectedValue as DataRowView).Row[3].ToString();
            }
        }

        private void Upload_Btn_Click(object sender, RoutedEventArgs e)
        {
            List<Role> list = Converter.DeserializeObject<List<Role>>();
            foreach (var item in list)
            {
                role.InsertQueryRole(item.Name);
            }
            FullUpdate();
        }
    }
}
