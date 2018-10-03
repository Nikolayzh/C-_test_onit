using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class RemoveRecursion
    {
        public RemoveRecursion()
        {
        }
        public void doSomeWorkWithSomeData()
        { 

        Dictionary<string, List<string>> someData = new Dictionary<string, List<string>>();
            someData["Петр Иванович"] = new List<string>();
            someData["Петр Иванович"].Add("Анна Ивановна");
            someData["Петр Иванович"].Add("Максим Иванович");
            someData["Максим Иванович"] = new List<string>();
            someData["Максим Иванович"].Add("Коля");
            someData["Максим Иванович"].Add("Миша");
            someData["Максим Иванович"].Add("Николай Максимович");
            someData["Анна Ивановна"] = new List<string>();
            someData["Анна Ивановна"].Add("Артем");
            someData["Николай Максимович"] = new List<string>();
            someData["Николай Максимович"].Add("Катя");
            someData["Николай Максимович"].Add("Маша");
            someData["Анна Ивановна"].Add("Саша");
            Console.WriteLine("----------------------------Width Recurse");
            List<string> lastChilds = new List<string>();
            RecursFillLastChilds("Петр Иванович",someData,lastChilds);
            foreach (var child in lastChilds)
            {
                Console.WriteLine(child);
            }


            Console.WriteLine("-----------------------------Recurse Removed");
            var q = someData
                .OrderBy(o=>o.Key)
                .SelectMany(i => i.Value)
                .Where(t => !someData.ContainsKey(t));
            
            foreach (var child in q)
            {
                Console.WriteLine(child);
            }
            Console.ReadLine();
        }


        private static void RecursFillLastChilds(string parentName, Dictionary<string, List<string>> someData, List<string> lastChilds)
        {
            if(!someData.ContainsKey(parentName))
            {
                lastChilds.Add(parentName);
                return;
            }
            foreach(string child in someData[parentName])
            {
                RecursFillLastChilds(child, someData, lastChilds);
            }
        }


    }

}