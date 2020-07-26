
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Devart.Common;
using Devart.Data.Oracle;

namespace DevartPerformanceTest
{
    public class DevartExecute
    {
        //oracleConnection2.ConnectionString = "Direct=True;User Id=scott;Password=tiger;Server=192.168.0.100;SID=ORACLE18c;Port=1521;";

        private const string connectionString =
            "Direct=True;User Id=HIS6;Password=HIS6;Server=172.19.20.163;SID=orcl;Port=1521;Pooling=true;Min Pool Size=1;Max Pool Size=15;Connection Lifetime=0";

        private const string sqlText = "select * from mz_chufang1 where trunc(kaidanrq) > trunc(sysdate - 7200)";

        private const string sqlText2 = "select chufangid from mz_chufang1 where chufangid = '2000091258'";

        private const string sqlText3 = "select * from mz_chufang1 where chufangid in ('2000091258','1000127759')";

        private const string sqlText4 = "select * from mz_chufang1 where chufangid in ('2000091258','1000125532','1000127759')";

        private const string sqlText5 = "select * from mz_chufang2 where chufangid = '2000091258'";

        private OracleConnection myConnection = null;
        public DevartExecute()
        {
            myConnection = new OracleConnection(connectionString);
        }

        public void Query()
        {
            myConnection.Open();
            OracleCommand command = myConnection.CreateCommand();
            command.CommandText = sqlText4;

            using OracleDataReader reader = command.ExecuteReader();
            // printing the column names
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write(reader.GetName(i) + "\t");
            Console.Write(Environment.NewLine);
            try
            {
                while (reader.Read())
                {
                    // printing the table content
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write(reader.GetValue(i) + "\t");
                    Console.Write(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        /// <summary>
        /// 查询单个值
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalar()
        {
            using OracleConnection con = new OracleConnection(connectionString);
            con.Open();
            OracleCommand cmd = new OracleCommand(sqlText2, con);

            var obj = cmd.ExecuteScalar();
            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetDatatable()
        {
            myConnection.Open();
            OracleCommand cmd = new OracleCommand(sqlText3, myConnection);

            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
         

        }
    }
}
