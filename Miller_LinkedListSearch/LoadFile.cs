using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Miller_LinkedListSearch
{
    class LoadFile
    {
        public static LinkedList FLoader()
        {
            string fileData;
            string[] fileSplit;
            string delimstring = ",;:";
            char[] deliminator = delimstring.ToCharArray();
            char gender;
            string name;
            int rank;
            MetaData data;
            LinkedList list = new LinkedList();

            StreamReader file = new StreamReader("yob2019.txt");
            while((fileData = file.ReadLine()) != null)
            {
                fileSplit = fileData.Split(deliminator,3);
                gender = Convert.ToChar(fileSplit[1]);
                name = fileSplit[0];
                rank = Convert.ToInt32(fileSplit[2]);
                data = new MetaData(gender, name, rank);
                list.Add(data);
            }
            file.Close();
            return list;
        }
    }
}
