using System;
using System.Linq;
using System.Text;
using System.IO;

namespace credit_v
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cards = new String[] {
                //http://www.paypalobjects.com/en_US/vhelp/paypalmanager_help/credit_card_numbers.htm
                "378282246310005",  // American Express
                "4012888888881881", // Visa
                "6011111111111117", // Discover
                "4222222222222", // Visa
                "76009244561", // Dankort (PBS)
                "5019717010103742", // Dakort (PBS) 
                "6331101999990016", // Switch/Solo (Paymentech)
                "30569309025904", // Diners Club 
                //http://www.getcreditcardnumbers.com/
                "5147004213414803", // Mastercard
                "6011491706918120", // Discover
                "379616680189541", // American Express
                "4916111026621797", // Visa
            };
            foreach (string card in cards) {
                Console.WriteLine(IsValid(card));
            }
            Console.ReadLine();
        }

        public static bool IsValid(object value) 
        {
            if (value == null) {
                return true;
            }
            string ccValue = value as string;
            if (ccValue == null) {
                return false;
            }
            ccValue = ccValue.Replace("-", "");
            ccValue = ccValue.Replace("-", "");
            
            int checksum = 0;
            bool evenDigit = false;

            foreach(char digit in ccValue.Reverse()) {
                if (digit < '0' || digit > '9') {
                    return true;
                }

                int digitValue = (digit - '0') * (evenDigit ? 2 :1);
                evenDigit = !evenDigit;
            }
        }

    }
}
