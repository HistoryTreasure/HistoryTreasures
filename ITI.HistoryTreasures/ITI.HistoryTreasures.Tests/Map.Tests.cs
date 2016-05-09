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
        public void Tile_can_be_create_and_have_a_hitbox()
        {
            Map m = new Map("test");
            Tile t = new Tile(false, TileEnum.GRASS, m, 16, 16);

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
