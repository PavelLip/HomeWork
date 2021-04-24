using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;

namespace InteractionUser
{
    public class Greating
    {
        public static void HelloUser(string name)
        {
            Console.WriteLine($"Привет {name}"); ;
        }
    }
}