using System;

namespace Kortlek
{
    public class Program
    {
        public int kortRND()
        {            
            Random rnd = new Random();
                int[][] kort = new int[][]
                {
                    new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}, //Hjärter 
                    new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}, //Klöver
                    new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}, //spade
                    new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}, //Ruter
                };
            int kortindex = rnd.Next(0, 3);
            int kortval = rnd.Next(0, 12);
            return kort[kortindex][kortval];
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetWindowSize(50,50);
            Console.WriteLine("Kortlek v0");
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
                        int up = p.kortRND() + p.kortRND();
                        int cp = p.kortRND() + p.kortRND();
                        Console.WriteLine("Dina poäng är: " + up);
                        Console.WriteLine("Datorns poäng är: " + cp);
                        if (up > 21)  // De två nedanstående if kollar om de har förlorat
                        {
                            Console.WriteLine("Du förlorade");
                            vinnare = false;
                            break;
                        }
                        else if (cp > 21)
                        {
                            Console.WriteLine("Du vann! :)");
                            vinnare = true;
                            break;
                        }
                        Console.WriteLine("Vill du ta ett till kort? (y/n)");
                        string gval = Console.ReadLine().ToLower();
                        if (gval == "y")  // Kör så länge spelaren vill fortsätta ta upp kort.
                        {
                            while (gval == "y")
                            {
                                int x = p.kortRND();
                                Console.WriteLine("Ditt nya kort är: " + x);
                                up = up + x;
                                cp = cp + p.kortRND();
                                Console.WriteLine("Dina poäng är: " + up);
                                Console.WriteLine("Datorns poäng är: " + cp);
                                if (up > 21)
                                {
                                    Console.WriteLine("Du förlorade");
                                    vinnare = false;
                                    break;

                                }
                                else if (cp > 21)
                                {
                                    Console.WriteLine("Du vann! :)");
                                    vinnare = true;
                                    break;
                                }
                                Console.Write("Vill du fortsätta ? ");
                                gval = Console.ReadLine().ToLower();
                            }
                        }  // Körs för att datorn ska ta upp kort till den har mer än spelaren.
                        else if (gval == "n")
                        {
                            while(cp < up)
                            {
                                cp = cp + p.kortRND();
                                Console.WriteLine(cp);
                                if (cp > 22)
                                {
                                    Console.WriteLine("Du vann");
                                    vinnare=true;
                                    break;
                                }
                            }
                            
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
