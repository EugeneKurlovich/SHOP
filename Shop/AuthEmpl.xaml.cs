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
using System.Windows.Shapes;

namespace Shop
{

    public partial class AuthEmpl : Window
    {
        public AuthEmpl()
        {
            InitializeComponent();
        }

        string connStr = @"Data Source=EUGENEPC;Initial Catalog=StoreDB;Integrated Security=True";
        private void button_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection(connStr);
            if (db.getAllEmplLogPass(textBox.Text, textBox1.Text))
            {
                db.closeConnection();
                Employe a = new Employe();
                a.Show();
                this.Close();
            }
            else
            {
                db.closeConnection();
                MessageBox.Show("Сотрудник не найден!!!");
            }
        }
    }
}
