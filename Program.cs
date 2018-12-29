using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ICSBirthdayValidator
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Missing complete url to ics file");
                return;
            }

            var icsUrl = args[0];

            using (var client = new WebClient())
            {
                var calendarContents = client.DownloadString(icsUrl);
                var list = new List<string>();

                var calendarEvents = calendarContents.Split("BEGIN:VEVENT");

                foreach (var calendarEvent in calendarEvents)
                {
                    var formattedLines = calendarEvent.Split("\r\n").ToList();
                    var birthdayInformation = new BirthdayInformation();

                    birthdayInformation.Recurring = formattedLines.Any(line => line.Contains("FREQ=YEARLY"));
                    birthdayInformation.Name = formattedLines.SingleOrDefault(item => item.Contains("SUMMARY:"));
                    birthdayInformation.Date = formattedLines.SingleOrDefault(item => item.Contains("DTSTART;VALUE=DATE:"));

                    if (birthdayInformation.HasValidInformation())
                    {
                        Console.WriteLine(birthdayInformation);
                    }
                }
            }
        }
    }
}
