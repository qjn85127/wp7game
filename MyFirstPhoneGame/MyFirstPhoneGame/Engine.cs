using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Utility;

namespace Striker
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Engine : Microsoft.Xna.Framework.Game
    {
        int time = 0;
        int enemyTime = 0;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player _player;
        ControlButtons _btns;
        PlayerBullets _playerBullets;
        Enemies enimies;

        public Engine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";           
            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);
           GlobalValue.ScreenWidth = this.Window.ClientBounds.Width;
           GlobalValue.ScreenHeight = this.Window.ClientBounds.Height;
        }

        protected override void Initialize()
        {
            base.Initialize();
            _player.InitializeDrawing(@"Plane\Player", 1f);
            _btns = new ControlButtons(this.Content, this.spriteBatch);
            _playerBullets = new PlayerBullets(this.Content, this.spriteBatch);
            enimies = new Enemies(this.Content, this.spriteBatch);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _player = new Player(this.Content, this.spriteBatch);
            _player.InitializeDrawing(@"Plane\Player", 1f);
            _player.IntializePosition(GlobalValue.ScreenWidth / 2 + 16f, GlobalValue.ScreenHeight - 200, 32, 32);
            _player.Scale = 2;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
          
            time += gameTime.ElapsedGameTime.Milliseconds;
            enemyTime += gameTime.ElapsedGameTime.Milliseconds;
            if (time > 200)
            {
                time = 0;
                this._playerBullets.Create(_player.Center.X, _player.Center.Y);
            }
            if (enemyTime > 1000)
            {
                enemyTime = 0;
                Random random = new Random();
                int x = random.Next(0, GlobalValue.ScreenWidth);
                this.enimies.Create(x, 0);
            }
            this.enimies.Update();
            this._btns.Update();
            this._player.Update();
            this._playerBullets.Update();

            for (int i = this.enimies.Count - 1; i >= 0; i--)
            {
                for (int k = this._playerBullets.Count - 1; k >= 0; k--)
                {
                    if (enimies[i].Bound.Intersects(this._playerBullets[k].Bound) || enimies[i].Bound.Contains(this._playerBullets[k].Bound))
                    {
                      
                        this.enimies[i].HP = this.enimies[i].HP - this._playerBullets[k].Damage;
                        this.enimies[i].Hit = true;
                        this._playerBullets.RemoveAt(k);
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _btns.Draw();
            // TODO: Add your drawing code here
            this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            
            this._player.Draw();
            _playerBullets.Draw();

            this.spriteBatch.End();

            this.enimies.Draw();
            base.Draw(gameTime);
        }

       
    }
}
