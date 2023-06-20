using AdoNetLib.Configurations;
using Microsoft.Data.SqlClient;
using System.Data;



namespace AdoNetLib
{
    public class MainConnector
    {
        public SqlConnection connection = new SqlConnection(ConnectionString.MsSqlConnection);
        

        //метод для закрытия асинхронного подключения
        public async void DisconnectAsync()
        {
            if (connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }

        //метод для открытия асинхронного подключения
        public async Task <bool> ConnectAsync()
        {
            bool result;
            try
            {
                await connection.OpenAsync();
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }


        //метод получения подключения - метод, который будет управлять состоянием подключения, чтобы избежать ошибок и не пытаться
        //сделать выборку из закрытого ранее подключения. Например, если оно было прервано по причинам сетевой ошибки: 
        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                return connection;
            }
            else
            {
                throw new Exception("Подключение уже закрыто!");
            }
        }
    }
}