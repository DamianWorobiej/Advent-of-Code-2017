using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoC2017_5
{
    class Solution
    {
        public String Puzzle;

        public Solution()
        {
            FileOpen();
        }

        public void FileOpen()
        {
            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    Puzzle = sr.ReadToEnd();
                }
            }
            catch (Exception e) // jeśli nie znajdzie pliku, wyswietli komunikat
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public List<string> GetSStep()
        {
            List<string> SStep1 = new List<string>();
            string buffer = "";
            int i = 0;
            while (i < Puzzle.Length)
            {
                if (Puzzle[i] != '\r')
                {
                    buffer = buffer + Puzzle[i];
                    i++;
                }
                else
                {
                    SStep1.Add(buffer);
                    buffer = "";
                    i = i + 2;
                }
            }
            return SStep1;
        }

        public List<int> StringToIntList(List<string> sstep)
        {
            List<int> IStep = new List<int>();
            for (int j = 0; j < sstep.Count; j++)
            {
                
                    IStep.Add(Convert.ToInt32(sstep[j]));
                
            }
            return IStep;
        }

        public int Pierwsze()
        {
            int Exit = 0;
            List<int> ToExit = StringToIntList(GetSStep());
            int i = 0;
            while (i<ToExit.Count)
            {        
                int j = i;
                i = i + ToExit[j];
                ToExit[j]++;               
                Exit++;
            }
            return Exit;
        }
        public int Drugie()
        {
            int Exit = 0;
            List<int> ToExit = StringToIntList(GetSStep());
            int i = 0;
            while (i < ToExit.Count)
            {

                int j = i;
                i = i + ToExit[i];
                if (ToExit[j]>=3)
                {
                    ToExit[j]--;
                }
                else
                {
                    ToExit[j]++;
                }
                Exit++;
            }
            return Exit;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string input = sol.Puzzle.ToString() ;
            Console.WriteLine("Pierwsze: " + sol.Pierwsze());
            Console.WriteLine("Drugie: " + sol.Drugie());
            Console.ReadKey();
        }
    }
}
