using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Utils
{
    public static class PathDb
    {
        public static string GetPath(string nameDb)
        {
            string pathDbSqlite = string.Empty;

            if(DeviceInfo.Platform == DevicePlatform.Android)
            {
                pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                pathDbSqlite = Path.Combine(pathDbSqlite, nameDb);  

            }
            
            else if(DeviceInfo.Platform == DevicePlatform.iOS)
            {
                pathDbSqlite = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                pathDbSqlite = Path.Combine(pathDbSqlite, "..","Libary",nameDb);
            }

            return Path.Combine(pathDbSqlite, nameDb);
        }
    }
}
//Path.Combine(pathDbSqlite, nameDb)
//pathDbSqlite