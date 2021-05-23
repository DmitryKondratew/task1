using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using System.Data.OracleClient;

namespace WcfToDb
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public Service1()
        {
            ConnectToDb();
        }

        OracleConnection connection;
        string host = "Dmitriy";
        string port = "1521";
        string sid = "xe";
        string user = "c##Dimitry";
        string password = "S2n0s0d7";

        string connectionString;
        void ConnectToDb()
        {
            connectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                     + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                     + sid + ")));Password=" + password + ";User ID=" + user;
            connection = new OracleConnection(connectionString);
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Contract> GetAllContract()
        {
            List<Contract> contractL = new List<Contract>();
            try
            {
                connection.Open();
                string queryString = "select id, contract_number, date_time, date_update, trunc(to_date(sysdate,'dd-mm-yy') - to_date(date_update, 'dd-mm-yy')) as days from Contract";

                OracleCommand command1 = new OracleCommand(queryString);
                command1.Connection = connection;
                OracleDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    bool ch = false;
                    if (Convert.ToInt32(reader[4]) <= 60) ch = true;
                    Contract contract = new Contract()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Contract_Number = reader[1].ToString(),
                        Date_Time = reader[2].ToString(),
                        Date_Update = reader[3].ToString(),
                        Relevance = ch
                    };
                    contractL.Add(contract);
                }
                reader.Close();
                return contractL;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
