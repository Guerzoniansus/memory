using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Memory_Game
{
    class Card : Image
    {

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


        public Card(int id, ImageSource frontImage, ImageSource backImage)
        {
            this.id = id;
            this.backImage = backImage;
            this.frontImage = frontImage;
            Image = backImage;

            this.flipped = false;
            this.found = false;
        }

        public bool IsFlipped()
        {
            return flipped;
        }

        public bool IsFound()
        {
            return found;
        }

        public void SetFoundTrue()
        {
            found = true;
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
