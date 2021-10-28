using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using Npgsql;

namespace fakeLogin {
    internal class Usuario {
        private int id;
        private string email;
        private string senha;

        public int Id { get; set; }

        public string Email { get; set; }   

        public string Senha { get; set; }   

        public bool logar() {
            NpgsqlConnection pgsqlConnection = null;

            try {
                Conexao objconexao = new Conexao();

                pgsqlConnection = objconexao.getConexao();

                pgsqlConnection.Open();

                string sql = "";

                sql = "select * from login where email='" + this.Email + "' and senha='" + GerarHashMd5(this.Senha) + "' LIMIT 1;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, pgsqlConnection);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read()) {
                    this.id = Convert.ToInt32(dr["id"]);

                    if(this.Email == dr["email"].ToString() && GerarHashMd5(this.Senha) == dr["senha"].ToString()) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }

            } catch (Exception ex) {
                return false;
            }
            finally {
                pgsqlConnection.Close();
            }
        }

        public static string GerarHashMd5(string input) {
            MD5 md5Hash = MD5.Create();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));   

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append(data[i].ToString("x2")); 
            }
            return sBuilder.ToString();
        }

        public static bool Log(string strMensagem, string strNomeArquivo = "ArquivoLog") {
            try {
                var caminhoExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string caminhoArquivo = Path.Combine(caminhoExe, strNomeArquivo);
                if(!File.Exists(caminhoArquivo)) {
                    FileStream arquivo = File.Create(caminhoArquivo);
                    arquivo.Close();    
                }
                using (StreamWriter w = File.AppendText(caminhoArquivo)) {
                    AppendLog(strMensagem, w);
                }
                return true;
            } catch (Exception ex) {
                return false;

            }
        }

        public static void AppendLog(string logMensagem, TextWriter txtWriter) {
            try {
                txtWriter.Write("\r\nLog Entrada : ");
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLine(" :");
                txtWriter.WriteLine($" :{logMensagem}");
                txtWriter.WriteLine("---------------------------------------------");
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
