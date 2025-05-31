using Microsoft.Xna.Framework.Graphics;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Platformer;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Platformer
{
    public class Sky
    {
        private List<Entity> clouds = new List<Entity>();
        private ContentManager cm;

        public Sky(ContentManager cm)
        {
          this.cm = cm;
        }


        public void Draw(SpriteBatch sb, Camera camera)
        {
            for (int i = 0; i < clouds.Count; i++)
            {
                Entity cloud = clouds[i];
                cloud.Draw(sb, camera);
            }
        }
        private async Task<int> GetCloudCoverAsync()
        {
            string url = "https://api.open-meteo.com/v1/forecast?latitude=59.33&longitude=18.06&current=cloudcover&timezone=Europe%2FStockholm";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);
                    using (JsonDocument doc = JsonDocument.Parse(response))
                    {
                        JsonElement root = doc.RootElement;
                        int cloudCover = root.GetProperty("current").GetProperty("cloudcover").GetInt32();
                        return cloudCover;
                    }
                }
            }
            
            catch (Exception error)
            {
                return 10; // on error use just one cloud
            }
        }

        public async void SetCloudCover()
        {
            Random rnd = new Random();

            int cloudCover = await GetCloudCoverAsync() / 10;
            float layer = 0.0f;

            for (int i = 0; i < cloudCover; i++)
            {
                int x = rnd.Next(0,700);
                int y = rnd.Next(0, 50);
                Vector2 cloudPos = new Vector2(x, y);
                
                Entity newCloud = new Cloud(cm, cloudPos, layer);
                layer += 0.001f;
                clouds.Add(newCloud);
            }

            
        }

        
    }
}
