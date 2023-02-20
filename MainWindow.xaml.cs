using Microsoft.Data.SqlClient;

using System.Data;
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
using System.Reflection.PortableExecutable;
using System.Data.Common;

namespace SQL_ADO_NET_WPF_fruits_vegetables
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectString;
        SqlDataAdapter adapter;
        
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }


        //SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;" +
        //"Initial Catalog = Vegetables_Fruits; Integrated Security = true");
        private void butt_load_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LoadData()
        {
            string sql = "SELECT * FROM Veg_Fru"; 
            // тупил часа два, вместо имени таблицы вставлял имя базы данных

            string connectString = (@"Data Source = (localdb)\MSSQLLocalDB;" +
            "Initial Catalog = Vegetables_Fruits; Integrated Security = true");

            SqlConnection con = new SqlConnection(connectString);

            SqlCommand cmd = new SqlCommand(sql,con);

            con.Open();
            
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sql_data.ItemsSource = dt.DefaultView;

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
//// 1 Отображение всех названий и овощей (исключая повторения); +
//// 2 Отображение всех цветов (без повторений);                 запрос
//// 3 Показать максимальную калорийность и у какого продукта;   запрос
//// 4 Показать минимальную калорийность и у какого продукта;    запрос
//// 5 Показать среднюю калорийность                             messagebox
//// 6 Показать количество овощей и фруктов по отдельности;      messagebox
//// 7 Показать количество овощей и фруктов заданного цвета;     messagebox
//// 8 Показать овощи и фрукты с калорийность выше указанной;    запрос
//// 9 Показать овощи и фрукты с калорийность ниже указанной.    запрос
///
///   
///   
