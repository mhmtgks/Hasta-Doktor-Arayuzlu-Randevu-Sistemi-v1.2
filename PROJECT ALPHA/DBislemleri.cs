using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PROJECT_ALPHA
{
    class DBislemleri
    {
        public static int id = 0, tip = 0;
        public static string adı = "", soyadı = "", tc = "", dt = "", adres = "";
        static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mgoek\Documents\randevukayıt.mdf;Integrated Security=True;Connect Timeout=30";
        static SqlConnection baglanti = new SqlConnection(baglantiYolu);
        public static int hastidrg, sehiriddd, hiddb;
        public static bool girisKontrol(string kadi, string sifre)
        {
            bool sonuc = false;
            try
            {
                string sql = "select id from giriş where kullanıcıadı=@pkadı and Şifre=@psifre";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@psifre", sifre);
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                DataSet sonucDS = new DataSet();
                id=readint(komut,kadi);
                baglanti.Open();
                adaptor.Fill(sonucDS);
                baglanti.Close();
                

                if (sonucDS.Tables[0].Rows.Count > 0)
                    sonuc = true;
                
            }
            catch (System.InvalidOperationException)
            {

            }
            return sonuc;
        }
        public static void Ekle(string ad, string soyad, string tc, string adres, string dt)
        {
            string sql = "insert into Bilgi values (@pAd,@pSoyad,@ptc,@padr,@pdt)";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@pAd",ad );
            komut.Parameters.AddWithValue("@pSoyad", soyad);
            komut.Parameters.AddWithValue("@ptc", tc);
            komut.Parameters.AddWithValue("@padr", adres);
            komut.Parameters.AddWithValue("@pdt", dt);
            updatecommand(komut);


        }
        public static void girişEkle(string kullanıcıadı, string şifre, int tip, int pid)
        {
            try
            {
                string trry= "";
                string sql = "insert into giriş values (@pkad,@psifre,@ptc,@pidd)";
                SqlCommand komut = new SqlCommand();
                komut.CommandText = sql;
                komut.Connection = baglanti;
                komut.Parameters.AddWithValue("@pAd", trry);
                komut.Parameters.AddWithValue("@pkad", kullanıcıadı);
                komut.Parameters.AddWithValue("@psifre", şifre);
                komut.Parameters.AddWithValue("@ptc", tip);
                komut.Parameters.AddWithValue("@pidd", pid);
                updatecommand(komut);
            }
            catch (System.Data.SqlClient.SqlException)
            {

            }


        }
        public static int idçekme(string kadi)
        {
            string sql = "select id from Bilgi where kimlikno=@pkadı";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            id = readint(komut,kadi);
            return id;
        }
        public static int tipçekme(string kadi)
        {
            string sql = "select tip from giriş where kullanıcıadı=@pkadı";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            tip = readint(komut,kadi);
            return tip;
        }
        public static int bilgiyükleme()
        {
            string sql = "select * from Bilgi where Id=@pkadı";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pkadı", id);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                adı = rdr.GetString(1);
                soyadı = rdr.GetString(2);
                tc = rdr.GetString(3);
                adres = rdr.GetString(4);
                dt = rdr.GetString(5);

            }
            baglanti.Close();
            return tip;
        }

        public static void Guncelle(string ad, string soyad, string tc, string adr, string dt)
        {
            string sql = "update Bilgi set adı=@padi, soyad=@psoyad,adres=@padr, DoğumTarihi=@pdt where ID=@pkid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut=adblock(komut,ad,soyad, id.ToString(), adr,dt);
            updatecommand(komut);

        }
        public static DataSet sehirlericekk()
        {
            string sql = "select * from Sehir";
            SqlCommand komut = new SqlCommand();
            return dataçek(sql, komut);

        }
        public static DataSet drcek(int hassstid, int polid)
        {
            string sql = "select [Doktor Adı] , kid from Doktorlar where  [Hastane İd]=@pid and polid=@ppid";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@pid", hassstid);
            komut.Parameters.AddWithValue("@ppid", polid);
            return dataçek(sql, komut);

        }
        public static DataSet hastcekk(int hastid)
        {
            string sql = "select hasteneadı,hastaneid from Hastaneler where sehirid=@pid";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@pid", hastid);
            return dataçek(sql, komut);

        }
        public static DataSet polcek()
        {
            string sql = "select PoliklinikAdı,polid from Pol1";
            SqlCommand komut = new SqlCommand();
            return dataçek(sql, komut);

        }

        public static void Guncellerand(string ad, string soyad, string tc, string adr, string dt)
        {
            string sql = "update Bilgi set adı=@padi, soyad=@psoyad,adres=@padr, DoğumTarihi=@pdt where ID=@pkid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut = adblock(komut, ad, soyad, id.ToString(), adr, dt);
            updatecommand(komut);

        }
        public static void Eklerand(int did, int polid, string tarih, string doktornotu,int saat)
        {
            string sql = "insert into Randevular values (@pid,@ppolid,@pdid,@ptrh,@pdnt,@prdt,@psaatid)";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            string rdt = "";
            komut.Parameters.AddWithValue("@pid", id);
            komut.Parameters.AddWithValue("@ppolid", polid);
            komut.Parameters.AddWithValue("@pdid", did);
            komut.Parameters.AddWithValue("@ptrh", tarih);
            komut.Parameters.AddWithValue("@pdnt", doktornotu);
            komut.Parameters.AddWithValue("@prdt", rdt);
            komut.Parameters.AddWithValue("@psaatid", saat);
            updatecommand(komut);


        }
        public static DataSet randkontrol(int did, string tarih,int saat)
        {
            string sql = "select * from Randevular where doktorid=@pdid and Gün=@pgn and saatid=@psid ";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@pdid", did);
            komut.Parameters.AddWithValue("@pgn", tarih);
            komut.Parameters.AddWithValue("@psid", saat);
            return dataçek(sql, komut);

        }
        public static DataSet güncelrand()
        {
            string sql = "select * from Randevular where kullanıcıid=@pdid and randdurum=''";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@pdid", id);
            return dataçek(sql, komut);


        }
        public static DataSet eskirand()
        {
            string sql = "select * from Randevular where kullanıcıid=@pdid and randdurum='1'";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@pdid", id);
            return dataçek(sql, komut);

        }
        public static string dradi(int id)
        {
            string adi = " ";
            string sql = "select [Doktor Adı],[Hastane İd] from Doktorlar where kid=@pid";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@pid", id);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet dtadı = new DataSet();
            baglanti.Open();
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                adi = rdr.GetString(0);
                hastidrg = rdr.GetInt32(1);
            }
            baglanti.Close();
            return adi;

        }
        public static string poladdı(int id)
        {
            string adi = " ";
            string sql = "select PoliklinikAdı from Pol1 where polid=@pid";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@pid", id);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet dtadı = new DataSet();
            baglanti.Open();
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                adi = rdr.GetString(0);
            }
            baglanti.Close();
            return adi;

        }
        public static string hastadı()
        {
            string adi = " ";
            string sql = "select hasteneadı,sehirid from Hastaneler where hastaneid=@pid";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@pid", hastidrg);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet dtadı = new DataSet();
            baglanti.Open();
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                adi = rdr.GetString(0);
                sehiriddd = rdr.GetInt32(1);
            }
            baglanti.Close();
            return adi;

        }
        public static string sehiradııı()
        {
            string adi = " ";
            string sql = "select sehiradı from Sehir where sehirid=@pid";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@pid", sehiriddd);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet dtadı = new DataSet();
            baglanti.Open();
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                adi = rdr.GetString(0);
            }
            baglanti.Close();
            return adi;

        }
        public static void randsil(int randid)
        {
            string sql = "DELETE FROM Randevular WHERE randid=@pid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pid", randid);
            updatecommand(komut);

        }
        public static DataSet güncelranddr()
        {
            string sql = "select * from Randevular where doktorid=@pdid and randdurum=''";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@pdid", id);
            return dataçek(sql, komut);


        }
        public static int bilgiyüklemehst(int hid)
        {
            hiddb = hid;
            string sql = "select * from Bilgi where Id=@pkadı";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pkadı", hid);
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sonucDS = new DataSet();
            baglanti.Open();
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                adı = rdr.GetString(1);
                soyadı = rdr.GetString(2);
                tc = rdr.GetString(3);
                dt = rdr.GetString(5);

            }
            baglanti.Close();
            return tip;
        }
        public static DataSet ziyaretler()
        {
            string sql = "select * from Randevular where doktorid=@pdid and randdurum=1 and kullanıcıid=@phid";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@pdid", id);
            komut.Parameters.AddWithValue("@phid", hiddb);
            return DBislemleri.dataçek(sql, komut);

        }
        public static DataSet tümmuayne()
        {
            string sql = "select * from Randevular where randdurum=1 and kullanıcıid=@phid";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.AddWithValue("@phid", hiddb);
            return DBislemleri.dataçek(sql, komut);

        }
        public static void teshis(int randid, string dnotu)
        {
            string sql = "update Randevular set DoktorNotu=@pnot,randdurum=1 where randid=@pkid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pnot", dnotu);
            komut.Parameters.AddWithValue("@pkid", randid);
            updatecommand(komut);


        }
        public static DataSet saatcek()
        {
            SqlCommand komut = new SqlCommand();
            string sql = "select * from Saatt";
            return DBislemleri.dataçek(sql,komut);

        }
        public static DataSet dataçek(String sql,SqlCommand komut)
        { 
            komut.CommandText = sql;
            komut.Connection = baglanti;
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet ds = new DataSet();
            baglanti.Open();
            adaptor.Fill(ds);
            baglanti.Close();
            return ds;
        }
        public static void updatecommand(SqlCommand komut)
        {
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            

        }
        public static SqlCommand adblock (SqlCommand komut, string ad, string soyad, string tc, string adr, string dt)
        {
            komut.Parameters.AddWithValue("@padi", ad);
            komut.Parameters.AddWithValue("@psoyad", soyad);      
            komut.Parameters.AddWithValue("@pkid", tc);
            komut.Parameters.AddWithValue("@padr", adr);
            komut.Parameters.AddWithValue("@pdt", dt);
            return komut;
        }
        public static int readint (SqlCommand komut,string kadi)
        {
            int x = 0;
            komut.Parameters.AddWithValue("@pkadı", kadi);
            baglanti.Open();
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                x = rdr.GetInt32(0);//
            }
            baglanti.Close();
            return x;
        }
    }
}
