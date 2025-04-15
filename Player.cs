using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Player : Entity
    {
        private float speed = 200f;
        private float gravity = 5;
        private float velocityY = 0;
        private float fireRate = 0f;
        public Player(ContentManager cm, Vector2 startPos) : base(cm, "Hero1", startPos, EntityType.Player)
        {
        }

        private bool IsCollision(Entity ent)
        {
            Vector4 selfPos = getPosSize();
            Vector4 entPos = ent.getPosSize();

            if (selfPos.X < entPos.X + entPos.Z &&
                selfPos.X + selfPos.Z > entPos.X &&
                selfPos.Y < entPos.Y + entPos.W &&
                selfPos.Y + selfPos.W > entPos.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public override void Update(GameTime gameTime, List<Entity> entities)
        {

            float stepSpeed = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            pos.Y += velocityY;

            var kstate = Keyboard.GetState();


            if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A))
            {
                pos.X -= stepSpeed;

                flip = true;
            }

            if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D))
            {
                pos.X += stepSpeed;

                flip = false;
            }

            if (kstate.IsKeyDown(Keys.K) && fireRate <= 0)
            {
                int xOffset = entityTexture.Width;
                if (flip)
                {
                    xOffset = 0;
                    
                }
                fireRate = 0.2f;
                Bullet bullet1 = new Bullet(contentManager, new Vector2(pos.X + xOffset, pos.Y + entityTexture.Height / 2));
                bullet1.SetFlip(flip);
                entities.Add(bullet1);

            }
            fireRate -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            //check collision
            foreach (var entity in entities)
            {
                if (entity == this )
                {
                    continue;
                }
                if (IsCollision(entity) == true)
                {
                    //boundingBox collision box
                    //_aabb = true;
                    gravity = 0;
                    velocityY = 0;

                    if (kstate.IsKeyDown(Keys.Space))
                    {
                        velocityY = -10;
                    }
                    break;
                }
                else
                {
                    _aabb = false;
                    gravity = 12;
                }
            }

            velocityY += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;


            
            //speed += speed;

        }
    }
}
