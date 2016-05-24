using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;

namespace TimeLoggerService
{
    public static class TimeLogger
    {
        public static string ConnectionString = ReadConnectionString();
        public static void LogTime()
        {
            // Record Travel Time
            try
            {
                WebClient webClient = new WebClient();
                Dictionary<int, string> allURLs = GetGoogleMapsAPIURLs();

                foreach(KeyValuePair<int, string> APIURL in allURLs)
                {
                    dynamic result = JsonConvert.DeserializeObject(webClient.DownloadString(APIURL.Value.ToString()));
                    int timeSeconds = Convert.ToInt32(result.rows[0].elements[0].duration_in_traffic.value);
                    int timeMins = timeSeconds / 60;

                    // Log Travel Time
                    LogTravelTime(timeMins, APIURL.Key);
                }
            }
            catch(Exception ex)
            {
                WriteErrorLog(ex.Message);
            }
            
        }

        public static string ReadConnectionString()
        {
            //string connectionstring = "data source=172.16.33.180; initial catalog=AccrtvTDM; user id=sa; password=Change123;";
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return connectionString;
        }

        public static void WriteErrorLog(string message)
        {
            StreamWriter errorLogWriter = null;
            try
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLog.txt";
                errorLogWriter = new StreamWriter(filePath, true);

                string errorMessage = DateTime.Now.ToString() + ": " + message;
                errorLogWriter.WriteLine(errorMessage);
                errorLogWriter.Flush();
                errorLogWriter.Close();
            }
            catch(Exception)
            {

            }
        }

        public static void LogTravelTime(int travelTime, int PathID)
        {
            // Get Datetime in HHMM format (24 HR)
            int timeInterval = Convert.ToInt32(DateTime.Now.ToString("HHmm"));

            SqlConnection connection = new SqlConnection(ConnectionString);
            string insertCommandFormat = "Insert Into [dbo].[TravelTime] Values ({0}, {1}, GETDATE(), {2});";
            string insertTravelTimeCommand = String.Format(insertCommandFormat, PathID, travelTime, timeInterval);

            SqlCommand insertCommand = new SqlCommand(insertTravelTimeCommand, connection);

            try
            {
                connection.Open();

                insertCommand.ExecuteNonQuery();    
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static Dictionary<int, string> GetGoogleMapsAPIURLs()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string getAllPathsCommand = "SELECT * FROM [dbo].[Path] Where [EndDate] Is Null Order By PathID Asc;";

            SqlCommand command = new SqlCommand(getAllPathsCommand, connection);

            Dictionary<int, string> allAPIURLs = new Dictionary<int, string>();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    string APIURLFormat = "https://maps.googleapis.com/maps/api/distancematrix/json?origins={0}&destinations={1}&departure_time=now&key={2}";

                    int pathID = Convert.ToInt32(reader["PathID"]);
                    string origin = reader["Origin"].ToString();
                    string destination = reader["Destination"].ToString();
                    string APIKey = reader["GoogleAPIKey"].ToString();

                    string APIURL = String.Format(APIURLFormat, origin, destination, APIKey);
                    allAPIURLs.Add(pathID, APIURL);
                }

                return allAPIURLs;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            
        }


    }
}
