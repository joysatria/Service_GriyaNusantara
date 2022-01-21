using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceKos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string constring = "Data Source= LAPTOP-3AAAJO1I; Initial Catalog=ReservasiKos; Persist Security Info= True; User ID= sa; Password=123";
        SqlConnection connection;
        SqlCommand com;

        public List<DataRegister> DataRegist()
        {
            List<DataRegister> list = new List<DataRegister>();
            try
            {
                string sql = "select id, username, password, kategori from Login";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DataRegister data = new DataRegister();
                    data.id = reader.GetInt32(0);
                    data.username = reader.GetString(1);
                    data.password = reader.GetString(2);
                    data.kategori = reader.GetString(3);
                    list.Add(data);
                }
                connection.Close();

            }
            catch (Exception e)
            {
                e.ToString();
            }
            return list;
        }

        public string deletePemesanan(string IDPemesanan)
        {
            string a = "gagal";
            try
            {
                string sql = "delete from dbo.Pemesanan where id_pemesanan = '" + IDPemesanan + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "Sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string DeleteRegister(string username)
        {
            try
            {
                int id = 0;
                string sql = "select id from dbo.Login where username ='" + username + "' ";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                connection.Close();

                string sql2 = "delete from dbo.Login where id = '" + id + "' ";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public List<DetailKos> DetailKos()
        {
            List<DetailKos> KosFull = new List<DetailKos>();
            try
            {
                string sql = "select id_kamar, nama_kamar, deskripsi, harga, ketersediaan from dbo.Kosan";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DetailKos data = new DetailKos();

                    data.IDKamar = reader.GetString(0);
                    data.NamaKamar = reader.GetString(1);
                    data.Deskripsi = reader.GetString(2);
                    data.Harga = reader.GetString(3);
                    data.Ketersediaan = reader.GetString(4);
                    KosFull.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return KosFull;
        }

        public string editPemesanan(string IDPemesanan, string NamaPemesan, string No_telpon)
        {
            string a = "Gagal";
            try
            {
                string sql = "update dbo.Pemesanan set nama_pemesan = '" + NamaPemesan + "', no_telepon = '" + No_telpon + "'" + " where id_pemesanan = '" + IDPemesanan + "' ";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "Sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string Login(string username, string password)
        {
            string kategori = "";

            string sql = "select kategori from Login where username ='" + username + "' and password = '" + password + "' ";
            connection = new SqlConnection(constring);
            com = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                kategori = reader.GetString(0);
            }

            return kategori;
        }

        public string pemesanan(string IDPemesanan, string NamaPemesan, string NoTelpon, int WaktuSewa, string IDKamar)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Pemesanan values ('" + IDPemesanan + "', '" + NamaPemesan + "', '" + NoTelpon + "', " + WaktuSewa + ", '" + IDKamar + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                //string sql2 = "update dbo.Kosan";
                //connection = new SqlConnection(constring);
                //com = new SqlCommand(sql2, connection);
                //connection.Open();
                //com.ExecuteNonQuery();
                //connection.Close();

                a = "Sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public List<Pemesanan> Pemesanan()
        {
            List<Pemesanan> pemesanans = new List<Pemesanan>();
            try
            {
                string sql = "select id_pemesanan, nama_pemesan, no_telepon," +
                    "waktu_sewa, nama_kamar from dbo.Pemesanan p join dbo.Kosan l on p.id_kamar = l.id_kamar";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Pemesanan data = new Pemesanan();

                    data.IDPemesanan = reader.GetString(0);
                    data.NamaPemesan = reader.GetString(1);
                    data.NoTelpon = reader.GetString(2);
                    data.WaktuSewa = reader.GetInt32(3);
                    data.IDKamar = reader.GetString(4);
                    pemesanans.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return pemesanans;
        }

        public string Register(string username, string password, string kategori)
        {
            try
            {
                string sql = "insert into Login values('" + username + "', '" + password + "', '" + kategori + "') ";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public List<CekKos> ReviewKos()
        {
            throw new NotImplementedException();
        }

        public string UpdateRegister(string username, string password, string kategori, int id)
        {
            try
            {
                string sql2 = "update loginKos SET username='" + username + "', password= '" + password + "', kategori= '" + kategori + "' ";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
