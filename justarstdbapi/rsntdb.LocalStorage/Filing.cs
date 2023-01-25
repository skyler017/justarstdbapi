using System.Xml.Serialization;

namespace rsntdb.LocalStorage
{
    public static class ListExtension
    {
        private static string path = @"D://.datarepository/.rsntdb/"; // A folder to put files in
        public static XmlSerializer Serializer { get; set; }

        public static List<T> LoadFromMemory<T>(this List<T> listedT)
        {
            if (Serializer == null || typeof(T) != Serializer.GetType()) ReadyMemory<T>();
            using StreamReader reader = new StreamReader(path + typeof(T) + ".xml");
            listedT = (List<T>?)Serializer.Deserialize(reader);
            reader.Close();
            return listedT;
        }

        public static List<T> SaveToMemory<T>(this List<T> listedT)
        {
            if (Serializer == null || typeof(T) != Serializer.GetType()) ReadyMemory<T>();
            using StringWriter writer = new StringWriter();
            Serializer.Serialize(writer, listedT);
            File.WriteAllText(path + typeof(T) + ".xml", writer.ToString());
            writer.Close();
            return listedT;
        }

        private static void ReadyMemory<T>()
        {
            Serializer = new XmlSerializer(typeof(List<T>));
        }
    }
}
