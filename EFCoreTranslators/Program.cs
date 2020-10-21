
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using EFCoreTranslators.Item;
using System.Runtime.CompilerServices;
using EFCoreTranslators.Models;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using EFCoreTranslators.Service;

namespace EFCoreTranslators
{
    class Program
    {
        static void Main(string[] args){

            //Vtp_Provice vtp_Provice = new Vtp_Provice();
            //vtp_Provice.Run();

            //Vtp_District vtp_District = new Vtp_District();
            //vtp_District.Run();

            //Vtp_Ward vtp_Ward = new Vtp_Ward();
            //vtp_Ward.Run();

            Vtp_Test_Ward vtp_Test_Ward = new Vtp_Test_Ward();
            vtp_Test_Ward.Run();
            Console.WriteLine("Hello World!");
           

        }
    }
}
