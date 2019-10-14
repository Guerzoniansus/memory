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

        public ImageSource image
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
            image = backImage;

            this.flipped = false;
            this.found = false;
        }

        public bool isFlipped()
        {
            return flipped;
        }

        public bool isFound()
        {
            return found;
        }

        public void setFoundTrue()
        {
            found = true;
        }


        public void flip()
        {
            // if (image == frontImage) image = backImage, ELSE image = frontImage
            // if (flipped == false) flipped = true, ELSE flipped = false;
            image = (image == frontImage) ? backImage : frontImage;
            flipped = (flipped == false) ? true : false;
        }

    }
}
