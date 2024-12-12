using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    internal class EnemySpawner
    {
        Game1 game;

        public EnemySpawner(Game1 game)
        {
            this.game = game;

            SpawnEnemy();
        }

        public void SpawnEnemy()
        {
            game.enemies.Add(new Enemy());
        }
    }
}
