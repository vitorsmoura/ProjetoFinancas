using MySql.Data.MySqlClient;
using ProjData.Models.DadosTabela;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjData.Models.Repositorio
{
    public class clBuscaDesc
    {

        Conexao conexao = new Conexao();
        public List<Descricao> buscaDesc(int codUser)
        {
            try
            {
                MySqlCommand select = new MySqlCommand(@"select * from tbDados where codUsuario = @codUser", conexao.MyConectarBD());
                List<Descricao> descricoes = new List<Descricao>();

                select.Parameters.Add("@codUser", MySqlDbType.Int16).Value = codUser;

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(select);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Descricao desc = new Descricao();
                    desc.CodDesc = row[0].ToString();
                    desc.Datac = row[1].ToString();
                    desc.Descr = row[2].ToString();
                    desc.Loja = row[3].ToString();
                    desc.Categoria = row[4].ToString();
                    desc.Necessidade = row[5].ToString();
                    desc.Tipo = row[6].ToString();
                    desc.Forma_pgto = row[7].ToString();
                    desc.Preco = double.Parse(row[8].ToString());
                    descricoes.Add(desc);

                    conexao.MyDesconectarBD();
                }
                return descricoes;
            }




            catch (Exception)
            {

                throw;
            }

        }

        public List<Descricao> buscaMesAtual(int mesAtual, int anoAtual, int codUser)
        {
            try
            {
                MySqlCommand select = new MySqlCommand(@"select * from tbDados l where month(l.datac) = @mesAtual and year(l.datac) = @anoAtual and codUsuario = @codUser", conexao.MyConectarBD());
                List<Descricao> descricoes = new List<Descricao>();
                select.Parameters.Add("@mesAtual", MySqlDbType.Int16).Value = mesAtual;
                select.Parameters.Add("@anoAtual", MySqlDbType.Int16).Value = anoAtual;
                select.Parameters.Add("@codUser", MySqlDbType.Int16).Value = codUser;

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(select);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Descricao desc = new Descricao();
                    desc.CodDesc = row[0].ToString();
                    desc.Datac = row[1].ToString();
                    desc.Descr = row[2].ToString();
                    desc.Loja = row[3].ToString();
                    desc.Categoria = row[4].ToString();
                    desc.Necessidade = row[5].ToString();
                    desc.Tipo = row[6].ToString();
                    desc.Forma_pgto = row[7].ToString();
                    desc.Preco = double.Parse(row[8].ToString());
                    descricoes.Add(desc);

                    conexao.MyDesconectarBD();
                }
                return descricoes;
            }

            catch (Exception)
            {

                throw;
            }

        }


    }
}