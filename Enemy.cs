﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Enemy : Entity
    {
        private float speed = 100f;
        private float gravity = 10;
        private float velocityY = 0;
        public Enemy(ContentManager cm, Vector2 startPos) : base(cm, "enemy1", startPos, EntityType.Enemy)
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
                        entities.Remove(this);
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
