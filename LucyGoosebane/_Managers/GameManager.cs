using Microsoft.Xna.Framework.Graphics;

namespace LucyGoosebane;

public class GameManager
{
    private readonly Game _game;
    private readonly GraphicsDeviceManager _graphics;
    private readonly Canvas _canvas;

    private readonly Map _map;
    private readonly Hero _hero;


    public GameManager(Game game, GraphicsDeviceManager graphics)
    {
        _game = game;
        _graphics = graphics;
        _canvas = new(320, 180);
        _map = new();
        _hero = new(Globals.Content.Load<Texture2D>("hero"), new(16, 16));
        SetResolution(1280, 720);
        //SetFullScreen();
    }

    private void SetResolution(int height, int width)
    {
        _graphics.PreferredBackBufferWidth = height;
        _graphics.PreferredBackBufferHeight = width;
        _game.Window.IsBorderless = false;
        _graphics.ApplyChanges();
        _canvas.SetDestinationRectangle();
    }

    private void SetFullScreen()
    {
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _game.Window.IsBorderless = true;
        _graphics.ApplyChanges();
        _canvas.SetDestinationRectangle();
    }

    public void Update()
    {
        _hero.Update();
    }

    public void Draw()
    {
        _canvas.Activate();

        Globals.SpriteBatch.Begin();
        _map.Draw();
        _hero.Draw();
        Globals.SpriteBatch.End();

        _canvas.Draw();
    }
}