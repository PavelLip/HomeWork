using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Greeting
{
    public class InteractionUser
    {
        public static void HelloUser(string name)
        {
            Console.WriteLine($"Привет {name}");
        }
    }
}