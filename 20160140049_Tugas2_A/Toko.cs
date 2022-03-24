using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _20160140049_Tugas2_A
{
    class Toko
    {
        public void DisplayMenuToko()
        {
            int menu;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Toko :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("1. Tambah Toko");
            Console.WriteLine("2. Daftar Toko");
            Console.WriteLine("3. Kembali Menu Toko");
            Console.WriteLine("4. Kembali ke Home");
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
            else if (menu == 3)
            {
                Console.Clear();
                new Program().Tampilan();
                new Toko().DisplayMenuToko();
            }else if(menu == 4)
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
                SqlConnection con = new SqlConnection("data source=LAPTOP-8MKEQ456; " +
                 "database=Tugas2PABD; Integrated Security=True; User ID=sa;Password=mentepermaib20");
                con.Open();

                SqlCommand sql = new SqlCommand("insert into dbo.Customer (ID_Toko,NamaToko,Loaksi,Pemilik) values ('" + idToko + "', '" + namaToko + "', '" + lokasi + "', '" + pemilik + "')", con);
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
                new Toko().DisplayMenuToko();
            }


        }
    }
}
