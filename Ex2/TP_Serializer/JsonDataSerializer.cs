using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;


namespace TP_Serializer
{
    public class JsonDataSerializer
    {

        private readonly static JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            TypeNameHandling = TypeNameHandling.All,
            MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
        };

        public static void Serialize(Object obj, string pathToFile)
        {
            using (FileStream _filewriter = new FileStream(pathToFile, FileMode.Create))
            {
                string serialized = JsonConvert.SerializeObject(obj, Formatting.Indented, JsonSettings);
                _filewriter.Write(Encoding.UTF8.GetBytes(serialized));
                _filewriter.Flush();
            }
        }

        public static T Deserialize<T>(string pathToFile)
        {
            if (File.Exists(pathToFile))
            {
                using (FileStream _fileWriter = new FileStream(pathToFile, FileMode.Open))
                {
                    byte[] readedBytes = new byte[_fileWriter.Length];
                    _fileWriter.Read(readedBytes);
                    return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(readedBytes), JsonSettings);
                }
            }
            return default(T);
        }
    }
}
