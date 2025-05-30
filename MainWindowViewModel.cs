using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RocketSim;
using RocketSimWpf.MonoGameControls;
using SharpDX.Direct3D9;
using System;
using System.Reflection.Metadata;

namespace RocketSimWpf;

public class MainWindowViewModel : MonoGameViewModel
{
    private SpriteBatch _spriteBatch = default!;
   
    private Vector2 _position;
    private float _rotation;
    private Vector2 _origin;
    private Vector2 _scale;
    private float _rotationSign = 1;

    private TexturesAndFonts _textures = new();

    public override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _textures.LoadTextures(Content, GraphicsDevice);
    }

    public override void OnMouseUp(MouseStateArgs mouseState)
    {
        _rotationSign *= -1;
    }

    public override void Update(GameTime gameTime)
    {
        _position = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
        _rotation = (float)Math.Sin(_rotationSign*gameTime.TotalGameTime.TotalSeconds) / 4f;
        _origin = _textures.Rocket.Bounds.Center.ToVector2();
        _scale = Vector2.One;
    }

    public override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_textures.Rocket, _position, null, Color.White, _rotation, _origin, _scale, SpriteEffects.None, 0f);
        _spriteBatch.End();
    }
}
