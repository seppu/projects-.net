﻿using System;
using Newtonsoft.Json;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello Ron!");
            Console.WriteLine(JsonConvert.SerializeObject(args));
        }
    }
}
