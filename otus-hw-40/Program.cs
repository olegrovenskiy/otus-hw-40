using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");


var listPoint1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var result = listPoint1.TopPoint1(30);
Console.WriteLine(string.Join("|", result));



var listPoint2 = new List<Person>
{
                new Person ( "Oooo1", 1 ),
                new Person ( "Sooo2", 2 ),
                new Person ( "Oooo3", 3 ),
                new Person ( "Oooo4", 4 ),
                new Person ( "Oooo5", 5 ),
                new Person ( "Oooo6", 6 ),
                new Person ( "Oooo7", 7 ),
                new Person ( "Oooo8", 8 ),
                new Person ( "Oooo9", 9 )

            };

var result2 = listPoint2.TopPoint2(30, x => x.Age );


foreach (var t in result2 )
    Console.WriteLine(t.Name);





Console.ReadKey();

public static class MyExtensionsPoint1

{
    public static IEnumerable<T> TopPoint1<T>(this IEnumerable<T> collection, int procent)

    {
        if ((procent < 1) || (procent > 100))
            throw new ArgumentException("Процент не дозволен");
        

            var quantityIn = collection.Count<T>();
            var quantityOut = (int)Math.Ceiling(quantityIn * procent / 100.0);

            return collection.OrderByDescending(x => x).Take(quantityOut);


    } 
}


public static class MyExtensionsPoint2

{
    public static IEnumerable<T> TopPoint2<T>(this IEnumerable<T> collection, int procent, Func<T,int> func )

    {
        if ((procent < 1) || (procent > 100))
            throw new ArgumentException("Процент не дозволен");


        var quantityIn = collection.Count<T>();
        var quantityOut = (int)Math.Ceiling(quantityIn * procent / 100.0);

        return collection.OrderByDescending(func).Take(quantityOut);


    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }


    public Person (string name, int age)
    {
        Name = name;
        Age = age;

    }

    public Person() {}

}


class ArgumentException : Exception

{

    public ArgumentException(string message) : base(message)

    {

    }

}















/*
public static class MyExtensions

{
    public static IEnumerable<T> Top<T> (this IEnumerable<T> collection, int proc)

    {
        proc = proc * 2;

        foreach (var item in collection)
        {
            string a = item.ToString();
            int c = int.Parse(a);

            if (c == 0)
            yield return item;  
         
        }
    }




}

*/