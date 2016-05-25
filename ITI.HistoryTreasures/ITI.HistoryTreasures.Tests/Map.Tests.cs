﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.HistoryTreasures.Tests
{
    [TestFixture]
    class MapTest
    {
        [Test]
        [Ignore("To do")]
        public void Map_array_return_good_value()
        {
        }

        [Test]
        public void Map_can_be_create()
        {
            Game g = new Game();
            Theme t = g.CreateTheme("Theme");
            Level l = t.CreateLevel("Level");
            Map m = new Map(l, 10, 10);

            Assert.That(m, Is.EqualTo(m));
        }

        [Test]
        public void Only_tile_with_isSolid_parameter_on_true_have_hitbox()
        {
            Map m = new Map("test");
            Tile t = new Tile(false, TileEnum.GRASS, m, 16, 16);
            Tile t2 = new Tile(true, TileEnum.WATER, m, 32, 32);

            Assert.That(t.TileHitbox == null);
            Assert.That(t2.TileHitbox != null);
        }
        
        [Test]
        public void Tile_can_be_create_and_have_a_hitbox()
        {
            Map m = new Map("test");
            Tile t = new Tile(true, TileEnum.WATER, m, 16, 16);

            Assert.That(t.TileHitbox.xA== 0);
            Assert.That(t.TileHitbox.yA == 32);
            Assert.That(t.TileHitbox.xB == 32);
            Assert.That(t.TileHitbox.yB == 32);
            Assert.That(t.TileHitbox.xC == 32);
            Assert.That(t.TileHitbox.yC == 0);
            Assert.That(t.TileHitbox.xD == 0);
            Assert.That(t.TileHitbox.yD == 0);
        }
    }
}
