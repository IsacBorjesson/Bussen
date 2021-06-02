using System;
using System.Collections.Generic;
using System.Text;

namespace Bussen
{
    class UserInput
    {

        public static int Position(Passenger[] passengers)
        {
            bool loop = true;
            int position = 0;
            do
            {
                try
                {
                    Console.WriteLine("Skriv in position");
                    position = int.Parse(Console.ReadLine());
                    if (IsPositionValid(position))
                    {
                        if (!IsPositionOccuped(passengers, position))
                        {
                            loop = false;
                        }
                        else
                        {
                            PrintOccupiedMessage(passengers);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bussen har bara platser mellan 0 och 24");
                    }
                }
                catch
                {
                    Console.WriteLine("Inkorrekt inmatning");
                }
            }
            while (loop);
            return position;
        }

        public static int Position(Passenger[] passengers, bool CheckOccepiedSeat)
        {
            bool loop = true;
            int position = 0;
            do
            {
                try
                {
                    Console.WriteLine("Skriv in position");
                    position = int.Parse(Console.ReadLine());

                    if (IsPositionValid(position))
                    {
                        if (CheckOccepiedSeat)
                        {

                            loop = VerifyOccupancy(passengers, position);
                             
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bussen har bara platser mellan 0 och 24");
                    }
                }
                catch
                {
                    Console.WriteLine("Inkorrekt inmatning");
                }
            }
            while (loop);
            return position;
        }

        private static bool VerifyOccupancy(Passenger[] passengers, int position)
        {
            var isPositionOccuped = IsPositionOccuped(passengers, position);
            if (!isPositionOccuped)
            {
                PrintOccupiedMessage(passengers);
            }
            return !isPositionOccuped;
        }

        private static void PrintOccupiedMessage(Passenger[] passengers)
        {
            Console.WriteLine("På dessa platser sitter passagerare");
            foreach (var passenger in passengers)
            {
                if (passenger != null)
                {
                    Console.WriteLine(passenger.position);
                }
            }
        }

        private static bool IsPositionOccuped(Passenger[] passenger, int position)
        {           
            return (passenger[position] != null);           
        }

        private static bool IsPositionValid(int position)
        {
            return (0 <= position && position < 25);
        }

        public static string Name()
        {
            bool loop = true;
            string name = "";
            Console.WriteLine("Skriv in namn");
            do
            {
                try
                {
                    name = Console.ReadLine();
                    if (IsNameValid(name))
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Inkorrekt inmatning");
                    }
                }
                catch 
                {
                    Console.WriteLine("Super inkorrekt inmatning");
                }
            }
            while (loop);
            return name;
        }

        private static bool IsNameValid(string name)
        {
            foreach (var charekter in name)
            {
                if (!Char.IsLetter(charekter))
                {
                    return false;
                }
            }
            if (0 < name.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int Age()
        {
            bool loop = true;
            int age = 0;
            do
            {
                try
                {
                    Console.WriteLine("Skriv in åldern");
                    age = int.Parse(Console.ReadLine());
                    if (IsAgeValid(age))
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Det var en omöjlig ålder");
                    }
                }
                catch
                {
                    Console.WriteLine("Inkorrekt inmatning");
                }
            }
            while (loop);
            return age;
        }

        private static bool IsAgeValid(int age)
        {
            return (0 <= age && age <= 120);
        }

        public static int Sex()
        {
            bool loop = true;
            int sex = 0;
            do
            {
                try
                {
                    Console.WriteLine("Skriv in kön:");
                    Console.WriteLine("Man = 0 Kvinnna = 1");
                    sex = int.Parse(Console.ReadLine());
                    if (IsSexValid(sex))
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Du behöver skriva in talen 0 eller 1");
                    }
                }
                catch
                {
                    Console.WriteLine("Inkorrekt inmatning");
                }
            }
            while (loop);
            return sex;
        }

        private static bool IsSexValid(int sex)
        {
            return (sex == 0 || sex == 1);
        }

        public static int Menu()
        {
            bool loop = true;
            int menu = 0;
            do
            {
                try
                {
                    menu = int.Parse(Console.ReadLine());
                    if (IsMenuValid(menu))
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Du behöver välja ett nummer som finns i menyn");
                    }
                }
                catch
                {
                    Console.WriteLine("Inkorrekt inmatning");
                }
            }
            while (loop);
            return menu;
        }

        private static bool IsMenuValid(int menu)
        {
            return (0 <= menu && menu <= 10);
        }
    }
}
