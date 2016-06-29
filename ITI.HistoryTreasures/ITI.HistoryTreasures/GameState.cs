﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ITI.HistoryTreasures
{
    public class GameState
    {
        string _name;
        string _path;
        Game _gCtx;
        Theme _tCtx;
        Level _lCtx;

        //level / theme en cours a sauvegarder
        //sauvegarde entre chaque niveau

        /// <summary>
        /// Initializes a new instance of the <see cref="GameState"/> class.
        /// </summary>
        /// <param name="gCtx">The g CTX.</param>
        /// <param name="name">The name.</param>
        public GameState(Game gctx)
        {
            _gCtx = gctx;
            //_tCtx = _gCtx.CreateTheme(Name);
        }

        public void Save()
        {
            LCtx = GCtx.Check();
            TCtx = LCtx.Theme;

            XElement game = new XElement("GameState",
                new XElement("Game", GCtx),
                new XElement("Theme", TCtx),
                new XElement("Level", LCtx)
                );
            game.Save("./GameState.xml");

            Load();
        }

        public string Load()
        {
            string save;
            XmlTextReader xml = new XmlTextReader("GameState.xml");
            xml.Read();

            while (xml.Read())
            {
                if (xml.Name == "Level")
                {
                    xml.Read();
                    return xml.Value;
                }
            }

            return "";
        }

        public List<Theme> Check()
        {
            foreach (Theme t in GCtx.Themes)
            {
                foreach (Level l in t.Levels)
                {
                    if (l.Name != Load())
                    {
                        l.IsFinish = true;
                    }
                    else
                    {
                        return GCtx.Themes;
                    }
                }
            }
            throw new InvalidOperationException("Not possible");
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The g CTX.
        /// </value>
        public Game GCtx
        {
            get { return _gCtx; }
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The t CTX.
        /// </value>
        public Theme TCtx
        {
            get { return _tCtx; }
            set { _tCtx = value; }
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The l CTX.
        /// </value>
        public Level LCtx
        {
            get { return _lCtx; }
            set { _lCtx = value; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path
        {
            get { return _path; }
        }
    }
}
