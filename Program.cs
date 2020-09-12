using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PetroTest
{
    class Program
    {
        static void Main(string[] args)
        {


            // return top X words
            string txt = File.ReadAllText(@"C:\Users\15878\source\repos\PetroTest\file\test.txt");

            // Use regular expressions to replace characters
            // that are not letters or numbers with spaces.
            Regex reg_exp = new Regex("[^a-zA-Z0-9]");
            txt = reg_exp.Replace(txt, " ");

            string[] lines = txt.Split(
            new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> char_counts = new Dictionary<string, int>();



            foreach (string line in lines)
            {
                // for each char  see if exists in char_counts 
                if (!char_counts.ContainsKey(line.ToUpper()))
                {
                    char_counts.Add(line.ToUpper(), 1);
                }
                else if (char_counts.ContainsKey(line.ToUpper()))
                {
                    char_counts[line.ToUpper()]++;
                }

            }
            // sort the dic
            var list = char_counts.Keys.ToList();
            list.Sort();
            // return list of distinct word
            // foreach (var key in list)
            //{
            //    Console.WriteLine("Key = {0}, Value = {1}",
            //        key, char_counts[key]);
            //}



            // return top X used word

            var sorted_char_count = from entry in char_counts
                                orderby entry.Value descending
                                select entry;

            int i = 0;
            Console.WriteLine("The top 10 words are: ");
            foreach(var ch in sorted_char_count)
            {

                if (i < 10) {
                        Console.WriteLine("Key = {0}, Value = {1}", ch.Key, ch.Value);
                        i++;
                    }
            }


            Console.ReadKey();

        

        // Count the characters
        //Dictionary<char, int> char_counts = new Dictionary<char, int>();
        //string txt = File.ReadAllText(@"C:\Users\15878\source\repos\PetroTest\file\test.txt");

        //String[] p= txt.Split(" ");

        //foreach(var ch in p)
        //{
        //    foreach(char c in ch)
        //    {
        //        if(Char.IsPunctuation(c))
        //        {
        //                // for each char  see if exists in char_counts 
        //                if (!char_counts.ContainsKey(c))
        //                {
        //                    char_counts.Add(c, 1);
        //                }
        //                else if (char_counts.ContainsKey(c))
        //                {
        //                    char_counts[c]++;
        //                }



        //        }
        //    }


        //}


        //var sorted_char_count = from entry in char_counts
        //                        orderby entry.Value descending
        //                        select entry;

        //foreach (KeyValuePair<char, int> kvp in sorted_char_count)
        //{
        //    Console.WriteLine("Key = {0}, Value = {1}",
        //        kvp.Key, kvp.Value);
        //}







        // return a list of matches

        //List<int> key_word_linenumber = new List<int>();
        //string path = @"C:\Users\15878\source\repos\PetroTest\file\test.txt";

        //int lineNum = 0;
        //string search_request = "email";

        //using(StreamReader sr= new StreamReader(path))
        //{
        //    string line;

        //    while ((line = sr.ReadLine()) != null)
        //    {
        //        line = line.ToUpper();
        //        lineNum++;
        //        if(line.Contains(search_request.ToUpper()))
        //        {
        //            key_word_linenumber.Add(lineNum);
        //        }

        //    }
        //}

        //Console.WriteLine("key word {0} has the occurance in the following lines", search_request);
        //foreach(var c in key_word_linenumber)
        //{
        //    Console.Write(c + " ");
        //}



    
        } 
    }
}
