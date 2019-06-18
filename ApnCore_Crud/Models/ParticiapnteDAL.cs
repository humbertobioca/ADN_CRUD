using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApnCore_Crud.Models
{
    public class ParticipanteDAL
    {
        string connectionString = @"Server=tcp:biocasites.database.windows.net,1433;Initial Catalog=BaseBD;Persist Security Info=False;User ID=hbioca;Password=Amor!123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<Participante> GetAllParticipantes()
        {
            List<Participante> lstParticipante = new List<Participante>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT PPCODPAT, PPFULLNAME, PPTOKEN, PTQRCODE FROM PARTICIPANTES..BASEDB", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Participante participante = new Participante();

                    participante.PPCODPAT = Convert.ToInt32(rdr["PPCODPAT"]);
                    participante.PPFULLNAME = rdr["PPFULLNAME"].ToString();
                    participante.PPTOKEN = rdr["PPTOKEN"].ToString();
                    participante.PPQRCODE = rdr["PPQRCODE"].ToString();

                    lstParticipante.Add(participante);
                }
                con.Close();
            }
            return lstParticipante; 
        }

        public void AddParticipante(Participante participante)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL ="INSERT INTO PARTICIPANTES (PPFULLNAME,PPTOKEN,PPQRCODE) Values(@PPCODPATPPTOKEN, @PPTOKEN, @PPQRCODE)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@PPFULLNAME", participante.PPFULLNAME);
                cmd.Parameters.AddWithValue("@PPTOKEN", participante.PPTOKEN);
                cmd.Parameters.AddWithValue("@PPQRCODE", participante.PPQRCODE);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateParticipante(Participante participante)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "UPDATE PARTICIPANTES SET PPFULLNAME = @PPFULLNAME, PPTOKEN = @PPTOKEN, PPQRCODE = @PPQRCODE where PPCODPAT = @PPCODPAT";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@PPCODPAT", participante.PPCODPAT);
                cmd.Parameters.AddWithValue("@PPFULLNAME", participante.PPFULLNAME);
                cmd.Parameters.AddWithValue("@PPTOKEN", participante.PPTOKEN);
                cmd.Parameters.AddWithValue("@PPQRCODE", participante.PPQRCODE);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        
        public Participante GetParticipante(int? id)
        {
            Participante participante = new Participante();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM PARTICIPANTES WHERE PPCODPAT = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    participante.PPCODPAT = Convert.ToInt32(rdr["PPCODPAT"]);
                    participante.PPFULLNAME = rdr["PPFULLNAME"].ToString();
                    participante.PPTOKEN = rdr["PPTOKEN"].ToString();
                    participante.PPQRCODE = rdr["PPQRCODE"].ToString();
                }
            }
            return participante;
        }
        public void DeleteParticipante(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "DELETE FROM PARTICIPANTES WHERE PPCODPAT = @PPCODPAT";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@PPCODPAT", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
