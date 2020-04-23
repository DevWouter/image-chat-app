using Newtonsoft.Json;
using System.IO;

namespace FinalDemo
{
    public static class Store
    {
        public static T ReadJsonFromFile<T>(string path)
        {
            try
            {
                var text = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(text);
            }
            catch
            {
                return default(T);
            }
        }

        public static void WriteJsonToFile<T>(string path, T data)
        {
            var text = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, text);
        }
    }
}
