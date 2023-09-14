namespace LucyGoosebane;

public class Canvas
{
    private readonly RenderTarget2D _target;
    private Rectangle _destinationRectangle;

    public Canvas(int width, int height)
    {
        _target = new(Globals.GraphicsDevice, width, height);
    }

    public void SetDestinationRectangle()
    {
        var screenSize = Globals.GraphicsDevice.PresentationParameters.Bounds;
        float scaleX = (float) screenSize.Width / _target.Width;
        float scaleY = (float)screenSize.Height / _target.Height;
        float scale = Math.Min(scaleX, scaleY);

        int newWidth = (int)(_target.Width * scale);
        int newHeight = (int)(_target.Height * scale);

        int posX = (screenSize.Width - newWidth) / 2;
        int posY = (screenSize.Height - newHeight) / 2;

        _destinationRectangle = new Rectangle(posX, posY, newWidth, newHeight);

       
    }

    public void Activate()
    {
        Globals.GraphicsDevice.SetRenderTarget(_target);
        Globals.GraphicsDevice.Clear(Color.DarkGray);
    }

    public void Draw()
    {
        Globals.GraphicsDevice.SetRenderTarget(null);
        Globals.GraphicsDevice.Clear(Color.Black);
        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        Globals.SpriteBatch.Draw(_target, _destinationRectangle, Color.White);
        Globals.SpriteBatch.End();
    }
}