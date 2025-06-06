﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Platformer;
public class Entity

{
    //declaration
    public enum EntityType
    {
        Player,
        Enemy,
        Bullet,
        Platform,
        Cloud,
        Unknown
    }

    public enum TeamType
    {
        Hero,
        Enemy
    }

    protected EntityType entityType;
    protected bool _aabb = false;
    protected Texture2D entityTexture;
    protected Vector2 pos;
    protected bool flip;
    protected ContentManager contentManager;
    public TeamType Team { get; set; }
    protected float layerDepth = 0.5f;
    protected float alphaBlend = 1.0f;


    //Texturen för entiteten
    public Entity(ContentManager cm, String texture, Vector2 startPos, EntityType entityType = EntityType.Unknown)
    {
        entityTexture = cm.Load<Texture2D>(texture);
        pos = startPos;
        contentManager = cm;
        this.entityType = entityType;

    }

    public virtual void Update(GameTime gameTime, List<Entity> entities)
    {

    }

    public virtual Vector4 getPosSize()
    {
        return new Vector4(pos.X, pos.Y, entityTexture.Width, entityTexture.Height);
    }

    public EntityType GetType()
    {
        return entityType;
    }

    public virtual void Draw(SpriteBatch sb, Camera camera = null)
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
       
        sb.Draw(entityTexture,
                new Rectangle((int)pos.X - (int)cameraPos.X, (int)pos.Y - (int)cameraPos.Y , entityTexture.Width, entityTexture.Height),
                null,
                Color.White * alphaBlend,
                0f,
                new Vector2(0, 0),
                doFlip,
                layerDepth);

        if (_aabb == true)
        {
            //Draw bounding box
            sb.Draw(_texture, new Rectangle((int)pos.X, (int)pos.Y, entityTexture.Width, entityTexture.Height), Color.White);
        }

        //sb.End();

    }
}

