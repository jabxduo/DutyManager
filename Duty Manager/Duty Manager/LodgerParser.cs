using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Duty_Manager
{
    class LodgerParser
    {
        public static List<Lodger> LoadLodgers()
        {
            List<Lodger> lodgers;
            using (StreamReader r = new StreamReader("JSON_Files/lodgersJSON.json"))
            {
                string json = r.ReadToEnd();
                lodgers = JsonConvert.DeserializeObject<List<Lodger>>(json);
            }
            return lodgers;
        }
    }
}
