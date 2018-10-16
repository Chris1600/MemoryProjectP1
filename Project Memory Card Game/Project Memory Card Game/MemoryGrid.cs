using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Project_Memory_Card_Game
{
    public class MemoryGrid
    {
        private Grid grid;
        private int rows, cols;

        public MemoryGrid(Grid grid, int rows, int cols)
        {
            this.grid = grid;
            this.rows = rows;
            this.cols = cols;

            InitializeGrid();
            AddImage();
        }

        private void InitializeGrid()
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void ClearGrid()
        {
            grid.Children.Clear();
        }

        private void AddImage()
        {
            List<ImageSource> images = GetImagesList();

            Random random = new Random();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Image ImageOnBacksideOfCard = new Image();
                    ImageOnBacksideOfCard.Source = new BitmapImage(new Uri("project/achterkant.png", UriKind.Relative));

                    //Ruimte tussen kaartjes
                    Thickness margin = ImageOnBacksideOfCard.Margin;
                    margin.Top = 10;
                    ImageOnBacksideOfCard.Margin = margin;

                    //Randomize kaartjes op de grid
                    ImageOnBacksideOfCard.MouseDown += new MouseButtonEventHandler(CardClick);
                    int randomPositie = random.Next(images.Count);
                    ImageOnBacksideOfCard.Tag = images[randomPositie];
                    images.RemoveAt(randomPositie);
                    Grid.SetColumn(ImageOnBacksideOfCard, col);
                    Grid.SetRow(ImageOnBacksideOfCard, row);
                    grid.Children.Add(ImageOnBacksideOfCard);
                }
            }
        }

        public void Reset()
        {
            ClearGrid();
            AddImage();
        }


        //static bool Match(bool check)
        //{
        //    List<ImageSource> images = GetImagesList();
        //    switch (check)
        //    {
        //        case (images[0] == images[8]):
        //        case (images[1] == images[9]):
        //        case (images[2] == images[10]):
        //        case (images[3] == images[11]):
        //        case (images[4] == images[12]):
        //        case (images[5] == images[13]):
        //        case (images[6] == images[14]):
        //        case (images[7] == images[15]):
        //            return true;
        //        default:
        //            return false;
        //    }
        //}



        //Kaarten draaien om op klik
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
        }

        //Plaatsjes inladen
        private static List<ImageSource> GetImagesList()
        {
            List<ImageSource> images = new List<ImageSource>();

            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("project/" + imageNr + ".jpg", UriKind.Relative));
                images.Add(source);
            }

            return images;
        }

     
    }
}