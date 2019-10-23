using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Memory_Game
{
    class Card : Image
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
        }

        public bool IsFlipped()
        {
            return flipped;
        }

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

        public string GetFrontImageUrl()
        {
            return frontImageUrl;
        }

        public string GetBackImageUrl()
        {
            return backImageUrl;
        }

        public void Flip()
        {
            // if (image == frontImage) image = backImage, ELSE image = frontImage
            // if (flipped == false) flipped = true, ELSE flipped = false;
            Image = (Image == frontImage) ? backImage : frontImage;
            flipped = (flipped == false) ? true : false;
        }

    }
}
