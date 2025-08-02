// See https://aka.ms/new-console-template for more information
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");

var myTuple = (Id: 1, Name: "Selva");
Console.WriteLine(myTuple);

(int, string) typedMyTuple = (1, "test");
Console.WriteLine(typedMyTuple);
var stats = CalculateSumAndCount(new[] { 2, 3, 44 });
Console.WriteLine(stats);


(int sum,int count) CalculateSumAndCount(int[] numbers)
{
    int sum = numbers.Sum();
    int count = numbers.Length;
    return (sum, count);

}