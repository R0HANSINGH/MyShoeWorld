using System.Text.Json;
namespace MyShoeWorld.UI
{ 

    public static class SessionExtension
    {
        //set=write method
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        //get=return method 
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
