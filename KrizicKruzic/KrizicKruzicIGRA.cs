using System;



namespace KrizicKruzic
{
    class KrizicKruzicIGRA
    {
        public int Igrac { get; set; }
        public char[] Pos { get; set; } = new char[10];

        public void DrawBoard()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;  
            Console.WriteLine("┌──────┬──────┬──────┐  ");
            Console.WriteLine("│  {0}   │  {1}   │  {2}   │", Pos[1], Pos[2], Pos[3]);
            Console.WriteLine("├──────┼──────┼──────┤");
            Console.WriteLine("│  {0}   │  {1}   │  {2}   │", Pos[4], Pos[5], Pos[6]);
            Console.WriteLine("├──────┼──────┼──────┤");
            Console.WriteLine("│  {0}   │  {1}   │  {2}   │", Pos[7], Pos[8], Pos[9]);
            Console.WriteLine("└──────┴──────┴──────┘");
            Console.ResetColor();
        }

        bool TriZaRedom(int m, int n, int k)
        {
            return Pos[m] == Pos[n] && Pos[k] == Pos[n];
        }
       public bool Imamolipobjednika()
        {
            return (TriZaRedom(1,2,3)|| TriZaRedom(4, 5, 6) || TriZaRedom(7, 8, 9) || TriZaRedom(1, 4, 7) || TriZaRedom(2, 5, 8) || TriZaRedom(3, 6, 9) || TriZaRedom(1, 5, 9) || TriZaRedom(3, 5, 7));
        }



        public void ResetBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                string s = i.ToString();
                Pos[i] = char.Parse(s);
            }
        }


        public int Unos()
        {
            int pozicija;
            do
            {
                Console.WriteLine("Odaberite slobodno mjesto unosom broja (1-9). Pazite da odaberete mjesto na kojem već nije oznaka!");
            } while (!int.TryParse(Console.ReadLine(), out pozicija) || pozicija > 9 || pozicija < 1 || Pos[pozicija]=='X' || Pos[pozicija] == 'O');

            return pozicija;
        }
    }
}