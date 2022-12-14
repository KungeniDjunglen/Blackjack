using System;
using System.Text.RegularExpressions;

// Blackjack V1 

namespace Kortlek
{
    public class Program
    {
        public string WinChecker(int up, int cp)
            {
            var p = new Program();
                if (up > 21)  // De två nedanstående if kollar om de har förlorat
                {
                    p.Write("Du förlorade med " + cp + " poäng.");
                    return "c";
                }
                else if (cp > 21)
                {
                    p.Write("Du vann med " + up + " poäng :)");
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
                answear += rnd.Next(1,13);
            }

            return answear;
        }
        public string Write(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(7);
            }
            Console.Write("\n");
            return " ";
        }


        static void Main(string[] args)
        {
            var p = new Program();
            Console.ForegroundColor = ConsoleColor.Yellow;
            p.Write("Kortlek v1");
            bool gameon = true;
            bool vinnare = false;
            while (gameon == true)
            {
                Console.Clear();
                int val = 0;
                try
                {
                    p.Write("Välj ett av alternativen:");
                    p.Write("1. Spela blackjack");
                    p.Write("2. Visa spelets senaste vinnare");
                    p.Write("3. Spelets regler");
                    p.Write("4. Avsluta programet");
                    val = int.Parse(Console.ReadLine());
                }
                catch
                {
                    p.Write("Skriv in ett nummer!");
                }
                
                switch (val) {
                    case 1:
                        Console.Clear();
                        // All här nedan kör i början av spelet för att spelarna ska ta två kort
                        int up = p.kortRND(2);
                        int cp = p.kortRND(2);
                        p.Write("Dina poäng är: " + up);
                        p.Write("Datorns poäng är: " + cp);

                        if (p.WinChecker(up,cp) == "u") { vinnare = true; break; }
                        if (p.WinChecker(up,cp) == "c") { vinnare = false; break; }

                        p.Write("Vill du ta ett till kort? (y/n)");
                        string gval = Console.ReadLine().ToLower();
                        if (gval == "y")  // Kör så länge spelaren vill fortsätta ta upp kort.
                        {
                            while (gval == "y")
                            {
                                int x = p.kortRND(1);
                                p.Write("Ditt nya kort är: " + x);
                                up = up + x;
                                cp = cp + p.kortRND(1);
                                p.Write("Dina poäng är: " + up);
                                p.Write("Datorns poäng är: " + cp);

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
                            p.Write("y/n vad är det du inte fattar?");
                            break;
                        }

                        if (up > cp && up < 22)    //Slutchecken för att kolla vem som vann
                        {
                            p.Write("Du vann med: " + up + " poäng! :)");
                            vinnare = true;
                        }
                        else if (cp > up && cp < 22)
                        {
                            p.Write("Datorn vann med: " + cp + " poäng! :(");
                            vinnare = false;
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        if (vinnare == false)
                        {
                            p.Write("Datorn vann senast");
                        }
                        if (vinnare == true)
                        {
                            p.Write("Spelaren vann senast");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        p.Write("    Målet med blackjack är att komma så när 21 som möjligt utan att passera det. \n    " +
                            "När spelet börjar tar både du och datorn två kort, kortens poäng varierar mellan 1-13. \n    Får man över 21 poäng förlorar du, den som har mest" +
                            " poäng i slutet vinner. \n");
                        
                        Console.ReadKey();
                        break;
                    case 4:
                        gameon = false;

                        break;
                    default:
                        p.Write("??");
                        Console.ReadKey();
                        break;
                }

            }
            p.Write("Tack för att du har spelat spelet");
        }
    }
}
