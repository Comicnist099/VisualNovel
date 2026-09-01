using Godot;
using System.Threading.Tasks;

namespace Scripts.Data.Class.Dialogue
{
    public class AnimationManager
    {
        public async Task FadeColor(
            CanvasItem target,
            Color from,
            Color to,
            float duration
        )
        {
            if (target == null)
            {
                GD.PrintErr(
                    "Animation target es NULL."
                );

                return;
            }

            target.Modulate =
                from;

            Tween tween =
                target.CreateTween();

            tween.SetTrans(
                Tween.TransitionType.Sine
            );

            tween.SetEase(
                Tween.EaseType.InOut
            );

            tween.TweenProperty(
                target,
                "modulate",
                to,
                duration
            );

            await target.ToSignal(
                tween,
                Tween.SignalName.Finished
            );
        }
        public async Task Fade(
            CanvasItem target,
            float from,
            float to,
            float duration
        )
        {
            if (target == null)
            {
                GD.PrintErr(
                    "Animation target es NULL."
                );

                return;
            }

            target.Modulate =
                new Color(
                    1,
                    1,
                    1,
                    from
                );

            Tween tween =
                target.CreateTween();

            tween.SetTrans(
                Tween.TransitionType.Sine
            );

            tween.SetEase(
                Tween.EaseType.InOut
            );

            tween.TweenProperty(
                target,
                "modulate:a",
                to,
                duration
            );

            await target.ToSignal(
                tween,
                Tween.SignalName.Finished
            );
        }
    }
}
