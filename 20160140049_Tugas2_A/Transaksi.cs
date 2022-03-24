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
        public void DisplayMenuTransaksi()
        {
            int menu;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Transaksi :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("1. Sewa Toko");
            Console.WriteLine("2. Daftar Sewa");
            Console.WriteLine("3. Kembali Menu Transaksi");
            Console.WriteLine("4. Kembali ke Home");
            Console.WriteLine("");
            Console.Write("Pilih Menu 1/2/3 : ");
            menu = Convert.ToInt32(Console.ReadLine());
            if (menu == 1)
            {
                Console.Clear();
                new Program().Tampilan();
                new Transaksi().SewaToko();
            }
            else if (menu == 2)
            {
                Console.Clear();
                new Program().Tampilan();
                Console.WriteLine("Belum ada data");
            }
            else if (menu == 3)
            {
                Console.Clear();
                new Program().Tampilan();
                new Customer().DisplayMenuCustomer();
            }
            else if (menu == 4)
            {
                Console.Clear();
                new Program().Tampilan();
                new Program().Menu();
            }
            else
            {
                Console.WriteLine("Tidak ada menu tersebut");
            }
            Console.ReadLine();
        }
        public void SewaToko()
        {

            Console.WriteLine("Sewa Toko :");
            Console.Write("ID_Transaksi   : ");
            int idTransaksi = Convert.ToInt32(Console.ReadLine());
            Console.Write("Biaya : ");
            int biaya = Convert.ToInt32(Console.ReadLine());
            Console.Write("Lama Kontrak : ");
            string kontrak = Convert.ToString(Console.ReadLine());
            Console.Write("ID Toko : ");
            int idToko = Convert.ToInt32(Console.ReadLine());
            Console.Write("ID Customer : ");
            int idCustomer = Convert.ToInt32(Console.ReadLine());

            try
            {
                SqlConnection con = new SqlConnection("data source=LAPTOP-8MKEQ456; " +
                 "database=Tugas2PABD; Integrated Security=True; User ID=sa;Password=mentepermaib20");
                con.Open();

                SqlCommand sql = new SqlCommand("insert into dbo.Customer (ID_Customer,NamaCustomer,Alamat,Jenis_Kelamin) values ('" + idTransaksi + "', '" + biaya + "', '" + kontrak + "', '" + idCustomer + "', '" + idToko + "')", con);
                sql.ExecuteNonQuery();
                Console.WriteLine("Data berhasil ditambahkan");
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Gagal menambahkan data Kontrak");
                Console.ReadKey();
            }
            Console.WriteLine("1. Kembali ke Menu awal");
            int kembali = Convert.ToInt32(Console.ReadLine());
            if (kembali == 1)
            {
                Console.Clear();
                new Program().Tampilan();
                new Transaksi().DisplayMenuTransaksi();
            }


        }
    }
}
