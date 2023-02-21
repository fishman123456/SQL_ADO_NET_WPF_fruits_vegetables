using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
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
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;
// отсоединеный режим работы через адаптер
namespace SQL_ADO_NET_WPF_fruits_vegetables
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        SqlDataAdapter adapter;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            // to do меняем кодировку
           // System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

       public string sqlsel = "SELECT * FROM Veg_Fru";
       public string sqlupd = "update Veg_Fru";
        public string insertString = "insert into Veg_Fru(Name_v_f, Type_v_f,Color_v_f,Caloric_v_f)" +
            " values (N'автор',N'попытка',N'апр','2')";
        // тупил часа два, вместо имени таблицы вставлял имя базы данных

        string connectString = (@"Data Source = (localdb)\MSSQLLocalDB; " +
        "Initial Catalog = Vegetables_Fruits; Integrated Security = true");
        //SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;" +
        //"Initial Catalog = Vegetables_Fruits; Integrated Security = true");

        public void LoadData()
        {
           

            SqlConnection con = null;
            //описываем соединение 
            con = new SqlConnection(connectString);
            //создаем комманду на соединение
            SqlCommand cmd = new SqlCommand(sqlsel, con);
            //открываем соединение
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sql_data.ItemsSource = dt.DefaultView;
           
            //выполнить запрос, занесенный
            //в объект command
            cmd.ExecuteNonQuery();

            con.Close();
        }

     

        private void butt_load_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        // для эн. ценность, только цифры
        private void tb4_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void butt_1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = null;
            //описываем соединение 
            con = new SqlConnection(connectString);
            //создаем комманду на соединение  21-02-2023 1_готово
            SqlCommand cmdin = new SqlCommand("SELECT DISTINCT Name_v_f FROM Veg_Fru", con);
            //открываем соединение
            con.Open();
            SqlDataAdapter sdain = new SqlDataAdapter(cmdin);
            DataTable dt = new DataTable();
            sdain.Fill(dt);
            sql_data.ItemsSource = dt.DefaultView;
            con.Close();
            //LoadData();
        }

        private void butt_2_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = null;
            //описываем соединение 
            con = new SqlConnection(connectString);
            //создаем комманду на соединение  21-02-2023 1_готово
            SqlCommand cmdin = new SqlCommand("SELECT DISTINCT Color_v_f FROM Veg_Fru", con);
            //открываем соединение
            con.Open();
            SqlDataAdapter sdain = new SqlDataAdapter(cmdin);
            DataTable dt = new DataTable();
            sdain.Fill(dt);
            sql_data.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void butt_3_Click(object sender, RoutedEventArgs e)
        {
            // не работает нифига 21-02-2023 18-20
            // SELECT MAX(salary) as max FROM workers
            SqlConnection con = null;
            //описываем соединение 
            con = new SqlConnection(connectString);
            //создаем комманду на соединение  21-02-2023 1_готово
            SqlCommand cmdin = new SqlCommand(
                "SELECT  MAX(Caloric_v_f) FROM Veg_Fru " , con);
            //открываем соединение
            con.Open();
            SqlDataAdapter sdain = new SqlDataAdapter(cmdin);
            DataTable dt = new DataTable();
            sdain.Fill(dt);
            sql_data.ItemsSource = dt.DefaultView;
            con.Close();
        }
    }
}
//// 1 Отображение всех названий и овощей (исключая повторения) +
//// 2 Отображение всех цветов (без повторений)                 запрос +
//// 3 Показать максимальную калорийность и у какого продукта   запрос
//// 4 Показать минимальную калорийность и у какого продукта    запрос
//// 5 Показать среднюю калорийность                            messagebox
//// 6 Показать количество овощей и фруктов по отдельности      messagebox
//// 7 Показать количество овощей и фруктов заданного цвета     messagebox
//// 8 Показать овощи и фрукты с калорийность выше указанной    запрос
//// 9 Показать овощи и фрукты с калорийность ниже указанной    запрос
///
///   
///   
