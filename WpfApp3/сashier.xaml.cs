using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3.sales_dbDataSetTableAdapters;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для сashier.xaml
    /// </summary>
    public partial class сashier : Window
    {
        int count = 0;
        order_itemsTableAdapter order_Item = new order_itemsTableAdapter();
        List<OrderItems> list = new List<OrderItems>();
        customersTableAdapter customer = new customersTableAdapter();
        employeesTableAdapter employee = new employeesTableAdapter();
        ordersTableAdapter orders = new ordersTableAdapter();

        int countp = 0;
        int em_id;
        int cu_id;
        public сashier()
        {
            InitializeComponent();
            FullUpdate();
        }
        public void FullUpdate()
        {
            dg_Cheque.ItemsSource = null;
            dg_Order_Items.ItemsSource = order_Item.GetData();
            dg_Cheque.ItemsSource = list;
            cbx_Customer.ItemsSource = customer.GetData();
            cbx_Emloyee.ItemsSource = employee.GetData();
            cbx_Customer.DisplayMemberPath = "имя";
            cbx_Customer.SelectedValuePath = "айди";
            cbx_Emloyee.DisplayMemberPath = "имя";
            cbx_Emloyee.SelectedValuePath = "айди";
        }
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Order_Items.SelectedItem != null)
            {
                var r = Convert.ToInt32((dg_Order_Items.SelectedValue as DataRowView).Row[0].ToString());
                bool isch = false;
                foreach (var ff in list)
                {
                    if (r == ff.айди)
                    {
                        isch = true;
                        ff.количество += 1;
                        FullUpdate();
                        break;
                    }
                    
                }
                if (!isch)
                {
                    var a = (dg_Order_Items.SelectedValue as DataRowView).Row[1].ToString();
                    var b = (dg_Order_Items.SelectedValue as DataRowView).Row[2].ToString();
                    var c = (dg_Order_Items.SelectedValue as DataRowView).Row[3].ToString();
                    OrderItems item = new OrderItems();
                    item.айди = Convert.ToInt32((dg_Order_Items.SelectedValue as DataRowView).Row[0].ToString());
                    item.стоимость = Convert.ToDouble(c);
                    item.название = a;
                    item.количество = 1;
                    list.Add(item);
                    FullUpdate();
                }
                isch= false;
            }
            if (dg_Order_Items.SelectedValue == null && dg_Cheque.SelectedValue != null)
            {
                list[dg_Cheque.SelectedIndex].количество += 1;
                FullUpdate();
            }
            
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Order_Items.SelectedItem != null)
            {
                var a = dg_Cheque.SelectedIndex;
                if (a <= list.Count && a >= 0)
                    list.RemoveAt(a);
            }
            if (dg_Order_Items.SelectedValue == null && dg_Cheque.SelectedValue != null && list[dg_Cheque.SelectedIndex].количество >0)
            {
                
                list[dg_Cheque.SelectedIndex].количество -= 1;
                if (list[dg_Cheque.SelectedIndex].количество == 0)
                {
                    var a = dg_Cheque.SelectedIndex;
                    if (a <= list.Count && a >= 0)
                        list.RemoveAt(a);
                }
                FullUpdate();
            }
            FullUpdate();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string path = "C:/Users/aiX/Desktop/чек№";
            Random rnd = new Random();
            int id = rnd.Next(1000, 100000);
            path = path + id + ".txt";
            string text = "\t   Подшипники\r\n\t  Кассовый чек №" + id + "\n";
            double sum = 0;
            foreach (var item in list)
            {
                text += "\r\n " + item.название.ToString() + "\t—\t" + item.стоимость + " руб. * " + item.количество + "\r\n\t";
                sum += item.стоимость * item.количество;
            }
            var pay = Convert.ToInt32(tb_customer_cash.Text);
            double change = pay - sum;
            if (change > 0)
            {
                text += "\nИтого к оплате: " + sum + "\nВнесено: " + tb_customer_cash.Text + "\nСдача: " + change + "\n\n\n";
            }
            else
            {
                string error = "Справка об операции. Оплата отклонена: недостаточно средств";
                text += "\nИтого к оплате: " + sum + "\nВнесено: " + tb_customer_cash.Text + "\n" + error + "\n\n\n";
            }
            
            var now = Convert.ToString(DateTime.Now);
            var sum1 = Convert.ToDecimal(sum);
            orders.InsertQueryOrder(em_id, now, sum1, cu_id);
            File.WriteAllText(path, text);
            list.Clear();
            FullUpdate();
        }
    }
}