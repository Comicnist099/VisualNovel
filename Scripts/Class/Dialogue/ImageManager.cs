using Godot;
using Scripts.Dictionaries.Text;
using Scripts.Enums.Text;
using System;

namespace Scripts.Data.Class.Dialogue
{
	public class ImageManager
	{
		private readonly string characterName;
		private readonly ImageData imageData;

		public ImageManager(
			string characterName,
			ImageData imageData
		)
		{
			this.characterName = characterName;
			this.imageData = imageData;
		}

		public ImageConfig GetImage()
		{
			if (imageData == null)
			{
				throw new Exception(
					$"ImageData es NULL para {characterName}"
				);
			}

			if (!Enum.TryParse(
				imageData.state,
				true,
				out EmotionNames state
			))
			{
				throw new Exception(
					$"El estado de imagen " +
					$"'{imageData.state}' no existe."
				);
			}

			if (!ImageDictionary.Characters.TryGetValue(
				characterName,
				out var characterImages
			))
			{
				throw new Exception(
					$"No existe diccionario para " +
					$"'{characterName}'."
				);
			}

			if (characterImages == null)
			{
				throw new Exception(
					$"El diccionario de imágenes de " +
					$"'{characterName}' es NULL."
				);
			}

			if (!characterImages.TryGetValue(
				state,
				out var image
			))
			{
				throw new Exception(
					$"No existe imagen para " +
					$"{characterName} / {state}."
				);
			}

			if (image == null)
			{
				throw new Exception(
					$"ImageConfig es NULL para " +
					$"{characterName} / {state}."
				);
			}

			return image;
		}
	}
}
