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
using System.Runtime.InteropServices;

namespace EFCoreTranslators.Service
{
    public class Vtp_Test_Ward
    {
        public void Run()
        {           
            string log = String.Empty;
            ReplaceString replaceString = new ReplaceString();
            DirectoryInfo dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;
            string dirPath = dir.FullName;
            string templateReport = System.IO.Path.Combine(dirPath, @"Json\Ward.json");
            using (StreamReader r = new StreamReader(templateReport))
            {
                string json = r.ReadToEnd();
                List<Ward> items = JsonConvert.DeserializeObject<List<Ward>>(json);
                foreach (var item in items)
                {
                    using (var context = new quickbeedev1Context())
                    {
                        var ward = context.Translators.Where(x => x.DataKey == "VTP.WARD" && x.TranslatedValue == item.WARDS_ID.ToString());
                        if(ward.Count() == 0)
                        {
                            log += item.WARDS_NAME + "_" + item.DISTRICT_ID +"\n";
                        }
                    }
                }
            }
            Console.WriteLine(log);
        }
    }
}
