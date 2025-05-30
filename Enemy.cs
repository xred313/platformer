using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Platformer
{
    class Enemy : Entity
    {
        private float speed = 100f;
        private float gravity = 10;
        private float velocityY = 0;
        private float shootCooldown = 1.5f; // time between shots
        private float shootTimer = 0f;

        public Enemy(ContentManager cm, Vector2 startPos) : base(cm, "enemy1", startPos, EntityType.Enemy)
        {
            this.Team = TeamType.Enemy; 
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


        {
            shootTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (shootTimer <= 0)
            {
                shootTimer = shootCooldown;
                int xOffset = flip ? 0 : entityTexture.Width;
                Bullet bullet = new Bullet(contentManager, new Vector2(pos.X + xOffset, pos.Y + entityTexture.Height / 2));
                bullet.Team = this.Team; // Bullet belongs to shooter's team
                entities.Add(bullet);
                bullet.SetFlip(flip);
            }

            // other enemy update logic
        }

            //check collision
            //foreach (var entity in entities)
            for (var i = 0; i < entities.Count; i++)
            {
                Entity entity = entities[i];
                if (entity == this )
                {
                    continue;
                }
                if (IsCollision(entity) == true)
                {

                    //die if colliding bullet
                    if ( entity.GetType() == EntityType.Bullet )
                    {
                        Bullet bullet = (Bullet)entity;
                        if (bullet.Team != this.Team)
                        {
                            entities.Remove(this); // Enemy dies
                            GameState.score += 1;
                        }

                    }
                    
                    // if touching platform then stop moving down"gravity"
                    if (entity.GetType()== EntityType.Platform)
                    {
                        // _aabb = true;
                        gravity = 0;
                        velocityY = 0;


                        Vector4 entPos = entity.getPosSize();
                        Vector4 selfPos = getPosSize();

                        // checks when to turn around if true turn

                        if (selfPos.X + selfPos.Z > entPos.X + entPos.Z ||
                            selfPos.X < entPos.X)
                        {
                            speed *= -1;
                        }
                    }

                        //break;
                }
            }

            if (speed < 0)
            {
                flip = true;
            }
            else
            {
                flip = false;
            }

                float stepSpeed = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            velocityY += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            pos.Y += velocityY;

            pos.X += stepSpeed;
        }
    }
}