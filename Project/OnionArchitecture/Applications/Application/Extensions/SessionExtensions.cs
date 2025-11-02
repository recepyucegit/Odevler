using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Application.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            if (session == null) return; // NULL CHECK

            var jsonData = JsonSerializer.Serialize(value);
            session.SetString(key, jsonData);
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            if (session == null) return default; // NULL CHECK

            var jsonData = session.GetString(key);

            if (string.IsNullOrEmpty(jsonData))
                return default;

            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public static void RemoveObject(this ISession session, string key)
        {
            if (session == null) return; // NULL CHECK

            session.Remove(key);
        }
    }
}