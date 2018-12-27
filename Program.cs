using System;
using System.IO;
using System.Net;

namespace ICSBirthdayValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Missing complete url to ics file");
            }

            var icsUrl = args[0];

            using (var client = new WebClient())
            {
                using (var stream = new MemoryStream(client.DownloadData(icsUrl)))
                {
                    

                }
            }
        }
    }
}
