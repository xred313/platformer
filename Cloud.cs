using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class Cloud : Entity
    {
        private float layer;
        public Cloud(ContentManager cm, Vector2 startPos, float layer ) : base(cm, "CloudSmall", startPos, EntityType.Cloud)
        {
            this.layer = layer;
        }

        public override void Draw(SpriteBatch sb, Camera camera = null)
        {
            Texture2D _texture;
            _texture = new Texture2D(sb.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.Red });

            //sb.Begin();
            //sb.Draw(entityTexture, pos, Color.White);

            SpriteEffects doFlip = SpriteEffects.None;

            if (flip)
            {
                doFlip = SpriteEffects.FlipHorizontally;
            }

            Vector2 cameraPos = camera.GetCameraPos();

            int paralaxFactor = 10;

            sb.Draw(entityTexture,
                    new Rectangle((int)pos.X - (int)cameraPos.X / paralaxFactor, (int)pos.Y - (int)cameraPos.Y, entityTexture.Width, entityTexture.Height),
                    //new Rectangle((int)pos.X, (int)pos.Y, entityTexture.Width, entityTexture.Height),
                    null,
                    Color.White * 0.2f,
                    0f,
                    new Vector2(0, 0),
                    doFlip,
                    layer);

            if (_aabb == true)
            {
                //Draw bounding box
                sb.Draw(_texture, new Rectangle((int)pos.X, (int)pos.Y, entityTexture.Width, entityTexture.Height), Color.White);
            }

            //sb.End();

        }

    }
}
