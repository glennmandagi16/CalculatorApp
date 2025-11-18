using System;
using System.Collections.Generic;

namespace CalculatorConsoleApp
{
    class Program
    {
        // List untuk menyimpan riwayat
        static List<string> History = new List<string>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== CALCULATOR SEDERHANA ===");
                Console.WriteLine("1. Penjumlahan");
                Console.WriteLine("2. Pengurangan");
                Console.WriteLine("3. Perkalian");
                Console.WriteLine("4. Pembagian");
                Console.WriteLine("5. Akar Kuadrat");
                Console.WriteLine("6. Pangkat");
                Console.WriteLine("7. Modulus");
                Console.WriteLine("8. Riwayat Perhitungan");
                Console.WriteLine("9. Keluar");
                Console.Write("Pilih menu (1-9): ");

                string pilihan = Console.ReadLine();
                Console.Clear();

                switch (pilihan)
                {
                    case "1":
                        OperasiDuaAngka("Penjumlahan", (a, b) => a + b);
                        break;

                    case "2":
                        OperasiDuaAngka("Pengurangan", (a, b) => a - b);
                        break;

                    case "3":
                        OperasiDuaAngka("Perkalian", (a, b) => a * b);
                        break;

                    case "4":
                        OperasiDuaAngka("Pembagian", (a, b) =>
                        {
                            if (b == 0)
                            {
                                Console.WriteLine("Error: Tidak dapat membagi dengan nol.");
                                return double.NaN;
                            }
                            return a / b;
                        });
                        break;

                    case "5":
                        AkarKuadrat();
                        break;

                    case "6":
                        Pangkat();
                        break;

                    case "7":
                        Modulus();
                        break;

                    case "8":
                        TampilkanHistory();
                        break;

                    case "9":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nTekan ENTER untuk melanjutkan...");
                    Console.ReadLine();
                }
            }
        }

        static void OperasiDuaAngka(string namaOperasi, Func<double, double, double> hitung)
        {
            Console.WriteLine($"=== {namaOperasi} ===");

            double angka1 = InputAngka("Masukkan angka pertama: ");
            double angka2 = InputAngka("Masukkan angka kedua: ");

            double hasil = hitung(angka1, angka2);

            if (!double.IsNaN(hasil))
            {
                Console.WriteLine($"Hasil: {hasil}");
                History.Add($"{namaOperasi}: {angka1} dan {angka2} = {hasil}");
            }
        }

        static void AkarKuadrat()
        {
            Console.WriteLine("=== Akar Kuadrat ===");

            double angka = InputAngka("Masukkan angka: ");

            if (angka < 0)
            {
                Console.WriteLine("Error: Akar kuadrat bilangan negatif tidak real.");
                return;
            }

            double hasil = Math.Sqrt(angka);
            Console.WriteLine($"Hasil: {hasil}");

            History.Add($"Akar Kuadrat: {angka} = {hasil}");
        }

        static void Pangkat()
        {
            Console.WriteLine("=== Pangkat ===");

            double basis = InputAngka("Masukkan bilangan dasar: ");
            double eksponen = InputAngka("Masukkan eksponen: ");

            double hasil = Math.Pow(basis, eksponen);
            Console.WriteLine($"Hasil: {hasil}");

            History.Add($"Pangkat: {basis}^{eksponen} = {hasil}");
        }

        static void Modulus()
        {
            Console.WriteLine("=== Modulus ===");

            double a = InputAngka("Masukkan angka pertama: ");
            double b = InputAngka("Masukkan angka kedua: ");

            if (b == 0)
            {
                Console.WriteLine("Error: Modulus dengan nol tidak dapat dilakukan.");
                return;
            }

            double hasil = a % b;
            Console.WriteLine($"Hasil: {hasil}");

            History.Add($"Modulus: {a} % {b} = {hasil}");
        }

        static void TampilkanHistory()
        {
            Console.WriteLine("=== Riwayat Perhitungan ===");

            if (History.Count == 0)
            {
                Console.WriteLine("Belum ada riwayat.");
                return;
            }

            foreach (var item in History)
                Console.WriteLine(item);
        }

        static double InputAngka(string pesan)
        {
            double angka;
            while (true)
            {
                Console.Write(pesan);
                if (double.TryParse(Console.ReadLine(), out angka))
                    return angka;

                Console.WriteLine("Input tidak valid, masukkan angka yang benar.");
            }
        }
    }
}
