using System.Data.SqlClient;

namespace ADSWebApi.Entities
{
    public class DALBase
    {
        public DALBase()
        {

        }
        //private static string DBMain = @"Data Source=10.0.0.23; Initial Catalog=ads; 
        //                          Persist Security Info=True; 
        //                          User ID=general; 
        //                          Min Pool Size=0;
        //                          Max Pool Size=10024;
        //                          Pooling=true;";

        private static string DBMain = 
            @"workstation id=adsrecrea.mssql.somee.com;
            packet size=4096;
            user id=Sol_SQLLogin_1;
            pwd=fozp6d1e22;
            data source=adsrecrea.mssql.somee.com;
            persist security info=False;
            initial catalog=adsrecrea;
            TrustServerCertificate=True";
        public static SqlConnection GetConnection()
        {
            string connectionString;
            SqlConnection objCon;
            //    <add name="DBMain" />
            connectionString = DBMain;
            objCon = new SqlConnection(connectionString);

            return objCon;
        }
    }
}
