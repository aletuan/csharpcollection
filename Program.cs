using System;
using System.Collections;

namespace csharpcollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ArrayList arrayList = new ArrayList();
            arrayList.Add(22);
            // can add duplicate
            arrayList.Add(22);
            arrayList.Add("Ali");
            arrayList.Add(true);

            // iterate over each index of arraylist
            for (int i = 0; i < arrayList.Count; i++)
            {
                System.Console.WriteLine(arrayList[i]);
            }

            arrayList.Remove(22);
            // other way to iterate
            foreach(var item in arrayList)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
