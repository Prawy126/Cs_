namespace lekcja19
{
    class Program
    {
        static int kumulacja;
        static int START = 30;
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int pieniadze = START;
            int dzien = 0;
            do
            {
                pieniadze = START;
                ConsoleKey wybor;
                do
                {
                    kumulacja = rnd.Next(2, 37) * 10000000;
                    dzien++;
                    int losow = 0;
                    List<int[]> kupon = new List<int[]>();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("DZIEŃ: {0}", dzien);
                        Console.WriteLine("Witaj w grze LOTTO, dzieś do wygrania jest aż {0}zł", kumulacja);
                        Console.WriteLine("\nStan konta: {0}zł", pieniadze);
                        WyswietlKupon(kupon);
                        //Menu
                        if (pieniadze >= 3 && losow < 8)
                        {
                            Console.WriteLine("1 - Postaw los -3zł [{0}/8]", losow++);
                        }
                        Console.WriteLine("2 - Sprawdź kupon - losowanie");
                        Console.WriteLine("3 - Zakończ grę");

                        //koniec menu

                        wybor = Console.ReadKey().Key;
                        if (wybor == ConsoleKey.D1 && pieniadze >= 3 && losow < 8)
                        {
                            kupon.Add(PostawLos());
                            pieniadze -= 3;
                            losow++;
                        }
                    } while (wybor == ConsoleKey.D1);

                    Console.Clear();
                    if (kupon.Count > 0)
                    {
                        int wygrana = Sprawdz(kupon);
                        if (wygrana > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nBrawo wygrałeś {0}zł w tym losowaniu!", wygrana);
                            Console.ResetColor();
                            pieniadze += wygrana;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNiestety nic nie wygrałeś");
                            Console.ResetColor();
                            pieniadze += wygrana;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nie miałeś losów w tym losowaniu.");
                    }

                    Console.WriteLine("Enter - kontynuuj");

                } while (pieniadze >= 3 && wybor != ConsoleKey.D3);

                Console.WriteLine("Dzień {0}.\nKoniec gry, twój wynik to: {1}zł", dzien, pieniadze - START);
                Console.WriteLine("Enter - graj od nowa.");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }

        private static int Sprawdz(List<int[]> kupon)
        {
            return 0;
        }

        private static int[] PostawLos()
        {
            int[] liczby = new int[6];
            int liczba = -1;
            for (int i = 0; i < liczby.Length; i++)
            {
                liczba = -1;
                Console.Clear();
                Console.WriteLine("Postawione liczby: ");
                foreach (int l in liczby)
                {
                    if (l > 0)
                    {
                        Console.WriteLine(l + ", ");
                    }
                }
                Console.WriteLine("\n\nWybierz liczbę od 1 do 49:");
                Console.WriteLine("{0}/6", i + 1);
                bool prawidlowa = int.TryParse(Console.ReadLine(), out liczba);
                if (prawidlowa && liczba >= 1 && liczba <=49 && !liczby.Contains(liczba)       )
                {
                    liczby[i] = liczba;
                }
                else
                {
                    Console.WriteLine("Niestety błędna liczba.");
                    i--;
                    Console.ReadKey();
                }
            }
            Array.Sort(liczby);
            return liczby;
        }

        private static void WyswietlKupon(List<int[]> kupon)
        {
            if (kupon.Count == 0)
            {
                Console.WriteLine("NIe postawiłeś jeszcze żadnych losów.");
            }
            else
            {
                int i = 0;
                Console.WriteLine("\nTWÓJ KUPON:");
                foreach (int[] los in kupon)
                {
                    i++;
                    Console.WriteLine(i + ": ");
                    foreach (int liczba in los)
                    {
                        Console.Write(liczba + ", ");
                    }
                    Console.WriteLine();
                }
            }
        }

    }

}
