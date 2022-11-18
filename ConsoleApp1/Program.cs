
using System;

namespace Kortlek
{
    class Program
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
            Console.WriteLine("Kortlek v0");

            bool gameon = true;
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
                        var p = new Program();
                        int up = p.kortRND() + p.kortRND();
                        int cp = p.kortRND() + p.kortRND();
                        Console.WriteLine("Dina poäng är: " + up);
                        Console.WriteLine("Datorns poäng är: " + cp);
                        if (up > 21)
                        {
                            Console.WriteLine("Du förlorade");
                            break;
                        }
                        else if (cp > 21)
                        {
                            Console.WriteLine("Du vann! :)");
                            break;
                        }
                        Console.WriteLine("Vill du ta ett till kort? (y/n)");
                        string gval = Console.ReadLine().ToLower();
                        if (gval == "y")
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
                                    break;
                                }
                                else if (cp > 21)
                                {
                                    Console.WriteLine("Du vann! :)");
                                    break;
                                }
                                gval = Console.ReadLine().ToLower();
                            }
                        }
                        else if (gval == "n")
                        {
                            while(cp > up)
                            {
                                cp = cp + p.kortRND();
                            }
                        }

                        if (up > cp && up < 22)
                        {
                            Console.WriteLine("Du vann med: " + up + " poäng! :)");
                        }
                        else if (cp > up && cp < 22)
                        {
                            Console.WriteLine("Datorn vann med: " + cp + " poäng! :(");
                        }




                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        break;
                    case 4:
                        gameon = false;
                        break;
                }


            }
            Console.WriteLine("Tack för att du har spelat spelet");


        }
    }
}
