using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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

    public int Score = 0;


    HUD hud;
    SpriteFont font1;
    Vector2 fontPos;

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

        //initialize lvl1
        Level1 level1 = new Level1();
        entities = level1.createlevel(Content);

        player = new Player(Content, new Vector2(180,0));
        entities.Add(player);

        hud = new HUD(Content);
        camera = new Camera();
    }


    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Viewport viewport = _graphics.GraphicsDevice.Viewport;
        font1 = Content.Load<SpriteFont>("GameFont");

        // TODO: use this.Content to load your game content here
        fontPos = new Vector2(viewport.Width / 2, viewport.Height / 2);
        {

        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        //Start game when player hits any button
        if (Keyboard.GetState().GetPressedKeyCount() > 0)
        {
            GameState.isGameRunning = true;
        }

        if (GameState.isGameRunning == false)
        {
            return;
        }

        //pause game if player presses P
        if (Keyboard.GetState().IsKeyDown(Keys.P))
        {
            GameState.isGameRunning = false;
        }
            


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



        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        foreach (Entity entity in entities)
        {
            entity.Draw(_spriteBatch, camera);
        }

        //Draw HUD
        hud.Draw(_spriteBatch);
        base.Draw(gameTime);
    }
}