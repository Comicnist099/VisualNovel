using Godot;

namespace Scripts.Data.Class.Dialogue
{
    public class ImageConfig
    {
        public Texture2D Texture { get; }
        public Vector2 Position { get; }
        public Vector2 Scale { get; }

        public ImageConfig(
            Texture2D texture,
            Vector2 position,
            Vector2 scale
        )
        {
            Texture = texture;
            Position = position;
            Scale = scale;
        }

        public void ApplyTo(
            Sprite2D sprite
        )
        {
            if (sprite == null)
            {
                GD.PrintErr(
                    "Sprite2D es NULL."
                );

                return;
            }

            sprite.Texture = Texture;
            sprite.Position = Position;
            sprite.Scale = Scale;
        }
    }
}
