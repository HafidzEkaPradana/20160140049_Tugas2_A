using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _20160140049_Tugas2_A
{
    class Transaksi
    {
        public void DisplayCustomer()
        {
            int menu;
            Console.WriteLine("Menu :");
            Console.WriteLine();
            Console.WriteLine("1. Tambah Customer");
            Console.WriteLine("2. Daftar Customer");
            Console.WriteLine("3. Kembali ke Menu awal");
            Console.WriteLine("");
            Console.Write("Pilih Menu 1/2/3 : ");
            menu = Convert.ToInt32(Console.ReadLine());
            if (menu == 1)
            {
                Console.Clear();
                new Program().Tampilan();
                new Customer().TambahCustomer();
            }
            else
            {
                Console.WriteLine("Tidak ada menu tersebut");
            }
            Console.ReadLine();
        }
        public void TambahCustomer()
        {

            Console.WriteLine("Tambah :");
            Console.Write("ID_Customer   : ");
            int idCustomer = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nama Customer : ");
            string nama = Convert.ToString(Console.ReadLine());
            Console.Write("Alamat : ");
            string alamat = Convert.ToString(Console.ReadLine());
            Console.Write("Jenis Kelamin (L/P): ");
            string jenis = Convert.ToString(Console.ReadLine());

            try
            {
                SqlConnection con = new SqlConnection("data source=LAPTOP-8MKEQ456; " +
                 "database=Tugas2PABD; Integrated Security=True; User ID=sa;Password=mentepermaib20");
                con.Open();

                SqlCommand sql = new SqlCommand("insert into dbo.Customer (ID_Customer,NamaCustomer,Alamat,Jenis_Kelamin) values ('" + idCustomer + "', '" + nama + "', '" + alamat + "', '" + jenis + "')", con);
                sql.ExecuteNonQuery();
                Console.WriteLine("Data berhasil ditambahkan");
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Gagal menambahkan data customer");
                Console.ReadKey();
            }
            Console.WriteLine("1. Kembali ke Menu awal");
            int kembali = Convert.ToInt32(Console.ReadLine());
            if (kembali == 1)
            {
                Console.Clear();
                new Program().Tampilan();
                new Customer().DisplayCustomer();
            }


        }
    }
}
