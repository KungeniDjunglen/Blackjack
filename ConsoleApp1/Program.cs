using System;

// Blackjack V1 

namespace Kortlek
{
    public class Program
    {
        public string WinChecker(int up, int cp)
            {
                if (up > 21)  // De två nedanstående if kollar om de har förlorat
                {
                    Console.WriteLine("Du förlorade med " + cp + " poäng.");
                    return "c";
                }
                else if (cp > 21)
                {
                    Console.WriteLine("Du vann med " + up + " poäng :)");
                    return "u";
                }
                return " ";
            }
        public int kortRND(int times)
        {            
            Random rnd = new Random();
            int answear = 0;
            for (int x = 0; x < times; x++)
            {
                answear += rnd.Next(1,14);
            }

            return answear;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Kortlek v1");
            bool gameon = true;
            bool vinnare = false;
            while (gameon == true)
            {

                Console.WriteLine("Välj ett av alternativen:");
                Console.WriteLine("1. Spela blackjack");
                Console.WriteLine("2. Visa spelets senaste vinnare");
                Console.WriteLine("3. Spelets regler");
                Console.WriteLine("4. Avsluta programet");
                int val = int.Parse(Console.ReadLine());
                switch (val) {
                    case 1:
                        var p = new Program();  // All här nedan kör i början av spelet för att spelarna ska ta två kort
                        int up = p.kortRND(2);
                        int cp = p.kortRND(2);
                        Console.WriteLine("Dina poäng är: " + up);
                        Console.WriteLine("Datorns poäng är: " + cp);

                        if (p.WinChecker(up,cp) == "u") { vinnare = true; break; }
                        if (p.WinChecker(up,cp) == "c") { vinnare = false; break; }

                        Console.WriteLine("Vill du ta ett till kort? (y/n)");
                        string gval = Console.ReadLine().ToLower();
                        if (gval == "y")  // Kör så länge spelaren vill fortsätta ta upp kort.
                        {
                            while (gval == "y")
                            {
                                int x = p.kortRND(1);
                                Console.WriteLine("Ditt nya kort är: " + x);
                                up = up + x;
                                cp = cp + p.kortRND(1);
                                Console.WriteLine("Dina poäng är: " + up);
                                Console.WriteLine("Datorns poäng är: " + cp);

                                if (p.WinChecker(up, cp) == "u") { vinnare = true; break; }
                                if (p.WinChecker(up, cp) == "c") { vinnare = false; break; }

                                Console.Write("Vill du fortsätta ? ");
                                gval = Console.ReadLine().ToLower();
                            }
                        }  // Körs för att datorn ska ta upp kort till den har mer än spelaren.
                        else if (gval == "n")
                        {
                            while(cp < up)
                            {
                                cp = cp + p.kortRND(1);
                                if (p.WinChecker(up, cp) == "u") { vinnare = true; break; }
                            }
                        }
                        else
                        { // om man skriver inn något dummt istället för y/n
                            Console.WriteLine("y/n vad är det du inte fattar?");
                            break;
                        }

                        if (up > cp && up < 22)    //Slutchecken för att kolla vem som vann
                        {
                            Console.WriteLine("Du vann med: " + up + " poäng! :)");
                            vinnare = true;
                        }
                        else if (cp > up && cp < 22)
                        {
                            Console.WriteLine("Datorn vann med: " + cp + " poäng! :(");
                            vinnare = false;
                        }
                        break;
                    case 2:
                        if (vinnare == false)
                        {
                            Console.WriteLine("Datorn vann senast");
                        }
                        if (vinnare == true)
                        {
                            Console.WriteLine("Spelaren vann senast");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Målet med blackjack är att komma så när 21 som möjligt utan att passera det.");
                        break;
                    case 4:
                        gameon = false;
                        break;
                }
                Console.WriteLine("\n \n \n \n \n");

            }
            Console.WriteLine("Tack för att du har spelat spelet");
            

        }
    }
}