using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Invoice_Maker.XML
{
    /// <summary>
    /// This class contains methods for xml serialization of any 
    /// type of objects.
    /// </summary>
    /// <remarks></remarks>
    public static class XMLSerialization
    {
        /// <summary>
        /// A generic method that can be used to serialize any type of object.
        /// The type of object is defined at method call by the client object
        /// </summary>
        public static void SerializeToFile<T>(string filePath, T obj)
        {
            //bool bok = true;
            using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {

                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));

                xmlFormat.Serialize(stream, obj);

            }
        }




        /// <summary>
        /// Deserialize any xml file serialized  using this method.
        /// </summary>
        public static T DeserializeFromFile<T>(string filePath)
        {

            XmlSerializer xs = new XmlSerializer(typeof(T));
            object obj = null;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                obj = (T)xs.Deserialize(fs);
            }

            return (T)obj;

        }
    }

}
