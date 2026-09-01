using Godot;
using System.Text.Json;

namespace Scripts.Data
{
    public static class JsonLoader
    {
        public static T Load<T>(string route)
        {
            using FileAccess file = FileAccess.Open(
                route,
                FileAccess.ModeFlags.Read
            );

            if (file == null)
            {
                GD.PrintErr($"No se pudo abrir el archivo: {route}");
                return default;
            }

            string content = file.GetAsText();

            try
            {
                return JsonSerializer.Deserialize<T>(content);
            }
            catch (JsonException exception)
            {
                GD.PrintErr(
                    $"Error al leer JSON: {exception.Message}"
                );

                return default;
            }
        }
    }
}
