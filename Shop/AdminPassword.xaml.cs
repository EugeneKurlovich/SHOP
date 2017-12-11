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
    public partial class AdminPassword : Window
    {
        public AdminPassword()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Equals("MainAdmin") && textBox.Text.Equals("MainAdmin"))
            {
                Admin admin = new Admin();
                admin.Show();
                this.Close();
            }
            else
            {
                DB db = new DB();
                db.openConnection();
               if(db.getAllUsers(textBox.Text, passwordBox.Password))
                {
                    db.closeConnection();
                    Admin admin = new Admin();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    db.closeConnection();
                    MessageBox.Show("Администратор не найден!!!");
                }                               
            }
            
        }
    }
}
