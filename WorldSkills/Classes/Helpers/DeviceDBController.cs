using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSkills.Classes.Jsons;
using WorldSkills.Models;

namespace WorldSkills.Classes.Helpers
{
    public class DeviceDBController
    {
        public static Devices FindDevice(string name)  =>
            DataBase.ConnectContext.Devices.FirstOrDefault(d => d.Name.ToLower() == name.ToLower());

        public static void SaveRefreshDevice(Devices device)
        {
            try
            {
                IEnumerable<Devices> devicesCollection = DataBase.ConnectContext.Devices.Where(c => c.Id == device.Id).
                           AsEnumerable().Select(
                           c =>
                           {
                               c.Name = device.Name;
                               c.IP = device.IP;
                               c.MAC = device.MAC;
                               c.PortsJson = device.PortsJson;
                               return c;
                           });

                foreach (Devices needevice in devicesCollection)
                    DataBase.ConnectContext.Entry(needevice).State = EntityState.Modified;

                DataBase.ConnectContext.SaveChanges();
            }
            catch
            {

            }
        }

        public static void SaveNewDevice(Devices device)
        {
            try
            {
                DataBase.ConnectContext.Devices.Add(device);
                DataBase.ConnectContext.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
