using System;
using Godot;

public partial class DialogueUIManager : Control
{
	private Label speaker;
	private Label text;
	private TextureRect icon;


	public override void _Ready()
	{

		icon = 
			GetNode<TextureRect>(
				"Background/Icon"
				);

		speaker =
			GetNode<Label>(
				"Background/Speaker"
			);

		text =
			GetNode<Label>(
				"Background/Text"
			);

		if (speaker == null)
		{
			GD.PrintErr(
				"Speaker Label es NULL"
			);

			return;
		}

		if (text == null)
		{
			GD.PrintErr(
				"Text Label es NULL"
			);
			return;
		}

		if(icon == null)
		{
			GD.PrintErr(
				"Icon TextureRect es NULL"
			);
			return;
		}

		speaker.Text =
			"PRUEBA";

		text.Text =
			"HOLA MUNDO";

		icon.Texture = new Texture2D();

	}


	public void SetSpeaker(
		string value
	)
	{
		speaker.Text = value;
	}

	public void SetSpeakerFavoriteColor(
		Color value
	)
	{
		speaker.AddThemeColorOverride("font_color", value);
	}


	public void SetTextSize(
		int size
	)
	{
		text.AddThemeFontSizeOverride(
			"font_size",
			size
		);
	}


	public void SetTextFont(
		Font fontObject
	)
	{ 
		text.AddThemeFontOverride("font", fontObject);
	}

	public void SetText(
		string value
	)
	{
		text.Text = value;
	}

	public void SetIcon(
		Texture2D value
	)
	{
		icon.Texture = value;
	}
 
}
