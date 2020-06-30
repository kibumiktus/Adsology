using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Adsology.Common
{
    public static class XmlStreamSerializer
    {
        public static Stream Serialize<T>(T content)
        {
            //it is required method in production, but it is not used in test task
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            using (stream)
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(XmlReader.Create(stream));
            }
        }
    }
}
