﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ITI.HistoryTreasures
{
    class TileG : Resources
    {
        Image _sprite; //reference to an image
        TileEnum _tileName;

        /// <summary>
        /// Constructor for the Tile 
        /// </summary>
        /// <param name="Sprite"></param>
        /// <param name="tileName"></param>
        public TileG(Image Sprite, TileEnum tileName)
        {
            if (Sprite == null) throw new ArgumentNullException();
            _sprite = Sprite;
            _tileName = tileName;
        }

        /// <summary>
        /// Tile Image
        /// </summary>
        public Image Sprite
        {
            get { return _sprite; }
        }

        public MapDesign MapDesign
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}