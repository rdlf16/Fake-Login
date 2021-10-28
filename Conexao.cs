using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace fakeLogin {
    internal class Conexao {
        public NpgsqlConnection getConexao() {
            string serverName = "127.0.0.1";
            string port = "5432";
            string userName = "postgres";
            string password = "Teste1313";
            string databaseName = "fakelogin";

            NpgsqlConnection pgslConnection = null;
            string connectioString = String.Format("Server={0};" +
                "Port={1};User Id={2};Password={3};Database={4}",
                serverName, port, userName, password, databaseName);

            pgslConnection = new NpgsqlConnection(connectioString);

            return pgslConnection;
        }
    }
}
