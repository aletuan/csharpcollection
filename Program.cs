using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace csharpcollection
{
    class MyList<T> : IEnumerable<T>
    {
        List<T> list = new List<T>();

        // Get length
        public int Length()
        {
            return list.Count;
        }

        public void Add(T element)
        {
            list.Add(element);
        }

        public IEnumerator<T> GetEnumerator() {
            foreach(var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    class Person 
    {
        public string Name { get; set;}
        public int Age { get; set; }
    }

    class Program 
    {    
        /*
        public static IEnumerable EnumMethod(int number)
        {
            for(int i = 0; i < number; i++)
            {
                yield return i;
            }
        }
        */

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //ArrayList arrayList = new ArrayList();
            //Hashtable owner = new Hashtable();

            /*
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
            */

            // Adding some value in Hashtable
            /*
            owner.Add("Billl", "Microsoft");
            owner.Add("Paul", "Microsoft");
            owner.Add("Steve", "Apple");
            owner.Add("Mark", "Facebook");

            // Accessing one specified by key
            System.Console.WriteLine("Bill is owner of {0}", owner["Bill"]);

            // Iterate one by one
            foreach(DictionaryEntry item in owner)
            {
                Console.WriteLine("{0}, {1}", item.Key, item.Value);
            }
            */

            // Adding queue
            /*
            Queue days = new Queue();

            // Adding element into queue
            days.Enqueue("月曜日");
            days.Enqueue("か呼び");
            days.Enqueue("水曜日");
            days.Enqueue("木曜日");
            days.Enqueue("金呼び");
            days.Enqueue("ど呼び");
            days.Enqueue("日曜日");

            // iterate each element
            foreach(var item in days)
            {
                Console.WriteLine(item);
            }
            */

            // Testing for yield method
            /*
            foreach(var item in EnumMethod(10))
            {
                Console.WriteLine(item);
            }
            
            Console.ReadLine();
            */

            /*
            MyList<Person> temp = new MyList<Person>();
            temp.Add(new Person { Name = "Tuan Anh Le", Age = 35});
            temp.Add(new Person { Name = "Nguyen Thi Mai Huong", Age = 35});

            foreach(var item in temp)
            {
                Console.WriteLine("Person {0} {1}", item.Name, item.Age);
            }

            Console.ReadLine();
            */

            // Convert sequential into parallel
            /*
            var numbers = Enumerable.Range(0, 30);
            var parallelResult = numbers.AsParallel().Where( i => i % 2 == 0);

            parallelResult.ForAll(e => Console.WriteLine(e));
            */

            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() => {
                while(true)
                {
                    Console.WriteLine("Input: {0}",col.Take());
                }
            });
            Task write = Task.Run(() => {
                while(true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrEmpty(s))
                    {
                        break;
                    } else {
                        col.Add(s);
                    }
                }
            });
            write.Wait();
        }
    }
}
