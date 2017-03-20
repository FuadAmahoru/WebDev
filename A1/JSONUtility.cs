using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace WebA1
{
    public class JsonUtility
    {


        public static Object readJsonFile<Object>(string location)
        {

            StreamReader r = new StreamReader(location);
            string json = r.ReadToEnd();
            
                var list = JsonConvert.DeserializeObject<Object>(json);
           
          
            return list;
        }




    }
}
