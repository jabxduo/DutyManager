using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Duty_Manager
{
    class DutyParser
    {
        public static List<Duty> LoadDuties()
        {
            List<Duty> duties;
            using (StreamReader r = new StreamReader("JSON_Files/dutiesJSON.json"))
            {
                string json = r.ReadToEnd();
                duties = JsonConvert.DeserializeObject<List<Duty>>(json);
            }
            return duties;
        }
    }
}
