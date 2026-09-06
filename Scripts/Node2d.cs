using Godot;
using Scripts.Data.Class.Dialogue;
using Scripts.Data.Class.Dialogue.Controller;

public partial class Node2d : Node2D
{
	private DialogueManager dialogue;

	private AudioStreamPlayer voiceSFX;
	private Sprite2D characterImage;
	private AnimationManager animationManager;
	private CharacterImageController characterImageController;

	private DialogueUIManager dialogueUI;


	public override void _Ready()
	{
		// =========================
		// VOZ
		// =========================

		voiceSFX =
			new AudioStreamPlayer();

		AddChild(
			voiceSFX
		);


		// =========================
		// IMAGEN
		// =========================

		characterImage =
			new Sprite2D();

		characterImage.Centered =
			true;

		characterImage.ZIndex =
			-1;

		AddChild(
			characterImage
		);


		// =========================
		// IMAGE CONTROLLER
		// =========================

		animationManager =
			new AnimationManager();
		characterImageController =
			new CharacterImageController(
				characterImage,
				animationManager
			);


		// =========================
		// DIALOGUE MANAGER
		// =========================

		dialogue =
			new DialogueManager(
				"res://Scripts/dialogue.json",
				"res://Scripts/characters.json",
				voiceSFX
			);


		// =========================
		// UI
		// =========================

		PackedScene uiScene =
			GD.Load<PackedScene>(
				"res://Scenes/UI/DialogueUI.tscn"
			);


		if (uiScene == null)
		{
			GD.PrintErr(
				"No se pudo cargar DialogueUI.tscn"
			);

			return;
		}


		GD.Print(
			"DialogueUI.tscn cargado"
		);


		dialogueUI =
			uiScene.Instantiate<
				DialogueUIManager
			>();


		if (dialogueUI == null)
		{
			GD.PrintErr(
				"dialogueUI es NULL después de Instantiate"
			);

			return;
		}


		GD.Print(
			"dialogueUI creado"
		);


		AddChild(
			dialogueUI
		);


		// =========================
		// IMAGEN INICIAL
		// =========================

		ImageConfig initialImage =
			dialogue.GetImage();

		if (initialImage != null)
		{
			initialImage.ApplyTo(
				characterImage
			);
		}


		// =========================
		// UI INICIAL
		// =========================

		UpdateDialogueUI();
	}


	public override void _Process(
		double delta
	)
	{
		if (dialogue == null)
			return;

		dialogue.Update(
			delta
		);

		UpdateDialogueUI();
	}


	public override async void _Input(
	InputEvent @event
)
	{
		if (dialogue == null)
			return;

		// =========================
		// CONTINUAR DIALOGO
		// =========================

		bool changedDialogue =
			dialogue.ContinueText(@event);


		// =========================
		// CAMBIO DE IMAGEN
		// =========================

		if (changedDialogue)
		{
			ImageConfig image =
				dialogue.GetImage();

			if (image != null)
			{
				await characterImageController.Show(
					image
				);
			}
		}


		// =========================
		// ACTUALIZAR UI
		// =========================

		UpdateDialogueUI();
	}


	private void UpdateDialogueUI()
	{
		if (dialogue == null)
		{
			GD.PrintErr(
				"dialogue es NULL"
			);

			return;
		}


		if (dialogueUI == null)
		{
			GD.PrintErr(
				"dialogueUI es NULL"
			);

			return;
		}


		dialogueUI.SetSpeaker(
			dialogue.GetSpeaker()
		);


		dialogueUI.SetTextSize(
			dialogue.GetSize()
		);

		dialogueUI.SetTextFont(
			dialogue.GetFont()
		);

		dialogueUI.SetSpeakerFavoriteColor(
			dialogue.GetFavoriteColor()
		);

		dialogueUI.SetText(
			dialogue.GetVisibleText()
		);
	}
}
