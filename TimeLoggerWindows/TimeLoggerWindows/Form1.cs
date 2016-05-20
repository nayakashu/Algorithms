using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TimeLoggerWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogTime_Click(object sender, EventArgs e)
        {
            tmrLogTime.Start();
        }

        private void tmrLogTime_Tick(object sender, EventArgs e)
        {
            LogTimeToDB();
            lblLastTime.Text = DateTime.Now.ToString();
        }

        private void LogTimeToDB()
        {
            string connectionString = "Data Source=172.16.33.180; Initial Catalog=AccrtvTDM; User ID=sa; Password=Change123";
            string mapAPIAddress = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=12.905166,77.629748&destinations=12.948156,77.708109&departure_time=now&key=AIzaSyBx23Lnkzn_9VBceuRpaGYqDMLavpmZOdw";

            WebClient webClient = new WebClient();
            dynamic result = JsonConvert.DeserializeObject(webClient.DownloadString(mapAPIAddress));
            double timeTakenInTraffic = Convert.ToInt32(result.rows[0].elements[0].duration_in_traffic.value);
            int timeTakenInMins = Convert.ToInt32(Math.Round(timeTakenInTraffic / 60));

            SqlConnection connection = new SqlConnection(connectionString);
            string insertCommandText = "INSERT INTO [dbo].[TravelTime] VALUES (1, " + timeTakenInMins + ", GETDATE());";

            connection.Open();

            SqlCommand insertCommand = new SqlCommand(insertCommandText, connection);
            insertCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}
