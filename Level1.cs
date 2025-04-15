using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Platformer
{
    class Level1
    {
        public List<Entity> createlevel(ContentManager Content)
        {
            List<Entity> entities = new List<Entity>();

            Random rnd = new Random();

            int x = 10;
            int y = 350;

            // add platforms at random locations

            for (int i = 0; i < 10; i++)
            {
                if (rnd.Next(1, 11) > 6)
                {
                    //add enemy
                    entities.Add(new Enemy(Content, new Vector2(x, 0)));
                }
                entities.Add(new Platform(Content, new Vector2(x, y)));
                x = x + rnd.Next(250, 450);
                y = rnd.Next(100, 300);
            }

            //Platform platf1 = new Platform(Content, new Vector2(100, 300));
            //Entity platf2 = new Platform(Content, new Vector2(450, 300));
            //Enemy enemy1 = new Enemy(Content, new Vector2(450, 0));

            //entities.Add(platf2);
            //entities.Add(platf1);
            //entities.Add(enemy1);

            return entities;
        }
    }
}
