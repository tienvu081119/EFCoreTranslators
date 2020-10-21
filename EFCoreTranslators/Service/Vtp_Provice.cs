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
    public class Vtp_Provice
    {
        public void Run()
        {            
            string log = String.Empty;
            ReplaceString replaceString = new ReplaceString();
            DirectoryInfo dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;
            string dirPath = dir.FullName;
            string templateReport = System.IO.Path.Combine(dirPath, @"Json\Province.json");
            using (StreamReader r = new StreamReader(templateReport))
            {
                string json = r.ReadToEnd();
                List<Province> items = JsonConvert.DeserializeObject<List<Province>>(json);
                foreach (var item in items)
                {
                    using (var context = new quickbeedev1Context())
                    {
                        var provine = (from p in context.Provinces
                                       select new
                                       {
                                           Id = p.Id,
                                           Name = replaceString.Replace(p.Name, "PROVINCE")
                                       }).ToList();

                        var provinceObj = provine.Where(x => x.Name == replaceString.Replace(item.PROVINCE_NAME, "PROVINCE")).FirstOrDefault();
                      
                        if (provinceObj != null)
                        {
                            var translators = new Translators()
                            {
                                DataKey = "VTP.PROVINCE",
                                OriginalValue = Convert.ToString(provinceObj.Id),
                                TranslatedValue = Convert.ToString(item.PROVINCE_ID)
                            };
                            var provineExists = context.Translators.Where(x => x.DataKey == translators.DataKey
                            && x.OriginalValue == translators.OriginalValue && x.TranslatedValue == translators.TranslatedValue);
                            if (provineExists.Count() == 0)
                            {
                                context.Translators.Add(translators);
                                context.SaveChanges();
                                log += provinceObj.Name + "-" + item.PROVINCE_NAME + "\n";
                            }
                        }
                        else
                        {
                            string a = replaceString.Replace(item.PROVINCE_NAME, "PROVINCE");
                            var province = new Provinces()
                            {
                                Name = item.PROVINCE_NAME,
                                ProvinceType = "Tỉnh",
                                CountryId = 256
                            };
                            context.Provinces.Add(province);
                            context.SaveChanges();
                            var translators = new Translators()
                            {
                                DataKey = "VTP.PROVINCE",
                                OriginalValue = Convert.ToString(province.Id),
                                TranslatedValue = Convert.ToString(item.PROVINCE_ID)
                            };
                            context.Translators.Add(translators);
                            context.SaveChanges();
                            log += provinceObj.Name + "-" + item.PROVINCE_NAME + "\n";
                        }
                    }
                }
                Console.WriteLine(log);
            }


        }
    }
}
