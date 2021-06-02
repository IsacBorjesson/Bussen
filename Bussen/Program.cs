using System;
using System.Linq;
using System.Collections.Generic;

namespace Bussen
{
    enum Sex
    {
        Man = 0,
        Kvinna = 1,
    } 
    class Passenger
    {
        public int position;
        public string name;
        public int age;
        public Sex sex;

        public Passenger(int Position, string Name, int Age, Sex Sex)
        {
            position = Position;
            name = Name;
            age = Age;
            sex = Sex;
        }

        public void Poke_result()
        {
            if (age > 60 && sex == Sex.Kvinna)
            {
                Console.WriteLine("{0} erbjöd dig en karamell", name);
            }
            else if (age > 60 && sex == Sex.Man)
            {
                Console.WriteLine("{0} kollade upp från sin tidning och gav dig en sträng blick", name);
            }
            else if (age > 30 && age <= 60 && sex == Sex.Kvinna)
            {
                Console.WriteLine("{0} pausa sin ljudbok och frågade hur hon kunde hjälpa dig", name);
            }
            else if (age > 30 && age <= 60 && sex == Sex.Man)
            {
                Console.WriteLine("{0} kollade på dig en halv sekund innan han fortsatte att prata ur sitt trådlösa headset", name);
            }
            else if (age > 18 && age <= 30 && sex == Sex.Kvinna)
            {
                Console.WriteLine("{0} gav ingen reaktion utan bara fortsatte att lyssna på sin musik", name);
            }
            else if (age > 18 && age <= 30 && sex == Sex.Man)
            {
                Console.WriteLine("{0} märkte inte av dig för han var sedan 10 min in på resan i en djup sömn", name);
            }
            else
            {
                Console.WriteLine("{0} märkte inte av dig med näsan mot en ipad", name);
            }
        }
    }
    class Buss
    {
        public Passenger[] passenger = new Passenger[25];
        
        public Buss()
        {
            int input = 1;
            Sex sex;
            sex = (Sex)input;
            int input2 = 0;
            Sex sex2;
            sex2 = (Sex)input2;

            passenger[0] = new Passenger(0, "Anders", 50, sex2); 
            /*passenger[1] = new Passenger(1, "Malin", 5, sex);
            passenger[2] = new Passenger(2, "Isac", 22, sex2);
            passenger[24] = new Passenger(24, "Börje", 10, sex2);*/

        }

        public void Run()
        {
            int menu = 0;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Välkommen till bussen");
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1 Lägg till en passagerare");
                Console.WriteLine("2 Skriv ut bussens passagerare");
                Console.WriteLine("3 Beräkna den totala åldern på bussen");
                Console.WriteLine("4 Beräkna medelåldern på bussen");
                Console.WriteLine("5 Skriv ut den äldsta personen på bussen");
                Console.WriteLine("6 Hitta specifika ålderar på bussen");
                Console.WriteLine("7 Sortera bussen i åldersordning");
                Console.WriteLine("8 Peta på en passagerare");
                Console.WriteLine("9 Skriv ut allas kön som sitter på bussen");
                Console.WriteLine("10 Ta bort en passagerare");
                Console.WriteLine("0 Avsluta programmet");
                menu = UserInput.Menu();
                switch (menu)
                {
                    case 1:
                        Add_passenger();
                        break;
                    case 2:
                        Print_buss();
                        break;
                    case 3:
                        Calc_total_age();
                        break;
                    case 4:
                        Calc_average_age();
                        break;
                    case 5:
                        Max_age();
                        break;
                    case 6:
                        Find_age();
                        break;
                    case 7:
                        Sort_bus();
                        break;
                    case 8:
                        Poke();
                        break;
                    case 9:
                        Print_sex();
                        break;
                    case 10:
                        Getting_off();
                        break;
                    case 0:
                        Console.WriteLine("Programmet avslutas");
                        break;
                    default:
                        Console.WriteLine("Felaktig inmatning");
                        break;
                }
            }
            while (menu != 0);
        }

        public void Add_passenger()
        {
            int position = 0;
            string Name;
            int Age = 0;
            Sex Sex;
            position = UserInput.Position(passenger);
            Name = UserInput.Name();
            Age = UserInput.Age();
            Sex = (Sex)UserInput.Sex();

            passenger[position] = new Passenger(position, Name, Age, Sex);
            Console.WriteLine("En passagere klev precis på bussen");
        }

        public void Print_buss()
        {
            Console.WriteLine("Dina passagerare sitter i denna ordningen");
            foreach (var position in passenger)
            {
                if (position != null)
                {
                    Console.WriteLine("På plats {0} sitter den {1} årig {2} som heter {3}.",
                        position.position,
                        position.age,
                        position.sex.ToString().ToLower(),
                        position.name);
                }
            }
        }

        public int Calc_total_age()
        {
            int total_age = passenger.Where(x => x != null).Sum(x => x.age);
            Console.WriteLine("Den totala åldern på bussen är {0} år", total_age);
            return total_age;
        }

        public double Calc_average_age()
        {
            double average_age = passenger.Where(x => x != null).Average(x => x.age);
            Console.WriteLine("Medelåldern i denna bussen är {0} år",average_age);
            return average_age;
        }

        public int Max_age()
        {
            int max_age = passenger.Where(x => x != null).Max(x => x.age);
            Console.WriteLine("Den äldsta personen på bussen är {0} år gammal", max_age);
            return max_age;
        }

        public void Find_age()
        {
            Console.WriteLine("Välj två åldrar att söka mellan");
            int lowerBound = 0;
            int upperBound = 0;
            lowerBound = UserInput.Age();
            upperBound = UserInput.Age();

            string[] array_name = passenger.Where(x => x != null).Where(x => x.age >= lowerBound && x.age <= upperBound).Select(x => x.name).ToArray();
            Console.WriteLine("Dessa personer finns mellan åldrarna du satte");
            foreach (string name in array_name)
            {
                Console.WriteLine(name);
            }
        }

        public Passenger [] Sort_bus()
        {
            Passenger[] intarray = passenger.Where(x => x != null).Select(x => x).ToArray();
            intarray = Bubblesort(intarray);
            Print_list(intarray);
            return intarray;
        }
        public Passenger[] Bubblesort(Passenger []passenger)
        {
            int a = passenger.Length;
            for (int i = 0; i < a - 1; i++)
            {
                for (int j = 0; j < a - i - 1; j++)
                {
                    if (passenger[j].age > passenger[j + 1].age)
                    {
                        Passenger temp = passenger[j];
                        passenger[j] = passenger[j + 1];
                        passenger[j + 1] = temp;
                    }
                }
            
            }
            return passenger;
        }
        public Passenger[] Print_list(Passenger[] passenger)
        {
            Console.WriteLine("Detta är bussen sorterad i åldersordning: \n");
            int n = passenger.Length;
            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine(passenger[i].name );
                Console.WriteLine(passenger[i].age );
            }
            return passenger;
        }

        public void Print_sex()
        {
            Console.WriteLine("Så här sitter folk med tanke på deras kö:");
            foreach (var position in passenger)
            {
                if (position != null)
                {
                    Console.WriteLine("På plats {0} sitter en {1}", position.position, position.sex.ToString().ToLower());
                }
            }
        }

        public void Poke()
        {
            Console.WriteLine("På dessa platser sitter folk");
            foreach (var position in passenger)
            {
                if (position != null)
                {
                    Console.WriteLine("Plats {0} sitter {1}", position.position, position.name);
                }
            }

            Console.WriteLine("Skriv in på vilken plats den du vill peta på sitter");
            int poke = 0;
            poke = UserInput.Position(passenger, false);
            var person2 = passenger[poke];
            person2.Poke_result();
        }

        public void Getting_off()
        {
            //var userInput = new UserInputServes();
            var input = UserInput.Position(passenger, true);

            for (int i = 0; i < passenger.Length; i++)
            {
                if (passenger[i]?.position == input)
                {
                    Console.WriteLine("{0} steg precis av bussen", passenger[input].name);
                    passenger[i] = null;
                }
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var minbuss = new Buss();
            minbuss.Run();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}