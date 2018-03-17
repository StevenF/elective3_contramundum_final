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
using System.Diagnostics;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        SQLAdapter sqlAdapter;
        

        public MainWindow()
        {
            InitializeComponent();
            InitListView();
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            string bikeNumber = tb_bikeNumber.Text;
            string bikeUser = tb_user.Text;
            string timeStart = tb_timeStart.Text;
            string timeEnd = tb_timeEnd.Text;
            bool isPaid = cb_isPaid.IsChecked.Value;
            //bool isAvailable = cb_isAvailable.IsChecked.Value;

            var comboBoxTime = ComboBox_Time.SelectedValue.ToString();
            var comboBoxType = ComboBox_Type.SelectedValue.ToString();

            string time = comboBoxTime;
            
            Debug.Write("mainWindow: bikeNumber : " + bikeNumber + "\n");
            Debug.Write("mainWindow: bikeUser : " + bikeUser + "\n");
            Debug.Write("mainWindow: time : " + time + "\n");
            Debug.Write("mainWindow: timeStart : " + timeStart + "\n");
            Debug.Write("mainWindow: timeEnd : " + timeEnd + "\n");
            Debug.Write("mainWindow: isPaid : " + isPaid + "\n");
            //Debug.Write("mainWindow: isAvailable : " + isAvailable + "\n");
            Debug.Write("mainWindow: comboBoxValue : " + comboBoxTime + "\n");

            bool isAvailable;

            if (isPaid)
            {
                isAvailable = false;
            }
            else
            {
                isAvailable = true;
            }

            sqlAdapter = new SQLAdapter();
            sqlAdapter.updateRow(bikeNumber, bikeUser, time, timeStart, timeEnd, isAvailable, isPaid, comboBoxType);

            InitListView();

        }

        private void ComboBox_Time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ComboBox_Loaded_Time(object sender, RoutedEventArgs e)
        {
            List<string> listTime = new List<string>();
          
            for (int i = 0; i <= 10; i++)
            {
                int value = i * 30;
                listTime.Add(value.ToString());

            }

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = listTime;
            comboBox.SelectedIndex = 0;
        }


        private void InitListView()
        {
            sqlAdapter = new SQLAdapter();

            List<Model_RentalSystem> listModelRentalSystem = new List<Model_RentalSystem>();
            

            string queryBikeNumber = "SELECT * FROM " + SQLAdapter.sql_table + "";
                
            MySql.Data.MySqlClient.MySqlCommand mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand(queryBikeNumber, SQLAdapter.mySqlConnection);
            MySql.Data.MySqlClient.MySqlDataReader  mySqlDataReader = mySqlCommand.ExecuteReader();

            try
            {
                while (mySqlDataReader.Read())
                {
                    //listModelRentalSystem.Add(new Model_RentalSystem()
                    //{

                    //    BikeNumber = mySqlDataReader["bike_number"].ToString(),
                    //    BikeUser = mySqlDataReader["user_name"].ToString(),
                    //    TimeLeft = mySqlDataReader["time_left"].ToString(),
                    //    TimeStart = mySqlDataReader["time_start"].ToString(),
                    //    TimeEnd = mySqlDataReader["time_end"].ToString(),
                    //    IsPaid = mySqlDataReader["isPaid"].ToString(),
                    //    Status = mySqlDataReader["isAvailable"].ToString()
                    //});

                    Model_RentalSystem model_RentalSystem = new Model_RentalSystem();

                    model_RentalSystem.BikeNumber = mySqlDataReader["bike_number"].ToString();
                    model_RentalSystem.BikeUser = mySqlDataReader["user_name"].ToString();
                    model_RentalSystem.Time = mySqlDataReader["time_time"].ToString();
                    model_RentalSystem.TimeStart = mySqlDataReader["time_start"].ToString();
                    model_RentalSystem.TimeEnd = mySqlDataReader["time_end"].ToString();
                    model_RentalSystem.Type = mySqlDataReader["bike_type"].ToString();

                    string isPaid = null;
                    string isAvailable = null;

                    if (mySqlDataReader["isPaid"].ToString().Equals("True"))
                    {
                        isPaid = "Yes";
                    }
                    else
                    {
                        isPaid = "No";
                    }

                    if (mySqlDataReader["isAvailable"].ToString().Equals("True"))
                    {
                        isAvailable = "Available";
                    }
                    else
                    {
                        isAvailable = "Rented";
                    }

                    model_RentalSystem.IsPaid = isPaid;
                    model_RentalSystem.Status = isAvailable;

                    listModelRentalSystem.Add(model_RentalSystem);

                }

                Listview_Main.ItemsSource = listModelRentalSystem;

                mySqlDataReader.Close();

            }
            catch(Exception e)
            {

            }

        }

        private void Listview_Main_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectIndex = Listview_Main.SelectedIndex + 1;

            string queryBikeNumber = "SELECT * FROM " + SQLAdapter.sql_table + " WHERE ID = '"+selectIndex+"'";

            
            MySql.Data.MySqlClient.MySqlCommand mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand(queryBikeNumber, SQLAdapter.mySqlConnection);
            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader  = mySqlCommand.ExecuteReader();

            string bikeNumber = null;
            string bikeUser = null;
            string time = null;
            string timeStart = null;
            string timeEnd = null;
            string isPaid = null;
            string status = null;

            try
            {
                while (mySqlDataReader.Read())
                {
                    bikeNumber = mySqlDataReader["bike_number"].ToString();
                    bikeUser = mySqlDataReader["user_name"].ToString();
                    time = mySqlDataReader["time_time"].ToString();
                    timeStart = mySqlDataReader["time_start"].ToString();
                    timeEnd = mySqlDataReader["time_end"].ToString();
                    isPaid = mySqlDataReader["isAvailable"].ToString();
                    status = mySqlDataReader["isPaid"].ToString();

                }

                tb_bikeNumber.Text = bikeNumber;
                tb_user.Text = bikeUser;
                tb_timeStart.Text = timeStart;
                tb_timeEnd.Text = timeEnd;

                mySqlDataReader.Close();

            }
            catch (Exception exception)
            {

            }

        }


        private void ComboBox_Type_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> listType = new List<string>();
            listType.Add("Family Bikes : Single Seater");
            listType.Add("Family Bikes : Double Seater");
            listType.Add("Kiddie Bikes : Side Car");
            listType.Add("Kiddie Bikes : BMX Small");
            listType.Add("Solo Bikes: Mountain Bike");
            listType.Add("Solo Bikes : BMX");

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = listType;

        }
    }
}
