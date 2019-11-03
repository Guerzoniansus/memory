using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Memory_Game
{
    class Game
    {

        private static Game game;

        // Misschien verschillende tijden per difficulty, 300 seconden = 5 min
        public const int STARTING_TIME = 20;

        // TODO wat constanten voor de score formules

        // TODO kiezen welke van de twee we gebruiken:
        private string player1, player2;
        private List<string> players;

        private MemoryGrid memoryGrid;

        private Difficulty difficulty;
        private bool isMultiplayer;
        private int time;
        public string turn; // player name whose turn it is
        private int amountOfCards;

        private MainWindow gridWindow;

        // String = player, double = de score van de player
        private Dictionary<string, double> scores;

        private GameWindow gameWindow;

        public static MediaPlayer mediaPlayer = new System.Windows.Media.MediaPlayer();

        public bool HasStarted;

        // Public constants for score formulas
        public const double scoreMatchBonus = 100;
        public const double scoreStreakBonusEasy = 20;
        public const double scoreStreakBonusMedium = 30;
        public const double scoreStreakBonusHard = 50;
        public const double scoreTimeBonusEasy = 2.5;
        public const double scoreTimeBonusMedium = 2.75;
        public const double scoreTimeBonusHard = 3;
        public const double scoreStreakMaxEasy = scoreStreakBonusEasy + 100;
        public const double scoreStreakMaxMedium = scoreStreakBonusMedium + 100;
        public const double scoreStreakMaxHard = scoreStreakBonusHard + 100;
        public Game()
        {
            // For debugging purposes, you're supposed to change these yourself somewhere else from user input
            this.player1 = "undefined";
            this.player2 = "undefined2";
            this.difficulty = Difficulty.UNDEFINED;
            this.isMultiplayer = false;
            this.time = STARTING_TIME;
            this.turn = player1;
            this.amountOfCards = 16;
            scores = new Dictionary<string, double>();
            scores.Add(player1, 0);
            scores.Add(player2, 0);

            HasStarted = false;
        }

        /// <summary>
        /// Set the static instance of the game object that can be used in other classes
        /// </summary>
        /// <param name="game">The game object to use</param>
        public static void SetGame(Game game)
        {
            Game.game = game;
        }

        /// <summary>
        /// Use Game.GetGame() to get the static object that's the same for every class
        /// </summary>
        /// <returns>The game</returns>
        public static Game GetGame()
        {
            return Game.game;
        }

        /// <summary>
        /// Set the instance of the GameWindow that is used to display the game
        /// </summary>
        /// <param name="window">The GameWindow instance that is being used</param>
        public void SetGameWindow(GameWindow window)
        {
            this.gameWindow = window;
        }

        /// <summary>
        /// Get the Game Window that the game is currently using
        /// </summary>
        /// <returns>GameWindow currently in use</returns>
        public GameWindow GetGameWindow()
        {
            return gameWindow;
        }

        /// <summary>
        /// Resets the game. Resets time, turn, scores, resets the grid and updates the window
        /// </summary>
        public void Reset()
        {
            this.time = STARTING_TIME;
            this.turn = player1;
            scores = new Dictionary<string, double>();
            scores.Add(player1, 0);
            scores.Add(player2, 0);
            memoryGrid.Reset();

            gameWindow.UpdateWindow();
        }

        /// <summary>
        /// Sets the grid the game uses
        /// </summary>
        /// <param name="grid">A MemoryGrid instance</param>
        public void SetGrid(MemoryGrid grid)
        {
            this.memoryGrid = grid;
        }

        /// <summary>
        /// Get the MemoryGrid the game uses
        /// </summary>
        /// <returns>The MemoryGrid the game uses</returns>
        public MemoryGrid GetGrid()
        {
            return memoryGrid;
        }

        /// <summary>
        /// Easy lazy static method to play sounds
        /// </summary>
        /// <param name="sound">Name of the sound file, without path or file extension</param>
        public static void PlaySound(string sound)
        {
            //var player = new System.Windows.Media.MediaPlayer();
            mediaPlayer.Open(new Uri(@"sounds\" + sound + ".wav", UriKind.Relative));
            mediaPlayer.Play();
        }

        /// <summary>
        /// Easy lazy static method to play background music, which automatically chooses the song depending on the difficulty
        /// </summary>
        public static void PlayMusic()
        {
            StopMusic();
            string musicToPlay = "bgmusic_easy";

            switch (Game.GetGame().GetDifficulty())
            {
                case Difficulty.MEDIUM: musicToPlay = "bgmusic_medium";
                    break;
                case Difficulty.HARD: musicToPlay = "bgmusic_hard";
                    break;
                case Difficulty.EASY: musicToPlay = "bgmusic_easy"; 
                    break;
            }

            SoundPlayer player = new SoundPlayer(@"sounds\" + musicToPlay + ".wav");
            player.PlayLooping();
            player.Dispose();
        }

        /// <summary>
        /// Easy lazy static method to stop the background music
        /// </summary>
        public static void StopMusic()
        {
            SoundPlayer player = new SoundPlayer(@"sounds\bgmusic.wav");
            player.Stop();
            player.Dispose();
        }

        // Old code that is no longer used
        //public void SetGridWindow(MainWindow window)
        //{
        //    this.gridWindow = window;
        //}

        //public MainWindow GetGridWindow()
        //{
        //    return gridWindow;
        //}

        /// <summary>
        /// Set the names of the players
        /// </summary>
        /// <param name="player1">The name of player 1</param>
        /// <param name="player2">The name of player 2</param>
        public void SetPlayers(string player1, string player2)
        {
            this.player1 = player1;
            this.player2 = player2;

            // Try catch to fix a stupid bug: "Er is al een item met dezelfde sleutel toegevoegd."
            try
            {
               scores.Add(player1, 0);
               scores.Add(player2, 0);
            }
            catch (System.ArgumentException e)
            {
                scores[player1] = 0;
                scores[player2] = 0;
            }

            
            SetTurn(player1);
        }

        /// <summary>
        /// Get the current score of a player
        /// </summary>
        /// <param name="player">The name of the player you want to know the score of</param>
        /// <returns></returns>
        public double GetScore(string player)
        {
            return scores[player];
        }

        /// <summary>
        /// See whose turn it is
        /// </summary>
        /// <returns>The name of the player whose turn it is</returns>
        public string GetTurn()
        {
            return turn;
        }

        /// <summary>
        /// Choose which player's turn it is now
        /// </summary>
        /// <param name="playerName">Name of the player whose turn it is now</param>
        public void SetTurn(string playerName)
        {
            turn = playerName;
            if (gameWindow != null) gameWindow.UpdateWindow();
        }

        /// <summary>
        /// Set the new score of a player
        /// </summary>
        /// <param name="player">Name of the player you want to change the score of</param>
        /// <param name="newScore">New score</param>
        public void SetScore(string player, double newScore)
        {
            scores[player] = newScore;
            if (gameWindow != null) gameWindow.UpdateWindow();
        }

        /// <summary>
        /// Get the score of a player
        /// </summary>
        /// <param name="player">Name of the player whose score you want to get</param>
        /// <returns></returns>
        public double getScore(string player)
        {
            return scores[player];
        }

        /// <summary>
        ///  Set whether or not the game is multiplayer
        /// </summary>
        /// <param name="isTheGameMultiplayer">Whether the game should be multiplayer (true) or not (false) </param>
        public void SetMultiplayer(bool isTheGameMultiplayer)
        {
            isMultiplayer = isTheGameMultiplayer;
        }

        /// <summary>
        /// Check if the game is multiplayer or not
        /// </summary>
        /// <returns>true if multiplayer, false if singleplayer</returns>
        public bool IsGameMultiplayer()
        {
            return isMultiplayer;
        }

        /// <summary>
        /// Set the amount of cards the game should be using
        /// </summary>
        /// <param name="amountOfCards"></param>
        public void SetAmountOfCards(int amountOfCards)
        {
            this.amountOfCards = amountOfCards;
        }

        /// <summary>
        /// Get the amount of cards the game is using
        /// </summary>
        /// <returns>The amount of cards the game is using/returns>
        public int GetAmountOfCards()
        {
            return amountOfCards;
        }

        /// <summary>
        /// Set the difficulty of the game
        /// </summary>
        /// <param name="difficulty">The difficulty of the game</param>
        public void SetDifficulty(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }

        /// <summary>
        /// Get the difficulty of the game
        /// </summary>
        /// <returns>The difficulty of the game</returns>
        public Difficulty GetDifficulty()
        {
            return difficulty;
        }

        /// <summary>
        /// Set the amount of time left in seconds
        /// </summary>
        /// <param name="newTime">New time in seconds</param>
        public void SetTime(int newTime)
        {
            time = newTime;
            if (gameWindow != null) gameWindow.UpdateWindow();
        }

        public int GetTimeLeft()
        {
            return time;
        }

        public string GetPlayer1()
        {
            return player1;
        }

        public string GetPlayer2()
        {
            return player2;
        }

        /// <summary>
        /// Get the name of the player that's in the lead / won the game
        /// </summary>
        /// <returns>"draw" (lowercase) if both players have the same scores. Otherwise return whichever player has the highest score</returns>
        public string GetWinner()
        {
            if (GetScore(player1) == GetScore(player2))
                return "draw";

            return (GetScore(player1) > GetScore(player2)) ? player1 : player2;
        }


        /// <summary>
        /// Gets the current score, calculates the new score and sets it
        /// </summary>
        public void CalculateScore(int streakscore, string player)
        {
            double currentScore = GetScore(player);
            currentScore += scoreMatchBonus;

            switch (GetDifficulty())
            {
                case Difficulty.EASY:
                    currentScore += Clamp((streakscore * Convert.ToInt32(scoreStreakBonusEasy)), 0, Convert.ToInt32(scoreStreakMaxEasy));
                    break;
                case Difficulty.MEDIUM:
                    currentScore += Clamp((streakscore * Convert.ToInt32(scoreStreakBonusMedium)), 0, Convert.ToInt32(scoreStreakMaxMedium));
                    break;
                case Difficulty.HARD:
                    currentScore += Clamp((streakscore * Convert.ToInt32(scoreStreakBonusHard)), 0, Convert.ToInt32(scoreStreakMaxHard));
                    break;
                default:
                    break;
            }

            SetScore(player, currentScore);
        }

        public void AddTimeBonus(int remainingTime)
        {
            double currentScorePlayer1 = GetScore(GetPlayer1());

            switch (GetDifficulty())
            {
                case Difficulty.EASY:
                    SetScore(GetPlayer1(), currentScorePlayer1 + (remainingTime * scoreTimeBonusEasy));
                    break;
                case Difficulty.MEDIUM:
                    SetScore(GetPlayer1(), currentScorePlayer1 + (remainingTime * scoreTimeBonusMedium));
                    break;
                case Difficulty.HARD:
                    SetScore(GetPlayer1(), currentScorePlayer1 + (remainingTime * scoreTimeBonusHard));
                    break;
                default:
                    break;
            }

            if (IsGameMultiplayer())
            {
                double currentScorePlayer2 = GetScore(GetPlayer2());

                switch (GetDifficulty())
                {
                    case Difficulty.EASY:
                        SetScore(GetPlayer2(), currentScorePlayer2 + (remainingTime * scoreTimeBonusEasy));
                        break;
                    case Difficulty.MEDIUM:
                        SetScore(GetPlayer2(), currentScorePlayer2 + (remainingTime * scoreTimeBonusMedium));
                        break;
                    case Difficulty.HARD:
                        SetScore(GetPlayer2(), currentScorePlayer2 + (remainingTime * scoreTimeBonusHard));
                        break;
                    default:
                        break;
                }
            }
        }

        private int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }


    }
}
