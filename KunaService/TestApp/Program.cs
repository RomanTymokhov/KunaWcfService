using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.ServiceReference2;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            KunaServiseClient kunaServise = new KunaServiseClient();

            Console.WriteLine(kunaServise.GetTimestamp());
        }
    }
}
