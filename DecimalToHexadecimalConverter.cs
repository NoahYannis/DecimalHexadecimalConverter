using System;
using System.Collections.Generic;

namespace DecimalHexadecimalConverter
{
    public static class DecimalToHexadecimalConverter
    {
        public static double EnteredNumber { get; set; }

        /// <summary>
        /// The last number we divided by 16 (rounded off).
        /// </summary>
        public static double OldCalculationNumber { get; set; }

        /// <summary>
        /// The next number divided by 16.
        /// </summary>
        public static double CurrentCalculationNumber { get; set; }


        /// <summary>
        /// The remainder of the most recent ConvertNumber() calculation.
        /// </summary>
        public static double Remainder { get; set; } = 0;


        /// <summary>
        /// The calculation is finished once the current calculation number is smaller than 1.
        /// </summary>
        public static bool CalculationFinished { get; set; } = false;


        /// <summary>
        /// All division remainders are added to this list, reversed and displayed as the converted number.
        /// </summary>
        public static List<object> DivisionRemainders { get; set; } = new List<object>();


        static void Main(string[] args)
        {
            EnteredNumber = GetNumber();
            ConvertNumber();
            AssembleConvertedNumber();
        }


        /// <summary>
        /// Converts the entered number
        /// </summary>
        public static void ConvertNumber()
        {

            // The first calculation is done on the number entered by the user.
            CurrentCalculationNumber = EnteredNumber;
            Remainder = 0;

            while (!CalculationFinished)
            {

                OldCalculationNumber = Math.Floor(CurrentCalculationNumber);
                CurrentCalculationNumber = OldCalculationNumber / 16;

                // Remainder = difference between the old and the new number we divided by 16.
                Remainder = OldCalculationNumber - Math.Floor(CurrentCalculationNumber) * 16;

                // If our new number is smaller than 1, the calculation finished.
                if (CurrentCalculationNumber < 1)
                {
                    CalculationFinished = true;
                    AddNumberOrLetter(Math.Ceiling(CurrentCalculationNumber));
                    return;
                }

                // Our new number is greater than zero, the calculation continues.
                AddNumberOrLetter(Remainder);
            }

        }


        /// <summary>
        /// Asks the user to enter a number and saves it in the "EnteredNumber" property.
        /// </summary>
        /// <returns></returns>
        public static double GetNumber()
        {
            Console.WriteLine("Decimal To Hexadecimal Converter ---------------------------------");
            Console.Write("What number would you like to convert? (must be a positive integer): ");

            try
            {
                EnteredNumber = Convert.ToInt64(Console.ReadLine());

                while (EnteredNumber < 0 || EnteredNumber % 1 != 0)
                {
                    Console.WriteLine("Number must be a positive integer)");
                    EnteredNumber = Convert.ToInt64(Console.ReadLine());
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return EnteredNumber;
        }


        /// <summary>
        /// Takes the remainder of ConvertNumber() and transforms it to its hexadecimal equivalent. 
        /// </summary>
        /// <param name="remainder"></param>
        public static void AddNumberOrLetter(double remainder)
        {
            if (Remainder <= 9)
            {
                DivisionRemainders.Add(Remainder);
                return;
            }

            string convertedLetter = null;

            switch (Remainder)
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


        /// <summary>
        /// Takes all division remainders, reverses and displays them on the console.
        /// </summary>
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
