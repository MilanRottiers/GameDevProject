using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.enemies
{
    internal class EnemySpawner
    {
        Game1 game;
        Player player;

        Texture2D enemySprite;
        float timeToWait = 100;
        float timeSinceLastSpawn;

        Random rng = new Random();

        public EnemySpawner(Game1 game, Player player, Texture2D enemysprite)
        {
            this.game = game;
            this.enemySprite = enemysprite;
            this.player = player;
        }

        public void Update(GameTime gameTime)
        {
            if (player.IsAlive)
            {
                if (timeSinceLastSpawn > timeToWait)
                {
                    timeSinceLastSpawn = 0;
                    SpawnEnemy();
                }
                timeSinceLastSpawn++;
            }
        }


        public void SpawnEnemy()
        {
            game.enemies.Add(new Enemy(new Vector2(rng.Next(0, 1920), rng.Next(0, 1080)), player, enemySprite, game));
        }
    }
}
