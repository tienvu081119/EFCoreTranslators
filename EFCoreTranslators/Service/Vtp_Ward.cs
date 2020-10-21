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
    public class Vtp_Ward
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
                using (var context = new quickbeedev1Context())
                {
                    var translator = context.Translators.Where(x => x.DataKey == "VTP.DISTRICT").ToList();
                    foreach(var i in translator)
                    {
                        int? districtOriginId = Convert.ToInt32(i.OriginalValue);
                        string districtJsId = i.TranslatedValue;
                       
                        //List Ward
                        var wardJsList = items.Where(x => x.DISTRICT_ID == districtJsId).ToList();
                        var wardOriginalList = (from d in context.Wards.Where(x => x.DistrictId == districtOriginId)
                                                select new
                                                {
                                                    Id = d.Id,
                                                    Name = replaceString.Replace(d.Name, "WARD")
                                                }).ToList();
                        foreach(var itemW in wardJsList)
                        {
                            var wardOriginalObj = wardOriginalList.Where(x => x.Name == replaceString.Replace(itemW.WARDS_NAME, "WARD")).FirstOrDefault();
                            if (wardOriginalObj != null)
                            {
                                var translators = new Translators()
                                {
                                    DataKey = "VTP.WARD",
                                    OriginalValue = Convert.ToString(wardOriginalObj.Id),
                                    TranslatedValue = Convert.ToString(itemW.WARDS_ID)
                                };

                                var wardExists = context.Translators.Where(x => x.DataKey == translators.DataKey
                                   && x.TranslatedValue == translators.TranslatedValue);
                                if (wardExists.Count() == 0)
                                {
                                    context.Translators.Add(translators);
                                    context.SaveChanges();
                                    log += wardOriginalObj.Name + "-" + itemW.WARDS_NAME + "\n";
                                }
                            }
                            else
                            {
                                var wardNew = new Wards()
                                {
                                    Name = replaceString.ConverToUpper(itemW.WARDS_NAME),
                                    DistrictId = districtOriginId ?? 0
                                };

                                context.Wards.Add(wardNew);
                                context.SaveChanges();
                                var translators = new Translators()
                                {
                                    DataKey = "VTP.WARD",
                                    OriginalValue = Convert.ToString(wardNew.Id),
                                    TranslatedValue = Convert.ToString(itemW.WARDS_ID)
                                };
                                context.Translators.Add(translators);
                                context.SaveChanges();
                                log += itemW.WARDS_NAME + "\n";
                            }
                        }
                     
                    }
                }
            }

            Console.WriteLine(log);
        }
    }
}
