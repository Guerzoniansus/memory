using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Timers;

namespace Memory_Game
{
    public class MemoryGrid
    {

        private Grid grid;
        private int cols;
        private int rows;
        private Difficulty difficulty;
        private int amountOfCards;

        private List<Card> cards;

        private bool hasStarted = false;

        Game game;

        private Card firstCard;
        private Card secondCard;
        private int player1Streak = 0;
        private int player2Streak = 0;
        private int currentPlayer;
        private int amountCollected;

        public static bool isPaused;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid">GameGrid</param>
        /// <param name="cols">Amount of grid columns</param>
        /// <param name="rows">Amount of grid rows</param>
        /// <param name="difficulty">Difficulty</param>
        /// <param name="amountOfCards">Amount of cards/param>
        public MemoryGrid(Grid grid, int cols, int rows, Difficulty difficulty, int amountOfCards)
        {
            game = Game.GetGame();
            cards = new List<Card>();

            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            this.difficulty = difficulty;
            this.amountOfCards = amountOfCards;

            MemoryGrid.isPaused = false;

            InitializeGameGrid(cols, rows);
            AddImages();
        }

        /// <summary>
        /// Deze is speciaal voor wanneer het spel geladen wordt en je al van te voren een bestaande lijst met kaarten hebt (van je save file)
        /// </summary>
        /// <param name="grid">GameGrid</param>
        /// <param name="cols">Amount of grid columns</param>
        /// <param name="rows">Amount of grid rows</param>
        /// <param name="difficulty">Difficulty</param>
        /// <param name="amountOfCards">Amount of Cards</param>
        /// <param name="cards">Pre-existing list of cards</param>
        public MemoryGrid(Grid grid, int cols, int rows, Difficulty difficulty, int amountOfCards, List<Card> cards)
        {
            game = Game.GetGame();
            this.cards = cards;

            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            this.difficulty = difficulty;
            this.amountOfCards = amountOfCards;

            MemoryGrid.isPaused = false;

            int i = 0;
            foreach (Card card in cards)
            {
                if (card.IsFound())
                {
                    i++;
                }
            }
            amountCollected = i;


            InitializeGameGrid(cols, rows);
            LoadImages();
        }

        // Reset the grid
        public void Reset()
        {
            cards = new List<Card>();
            AddImages();

            firstCard = null;
            secondCard = null;
            player1Streak = 0;
            player2Streak = 0;
            currentPlayer = 0;
            amountCollected = 0;
        }

        /// <summary>
        /// Deze is speciaal voor wanneer kaarten geladen worden van een save file
        /// </summary>
        private void LoadImages()
        {
            int i = 0;

            // Verwijder de oude kaarten
            grid.Children.Clear();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (cards[i] == null) continue;

                    Grid.SetColumn(cards[i], col);
                    Grid.SetRow(cards[i], row);
                    cards[i].MouseDown += new MouseButtonEventHandler(CardClick);
                    grid.Children.Add(cards[i]);

                    i++;
                }
            }
        }

        private void AddImages()
        {
            int cardId = 0;

            // TODO bepaal de back image afhankelijk van difficulty
            // ImageSource backImage =

            var images = GetNumbers();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {

                    // TODO: assign a (random) front and back image to every card depending on the difficulty and other stuff, zie powerpoint, replace de twee bitmap images daarmee
                    // ImageSource frontImage =
                    // Replace de line hieronder met: Card card = new Card(cardId, frontImage, backImage) zodra je de TODOS hierboven hebt gedaan;

                    Card card = new Card(cardId, "/img/" + difficulty + "/" + images[cardId] + ".png", "/img/Backgrounds/" + difficulty + "Background.png");
                    
                    //"frontTestImage.png"
                    card.MouseDown += new MouseButtonEventHandler(CardClick);

                    Grid.SetColumn(card, col);
                    Grid.SetRow(card, row);
                    grid.Children.Add(card);

                    cards.Add(card);

                    cardId++;
                }
            }
        }


        private List<int> GetNumbers()
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < (amountOfCards / 2); i++)
            {
                numbers.Add(i + 1);
            }
            numbers.AddRange(numbers);
            numbers = ShuffleList<int>(numbers);
            return numbers;
        }

        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        /// <summary>
        /// Flips the selected back.
        /// </summary>
        public void DelayedCardFlip()
        {
            firstCard.Flip();
            if (secondCard != null)
                secondCard.Flip();
            firstCard = null;
            secondCard = null;
            Game.PlaySound("flip_card_wrong");
            SwitchTurn();
            MemoryGrid.isPaused = false;
            game.GetGameWindow().UpdateWindow();
        }

        /// <summary>
        /// Called when card is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            if (!hasStarted)
            {
                StartGame();
            }

            Card card = (Card)sender;
            if (!card.IsFlipped() && secondCard == null)
            {
                card.Flip();
                Game.PlaySound("flip_card");
                if (firstCard == null)
                {
                    firstCard = card;
                    isPaused = true;
                }
                else if (firstCard.GetFrontImageUrl() == card.GetFrontImageUrl())
                {
                    //Found Correct Card
                    secondCard = card;
                    firstCard.SetFound(true);
                    secondCard.SetFound(true);          
                    firstCard = null;
                    secondCard = null;
                    Game.PlaySound("match");
                    isPaused = false;
                    if (game.IsGameMultiplayer())
                    {
                        amountCollected += 2; 
                        if (amountCollected != amountOfCards)
                        {
                            if (currentPlayer == 1)
                            {
                                game.CalculateScore(player1Streak, game.GetPlayer1());
                                player1Streak += 1;
                            }
                            else
                            {
                                game.CalculateScore(player2Streak, game.GetPlayer2());
                                player2Streak += 1;
                            }
                        }
                        else
                        {
                            //Final pair collected, End Game Multiplayer

                            isPaused = true;
                            Highscores highscores = new Highscores();
                            highscores.TryAddNewScore(new HighscoreData(game.GetPlayer1(), game.GetScore(game.GetPlayer1()), game.GetDifficulty(), true));
                            highscores.TryAddNewScore(new HighscoreData(game.GetPlayer2(), game.GetScore(game.GetPlayer2()), game.GetDifficulty(), true));

                            WinWindow winWindow = new WinWindow();
                            winWindow.Show();
                            
                        }
                    }
                    else
                    {
                        amountCollected += 2;

                        if (amountCollected != amountOfCards)
                        {
                            game.CalculateScore(player1Streak, game.GetPlayer1());
                            player1Streak += 1;
                        }
                        else
                        {
                            //Final pair collected, End Game Singleplayer

                            isPaused = true;
                            Highscores highscores = new Highscores();
                            highscores.TryAddNewScore(new HighscoreData(game.GetPlayer1(), game.GetScore(game.GetPlayer1()), game.GetDifficulty(), false));

                            WinWindow winWindow = new WinWindow();
                            winWindow.Show();
                        }
                    }

                }
                else
                {
                    //Didn't find the correct card
                    secondCard = card;
                    isPaused = true;

                    if (currentPlayer == 1)
                        player1Streak = 0;
                    else
                        player2Streak = 0;

                    
                    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer.Start();
                    delayedFlipActive = true;
                }
            }

            game.GetGameWindow().UpdateWindow();

            // Ik gebruikte de code hieronder om saven en laden te testen. 
            // De 2e kaart (boven aan) savet, de derde kaart (boven aan) laadt als je op ze klikt

            //if (card.getId() == 1)
            //{
            //    SaveUtils.SaveGame();
            //}

            //else if (card.getId() == 2)
            //{
            //    SaveUtils.LoadGame();
            //}

            //else
            //{
            //    card.Flip();
            //}
        }

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private bool delayedFlipActive;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if(delayedFlipActive == true)
            {
                DelayedCardFlip();
                delayedFlipActive = false;
                dispatcherTimer.Stop();
            }
        }

        /// <summary>
        /// Switches the turn to the other player.
        /// </summary>
        public void SwitchTurn()
        {
            if (game.IsGameMultiplayer())
            {
                if (currentPlayer == 1)
                {
                    currentPlayer = 2;
                    game.SetTurn(game.GetPlayer2());
                }
                else
                {
                    currentPlayer = 1;
                    game.SetTurn(game.GetPlayer1());
                }
            }
        }

        /// <summary>
        /// Handles what needs to happen when the game starts.
        /// </summary>
        private void StartGame()
        {
            hasStarted = true;
            
            if (game.GetTurn().Equals(game.GetPlayer1()))
                currentPlayer = 1;

            else if (game.GetTurn().Equals(game.GetPlayer2()))
                currentPlayer = 2;

            game.GetGameWindow().UpdateWindow();
        }

        /// <summary>
        /// Initializes the game grid.
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="rows"></param>
        private void InitializeGameGrid(int cols, int rows)
        {
            grid.RowDefinitions.Clear();
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            grid.ColumnDefinitions.Clear();
            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public List<Card> GetCardsAsList()
        {
            return cards;
        }
    }
}
