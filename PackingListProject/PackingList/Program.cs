
namespace PackingList
{
    class Program
    {
        static Dictionary<string, string> users= new Dictionary<string, string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to PackPal!");
            Console.WriteLine("Please select mode (login or create account)");
            string loginmode = Console.ReadLine();

            if (loginmode.ToLower() == "login")
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Hello " + username);
            }
            else if (loginmode.ToLower() == "create account")
            {
                Console.Write("Enter a username: ");
                string newUsername = Console.ReadLine();

                if (users.ContainsKey(newUsername))
                {
                    Console.WriteLine("Username already exists. Please try again.");
                }
                else
                {
                    Console.Write("Enter a new password: ");
                    string newPassword = Console.ReadLine();
                    users.Add(newUsername, newPassword);
                    Console.WriteLine("You have successfully created your account!"); 
                }    
            }      
        }
    }
}
