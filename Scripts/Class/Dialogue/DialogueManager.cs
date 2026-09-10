using System;
using Godot;
using Scripts.Data;
using Scripts.Data.File;

namespace Scripts.Data.Class.Dialogue
{
    public class DialogueManager
    {
        private DialogueData[] dialogueData = [];
        private CharacterData[] characterData = [];

        private int currentDialogueIndex = 0;

        private ContentManager contentManager;
        private SpeakerManager speakerManager;
        private ImageManager imageManager;
        private CharacterManager characterManager;

        private AudioStreamPlayer voiceSFX;


        public DialogueManager(
            string dialogueRoute,
            string characterRoute,
            AudioStreamPlayer voiceSFX
        )
        {
            this.voiceSFX = voiceSFX;

            LoadDialogue(dialogueRoute);
            LoadCharacters(characterRoute);

            characterManager =
                new CharacterManager(characterData);

            if (dialogueData.Length > 0)
            {
                InitializeManagers();
            }
        }


        private void InitializeManagers()
        {
            DialogueData dialogue =
                dialogueData[currentDialogueIndex];

            if (dialogue == null)
            {
                GD.PrintErr(
                    "DialogueData es NULL"
                );

                return;
            }

            if (dialogue.speaker == null)
            {
                GD.PrintErr(
                    "dialogue.speaker es NULL"
                );

                return;
            }


            GD.Print(
                $"Speaker: {dialogue.speaker.name} | " +
                $"Emotion: {dialogue.speaker.emotion}"
            );


            // =========================
            // BUSCAR PERSONAJE
            // =========================

            CharacterData character =
                characterManager.GetCharacter(
                    dialogue.speaker.name
                );

            if (character == null)
            {
                GD.PrintErr(
                    $"No se encontró el personaje: " +
                    $"{dialogue.speaker.name}"
                );

                return;
            }


            // =========================
            // BUSCAR EMOCIÓN
            // =========================

            EmotionData emotion =
                characterManager.GetEmotion(
                    character,
                    dialogue.speaker.emotion
                );

            if (emotion == null)
            {
                GD.PrintErr(
                    $"No se encontró la emoción " +
                    $"'{dialogue.speaker.emotion}' " +
                    $"para {dialogue.speaker.name}"
                );

                return;
            }
            // =========================
            // CONTENT MANAGER
            // =========================

            contentManager =
                new ContentManager(
                    dialogue.speaker.text,
                    emotion,
                    voiceSFX
                );
            // =========================
            // SPEAKER MANAGER
            // =========================

            speakerManager =
                new SpeakerManager(
                    character
                );
            // =========================
            // IMAGE MANAGER
            // =========================

            imageManager =
                new ImageManager(
                    character.person.name,
                    emotion.image
                );


            GD.Print(
                $"ImageManager creado para: " +
                $"{character.person.name}"
            );
        }
        public ImageConfig GetImage()
        {
            if (imageManager == null)
            {
                GD.PrintErr(
                    "imageManager es NULL."
                );

                return null;
            }

            return imageManager.GetImage();
        }


        private void LoadDialogue(string route)
        {
            DialogueFile file =
                JsonLoader.Load<DialogueFile>(route);

            if (file == null)
            {
                GD.PrintErr(
                    $"No se pudo cargar dialogue: {route}"
                );

                return;
            }

            dialogueData = file.dialogue;

            if (dialogueData == null)
            {
                dialogueData = [];
            }
        }


        private void LoadCharacters(string route)
        {
            CharacterFile file =
                JsonLoader.Load<CharacterFile>(route);

            if (file == null)
            {
                GD.PrintErr(
                    $"No se pudo cargar characters: {route}"
                );

                return;
            }

            characterData = file.characters;

            if (characterData == null)
            {
                characterData = [];
            }
        }
        public void Update(double delta)
        {
            if (dialogueData == null)
            {
                GD.PrintErr(
                    "dialogueData es NULL"
                );

                return;
            }

            if (dialogueData.Length == 0)
            {
                return;
            }

            if (contentManager == null)
            {
                GD.PrintErr(
                    "contentManager es NULL"
                );

                return;
            }

            contentManager.Update(delta);
        }


        public bool ContinueText(InputEvent @event)
        {
            if (@event is InputEventKey keyEvent &&
                keyEvent.Pressed &&
                !keyEvent.Echo &&
                keyEvent.Keycode == Key.Space)
            {
                if (!contentManager.IsFinished())
                {
                    contentManager.ShowAll();

                    return false;
                }

                NextDialogue();

                return true;
            }

            return false;
        }


        private void NextDialogue()
        {
            currentDialogueIndex++;

            if (currentDialogueIndex >= dialogueData.Length)
            {
                currentDialogueIndex = 0;
            }

            InitializeManagers();
        }


        public string GetSpeaker()
        {
            if (dialogueData.Length == 0)
                return "";

            if (speakerManager == null)
                return "";

            return speakerManager.GetName();
        }


        public int GetSize()
        {
            if (dialogueData.Length == 0)
                return 0;

            if (contentManager == null)
                return 0;

            return contentManager.GetSize();
        }


        public string GetVisibleText()
        {
            if (dialogueData.Length == 0)
                return "";

            if (contentManager == null)
                return "";

            return contentManager.GetVisibleText();
        }

        public Font GetFont()
        {
            if (characterData.Length == 0)
                return null; // TODO: DEFAULTS

            if (contentManager == null)
                return null;

            return contentManager.GetFont();
        }

        public Color GetFavoriteColor()
        {
            if (characterData.Length == 0)
                return new Color(); // TODO: DEFAULTS

            if (speakerManager == null)
                return new Color(); // TODO: DEFAULTS

            return speakerManager.GetFavoriteColor();
        }

        public Texture2D GetIcon()
        {
            if (characterData.Length == 0)
                return new Texture2D(); // TODO: DEFAULTS

            if (speakerManager == null)
                return new Texture2D(); // TODO: DEFAULTS

            return speakerManager.GetIcon();
        }
    }
}
