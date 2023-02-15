using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSkills.Classes.Jsons
{
    [Serializable]
    public class PortsJson
    {
        public List<PortJson> Ports;

        public PortsJson(int numPorts)
        {
            Ports = new List<PortJson>();
            for (int i = 1; i < numPorts + 1; i++)
                Ports.Add(new PortJson { Num = i });
        }
    
        public PortsJson(PortsJson json) =>
            Ports = json.Ports;
        public PortsJson()
        {

        }
    }
}
