using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers_For_Server
{
    public class Servers
 {
     // Жадная инициализация
     private static readonly Servers eagerInstance = new Servers();
     // Ленивая инициализация
     private static Lazy<Servers> lazyInstance = new Lazy<Servers>(() => new Servers());

     private List<string> serverList;
     private static readonly object lockObject = new object();

     private Servers()
     {
         serverList = new List<string>();
     }

     // Метод для получения жадной версии
     public static Servers GetEagerInstance()
     {
         return eagerInstance;
     }

     // Метод для получения ленивой версии
     public static Servers GetLazyInstance()
     {
         return lazyInstance.Value;
     }

     public bool AddServer(string serverAddress)
     {
         lock (lockObject)
         {
             if (serverAddress.StartsWith("http://") || serverAddress.StartsWith("https://"))
             {
                 if (!serverList.Contains(serverAddress))
                 {
                     serverList.Add(serverAddress);
                     return true;
                 }
             }
             return false;
         }
     }

     public List<string> GetHttpServers()
     {
         lock (lockObject)
         {
             return serverList.FindAll(server => server.StartsWith("http://"));
         }
     }

     public List<string> GetHttpsServers()
     {
         lock (lockObject)
         {
             return serverList.FindAll(server => server.StartsWith("https://"));
         }
     }
 }
}
