using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{

    class Timer
    {
        private static System.Timers.Timer timer;
        private int seconds;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private int delayedCardFlipTime;
        public bool isGameRunning;
        MemoryGrid grid;
        public Timer(int seconds, MemoryGrid grid)
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            this.seconds = seconds;
            dispatcherTimer.Start();
            this.grid = grid;
        }

        public int GetRemainingTime()
        {
            return seconds;
        }
        public void DelayedCardFlip()
        {
            delayedCardFlipTime = seconds - 2;
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Game.GetGame().HasStarted == false) return;

            Console.WriteLine(seconds + "AAA");
       

            if (isGameRunning)
                seconds--;

            if (Game.GetGame().HasStarted)
                Game.GetGame().SetTime(seconds);

            if(seconds == delayedCardFlipTime)
            {
                grid.DelayedCardFlip();
            }

            if (seconds == 0)
                FinishedCountdown();
           
        }

        public void Dispose()
        {
            dispatcherTimer = null;
        }

        public void FinishedCountdown()
        {
            WinWindow winWindow = new WinWindow();
            winWindow.Show();
        }
    }
}
