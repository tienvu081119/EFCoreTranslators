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
using Microsoft.VisualBasic;

namespace EFCoreTranslators.Service
{
    public class Vtp_District
    {
        public void Run()
        {
            string log = String.Empty;
            ReplaceString replaceString = new ReplaceString();
            DirectoryInfo dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;
            string dirPath = dir.FullName;
            string templateReport = System.IO.Path.Combine(dirPath, @"Json\District.json");
            using (StreamReader r = new StreamReader(templateReport))
            {
                string json = r.ReadToEnd();
                List<District> items = JsonConvert.DeserializeObject<List<District>>(json);
                using (var context = new quickbeedev1Context())
                {
                    var translator = context.Translators.Where(x => x.DataKey == "VTP.PROVINCE").ToList();
                    foreach(var i in translator)
                    {
                        int? provinceOriginalId = Convert.ToInt32(i.OriginalValue);                      
                        string provinceJsId = i.TranslatedValue;
                        //List DistrictJS
                        var districtJsList = items.Where(x => x.PROVINCE_ID == provinceJsId);
                        var districtOriginalList = (from d in context.Districts.Where(x => x.ProvinceId == provinceOriginalId)
                                                    select new
                                                    {
                                                        Id = d.Id,
                                                        Name = replaceString.Replace(d.Name, "DISTRICT")
                                                    }).ToList();                       
                        
                        foreach (var itemD in districtJsList)
                        {
                            var districtOriginalObj = districtOriginalList.Where(x => x.Name == replaceString.Replace(itemD.DISTRICT_NAME, "DISTRICT")).FirstOrDefault();
                            if (districtOriginalObj != null)
                            {
                                var translators = new Translators()
                                {
                                    DataKey = "VTP.DISTRICT",
                                    OriginalValue = Convert.ToString(districtOriginalObj.Id),
                                    TranslatedValue = Convert.ToString(itemD.DISTRICT_ID)
                                };
                                var districtExists = context.Translators.Where(x => x.DataKey == translators.DataKey
                                    && x.TranslatedValue == translators.TranslatedValue);
                                if (districtExists.Count() == 0)
                                {
                                    context.Translators.Add(translators);
                                    context.SaveChanges();
                                    log += districtOriginalObj.Name + "-" + itemD.DISTRICT_NAME + "\n";
                                }
                            }
                            else
                            {
                                var districtNew = new Districts()
                                {
                                    Name = replaceString.ConverToUpper(itemD.DISTRICT_NAME),
                                    ProvinceId = provinceOriginalId ?? 0
                                };

                                context.Districts.Add(districtNew);
                                context.SaveChanges();
                                var translators = new Translators()
                                {
                                    DataKey = "VTP.DISTRICT",
                                    OriginalValue = Convert.ToString(districtNew.Id),
                                    TranslatedValue = provinceJsId
                                };
                                context.Translators.Add(translators);
                                context.SaveChanges();
                                log += itemD.DISTRICT_NAME + "\n";
                            }
                        }
                    }
                    Console.WriteLine(log);
                }
            }
        }
    }
}
