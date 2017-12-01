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
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }


        private void prodGrid_Loaded(object sender, RoutedEventArgs e)
        {
            prodGrid.ItemsSource = ProductsList.prodList;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            db.getAllProducts();
            prodGrid.ItemsSource = ProductsList.prodList;
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string name = textBox.Text;
            string surname = textBox1.Text;
           DateTime date = new DateTime(2017,1,1,1,1,1);
            string post = comboBox.Text;
            string log = textBox2.Text;
            string pass = passwordBox.Password;
            DB db = new DB();
            db.openConnection();
            db.addEmploye(name, surname, date, post, log, pass);
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            prodGrid.ItemsSource = null;
            prodGrid.ItemsSource = ProductsList.prodList;
        }
    }
}
