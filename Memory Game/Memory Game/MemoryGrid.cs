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

        private bool hasStarted = false;

        Game game;

        private Card firstCard;
        private Card secondCard;
        private int player1Streak = 0;
        private int player2Streak = 0;
        private int currentPlayer;
        private int amountCollected;

        public bool isPaused = false;
        
        public MemoryGrid(Grid grid, int cols, int rows, Difficulty difficulty, int amountOfCards)
        {
            game = Game.GetGame();
            cards = new List<Card>();

            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            this.difficulty = difficulty;
            this.amountOfCards = amountOfCards;

            isPaused = false;

            InitializeGameGrid(cols, rows);
            AddImages();
        }

        /// <summary>
        /// Deze is speciaal voor wanneer het spel geladen wordt en je al van te voren een bestaande lijst met kaarten hebt (van je save file)
        /// </summary>
        public MemoryGrid(Grid grid, int cols, int rows, Difficulty difficulty, int amountOfCards, List<Card> cards)
        {
            game = Game.GetGame();
            this.cards = cards;

            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            this.difficulty = difficulty;
            this.amountOfCards = amountOfCards;

            isPaused = false;

            InitializeGameGrid(cols, rows);
            LoadImages();
        }
        public void Reset()
        {
            cards = new List<Card>();
            AddImages();
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

        public void DelayedCardFlip()
        {
            firstCard.Flip();
            secondCard.Flip();
            firstCard = null;
            secondCard = null;
            Game.PlaySound("flip_card_wrong");
            SwitchTurn();
            //isPaused = false;
        }
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
                    firstCard = card;
                else if(firstCard.GetFrontImageUrl() == card.GetFrontImageUrl())
                {
                    //Found Correct Card
                    firstCard = null;
                    secondCard = null;
                    Game.PlaySound("match");
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
                            timer.isGameRunning = false;
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
                            timer.isGameRunning = false;
                            game.AddTimeBonus(timer.GetRemainingTime());
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
                    timer.DelayedCardFlip();
                    if (currentPlayer == 1)
                        player1Streak = 0;
                    else
                        player2Streak = 0;

                }
            }

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
        Timer timer;
        

        private void StartGame()
        {
            hasStarted = true;
            timer = new Timer(game.GetTimeLeft(), this);
            timer.isGameRunning = true;
            game.SetTurn(game.GetPlayer1());
            currentPlayer = 1;
            game.GetGameWindow().UpdateWindow();
        }

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
