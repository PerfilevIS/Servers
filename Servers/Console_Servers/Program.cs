using Servers_For_Server;

namespace Console_Servers
{
    class Program
    {
            static void Main()
        {
            // Жадная инициализация
            Servers eagerServers = Servers.GetEagerInstance();
            // Ленивая инициализация
            Servers lazyServers = Servers.GetLazyInstance();

            Console.WriteLine("Добавление серверов:");
            Console.WriteLine("Добавляем 'http://example.com': " + lazyServers.AddServer("http://example.com"));
            Console.WriteLine("Добавляем 'https://example.org': " + lazyServers.AddServer("https://example.org"));
            Console.WriteLine("Добавляем 'ftp://notallowed.com': " + lazyServers.AddServer("ftp://notallowed.com")); // Не добавится из-за префикса
            Console.WriteLine("Добавляем 'http://example.com': " + lazyServers.AddServer("http://example.com")); // Дубликат - не добавится

            Console.WriteLine("\nHTTP сервера:");
            var httpServers = lazyServers.GetHttpServers();
            foreach (var server in httpServers)
            {
                Console.WriteLine(server);
            }

            Console.WriteLine("\nHTTPS сервера:");
            var httpsServers = lazyServers.GetHttpsServers();
            foreach (var server in httpsServers)
            {
                Console.WriteLine(server);
            }
        }
    }
}
