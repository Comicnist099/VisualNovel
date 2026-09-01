using Godot;
using System.Threading.Tasks;
using Scripts.Data.Class.Dialogue;
using Scripts.Data.Class.Dialogue.Controller;

namespace Scripts
{
    public partial class DialogueController : Node
    {
        [Export]
        private Sprite2D characterSprite;

        private AnimationManager animationManager;
        private CharacterImageController imageController;


        public override void _Ready()
        {
            animationManager =
                new AnimationManager();

            imageController =
                new CharacterImageController(
                    characterSprite,
                    animationManager
                );
        }


        public async Task ShowCharacter(
            ImageConfig image
        )
        {
            await imageController.Show(
                image
            );
        }
    }
}
