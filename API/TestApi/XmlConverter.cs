using System.Xml.Serialization;

public class XmlConverter
{
    public static T ConvertXmlToObject<T>(string xmlData) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));

        using StringReader reader = new StringReader(xmlData);
        return (T)serializer.Deserialize(reader);
    }
}