using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace GetTableStracture
{
    public class DataHelper
    {
        public static List<ConnectionInfo> GetConnectionList()
        {
            FileStream fs = new FileStream("connectionList.xml", FileMode.Open);
            XmlSerializer xmlSe = new XmlSerializer(typeof(List<ConnectionInfo>));

            List<ConnectionInfo> connList = (List<ConnectionInfo>)xmlSe.Deserialize(fs);
            fs.Dispose();
            return connList;
        }
    }
}
