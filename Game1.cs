using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Net.Mime;

namespace Platformer;
/// <summary>
/// dotnet mgcb-editor 
/// </summary>
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    


    Entity player;
    Platform platf1 = null;

    private List<Entity> entities = new List<Entity>();
    private Camera camera;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
        player = new Player(Content, new Vector2(180,0));
        platf1 = new Platform(Content, new Vector2(100, 300));
        Entity platf2 = new Platform(Content, new Vector2(450, 300));
        Enemy enemy1 = new Enemy(Content, new Vector2(450, 0));
        camera = new Camera();

        entities.Add(platf2);
        entities.Add(player);
        entities.Add(platf1);
        entities.Add(enemy1);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

       /* foreach (Entity entity in entities)
        {
            entity.Update(gameTime, entities);       
        }*/

        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].Update(gameTime, entities);
        }

        Vector4 playerPosSize = player.getPosSize();
        Vector2 camPos = camera.GetCameraPos();
        int offsetX = 0;

        if (playerPosSize.X - camPos.X > GraphicsDevice.Viewport.Width * 0.6)
        {
            offsetX = (int)((int)playerPosSize.X - (int)camPos.X - GraphicsDevice.Viewport.Width * 0.6);
            
        } else if (playerPosSize.X - camPos.X < GraphicsDevice.Viewport.Width * 0.2)
        {
            offsetX = (int)((int)playerPosSize.X - (int)camPos.X - GraphicsDevice.Viewport.Width * 0.2);
        }

        camera.SetCameraPos(new Vector2(camPos.X + offsetX, camPos.Y));



        // TODO: Add your update logic here


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);


        // TODO: Add your drawing code here

        foreach (Entity entity in entities)
        {
            entity.Draw(_spriteBatch, camera);
        }

        base.Draw(gameTime);
    }
}
