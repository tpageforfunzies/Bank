using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("         _._._                       _._._");
            Console.WriteLine("        _|   |_                     _|   |_");
            Console.WriteLine("        | ... |_._._._._._._._._._._| ... |");
            Console.WriteLine("        | ||| |  o NATIONAL BANK o  | ||| |");
            Console.WriteLine("     WELCOME TO THE FIRST NATIONAL BANK OF TPAGE");
            Console.WriteLine("           PRESS ANY BUTTON TO CONTINUE");
            Console.ReadLine();
            Console.Clear();
            BankATM.Start();

        }
    }
}
