using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _20160140049_Tugas2_A
{
    /// <summary>
    /// Transaksi Class
    /// </summary>
    class Transaksi
    {
        /// <summary>
        /// Method DisplayMenuTransaksi
        /// </summary>
        /// <remarks>Untuk menampilkan menu di Transaksi</remarks>
        string constring = "data source=LAPTOP-8MKEQ456; " +
                 "database=Tugas2PABD; Integrated Security=True; User ID=sa;Password=mentepermaib20";
        SqlConnection connection;
        SqlCommand com;
        public void DisplayMenuTransaksi()
        {
            int menu;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Transaksi :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("1. Sewa Toko");
            Console.WriteLine("2. Daftar Sewa");
            Console.WriteLine("3. Kembali ke Home");
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
                new Program().Menu();
            }
            else
            {
                Console.WriteLine("Tidak ada menu tersebut");
                Console.WriteLine("Tekan tombol apapun untuk kembali");
                Console.ReadKey();
                Console.Clear();
                new Program().Tampilan();
                new Program().Menu();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Method SewaToko
        /// </summary>
        /// <remarks>Untuk menambahkan transaksi sewa kedalam tabel Transaksi di SQL</remarks>
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
                string sql = "insert into dbo.Transaksi (ID_Transaksi,Biaya,ID_Toko,ID_Customer) values " +
                    "('" + idTransaksi + "', '" + biaya + "', '" + kontrak + "', 'select into dbo.Toko where id','" + idToko + "' , 'select into dbo.Customer where id', '" + idCustomer + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Data berhasil ditambahkan");
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
        /// <summary>
        /// Method AmbilDataTransaksi
        /// </summary>
        /// <remarks>Untuk mengambil data dari database</remarks>
        public void AmbilDataTransaksi()
        {

        }
    }
}
