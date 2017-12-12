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
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            db.getAllCategories();
            cGrid.ItemsSource = null;
            cGrid.ItemsSource = Categories.categoriesList;
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            db.getAllProducts();
            pGrid.ItemsSource = ProductsList.prodList;
            MessageBox.Show("Выполнено !!!");
            db.closeConnection();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            pGrid.ItemsSource = null;
            pGrid.ItemsSource = ProductsList.prodList;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            ProductsList path = pGrid.SelectedItem as ProductsList;
            DB db = new DB();
            db.openConnection();
            db.buySelectedProduct(path.id, Convert.ToInt32(textBox.Text));      
            MessageBox.Show("Куплено");
            db.closeConnection();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Categories path = cGrid.SelectedItem as Categories;
            DB db = new DB();
            db.openConnection();
            ProductsList.prodList.Clear();
            db.filtrProduct(path.id);
            pGrid.ItemsSource = null;
            pGrid.ItemsSource = ProductsList.prodList;
            MessageBox.Show("Выполнено");
            db.closeConnection();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mv = new MainWindow();
            mv.Show();
            this.Close();
        }
    }
}
