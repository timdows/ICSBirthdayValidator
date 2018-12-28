using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ICSBirthdayValidator
{
    public class BirthdayInformation
    {
        public string Name { get; set; }
        public bool Recurring { get; set; }
        public string Date { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, recurring: {Recurring} on date: {Date}";
        }
    }
}
