using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Mime;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Platformer
{
    class Bullet : Entity
    {
        private float speed = 400f;
        private float timeToLive = 0.8f;
        public Entity Owner;

        public Bullet(ContentManager cm, Vector2 startPos) : base(cm, "Bullet1", startPos, EntityType.Bullet)
        {

        }
        
         public override void Update(GameTime gameTime, List<Entity> entities)
        {

            float stepSpeed = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            pos.X += stepSpeed;

            timeToLive -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeToLive < 0)
            {
                entities.Remove(this);
                
            }
        }

        public void SetFlip(bool isFlip)
        {
            flip = isFlip;
            if (flip)
            {
                speed *= -1;
            }
        }
    }
}
