namespace PackingList
{
    class loginScreen
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        static string filePath = "users.txt";

        public static void LoadUsers()
        {
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2 && !string.IsNullOrWhiteSpace(parts[0]) && !string.IsNullOrWhiteSpace(parts[1]))
                    {
                        users[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
        }

        public static void SaveUsers()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var user in users)
                {
                    writer.WriteLine($"{user.Key},{user.Value}");
                }
            }
        }

       

        public static void login()
        {
            Console.WriteLine("Welcome to PackPal!");
            Console.WriteLine("Please select mode (login or create account): ");
            string loginmode = Console.ReadLine().Trim().ToLower();

            if (loginmode == "login")
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine().Trim();

                if (users.ContainsKey(username))
                {
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine().Trim();

                    if (users[username] == password)
                    {
                        Console.WriteLine("Login successful! Welcome back.");
                        SaveUsers();
                        createList myList = new createList();
                        myList.list();
                    }

                    else
                    {
                        Console.WriteLine("Incorrect password. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("User not found. Please check your username or create an account.");
                }
            }
            else if (loginmode == "create account")
            {
                Console.Write("Enter a username: ");
                string newUsername = Console.ReadLine().Trim();

                if (users.ContainsKey(newUsername))
                {
                    Console.WriteLine("Username already exists. Please try again.");
                }
                else
                {
                    Console.Write("Enter a new password: ");
                    string newPassword = Console.ReadLine().Trim();
                    users.Add(newUsername, newPassword);
                    SaveUsers();
                    Console.WriteLine("You have successfully created your account!");
                    createList myList = new createList();  // create an instance of createList
                    myList.list(); // call the instance method on the object
                }
            }

            else
            {
                Console.WriteLine("Invalid mode selected. Please enter 'login' or 'create account'.");
            }
        }
    }
}
