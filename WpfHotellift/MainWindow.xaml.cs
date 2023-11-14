using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHotellift
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Lift> liftek = new List<Lift>();
        int celszint;
        int kartyaszam;

        public MainWindow()
        {
            InitializeComponent();

            File.ReadAllLines("lift.txt").ToList().ForEach(x => liftek.Add(new Lift(x)));
        }

        private void btnFeladat3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"3. feladat: Összes lifthasználat: {liftek.Count}");
        }

        private void btnFeladat4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"4. feladat: Időszak: {liftek[0].Idopont} - {liftek[liftek.Count - 1].Idopont}");
        }

        private void btnFeladat5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"5. feladat: Célszint max: {liftek.Max(x => x.Celszint)}");
        }

        private void btnFeladat6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kartyaszam = int.Parse(txtKartya.Text);
                celszint = int.Parse(txtCelszint.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Hibásan megadott adat");
                celszint = 5;
            }
            MessageBox.Show($"6. feladat:\nKártya száma: {kartyaszam}\nCélszint száma: {celszint}");
        }

        private void btnFeladat7_Click(object sender, RoutedEventArgs e)
        {
            int utazasSzam = liftek.Where(x => x.Celszint == celszint).Count(x => x.Kartyaszam == kartyaszam);

            MessageBox.Show(utazasSzam == 0
                ? $"7. feladat: A(z) {kartyaszam}. kártyával nem utaztak a(z) {celszint}. emeletre!"
                : $"7. feladat: A(z) {kartyaszam}. kártyával utaztak a(z) {celszint}. emeletre!");
        }

        private void btnFeladat8_Click(object sender, RoutedEventArgs e)
        {
            var csoportos = liftek.GroupBy(x => x.Idopont);
            string kiiratas = "8. feladat: Statisztika\n";
            foreach (var datum in csoportos)
            {
                kiiratas += $"{datum.Key} - {liftek.Where(x => x.Idopont == datum.Key).Count()}x\n";
            }
            MessageBox.Show(kiiratas);
        }
    }
}
