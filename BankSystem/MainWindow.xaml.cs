using System;
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

namespace BankSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BanksysteemDataContext db;
        public MainWindow()
        {
            InitializeComponent();
           db = new BanksysteemDataContext();
            SetData();
        }

        private void SetData()
        {
            canvas.Children.Clear();
            CVmain M = new CVmain(db);
            canvas.Children.Add(M);
        }

        private void btnRekeningen_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            CVtypen T = new CVtypen(db);
            canvas.Children.Add(T);
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            CVmain M = new CVmain(db);
            canvas.Children.Add(M);
        }

        private void btnKlanten_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            CVklanten K = new CVklanten(db);
            canvas.Children.Add(K);
        }
    }
}
