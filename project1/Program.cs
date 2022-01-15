using System;
using System.Collections.Generic;
namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new Phone("05077603502", "Ben");
            Dictionary<string, string> contacts = phone.contacts;
            phone.menu();
        }
    }
}
