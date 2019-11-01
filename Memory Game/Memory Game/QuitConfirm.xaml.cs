using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Memory_Game
{
    /// <summary>
    /// Interaction logic for QuitConfirm.xaml
    /// </summary>
    public partial class QuitConfirm : Window
        
    {
        // Needed to prevent crashes
        private bool isClosing;

        public QuitConfirm()
        {
            InitializeComponent();

            isClosing = false;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            isClosing = true;
            Environment.Exit(0);
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            Game.PlaySound("click");
            isClosing = true;
            Close();          
        }

        private void MyMouseEnterEvent(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = Brushes.LightGray;
        }

        private void MyMouseLeaveEvent(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Background = Brushes.White;
        }

        /// <summary>
        /// Makes sure that if you click outside the window (and the window gets minimized), it actually gets closed.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);

            // This is needed to prevent crashses (checks if a player manually clicked on close instead of clicking outside the window)
            if (isClosing == false) Close();
        }
    }
}
