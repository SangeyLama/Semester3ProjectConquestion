﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFConquestion;

namespace ConquestionServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ConquestionService));

            host.Open();
            Console.WriteLine("Running Conquestion service host...");

            Console.ReadLine();
            host.Close();
        }
    }
}
