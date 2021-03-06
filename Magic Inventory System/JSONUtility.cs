﻿using System;
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
            string json =  File.ReadAllText(location);
                var list = JsonConvert.DeserializeObject<Object>(json);
            return list;
        }

        public static void writeJsonFile(string location,Object obj)
        {
            using (StreamWriter file = File.CreateText(location))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }
        }
    }
}
