using Microsoft.Xna.Framework;
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
        Player player;

        float timeToWait = 100;
        float timeSinceLastSpawn;

        Random rng = new Random();

        public EnemySpawner(Game1 game, Player player)
        {
            this.game = game;
            
            this.player = player;
        }

        public void Update(GameTime gameTime)
        {
            if (player.IsAlive)
            {
                if(timeSinceLastSpawn > timeToWait)
                {
                    timeSinceLastSpawn = 0;
                    SpawnEnemy();
                }
                    timeSinceLastSpawn++;
            }
        }


        public void SpawnEnemy()
        {
            game.enemies.Add(new Enemy(new Vector2(rng.Next(0, 1920), rng.Next(0, 1080))));
        }
    }
}
