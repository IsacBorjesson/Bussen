using System;
using System.Collections.Generic;
using System.Text;

namespace Bussen
{
    class UserInput
    {
        // Här har vi då klassen jag skapade för att ta hand om allt användaren kan skicka in i programmet
        // Jag delade även upp det på detta sättet för att testa på hur man senare ska arbeta för att göra det enklare att återanvända
        // Så man i ett senare projekt kan använda denna strukturen för sina UserInput 
        // De blir möjligt för nu får man inte med något av projektet bussen egentligen så den är mer omanvändbar för mig själv och även andra
        // Så här under har vi metoder som hanterar user input i variablerna position, name, age, sex och menu 
        public static int Position(Passenger[] passengers)
        {
            // Vad som finns i denna är en try catch som även går djupare i att kolla om positionen användaren skickar in är inom ramen 0 till 24
            // Där kollas bool metoden IsPositionValid som kollar detta och skickar tillbaka true eller false
            // Så antingen blir det loop = false och metoden är klar eller så är positionen upptagen och man kallar på metoden PrintOccupiedMessage
            // Där man skriver ut vart folk sitter så man kan välja en plats som inte är upptagen, så att man i nästa loop kan välja rätt och avsluta metoden
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
        // Ändring i inparrametrarna som blir en bool variabel
        public static int Position(Passenger[] passengers, bool CheckOccepiedPosition)
        {
            // Här har vi samma början men sen i else if satsen har vi if satsen som har bool variabeln CheckOccepiedPosition som i detta fallet är försatt till true
            // Då kallar den på metoden VerifyOccupancy() som kollar om det sitter någon där använder valde och blir då tvärt om här än på förra
            // Man kommer nu få det utskrivet vilka platser någon sitter i om man väljer en plats där någon inte sitter
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
                        if (CheckOccepiedPosition)
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

        private static bool IsPositionValid(int position)
        {
            return (0 <= position && position < 25);
        }

        private static bool IsPositionOccuped(Passenger[] passenger, int position)
        {           
            return (passenger[position] != null);           
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

        private static bool VerifyOccupancy(Passenger[] passengers, int position)
        {
            var isPositionOccuped = IsPositionOccuped(passengers, position);
            if (!isPositionOccuped)
            {
                PrintOccupiedMessage(passengers);
            }
            return !isPositionOccuped;
        }

        public static string Name()
        {
            // Ändringen i denna är att man kallar på IsNameValid()
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
            // Char.IsLetter() är något jag sökt mig fram för att kunna skilja på karraktären string 1 som för oss är en siffra och string A som är en bokstav
            // Det den gör är att kolla om det man skickar in i string variabeln name är bara bokstäver och inte någon siffra
            //  Foreach loopen funkar i att string i sig är en array och nu skickas varje karaktär i name in IsLetter() som kollar alla 
            // Om någon nu är en siffra så blir if true och man retunerar false som gör att Name() skriver ut "Inkorrekt inmatning"
            // Det som kommer efter är så att om man inte skriver in något så blockas det upp som för fel, för try catch fångar inte upp de
            foreach (var characters in name)
            {
                if (!Char.IsLetter(characters))
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
            // Inget nytt som inte har blivit förklarat innan
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
            // Inget nytt som inte har blivit förklarat innan
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
            // Inget nytt som inte har blivit förklarat innan
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
