using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160140049_Tugas2_A
{
    class Program
    {
        static void Main(string[] args)
        {
            //memanggil method koneksi
            new Program().Connection();
            //memanggil method tampilan
            new Program().Tampilan();
            //memanggil method menu
            new Program().Menu();
            
        }

        public void Connection()
        {
            
            //Membuat koneksi dengan database
            using (SqlConnection con = new SqlConnection("data source=LAPTOP-8MKEQ456; " +
                "database=Tugas2PABD; Integrated Security=True; User ID=sa;Password=mentepermaib20"))
            {
                //membuka database
                con.Open();
            }
        }

        public void Tampilan()
        {
            //Untuk tampilan
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                        Program Penyewaan Toko di MALL                        ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        public void Menu()
        {

            //Menu
            int menu;
            Console.WriteLine();
            Console.WriteLine("Menu : ");
            Console.WriteLine();
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Toko");
            Console.WriteLine("3. Sewa");
            Console.WriteLine("");
            Console.Write("Pilih Menu 1/2/3 : ");
            menu = Convert.ToInt32(Console.ReadLine());
            if (menu == 1)
            {
                Console.Clear();
                new Program().Tampilan();
                new Customer().DisplayMenuCustomer();
            }else if(menu == 2)
            {
                Console.Clear();
                new Program().Tampilan();
                new Toko().DisplayMenuToko();
            }
            else if(menu == 3)
            {
                Console.Clear();
                new Program().Tampilan();
                new Transaksi().DisplayMenuTransaksi();
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
    }
}
