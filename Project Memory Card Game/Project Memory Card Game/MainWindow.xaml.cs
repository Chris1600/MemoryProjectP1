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

namespace Project_Memory_Card_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int NR_OF_ROWS = 4;
        const int NR_OF_COLS = 4;
        MemoryGrid grid;
        

        public MainWindow()
        {
            InitializeComponent();
            grid = new MemoryGrid(GameGrid, NR_OF_ROWS, NR_OF_COLS);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.Reset();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Save game
        }
    }
}
