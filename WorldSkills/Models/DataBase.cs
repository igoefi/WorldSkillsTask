using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSkills.Models
{
    internal class DataBase
    {
        public static WorldSkillsEntities ConnectContext { get; set; } = new WorldSkillsEntities();  
    }
}
