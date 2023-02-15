using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace WorldSkills.Classes.Helpers
{
    internal class SerializationController
    {
        public static string SerializeFile(object file) => JsonConvert.SerializeObject(file);
    }
}
