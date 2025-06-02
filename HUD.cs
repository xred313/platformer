using Microsoft.Xna.Framework.Graphics;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Platformer;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;

namespace Platformer
{
    class HUD
    {
        SpriteFont font;
        public HUD(ContentManager cm)
        {
            font = cm.Load<SpriteFont>("GameFont");


        }

        private void DrawText(SpriteBatch sb, string text, Vector2 pos, float scale)
        {
            //Draw HUD

            Vector2 FontOrigin = font.MeasureString(text);
            //sb.Begin();
            sb.DrawString(font, text, pos, Color.BlueViolet, 0,
                                        FontOrigin, scale, SpriteEffects.None, 1f);

            //sb.End();
        }
        public void Draw(SpriteBatch sb)
        {
            string scoreText = "score: " + GameState.score;
            DrawText(sb, scoreText, new Vector2(150, 60), 1.4f);

            if (GameState.isGameRunning == false)
            {
                DrawText(sb, "press to start", new Vector2(550, 200), 2.0f);
            }

            if (GameState.isAlive == false)
            {

                DrawText(sb, "Game over", new Vector2(550, 250), 3.0f);

            }
        }
    }
}
