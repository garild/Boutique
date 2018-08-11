﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dac;

namespace DatabaseDeploy
{
    public class Program
    {
        private static string DatabaseName = "Boutique";
        private static string DacpacFileName = @"..\..\..\FileStore\Boutique.Database.dacpac";
        private static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Boutique;Integrated Security=True;Connect Timeout=0;Encrypt=False;TrustServerCertificate=True;";
        private static bool IsErrorAtDeyploment;


        public static void Main(string[] args)
        {
           // var filePath = Path.Combine(Environment.CurrentDirectory, DacpacFileName);
            var dacServices = new DacServices(ConnectionString);
            dacServices.Message += DacServices_Message;
            var options = new DacDeployOptions
            {
                CreateNewDatabase = false,
                BlockOnPossibleDataLoss = false,
                GenerateSmartDefaults = true,
                VerifyDeployment = true,
                DropObjectsNotInSource = true
            };

            Console.WriteLine("Start....");

            dacServices.GenerateDeployReport(DacPackage.Load(DacpacFileName), DatabaseName, options);

            if (!IsErrorAtDeyploment)
                dacServices.Deploy(DacPackage.Load(DacpacFileName), DatabaseName, true, options);

            Console.ReadKey();
        }

        private static void DacServices_Message(object sender, DacMessageEventArgs e)
        {
            IsErrorAtDeyploment = false;
            if (e.Message.MessageType == DacMessageType.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message.Message);
                IsErrorAtDeyploment = true;
            }
            if (e.Message.MessageType == DacMessageType.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message.Message);
            }
            else
                Console.WriteLine(e.Message.Message);

        }
    }
}
