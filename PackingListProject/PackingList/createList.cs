namespace PackingList
{
    public class createList
    {
        private FileSaver fileSaver;

        public createList()
        {
            fileSaver = new FileSaver("list-data.txt");
        }

        public void list()
        {
            string mode = AskForInput("Type 'add' to add items, 'view' to see your list, or 'remove' to delete an item: ").ToLower();

            if (mode == "view")
            {
                ViewList();
            }
            else if (mode == "remove")
            {
                RemoveItem();
            }
            else if (mode == "add")
            {
                string command;

                do
                {
                    string item = AskForInput("Enter item name: ");
                    
                    int quantity;
                    while (!int.TryParse(AskForInput("Enter the number you need to pack: "), out quantity))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }

                    fileSaver.AppendLine($"{item}:{quantity}");

                    command = AskForInput("Enter command ('end' or 'add'): ").Trim().ToLower();
                } while (command != "end");
            }
            else
            {
                Console.WriteLine("Invalid command. Try again.");
            }
        }

        public void ViewList()
        {
            if (File.Exists(fileSaver.FilePath))
            {
                string[] lines = File.ReadAllLines(fileSaver.FilePath);
                Console.WriteLine("\nCurrent Packing List:");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("No packing list found. Start adding items!");
            }
        }

        public void RemoveItem()
        {
            if (!File.Exists(fileSaver.FilePath))
            {
                Console.WriteLine("No packing list found.");
                return;
            }

            List<string> lines = new List<string>(File.ReadAllLines(fileSaver.FilePath));
            string itemToRemove = AskForInput("Enter the item to remove: ").Trim();

            bool removed = lines.RemoveAll(line => line.StartsWith(itemToRemove + ":")) > 0;

            if (removed)
            {
                File.WriteAllLines(fileSaver.FilePath, lines);
                Console.WriteLine($"'{itemToRemove}' has been removed from your list.");
            }
            else
            {
                Console.WriteLine($"'{itemToRemove}' not found in the list.");
            }
        }

        public static string AskForInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}


