using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestFromCleverenceSoft
{
    public class RLE
    {
        private string Input;
        private string Result_Coding;
        private string Result_Decoding;
        public RLE()
        {
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Input += Console.ReadLine();
            }
            //Input = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqwertttttttrrr";
        }
        public string Сoding()
        {
            int count = 1;
            char letter = Input[0];
            for (int i = 1; i < Input.Length; i++)
            {
                if(Input[i]== letter)
                {
                    count++;
                }
                else
                {
                    Result_Coding += letter;
                    if (count != 1)
                    { 
                        Result_Coding += count.ToString();
                    }
                    count = 1;
                    letter = Input[i];
                }
            }
            Result_Coding += letter;
            Result_Coding += count.ToString();
            return Result_Coding;
        }
        public string Decoding()
        {
            Result_Decoding = "";
            int count = 0;
            char letter = Result_Coding[0];
            for (int i = 1; i < Result_Coding.Length; i++)
            {
                int parse_letter;
                if (int.TryParse(Result_Coding[i].ToString(), out parse_letter))
                {
                    count = count * 10 + parse_letter;
                }
                else
                {
                    if(count==0)
                    {
                        count = 1;
                    }
                    for (int j = 0; j < count; j++)
                    {
                        Result_Decoding += letter;
                    }
                    letter = Result_Coding[i];
                    count = 0;
                }
            }
            for (int j = 0; j < count; j++)
            {
                Result_Decoding += letter;
            }
            return Result_Decoding;
        }
    }
}