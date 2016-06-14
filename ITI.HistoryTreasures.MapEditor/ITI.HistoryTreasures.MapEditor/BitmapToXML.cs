﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace ITI.HistoryTreasures.MapEditor
{
    public class BitmapToXML
    {
        Bitmap b = Properties.Resources._base;
        List<XElement> xElements = new List<XElement>();

        public BitmapToXML()
        {
            XElement map = new XElement("Map",
                    Translate()
                );
            map.Save("Test.xml");
            string str = File.ReadAllText("Test.xml");
            MessageBox.Show(str);
        }

        public List<XElement> Translate()
        {
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    Color p = b.GetPixel(i, j);

                    if (p.Name == "ff4040c0")
                    {
                        xElements.Add(new XElement("Tile", "Water"));
                    }
                    else if (p.Name == "ff08040")
                    {
                        xElements.Add(new XElement("Tile", "Floor"));
                    }
                    else if (p.Name == "ff800000")
                    {
                        xElements.Add(new XElement("Tile", "Bridge"));
                    }
                    else if (p.Name == "ff000000")
                    {
                        xElements.Add(new XElement("Tile", "Home"));
                    }
                    else if (p.Name == "ff040c0")
                    {
                        xElements.Add(new XElement("Tile", "PNJ"));
                    }
                    else if (p.Name == "ffe02040")
                    {
                        xElements.Add(new XElement("Tile", "Clue"));
                    }
                }
            }
            return xElements;
        }
    }
}
