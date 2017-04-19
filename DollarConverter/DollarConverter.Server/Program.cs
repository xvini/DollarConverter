using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DollarConverter.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var url = ConfigurationManager.AppSettings["Url"];
            using (var host = new ServiceHost(typeof(DollarToWordService), new Uri(url)))
            {
                Console.WriteLine("Service URL: " + url);
                host.Open();

                Console.WriteLine("Service is running. Press any key to EXIT.");
                Console.ReadKey();
            }
        }
    }
}
