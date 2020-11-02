using System;

namespace KrizicKruzic
{
    class Program
    {
        static void Main(string[] args)
        {
            int izbor;
            bool igrase;
            string igrac1="";
            string igrac2="";
            int mijenjanjeredoslijeda = 0;
            char tr;

            KrizicKruzicIGRA nova = new KrizicKruzicIGRA();

            do
            {
                igrase = true;
                nova.ResetBoard();

                switch (Odabir(ref igrac1, ref igrac2))
            {
                case 1:
                        while (igrase)
                        {
                            ClearAndDraw(nova);

                            if (nova.Igrac % 2 == 1)
                            {
                                tr = 'X';
                                Console.WriteLine($"{igrac1} je na redu, vas znak je {tr} ");
                            }
                            else
                            {
                                tr = 'O';
                                Console.WriteLine($"{igrac2} je na redu, vas znak je {tr} ");
                            }
                            nova.Pos[nova.Unos()] = tr;
                            nova.Igrac++;
                            ClearAndDraw(nova);
                            igrase = PobjedaIliNerjeseno(igrac1, igrac2, mijenjanjeredoslijeda, nova);

                        }           
                 
                    break;
                case 2:
                        while (igrase)
                        {
                            ClearAndDraw(nova);

                            if (nova.Igrac % 2 == 1)
                            {
                                tr = 'X';
                                Console.WriteLine($"{igrac1} je na redu, vas znak je {tr} ");
                                nova.Pos[nova.Unos()] = tr;
                            }
                            else
                            {
                                int t;
                                tr = 'O';
                                do
                                {
                                    t = RandomBroj(1,10);
                                } while ((nova.Pos[t] == 'X' || nova.Pos[t] == 'O'));

                                nova.Pos[t] = tr;

                            }   
                             nova.Igrac++;
                            ClearAndDraw(nova);
                            igrase = PobjedaIliNerjeseno(igrac1, igrac2, mijenjanjeredoslijeda, nova);
                        }
                    break;
            }

                mijenjanjeredoslijeda = nova.Igrac;

                Console.WriteLine();
                Console.WriteLine("Nova igra?0/1");
                izbor = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (izbor == 1);
        }

        private static bool PobjedaIliNerjeseno(string igrac1, string igrac2, int mijenjanjeredoslijeda, KrizicKruzicIGRA nova)
        {
            bool igrase = true;

            if (nova.Imamolipobjednika())
            {
                Console.WriteLine(nova.Igrac % 2 == 0 ? $"{igrac1} je pobijedio!" : $"{igrac2} je pobijedio!");
                igrase = false;
            }
            else if ((nova.Igrac % (9 + mijenjanjeredoslijeda)) == 0)
            {
                Console.WriteLine("Igra je zavrsila nerjeseno!");
                igrase = false;
            }
            return igrase;
        }


        private static void ClearAndDraw(KrizicKruzicIGRA nova)
        {
            Console.Clear();
            nova.DrawBoard();
        }

        private static int RandomBroj(int v1, int v2)
        { 
            Random r = new Random();
            return r.Next(v1, v2);    
        }

        private static int Odabir(ref string i1, ref string i2)
        {
            int pozicija;
            do
            {
                Console.WriteLine("1 - Igra za dva igraca");
                Console.WriteLine("2 - Igra protiv racunala");

            } while (!int.TryParse(Console.ReadLine(), out pozicija) || pozicija != 1 && pozicija != 2);
            Console.Clear();
            if (pozicija == 1)
            {
                Console.Write("Unesite ime prvog igraca: ");
                i1 = Console.ReadLine();
                Console.Write("Unesite ime drugog igraca: ");
                i2 = Console.ReadLine();
            }
            else
            {
                Console.Write("Unesite ime igraca: ");
                i1 = Console.ReadLine();
                i2 = "Racunalo";
            }
            return pozicija;
        }
    }
}
