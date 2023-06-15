namespace JARVIS.Option
{
    public class NginxConfiguration : IOptionResolver
    {
        private const string template = @"server {
        server_name   {@SERVER_NAME};
        location / {
                                        proxy_pass         http://127.0.0.1:{@PORT_NUMBER};
                                        proxy_http_version 1.1;
                                        proxy_set_header   Upgrade $http_upgrade;
                                        proxy_set_header   Connection $connection_upgrade;
                                        proxy_set_header   Host $host;
                                        proxy_cache_bypass $http_upgrade;
                                        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
                                        proxy_set_header   X-Forwarded-Proto $scheme;
        }
}";

        public string Key => "nginx";
        public string Name => "NGINX";
        public string ShortDescription => "NGINX deployment configuration";
        public double Version => 1.0;


        public async Task Resolve()
        {
            Console.Write("Please enter server name : ");
            string? serverName = Console.ReadLine();

            if (serverName == null)
            {
                return;
            }

            Console.Write("Please enter port number : ");
            string? portNumber = Console.ReadLine();

            if (portNumber == null)
            {
                return;
            }

            string v = template.Replace("{@SERVER_NAME}", serverName).Replace("{@PORT_NUMBER}", portNumber);
            Console.WriteLine($"Config file name : {serverName}.conf");
            Console.WriteLine("Configuration as follows");
            Console.WriteLine(v);
        }
    }
}
