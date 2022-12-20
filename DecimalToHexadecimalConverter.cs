using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DecimalHexadecimalConverter
{
    public static class DecimalToHexadecimalConverter 
    {
        public static double EnteredNumber { get; set; }
        public static double OldCalculationNumber { get; set; }
        public static double CurrentCalculationNumber { get; set; }
        public static List<object> DivisionRemainders { get; set; } = new List<object>();

        static void Main(string[] args)
        {            
            ConvertNumber(EnteredNumber);
            AssembleConvertedNumber();
        }

        public static void ConvertNumber(double oldNumber)
        {
            CurrentCalculationNumber = GetNumber();
            double remainder = 0;

            while (!(CurrentCalculationNumber < remainder))
            {
                OldCalculationNumber = Math.Floor(CurrentCalculationNumber);
                CurrentCalculationNumber = OldCalculationNumber / 16;
                remainder = OldCalculationNumber - Math.Floor(CurrentCalculationNumber) * 16;

                if (CurrentCalculationNumber < 1)
                {
                    remainder = Math.Floor(OldCalculationNumber);
                }

                AddNumberOrLetter(remainder);

            }
        }

        public static double GetNumber()
        {
            Console.Write("Which number would you like to convert? (positive integer): ");
            EnteredNumber = Convert.ToInt32(Console.ReadLine());

            while (EnteredNumber < 0 || EnteredNumber % 1 != 0)
            {
                Console.WriteLine("Number must be a positive integer)");
                EnteredNumber = Convert.ToInt32(Console.ReadLine());
            }

            return EnteredNumber;
        }


        public static void AddNumberOrLetter(double remainder)
        {
            if (remainder < 9)
            {
                DivisionRemainders.Add(remainder);
                return;
            }

            string convertedLetter = null;

            switch (remainder)
            {
                case 10:
                    convertedLetter = "A";
                    break;

                case 11:
                    convertedLetter = "B";
                    break;

                case 12:
                    convertedLetter = "C";
                    break;

                case 13:
                    convertedLetter = "D";
                    break;

                case 14:
                    convertedLetter = "E";
                    break;

                case 15:
                    convertedLetter = "F";
                    break;

                case 16:
                    convertedLetter = "A";
                    break;
            }

            DivisionRemainders.Add(convertedLetter);
        }

        public static void AssembleConvertedNumber()
        {
            DivisionRemainders.Reverse();
            Console.WriteLine();

            foreach (object remainder in DivisionRemainders)
            {
                Console.Write(remainder.ToString());
            }

            Console.ReadLine();
        }
    }
}
