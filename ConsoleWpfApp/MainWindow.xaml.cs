using System;
using System.Windows;

namespace CalculatorWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool IsEmpty(string s)
        {
            return s == null || s.Trim() == "";
        }

        private void Hitung_Click(object sender, RoutedEventArgs e)
        {
            // Validasi input
            if (IsEmpty(Input1.Text) || IsEmpty(Input2.Text))
            {
                Output.Text = "Input tidak boleh kosong.";
                return;
            }

            bool ok1 = double.TryParse(Input1.Text, out double angka1);
            bool ok2 = double.TryParse(Input2.Text, out double angka2);

            if (!ok1 || !ok2)
            {
                Output.Text = "Input harus berupa angka.";
                return;
            }

            if (OperationBox.SelectedItem == null)
            {
                Output.Text = "Pilih operasi.";
                return;
            }

            var selected = (OperationBox.SelectedItem as System.Windows.Controls.ComboBoxItem).Tag.ToString();
            double result = 0;

            switch (selected)
            {
                case "add":
                    result = angka1 + angka2;
                    break;
                case "sub":
                    result = angka1 - angka2;
                    break;
                case "mul":
                    result = angka1 * angka2;
                    break;
                case "div":
                    if (angka2 == 0)
                    {
                        Output.Text = "Tidak bisa membagi dengan nol.";
                        return;
                    }
                    result = angka1 / angka2;
                    break;
            }

            Output.Text = "Hasil: " + result;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Input1.Text = "";
            Input2.Text = "";
            OperationBox.SelectedIndex = -1;
            Output.Text = "Hasil akan muncul di sini";
        }
    }
}
