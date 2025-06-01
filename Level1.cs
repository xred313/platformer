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
            int y = 420;

            // add platforms and enemies at random locations

            for (int i = 0; i < 15; i++)
            {
                if (rnd.Next(1, 11) > 6)
                {
                    //add enemy
                    entities.Add(new Enemy(Content, new Vector2(x, 0)));
                }
                entities.Add(new Platform(Content, new Vector2(x, y)));
                x = x + rnd.Next(350, 550);
                y = rnd.Next(300, 400);
            }

            return entities;
        }
    }
}
 