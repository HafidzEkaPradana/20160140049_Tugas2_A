using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160140049_Tugas2_A
{
    /// <summary>
    /// Customer Class
    /// </summary>

    class Customer
    {
        string constring = "data source=LAPTOP-8MKEQ456; " +
                 "database=Tugas2PABD; Integrated Security=True; User ID=sa;Password=mentepermaib20";
        SqlConnection connection;
        SqlCommand com;
        /// <summary>
        /// Method DisplayMenuCustomer
        /// </summary>
        /// <remarks>Untuk menampilkan menu di Customer</remarks>
        public void DisplayMenuCustomer()
        {
            int menu;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Customer :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("1. Tambah Customer");
            Console.WriteLine("2. Daftar Customer");
            Console.WriteLine("3. Kembali ke Home");
            Console.WriteLine("");
            Console.Write("Pilih Menu 1/2/3 : ");
            menu = Convert.ToInt32(Console.ReadLine());
            if (menu == 1)
            {
                Console.Clear();
                new Program().Tampilan();
                new Customer().TambahCustomer();
            }
            else if (menu == 2)
            {
                Console.Clear();
                new Program().Tampilan();
                new Customer().AmbilDataCustomer();
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
        /// Method TambahCustomer
        /// </summary>
        /// <remarks>Untuk menambahkan customer kedalam tabel Customer di SQL</remarks>
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
 
                string sql =  "insert into dbo.Customer (ID_Customer,NamaCustomer,Alamat,Jenis_Kelamin) values ('" + idCustomer + "', '" + nama + "', '" + alamat + "', '" + jenis + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Data berhasil ditambahkan");
            }
            catch(Exception e)
            {
                Console.WriteLine("Gagal menambahkan data customer");
                Console.ReadKey();
            }
            Console.WriteLine("1. Kembali ke Menu awal");
            int kembali = Convert.ToInt32(Console.ReadLine());
            if(kembali == 1)
            {
                Console.Clear();
                new Program().Tampilan();
                new Customer().DisplayMenuCustomer();
            }


        }
        /// <summary>
        /// Method AmbilDataCustomer
        /// </summary>
        /// <remarks>Untuk mengambil data dari database</remarks>
        public void AmbilDataCustomer()
        {
            string sql = "select ID_Customer, NamaCustomer, Alamat, Jenis_Kelamin from dbo.Customer";
            connection = new SqlConnection(constring);
            com = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = com.ExecuteReader();
            connection.Close();
            Console.WriteLine("Sudah dipanggil tetapi belum ditampilkan");
            Console.WriteLine();
            Console.Write("Tekan apapun Untuk kembali");
            Console.Clear();
            new Program().Tampilan();
            new Customer().DisplayMenuCustomer();
        }
        

    }
}
