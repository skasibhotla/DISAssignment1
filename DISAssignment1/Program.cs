using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Palindrome
    {
        static void Main(string[] args)
        {

            PrintPattern(5);
            Console.ReadLine();

            PrintSeries(6);
            Console.ReadLine();

            string sDate = UsfTime("08:15:35AM");
            Console.ReadLine();

            UsfNumbers(110, 11);
            Console.ReadLine();

            string[] listOfWords = new string[] { "abcd", "lls", "efgh", "hgfe", "s", "sssll", "dcba" };
            PalindromePairs(listOfWords);
            Console.ReadLine();

            Stones(5);
            Console.ReadLine();
        }

        //Question 1: print pattern
        private static void PrintPattern(int n)
        {
            if (n == 0) return;
            for (int i = n; i > 0; i--)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            PrintPattern(--n);
        }

        //Question 2: print series
        private static void PrintSeries(int n2)
        {
            List<int> sbSeries = new List<int>();
            for (int i = 1; i <= n2; i++)
            {
                int calculatedNumber = i * (i + 1) / 2;
                sbSeries.Add(calculatedNumber);
            }
            Console.WriteLine(string.Join(",", sbSeries.ToArray()));
        }

        //Question-3--USF timing
        public static string UsfTime(string s)
        {
            string vTimeZone = s.Substring(8, 2);
            int totalNumberOfSeconds = totalNumberOfSeconds =
                (Convert.ToInt32(s.Substring(0, 2))) * 60 * 60 + Convert.ToInt32(s.Substring(3, 2)) * 60 + Convert.ToInt32(s.Substring(6, 2));
            if (vTimeZone.ToLower().Equals("pm"))
            {
                totalNumberOfSeconds =
                    (Convert.ToInt32(s.Substring(0, 2)) + 12) * 60 * 60 + Convert.ToInt32(s.Substring(3, 2)) * 60 + Convert.ToInt32(s.Substring(6, 2));
            }

            int usfHours = totalNumberOfSeconds / 2655;
            int usfMinutes = (totalNumberOfSeconds / 45) % 59;
            int usfSeconds = totalNumberOfSeconds % 45;
            Console.WriteLine(usfHours.ToString() + ":" + usfMinutes.ToString() + ":" + usfSeconds.ToString());
            return usfHours.ToString() + ":" + usfMinutes.ToString() + ":" + usfSeconds.ToString();
        }

        //question 4-- usf number
        public static void UsfNumbers(int n3, int k)
        {
            for (int i = 1; i <= n3; i++)
            {


                if (i % 3 == 0)
                {
                    if (i % k == 0)
                    {
                        Console.Write("U");
                        Console.WriteLine();
                        continue;
                    }
                    Console.Write("U");
                    Console.Write(" ");
                    continue;
                }

                if (i % 5 == 0)
                {
                    if (i % k == 0)
                    {
                        Console.Write("S");
                        Console.WriteLine();
                        continue;
                    }
                    Console.Write("S");
                    Console.Write(" ");

                    continue;
                }

                if (i % 7 == 0)
                {
                    if (i % k == 0)
                    {
                        Console.Write("F");
                        Console.WriteLine();
                        continue;
                    }
                    Console.Write("F");
                    Console.Write(" ");

                    continue;
                }

                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write("US");
                    Console.Write(" ");

                    continue;
                }
                if (i % 5 == 0 && i % 7 == 0)
                {
                    Console.Write("US");
                    Console.Write(" ");
                    continue;
                }

                if (i % k == 0)
                {
                    Console.Write(i);
                    Console.WriteLine();
                    continue;
                }
                Console.Write(i);
                Console.Write(" ");


            }
        }


        //question 5-- palindrome pairs
        public static void PalindromePairs(string[] words)
        {
            //array to store where the indices are at
            List<string> indicesAt = new List<string>();
            ArrayList test = new ArrayList();
            if (words.Length == 0) { Console.WriteLine("Ooops!! specify an array of strings"); }
            //this checks to see if there are any "Words" that exist out there as palindromes
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    //if (words[i].Length <= 1) return; 
                    if (i != j)
                    {
                        if (words[i].Length > 1)//ignore words that are 1 character in length.
                        {
                            string compareAgainst = GetReversedString(words[i]);
                            //first check to see if there exists a direct palindrome
                            //meaning abcd has an equivalent dcba in the array
                            int indexOfPalindrome = GetIndexOfPalindrome(words, compareAgainst, j);
                            //should not be the same as current index and shouldn't be 100000
                            if (indexOfPalindrome != -1)
                            {
                                //string[][] indexAt= new string[][]{new string[]{i.ToString(),indexOfPalindrome.ToString()}};
                                //Console.WriteLine("the palindrome for {0} is at {1}", i, indexOfPalindrome);
                                indicesAt.Add("[" + i.ToString() + ", " + indexOfPalindrome.ToString() + "]");
                                //found a palindrom for the current word from outer array. So no longer iterate the list.
                                j = words.Length;
                            }
                        }

                        if (j == words.Length) break;
                        //oops!! no palindrome, now check to see if any combinations exist (like any two words from the array combined can form a palindrome)
                        StringBuilder newPalindromeBuilder = new StringBuilder();
                        newPalindromeBuilder.Append(words[i]).Append(words[j]);
                        string reversedPalindromeBuilder = GetReversedString(newPalindromeBuilder.ToString());
                        if (newPalindromeBuilder.ToString().Equals(reversedPalindromeBuilder))
                        {
                            indicesAt.Add("[" + i.ToString() + ", " + j.ToString() + "]");
                            //Console.WriteLine("the palindrome for {0} is at {1}", i, j);
                            j = words.Length;
                        }

                    }
                }

            }
            Console.Write(string.Join(",", indicesAt.ToArray()));

        }

        private static string GetReversedString(string pWord)
        {
            if (pWord.Length <= 1) return pWord;
            return GetReversedString(pWord.Substring(1)) + pWord[0];
        }

        private static int GetIndexOfPalindrome(string[] pWords, string wordToBeComparedAgainst, int currentIndex)
        {
            for (int i = 0; i < pWords.Length; i++)
            {
                if (pWords[i] == wordToBeComparedAgainst)
                {
                    return i;
                }
            }

            return -1;//meaning we did not find any palindrome
        }


        //Question 6 -stones
        public static void Stones(int n4)
        {
            int ballsRemaining = n4;
            Random rnd = new Random();
            List<int> turns = new List<int>();
            //if (n4 % 4 == 0)
            //{
            //    Console.WriteLine("false");
            //}
            //else
            //{
            //Console.Write("[");
            int noOfBallsRemaining = n4;
            int NoOfTurns = 1;


            while (noOfBallsRemaining > 0)
            {
                //if (NoOfTurns % 2 == 0) //second person turn
                //{
                NoOfTurns += 1;
                if (noOfBallsRemaining > 3)
                {
                    int ballsTobePicked = rnd.Next(1, 3);
                    noOfBallsRemaining -= ballsTobePicked;
                    turns.Add(ballsTobePicked);
                    continue;
                }

                if (noOfBallsRemaining <= 3)
                {
                    //meaning this is the first players turn. So try to end the ball picking at this point and make sure that player one is winner
                    if (turns.Count % 2 == 0)
                    {
                        int ballsTobePicked = noOfBallsRemaining;
                        noOfBallsRemaining = 0;
                        turns.Add(ballsTobePicked);
                        continue;
                    }
                    //meaning this is the second players turn. So try to continue the game at this point and increase the chance that player one is winner
                    else if (turns.Count % 2 == 1)
                    {
                        if (noOfBallsRemaining > 1)
                        {
                            turns.Add(1);
                            noOfBallsRemaining -= 1;
                        }
                        else
                        {
                            turns.Add(1);
                            noOfBallsRemaining = 0;
                        }
                    }

                }
            }

            if (turns.Count % 2 == 1)
            {
                Console.Write(string.Join(",", turns.ToArray()));
            }

            if (turns.Count % 2 == 0)
            {
                Console.Write(false);
            }
        }

    }
}
