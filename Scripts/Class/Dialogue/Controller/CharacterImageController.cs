using Godot;
using System.Threading.Tasks;

namespace Scripts.Data.Class.Dialogue.Controller
{
    public class CharacterImageController
    {
        private readonly Sprite2D sprite;
        private readonly AnimationManager animationManager;

        private bool isTransitioning = false;


        // =================================
        // DURACIONES
        // =================================

        private const float FadeDuration = 0.12f;
        private const float BounceDuration = 0.05f;
        private const float ReturnDuration = 0.03f;


        public CharacterImageController(
            Sprite2D sprite,
            AnimationManager animationManager
        )
        {
            this.sprite = sprite;
            this.animationManager = animationManager;
        }


        public async Task Show(
            ImageConfig image
        )
        {
            if (!Validate(image))
                return;

            if (isTransitioning)
                return;

            isTransitioning = true;


            // =================================
            // SALIR
            // =================================

            if (sprite.Texture != null)
            {
                await animationManager.Fade(
                    sprite,
                    1f,
                    0f,
                    FadeDuration
                );
            }


            // =================================
            // CAMBIAR IMAGEN
            // =================================

            image.ApplyTo(sprite);


            // =================================
            // GUARDAR TRANSFORMACIÓN ORIGINAL
            // =================================

            Vector2 originalScale = sprite.Scale;
            Vector2 originalPosition = sprite.Position;


            // =================================
            // FADE + BOUNCE AL MISMO TIEMPO
            // =================================

            Task fadeTask = animationManager.Fade(
                sprite,
                0f,
                1f,
                FadeDuration
            );

            Task bounceTask = BounceSprite(
                originalScale,
                originalPosition,
                1.01f,       // un poco más ancho
                1.02f,       // un poco más alto
                0f,
                BounceDuration
            );

            await Task.WhenAll(
                fadeTask,
                bounceTask
            );


            // =================================
            // VOLVER AL TAMAÑO NORMAL
            // =================================

            await BounceSprite(
                originalScale,
                originalPosition,
                1.00f,
                1.00f,
                0f,
                ReturnDuration
            );


            // =================================
            // ASEGURAR TRANSFORMACIÓN ORIGINAL
            // =================================

            sprite.Scale = originalScale;
            sprite.Position = originalPosition;


            isTransitioning = false;
        }


        // =================================
        // BOUNCE
        // =================================

        private async Task BounceSprite(
            Vector2 originalScale,
            Vector2 originalPosition,
            float targetScaleX,
            float targetScaleY,
            float targetOffsetY,
            float duration
        )
        {
            Vector2 startScale = sprite.Scale;

            int steps = 7;

            int delay = Mathf.Max(
                1,
                (int)(duration * 1000f / steps)
            );


            for (int i = 0; i <= steps; i++)
            {
                float t = (float)i / steps;

                t = Mathf.SmoothStep(
                    0f,
                    1f,
                    t
                );


                // =================================
                // ESCALA
                // =================================

                float scaleX = Mathf.Lerp(
                    startScale.X,
                    originalScale.X * targetScaleX,
                    t
                );

                float scaleY = Mathf.Lerp(
                    startScale.Y,
                    originalScale.Y * targetScaleY,
                    t
                );


                sprite.Scale = new Vector2(
                    scaleX,
                    scaleY
                );


                // =================================
                // FIJAR PARTE INFERIOR
                // =================================

                float heightDifference =
                    sprite.Texture.GetHeight()
                    * (scaleY - originalScale.Y)
                    * 0.5f;


                sprite.Position = new Vector2(
                    originalPosition.X,
                    originalPosition.Y
                    - heightDifference
                    + Mathf.Lerp(
                        0f,
                        targetOffsetY,
                        t
                    )
                );


                await Task.Delay(delay);
            }


            // =================================
            // VALORES FINALES
            // =================================

            sprite.Scale = new Vector2(
                originalScale.X * targetScaleX,
                originalScale.Y * targetScaleY
            );
        }


        // =================================
        // VALIDACIÓN
        // =================================

        private bool Validate(ImageConfig image)
        {
            if (sprite == null)
            {
                GD.PrintErr(
                    "Sprite2D es NULL."
                );

                return false;
            }


            if (image == null)
            {
                GD.PrintErr(
                    "ImageConfig es NULL."
                );

                return false;
            }


            if (animationManager == null)
            {
                GD.PrintErr(
                    "AnimationManager es NULL."
                );

                return false;
            }


            return true;
        }
    }
}
