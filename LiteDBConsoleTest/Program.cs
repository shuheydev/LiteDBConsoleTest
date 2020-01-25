using LiteDB;
using LiteDBConsoleTest.Models;
using System;
using System.Linq;

namespace LiteDBConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new LiteDatabase(@"MyData.db"))
            {
                var collection = db.GetCollection<Person>();
                //var people = db.GetCollection<Person>("MyPeople");

                //全削除
                //foreach (var id in collection.FindAll().Select(x => x.Id))
                //{
                //    collection.Delete(x => x.Id == id);
                //}

                var person = new Person
                {
                    FirstName = "Taro",
                    LastName = "Tanaka",
                    Age = 20,
                };

                //追加
                collection.Insert(person);

                //確認のための出力
                Console.WriteLine("追加:");
                var people = collection.FindAll();
                people.ToList()
                      .ForEach(x => Console.WriteLine($"ID:{x.Id}, FirstName:{x.FirstName}, LastName={x.LastName}, Age:{x.Age}"));

                //更新
                Console.WriteLine("更新:");
                person.Age = 30;//インスタンス使いまわし
                collection.Update(person);

                people = collection.FindAll();
                people.ToList()
                      .ForEach(x => Console.WriteLine($"ID:{x.Id}, FirstName:{x.FirstName}, LastName={x.LastName}, Age:{x.Age}"));

                
            }
        }
    }
}
