using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Memory_Game
{
    class MemoryGrid
    {

        private Grid grid;
        private int cols;
        private int rows;
        private Difficulty difficulty;
        private int amountOfCards;

        private List<Card> cards;

        Game game;

        public MemoryGrid(Grid grid, int cols, int rows, Difficulty difficulty, int amountOfCards)
        {
            game = Game.getGame();
            cards = new List<Card>();

            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            this.difficulty = difficulty;
            this.amountOfCards = amountOfCards;

            InitializeGameGrid(cols, rows);
            AddImages();
        }

        private void AddImages()
        {
            int cardId = 0;

            // TODO bepaal de back image afhankelijk van difficulty
            // ImageSource backImage =

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {

                    // TODO: assign a (random) front and back image to every card depending on the difficulty and other stuff, zie powerpoint, replace de twee bitmap images daarmee
                    // ImageSource frontImage =

                    // Replace de line hieronder met: Card card = new Card(cardId, frontImage, backImage) zodra je de TODOS hierboven hebt gedaan;
                    Card card = new Card(cardId, new BitmapImage(new Uri("frontTestImage.png", UriKind.Relative)), new BitmapImage((new Uri("backTestImage.png", UriKind.Relative))));

                    card.MouseDown += new MouseButtonEventHandler(CardClick);

                    Grid.SetColumn(card, col);
                    Grid.SetRow(card, row);
                    grid.Children.Add(card);

                    cards.Add(card);

                    cardId++;
                }
            }
        }

        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Card card = (Card)sender;
            card.flip();
        }

        private void InitializeGameGrid(int cols, int rows)
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

        public List<Card> getCardsAsList()
        {
            return cards;
        }

    }
}
