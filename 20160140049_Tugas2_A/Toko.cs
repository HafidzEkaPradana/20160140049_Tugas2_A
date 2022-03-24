using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _20160140049_Tugas2_A
{
    /// <summary>
    /// Class Toko
    /// </summary>
    class Toko
    {
        /// <summary>
        /// Method DisplayMenuToko
        /// </summary>
        /// <remarks>Untuk menampilkan menu di toko</remarks>


        
        string constring = "data source=LAPTOP-8MKEQ456; " +
                 "database=Tugas2PABD; Integrated Security=True; User ID=sa;Password=mentepermaib20";
        SqlConnection connection;
        SqlCommand com;
        public void DisplayMenuToko()
        {
            int menu;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Toko :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("1. Tambah Toko");
            Console.WriteLine("2. Daftar Toko");
            Console.WriteLine("3. Kembali ke Home");
            Console.WriteLine("");
            Console.Write("Pilih Menu 1/2/3 : ");
            menu = Convert.ToInt32(Console.ReadLine());
            if (menu == 1)
            {
                Console.Clear();
                new Program().Tampilan();
                new Toko().TambahToko();
            }
            else if (menu == 2)
            {
                Console.Clear();
                new Program().Tampilan();
                Console.WriteLine("Belum ada data");
            }
            else if(menu == 3)
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
        /// Method TambahToko
        /// </summary>
        /// <remarks>Untuk menambahkan data ke dalam tabel Toko di SQL</remarks>
        public void TambahToko()
        {

            Console.WriteLine("Tambah :");
            Console.Write("ID_Toko   : ");
            int idToko = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nama Toko : ");
            string namaToko = Convert.ToString(Console.ReadLine());
            Console.Write("Lokasi : ");
            string lokasi = Convert.ToString(Console.ReadLine());
            Console.Write("Pemilik : ");
            string pemilik = Convert.ToString(Console.ReadLine());

            try
            {
                string sql = "insert into dbo.Toko (ID_Toko,NamaToko,Loaksi,Pemilik) values ('" + idToko + "', '" + namaToko + "', '" + lokasi + "', '" + pemilik + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Data berhasil ditambahkan");
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
                new Toko().DisplayMenuToko();
            }


        }
        /// <summary>
        /// Method AmbilDataToko
        /// </summary>
        /// <remarks>Untuk mengambil data dari database</remarks>
        public void AmbilDataToko()
        {

        }
    }
}
