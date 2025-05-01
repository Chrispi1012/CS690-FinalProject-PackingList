using System;
using System.Collections.Generic;
using System.IO;

namespace PackingList
{
    class Program
    {
        static void Main(string[] args)
        {
            loginScreen.LoadUsers();
            loginScreen.login();
        }
    }
}
