using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;

namespace EFCoreTranslators.Service
{
    public class ReplaceString
    {
        public string ConverToUpper(string inputText)
        {
            string res = String.Empty;
            string[] s = inputText.Split(' ');
            for(int i = 0; i < s.Count(); i++)
            {
                res += ToUpperFirstLetter(s[i]) + ' ';
            }
            return res.Substring(0,res.Length-1);

        }
        public string ToUpperFirstLetter(string source)
        {
            source = source.ToLower();
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }


        public string Replace(string inputText, string type)
        {           
            string[] array = inputText.ToUpper().Split(' ');
            inputText = String.Empty;
            for (int i = 0; i < array.Count(); i++)
            {                
                string aString = array[i];
                aString = Regex.Replace(aString, @"\s|-", "");
                aString = NonUnicode(aString);
                string aString2 = RemoveAccents(aString);
                if(aString2.Count() != aString.Count())
                {
                    aString = "D" + aString2;
                }
                inputText+= aString;

            }         
            if (type == "DISTRICT" || type == "WARD")
            {
                string[] arr = new string[]
                {
                    "QUAN",
                    "HUYEN",
                    "THIXA",
                    "THANHPHO",
                    "DAO",
                    "THITRAN",
                    "XA",
                    "PHUONG",
                    "THITRANNT",
                    "0",
                    "TTNONGTRUONG",
                    "THITRAN"
                };
                for (int i = 0; i < arr.Length; i++)
                {
                    bool a = inputText.StartsWith(arr[i]);
                  
                    if (a == true)
                    {
                        inputText = inputText.Replace(arr[i], String.Empty);
                    }
                }
            }
            return inputText;
        }
       
        public string NonUnicode(string s)
        {   
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {                
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {                                 
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            string res = (sb.ToString().Normalize(NormalizationForm.FormD));                
            return res;            
        }
   
        public string RemoveAccents(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormKD);
            Encoding removal = Encoding.GetEncoding(Encoding.ASCII.CodePage,
                                                    new EncoderReplacementFallback(""),
                                                    new DecoderReplacementFallback(""));
            byte[] bytes = removal.GetBytes(normalized);
            return Encoding.ASCII.GetString(bytes);
        }     
    }
}
