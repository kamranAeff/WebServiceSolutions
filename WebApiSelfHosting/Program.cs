using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Web.Http.SelfHost;

namespace WebApiSelfHosting
{
    //C:\Windows\System32\drivers\etc\hosts
    // append this line:  127.0.0.1 intelect.az
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Self Host WebApi Example";
            Console.OutputEncoding = Encoding.Unicode;


            var baseAddress = ConfigurationManager.AppSettings.Get("baseAddress");

            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                Console.WriteLine("Konfiqurasiya faylında servis adress-inin *[baseAddress] qeyd olunduğunu yoxlayın");
                Console.ReadKey();
                return;
            }

            try
            {
                var config = (new HttpSelfHostConfiguration(baseAddress))
                .RegisterRoutes()
                .RegisterSwagger();

                using (HttpSelfHostServer server = new HttpSelfHostServer(config))
                {
                    server.OpenAsync().ContinueWith(r=> {


                        Console.WriteLine($"Running api link:{baseAddress}{Environment.NewLine}Sistemdən çıxmaq üçün hər hansı düyməni sıxın.");


                        //open document with browser
                        ExecuteWithoutEx(() =>
                        {
                            Process.Start($"{baseAddress}{(baseAddress.EndsWith("/") ? "swagger" : "/swagger")}");
                        });


                    });

                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xəta:{Environment.NewLine}{ex}.");
                Console.ReadKey();
            }
        }

        static void ExecuteWithoutEx(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
