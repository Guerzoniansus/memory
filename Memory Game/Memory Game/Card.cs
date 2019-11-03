using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace Memory_Game
{
    public class Card : Image
    {

        // The current image source
        public ImageSource Image
        {
            get { return this.Source; }
            set { this.Source = value; }
        }

        private int id;

        private bool flipped;
        private bool found;

        private ImageSource frontImage;
        private ImageSource backImage;
        private string frontImageUrl;
        private string backImageUrl;

        /// <summary>
        /// Create a new Card which is a child of Image
        /// </summary>
        /// <param name="id">Card id</param>
        /// <param name="frontImageUrl">Url pointing to the front image, for example: "frontImage.png"</param>
        /// <param name="backImageUrl">Url pointing to the back image, for example: "backImage.png"</param>
        public Card(int id, string frontImageUrl, string backImageUrl)
        {
            this.id = id;
            this.frontImageUrl = frontImageUrl;
            this.backImageUrl = backImageUrl;
            this.backImage = new BitmapImage(new Uri(backImageUrl, UriKind.Relative));
            this.frontImage = new BitmapImage(new Uri(frontImageUrl, UriKind.Relative));
            Image = backImage;

            this.flipped = false;
            this.found = false;

            this.MouseEnter += new MouseEventHandler(MyMouseEnterEvent);
            this.MouseLeave += new MouseEventHandler(MyMouseLeaveEvent);
        }

        /// <summary>
        ///  Use this constructor when loading from a save file instead of generating a new field, to give cards specific properties instead of the default ones
        /// </summary>
        /// <param name="id">Card id</param>
        /// <param name="frontImageUrl">Url pointing to the front image, for example: "frontImage.png"</param>
        /// <param name="backImageUrl">Url pointing to the back image, for example: "backImage.png"</param>
        /// <param name="flipped"> is the card facing front upwards</param>
        /// <param name="found">Has the card been succesfully matched</param>
        public Card(int id, string frontImageUrl, string backImageUrl, bool flipped, bool found)
        {
            this.id = id;
            this.frontImageUrl = frontImageUrl;
            this.backImageUrl = backImageUrl;
            this.backImage = new BitmapImage(new Uri(backImageUrl, UriKind.Relative));
            this.frontImage = new BitmapImage(new Uri(frontImageUrl, UriKind.Relative));

            this.flipped = flipped;
            this.found = found;

            // if not flipped and not found, image = back image, otherwise image = frontImage;
            Image = (flipped == false && found == false) ? backImage : frontImage;

            this.MouseEnter += new MouseEventHandler(MyMouseEnterEvent);
            this.MouseLeave += new MouseEventHandler(MyMouseLeaveEvent);
        }

        private void MyMouseEnterEvent(object sender, MouseEventArgs e) 
        {
            // Add shadow on mouse hover
            this.Effect = new DropShadowEffect() { ShadowDepth = 0, BlurRadius = 10 };
        }

        private void MyMouseLeaveEvent(object sender, MouseEventArgs e)
        {
            // Remove shadow
            this.Effect = null;
        }

        public bool IsFlipped()
        {
            return flipped;
        }

        /// <summary>
        /// Get the ID / index of this card used for the grid and for save files
        /// </summary>
        /// <returns>The ID / index of this card</returns>
        public int getId()
        {
            return id;
        }

        public bool IsFound()
        {
            return found;
        }

        public void SetFound(bool found)
        {
            this.found = found;
        }

        public ImageSource GetFrontImage()
        {
            return frontImage;
        }

        public ImageSource GetBackImage()
        {
            return backImage;
        }

        /// <summary>
        /// Get the image url of the front image. You can use it to check if two cards match
        /// </summary>
        /// <returns>Image url of the front image</returns>
        public string GetFrontImageUrl()
        {
            return frontImageUrl;
        }

        /// <summary>
        /// Get the image url of the back image. You can use it to check if two cards match
        /// </summary>
        /// <returns>Image url of the back image</returns>
        public string GetBackImageUrl()
        {
            return backImageUrl;
        }

        /// <summary>
        /// Changes isFlipped and the current image to the opposite
        /// </summary>
        public void Flip()
        {
            // if (image == frontImage) image = backImage, ELSE image = frontImage
            // if (flipped == false) flipped = true, ELSE flipped = false;
            Image = (Image == frontImage) ? backImage : frontImage;
            flipped = (flipped == false) ? true : false;
        }

    }
}
