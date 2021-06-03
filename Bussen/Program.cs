using System;
using System.Linq;
using System.Collections.Generic;

namespace Bussen
{
    // Skapar en vektor där endast två alternativ är godkända i 0 och 1 som reprensenterar könen
    enum Sex
    {
        Man = 0,
        Kvinna = 1,
    }
    // Klassen som jag skapar för att dela upp och göra koden mer lättläslig och logisk
    class Passenger
    {
        // Började uppgiften med att jobba med endast publika metoder och testar och visar här hur man ska hantera om man vill sätta variablera till privata
        public int position { get { return _position; } }
        public string name { get { return _name; } }
        public int age { get { return _age; } }
        public Sex sex { get { return _sex; } }

        private int _position { get; set; }
        private string _name { get; set; }
        private int _age { get; set; }
        private Sex _sex { get; set; }

        public Passenger(int Position, string Name, int Age, Sex Sex)
        {
            _position = Position;
            _name = Name;
            _age = Age;
            _sex = Sex;
        }
        // En metod för Poke() som den blir kallad av, och är bara en samling av en massa else if satser
        // Här jag även börjar märka av funtionalliteten av att dela in kodblock i olika klasser och metoder
        // På detta sättet får man inte stora, långa och svårföljda metoder utan flera olika metoder i samma uppgift som man lättare kan följa
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
        // En vanlig deklaration av objektet passenger som innehåller en array med 25 index platser
        public Passenger[] passenger = new Passenger[25];
        // Här programet startar som deklarationen i main() utfärdar
        public void Run()
        {
            // Väldigt simpel meny tagen från youtubevideorna rekomenderade för uppgiften
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
                Console.WriteLine("8 Hur många män/kvinnor det finns på bussen");
                Console.WriteLine("9 Peta på en passagerare");
                Console.WriteLine("10 Ta bort en passagerare");
                Console.WriteLine("0 Avsluta programmet");
                // Här kommer första användningen av klassen UserInput som jag byggde i första hand för att hantera denna try and catch
                // Men det blev att jag blev intreserad av att utöka klassens funktion så nu tar klassen hand om all input från användaren
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
                        Print_sex(); 
                        break;
                    case 9:
                        Poke();
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
            // Kallar på metoden som kollar om bussen är full
            if (IsBussFull(passenger))
            {
                Console.WriteLine("Bussen är full");
            }
            else
            {
                // Här kallar jag nu igen på metoder i klassen UserInput som jag nu även har skapat en ny fil till för den
                // Så det blir lättare för mig att gå mellan klasserna och man inte behöver skrolla och leta lika mycket efter metoderna
                position = UserInput.Position(passenger);
                Name = UserInput.Name();
                Age = UserInput.Age();
                Sex = (Sex)UserInput.Sex();
                // Slutligen efter man har skrivit in alla värden korrekt så läggs nu allt in i arrayen och man skickas tillbaka till menyn
                passenger[position] = new Passenger(position, Name, Age, Sex);
                Console.WriteLine("En passagere klev precis på bussen");
            }

        }

        public void Print_buss()
        {
            // Kallar på metoden som kollar om bussen är tom
            if (IsBussEmty(passenger))
            {
                Console.WriteLine("Bussen är tom");
            }
            else
            {
                // Här skriver vi då ut arrayen med en foreach loop
                Console.WriteLine("Dina passagerare sitter i denna ordningen");
                foreach (var position in passenger)
                {
                    // Så nu har vi första problemet med att ha en array istället för en lista och vi har ofta indexpositioner med värdet null
                    // Null ger problem för man kan ju inte skriva ut något som inte finns, så här löser jag det med att filtera så med en if sats
                    // Så nu kommer inte indexpositionerna med null kunna krasha programmet
                    if (position != null)
                    {
                        Console.WriteLine("På plats {0} sitter den {1} årig {2} som heter {3}.",
                            // Här kallas de specifika variablera från arrayen så de kan bli utskrivna
                            position.position,
                            position.age,
                            position.sex.ToString().ToLower(),
                            position.name);
                    }
                }
            }
        }
        // Två simpla metoder som bara kollar om bussen är full eller tom och används i Add_ och Print_buss
        private static bool IsBussFull(Passenger[] passengers)
        {
            // Den kollar alla index platser i arrayen och om någon av dessa platser är null (alltså tomma) kommer metoden retunera false
            // Som innebär att if satsen inte körs
            foreach (var p in passengers)
            {
                if (p == null)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool IsBussEmty(Passenger[] passengers)
        {
            foreach (var p in passengers)
            {
                if (p != null)
                {
                    return false;
                }
            }
            return true;
        }
        
        public int Calc_total_age()
        {
            if (IsBussEmty(passenger))
            {
                Console.WriteLine("Bussen är tom");
                int tempint = 0;
                return tempint;
            }
            else
            {
                // Här kommer nästa lösning på null problemet i att använda metoder från System.Linq i Where() 
                // Som bara använder och skickar vidare indexpositioner som inte har värde null genom en lambda expression
                // Sen för att faktiskt lösa uppgiften metoden är namngiven efter så används värderna som inte är null i Sum()
                // Där metoden Sum() räknar ihop summan av alla åldrar från variabeln age i arrayen passenger
                // Vet att man kanske ska lösa uppgiften med att manuellt göra en liknade metod som Sum() med for eller foreach loopar 
                // Men tröttna rätt snabbt på det och sökte efter andra sätt att lösa på de så jag faktiskt kan lära mig något nytt
                int total_age = passenger.Where(x => x != null).Sum(x => x.age);
                Console.WriteLine("Den totala åldern på bussen är {0} år", total_age);
                return total_age;
            }
        }
        
        public double Calc_average_age()
        {
            if (IsBussEmty(passenger))
            {
                Console.WriteLine("Bussen är tom");
                double tempdouble = 0;
                return tempdouble;
            }
            else
            {
                // Exakt samma som förra med ändring på byte av metod till Average() och att metoden Calc_average_age nu returnerar double
                double average_age = passenger.Where(x => x != null).Average(x => x.age);
                Console.WriteLine("Medelåldern i bussen är {0} år", average_age);
                return average_age;
            }
            
        }
        
        public int Max_age()
        {
            if (IsBussEmty(passenger))
            {
                Console.WriteLine("Bussen är tom");
                int tempint = 0;
                return tempint;
            }
            else
            {
                // Samma fast med Max()
                int max_age = passenger.Where(x => x != null).Max(x => x.age);
                Console.WriteLine("Den äldsta personen på bussen är {0} år gammal", max_age);
                return max_age;
            }
        }

        public void Find_age()
        {
            if (IsBussEmty(passenger))
            {
                Console.WriteLine("Bussen är tom");
            }
            else
            {
                Console.WriteLine("Välj två åldrar att söka mellan");
                int lowerBound = 0;
                int upperBound = 0;
                // Kallar på en metod från klass UserInput
                lowerBound = UserInput.Age();
                upperBound = UserInput.Age();
                // Här använder vi samma ide som vid de förra metoderna och utökar den lite
                // Börjar med att lösa null problemet sen väljer man ut indexpositioner som har åldern mellan just de två åldrarna användaren skriver in
                //Sen om det fanns någon indexposition som klara sig igenom alla krav så används Select() metoden så man hämtar ut just variabeln name ur arrayen 
                // För att lägga alla värderna ur name i string arrayen array_name och då behövs metoden ToArray() 
                // Som behövs för att den ska kunna lägga värderna i en array och inte i en int som varit fallet i de förra egengjorda metoderna
                string[] array_name = passenger.Where(x => x != null).Where(x => x.age >= lowerBound && x.age <= upperBound).Select(x => x.name).ToArray();
                Console.WriteLine("Dessa personer finns mellan åldrarna du satte");
                // Sen skriver man då just ut värderna ur arrayen vi skapade
                foreach (string name in array_name)
                {
                    Console.WriteLine(name);
                }
            }
        }
        
        public Passenger [] Sort_bus()
        {
            if (IsBussEmty(passenger))
            {
                Console.WriteLine("Bussen är tom");
                Passenger[] temparray = passenger.Where(x => x != null).Select(x => x).ToArray();
                return temparray;
            }
            else
            {
                // Skapar ett nytt objekt där man inte tar med null och anpassar det till array
                // Sen kallar man på de två metoderna som sorterar arrayen sen den andra som skriver ut det
                Passenger[] intarray = passenger.Where(x => x != null).Select(x => x).ToArray();
                intarray = Bubblesort(intarray);
                Print_list(intarray);
                return intarray;
            }
        }
        public Passenger[] Bubblesort(Passenger [] intarray)
        {
            // Här fanns det det redan en metod i .Sort() om man använder sig av en lista men med en array får man göra en egen
            // Då stog det något om bubblesort så då använde jag den
            int a = intarray.Length;
            for (int i = 0; i < a - 1; i++)
            {
                for (int j = 0; j < a - i - 1; j++)
                {
                    if (intarray[j].age > intarray[j + 1].age)
                    {
                        Passenger temp = intarray[j];
                        intarray[j] = intarray[j + 1];
                        intarray[j + 1] = temp;
                    }
                }
            
            }
            return intarray;
        }
        public Passenger[] Print_list(Passenger[] intarray)
        {
            Console.WriteLine("Detta är bussen sorterad i åldersordning: \n");
            int n = intarray.Length;
            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine(intarray[i].name );
                Console.WriteLine(intarray[i].age );
            }
            return intarray;
        }
        
        public void Print_sex()
        {
            if (IsBussEmty(passenger))
            {
                Console.WriteLine("Bussen är tom");
            }
            else
            {
                // Det nya här är att omvandla Sex sex till int sex och då får man ut värderna 0 eller 1 istället för Man och Kvinna
                // Så efter det kan man lättare skilja på dem så man kan räkna och sen skriva ut hur många kvinnor och män det finns i bussen
                int man = 0;
                int woman = 0;
                foreach (var position in passenger)
                {
                    if (position != null)
                    {
                        int sex = (int)position.sex;
                        if (sex == 0)
                        {
                            man++;
                        }
                        else if (sex == 1)
                        {
                            woman++;
                        }
                    }
                }
                PrintSexMessage(man, woman);
            }
        }

        private void PrintSexMessage(int man, int woman)
        {
            if (man == 1 && woman == 1)
            {
                Console.WriteLine("Det finns {0} man och {1} kvinna på bussen", man, woman);
            }
            else if (man == 1)
            {
                Console.WriteLine("Det finns {0} man och {1} kvinnor på bussen", man, woman);
            }
            else if (woman == 1)
            {
                Console.WriteLine("Det finns {0} män och {1} kvinna på bussen", man, woman);
            }
            else
            {
                Console.WriteLine("Det finns {0} män och {1} kvinnor på bussen", man, woman);
            }
        }

        public void Poke()
        {
            if (IsBussEmty(passenger))
            {
                Console.WriteLine("Bussen är tom");
            }
            else
            {
                // Skriver ut vart passagerarna sitter så man slipper gissa 
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
                // Kallar på metod i UserInput
                poke = UserInput.Position(passenger, true);
                var person2 = passenger[poke];
                // Kallar på metod i Passenger
                person2.Poke_result();
            }

        }

        public void Getting_off()
        {
            if (IsBussEmty(passenger))
            {
                Console.WriteLine("Bussen är tom");
            }
            else
            {
                // Kallar på metod i UserInput
                var input = UserInput.Position(passenger, true);
                for (int i = 0; i < passenger.Length; i++)
                {
                    // Man lokaliserar rätt indexposition som man vill "radera" och när den är hittad gäller if satsen och då görs den indexpositionen till null
                    if (passenger[i]?.position == input)
                    {
                        Console.WriteLine("{0} steg precis av bussen", passenger[input].name);
                        passenger[i] = null;
                    }
                }
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            // Man skapar objektet minbuss som sedan kallar på metoden Run() som körs och "programmet" startar 
            // Programmet slutas då när Run() är klart då användaren väljer 0 på menyn och man kommer tillbaka till Main() igen och programmet är klart
            var minbuss = new Buss();
            minbuss.Run();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}