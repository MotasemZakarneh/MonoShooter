using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        World world;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            world = new World();

            print("Constructor");
        }

        protected override void LoadContent()
        {
            Global.content = Content;
            Global.spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.keyboard = new JG_Keyboard();
            Global.mouse = new JG_Mouse(Vector2.Zero,"Cursor",0,Vector2.One);

            world.Build();
            // TODO: use this.Content to load your game content here
            print("Load Content");
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            print("Initialize");
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            Global.keyboard.Update();
            Global.mouse.Update();
            
            world.Update();
            world.LateUpdate();

            Global.mouse.LateUpdate();
            Global.keyboard.LateUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Global.spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend);

            world.Draw();

            Global.spriteBatch.End();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }




        private void print(object o)
        {
            System.Console.WriteLine(o);
        }
    }

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
