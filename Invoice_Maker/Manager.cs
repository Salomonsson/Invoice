using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Maker
{
    [Serializable]
    public class Manager<T>
    {//: IListManager<T>

        //private List<T> m_list;
        public List<T> m_list;
        //private static List<T> m_list;


        /// <summary>
        /// Instantiate constrctor
        /// </summary>
        public Manager()
        {
            m_list = new List<T>();

        }


        /// <summary>
        /// Add new objekt(type) to list
        /// </summary>
        /// <param name="obj">income type</param>
        /// <returns></returns>
        public bool Add(T obj)
        {
            if (obj != null)
            {
                m_list.Add(obj);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove object by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteAt(int index)
        {
            if (index != null)
            {
                m_list.RemoveAt(index);
                return true;
            }

            return false;
            //m_list.RemoveAt(index);
        }


        /// <summary>
        /// Convert the list to an array.
        /// </summary>
        /// <returns></returns>
        public string[] ToStringArray()
        {

            int setID = 0;
            string[] arr = new string[m_list.Count];

            foreach (T an in m_list)
            {

                arr[setID++] = an.ToString();
            }
            return arr;
        }

        /// <summary>
        /// Return a list.
        /// </summary>
        /// <returns></returns>
        public List<string> ToStringList()
        {
            List<string> lst = new List<string>();

            foreach (T an in m_list)
            {
                lst.Add(an.ToString());
            }
            //return new List<T>();
            return lst;
            //return m_list;
        }


        /// <summary>
        /// Get index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetAt(int index)
        {
            return m_list[index];
        }


        /// <summary>
        /// Read only property to get nr of elemnts in list
        /// </summary>
        public int CountListItems
        {
            get { return m_list.Count; }
        }


        public void Reset()
        {
            m_list.Clear();
        }


        /// <summary>
        /// BinarySerialize serialize to file by the function SAVE in the class SerializeBin.
        /// 
        /// </summary>
        /// <param name="fileName">Path of location for file</param>
        /// <returns>Boolean if path is empty or not.</returns>
        public bool BinarySerialize(string fileName)
        {
            bool bok;
            bok = false;

            if (fileName != null)
            {
                //SerializeBin.Save<List<T>>(m_list, fileName);
                BinSerializer.SerializeBin.Save<List<T>>(m_list, fileName);
                bok = true;
            }
            return bok;
        }



        /// <summary>
        /// BinaryDeSerialize uses the static function OPEN of class SerializeBin.
        /// Boolean value is set if listmanager is null or not.
        /// </summary>
        /// <param name="fileName">path link, where to get file</param>
        /// <returns>return boolean</returns>
        public bool BinaryDeSerialize(string fileName)
        {
            bool bok;
            bok = false;

            //m_list = SerializeBin.Open<List<T>>(fileName);
            m_list = BinSerializer.SerializeBin.Open<List<T>>(fileName);

            if (m_list != null)
            {
                bok = true;
            }

            return bok;

        }


        /// <summary>
        /// Serialize any income to XML
        /// </summary>
        /// <param name="fileName">Path to file</param>
        /// <returns>boolean true if filename is active</returns>
        public bool XMLSerialize(string fileName)
        {
            bool bok = false;

            if (fileName != null)
            {

                //XMLSerialization.SerializeToFile<List<T>>(fileName, m_list);
                XML.XMLSerialization.SerializeToFile<List<T>>(fileName, m_list);

                bok = true;
            }

            return bok;
        }


        /// <summary>
        /// XMLDeserialize deserialize on from the XMLSerialization class.
        /// </summary>
        /// <param name="filePath">Path of file.</param>
        public void XMLDeserialize(string filePath)
        {
            //m_list = XMLSerialization.DeserializeFromFile<List<T>>(filePath);
            m_list = XML.XMLSerialization.DeserializeFromFile<List<T>>(filePath);

        }



        public List<T> LoadCollectionDataManager()
        {
            //List<ItemClass> authors = new List<ItemClass>();
            //int cou = 1;
            //authors.Add(new ItemClass()
            //{
            //    //Name = test.P20_StreetSender,
            //    //Size = test.P22_CitySender
            //    ID_Item = cou++,
            //    Name = "testMain",
            //    Size = "testMainSize"
            //});

            return m_list;
        }
    }
}
