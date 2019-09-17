using ProgrammingProblems.Amazon;
using System;

namespace ProgrammingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            var skiSlope = new int[,]
            {
                { 0, 0, 0, 0 },
                { 0, 1, 0, 1 },
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 }
            };

            // Test code here.
            Console.WriteLine($"Has clear path in ski slope?: {AmazonProblems.PathExistInSlope(skiSlope)}"); 
        }    
    }
}
