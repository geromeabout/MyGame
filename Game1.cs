using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Game1 : Game
{
    Texture2D spacecraftTexture;
    Vector2 spacecraftPosition;
    float spacecraftSpeed;
    Texture2D asteroidTexture;
    Vector2 asteroidPosition;
    float asteroidSpeed;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public Texture2D bulletTexture;
    public Vector2 bulletPosition;
    public float bulletSpeed;
    public bool IsVisible;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        //IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Random rand = new Random();
        spacecraftPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight-50);
        spacecraftSpeed = 100f;
        asteroidPosition = new Vector2(rand.Next(_graphics.PreferredBackBufferWidth), 0);
        asteroidSpeed = 0.5f;
        bulletPosition = new Vector2();
        bulletSpeed = 50f;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        bulletTexture = Content.Load<Texture2D>("bullet");
        spacecraftTexture = Content.Load<Texture2D>("startup");
        asteroidTexture = Content.Load<Texture2D>("meteorite");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up))
        {
            spacecraftPosition.Y -= spacecraftSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if(kstate.IsKeyDown(Keys.Down))
        {
            spacecraftPosition.Y += spacecraftSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kstate.IsKeyDown(Keys.Left))
        {
            spacecraftPosition.X -= spacecraftSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if(kstate.IsKeyDown(Keys.Right))
        {
            spacecraftPosition.X += spacecraftSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if(kstate.IsKeyDown(Keys.Space))
        {
            bulletPosition = new Vector2(_graphics.PreferredBackBufferWidth/2,_graphics.PreferredBackBufferHeight-90);
            bulletPosition.Y -= bulletSpeed;
            IsVisible = true;
        }
        asteroidPosition.Y += asteroidSpeed;
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(spacecraftTexture,
                            spacecraftPosition,
                            null,
                            Color.White,
                            0f,
                            new Vector2(spacecraftTexture.Width / 2, spacecraftTexture.Height / 2),
                            Vector2.One,
                            SpriteEffects.None,
                            0f);
        _spriteBatch.Draw(bulletTexture,
                            bulletPosition,
                            null,
                            Color.White,
                            0f,
                            new Vector2(bulletTexture.Width/2, bulletTexture.Height/2),
                            Vector2.One,
                            SpriteEffects.None,
                            0f);
        _spriteBatch.Draw(asteroidTexture,
                            asteroidPosition,
                            null,
                            Color.White,
                            0f,
                            new Vector2(asteroidTexture.Width/2, asteroidTexture.Height/2),
                            Vector2.One,
                            SpriteEffects.None,
                            0f); 
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
