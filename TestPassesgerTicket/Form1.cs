using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestPassesgerTicket
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		SqlConnection connection = new SqlConnection(@"Data Source=msyc;Initial Catalog=TestPassengerTicket;Integrated Security=True");
		
		void yolcuListele()
		{
			connection.Open();
			SqlDataAdapter da = new SqlDataAdapter("Select * From TBLYOLCUBILGI", connection);
			DataTable dt = new DataTable();

			da.Fill(dt);
			dataGridView1.DataSource = dt;
			connection.Close();

		}

		void yolcuekle()
		{
			connection.Open();
			SqlCommand command = new SqlCommand("insert into TBLYOLCUBILGI (AD, SOYAD,TELEFON,TC,CINSIYET,MAIL) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);

			command.Parameters.AddWithValue("@p1", TxtYolcuAd.Text);
			command.Parameters.AddWithValue("@p2", TxtYolcuSoyad.Text);
			command.Parameters.AddWithValue("@p3", MskYolcuTelefon.Text);
			command.Parameters.AddWithValue("@p4", MskYolcuTC.Text);
			command.Parameters.AddWithValue("@p5", CmbYolcuCinsiyet.Text);
			command.Parameters.AddWithValue("@p6", TextYolcuMail.Text);

			command.ExecuteNonQuery();
			connection.Close();
		}
		
		private void BtnYolcuKaydet_Click(object sender, EventArgs e)
		{
			yolcuListele();
			yolcuekle();
		}

		void seferListesi()
		{
			connection.Open();
			SqlDataAdapter da = new SqlDataAdapter("Select * From TBLSEFERBILGI", connection);

			DataTable dt = new DataTable();	
			da.Fill(dt);

			dataGridView2.DataSource = dt;
			connection.Close();
		}




		private void Form1_Load(object sender, EventArgs e)
		{
			yolcuListele();
			seferListesi();
		}

		private void BtnKaptanOlustur_Click(object sender, EventArgs e)
		{
			connection.Open();

			SqlCommand command = new SqlCommand("insert into TBLKAPTAN (KAPTANNO,ADSOYAD,TELEFON) values (@p1,@p2,@p3)", connection);

			command.Parameters.AddWithValue("@p1", TxtKaptanNo.Text);
			command.Parameters.AddWithValue("@p2",TxtKaptanAdSoyad.Text);
			command.Parameters.AddWithValue("@p3",MskKaptanTel.Text);

			command.ExecuteNonQuery();

			connection.Close();
		}

		private void BtnSeferOlustur_Click(object sender, EventArgs e)
		{
			connection.Open();

			SqlCommand command = new SqlCommand("insert into TBLSEFERBILGI (KALKIS, VARIS, TARIH, SAAT, KAPTAN, FIYAT) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);

			command.Parameters.AddWithValue("@p1",TxtKalkis.Text);
			command.Parameters.AddWithValue("@p2",TxtVaris.Text);
			command.Parameters.AddWithValue("@p3",MskTarih.Text);
			command.Parameters.AddWithValue("@p4",MskSaat.Text);
			command.Parameters.AddWithValue("@p5", MskKaptan.Text);
			command.Parameters.AddWithValue("@p6",TxtFiyat.Text);

			command.ExecuteNonQuery();

			connection.Close();
			seferListesi();


		}

		private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int secilen = dataGridView2.SelectedCells[0].RowIndex;

			TxtSeferNumara.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();



		}

		private void button2_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "1";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "2";
		}

		private void button4_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "3";
		}

		private void button5_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "4";
		}

		private void button6_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "5";
		}

		private void button7_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "6";
		}

		private void button8_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "7";
		}

		private void button9_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "8";
		}

		private void button10_Click(object sender, EventArgs e)
		{
			TxtKoltukNo.Text = "9";
		}

		private void BtnRezervasyonYap_Click(object sender, EventArgs e)
		{
			connection.Open();

			SqlCommand command = new SqlCommand("insert into TBLSEFERDETAY (SEFERNO,YOLCUTC,KOLTUK) values (@p1,@p2,@p3)", connection);

			command.Parameters.AddWithValue("@p1", TxtSeferNumara.Text);
			command.Parameters.AddWithValue("@p2",TxtSeferYolcuTC.Text);
			command.Parameters.AddWithValue("@p3", TxtKoltukNo.Text);
			command.ExecuteNonQuery();

			connection.Close();
			seferListesi();

		}
	}
}
