//create a grid
//get starting input
//validate starting input

public class Program
{
    static string[,] grid = new string[30, 120];

    const string HEADER = "HEADER GOES HERE";
    static void Main(string[] args)
    {
        Console.WriteLine("It's Alive!!!!");

        string fillingDead = ".";
        string fillingAlive = "O";

        //fill grid with dead cells
        Fill(fillingDead);

        bool userInputValidNumber = false;


        while (!userInputValidNumber)
        {
            string msg = "Please enter some starting positions:";            

            do
            {
                if (msg.Length > 68)
                {
                    msg = "Please enter some starting positions: \nPlease enter a valid number";
                }

                ConsoleReset();

                Console.WriteLine(msg);

                string userInput = Console.ReadLine();

                userInputValidNumber = int.TryParse(userInput, out int number);

                msg += $"\nPlease enter a valid number";
            }
            while (!userInputValidNumber);
            
            

            //ConsoleReset();
            //Console.WriteLine("Please enter some starting positions:");
            //string userInput = Console.ReadLine();
            //userInputValidNumber = int.TryParse(userInput, out int number);  

            //if (!userInputValidNumber)
            //{
            //    Console.WriteLine("Please enter a valid number");
            //}
        }

        grid[5, 10] = fillingAlive;
        grid[5, 11] = fillingAlive;
        grid[5, 12] = fillingAlive;

        ConsoleReset();
        Print(grid);
    }
    static public void Fill(string filling)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = filling;
            }
        }
    }
    static public void Print(string[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.Write("\n");
        }
    }

    static public void ConsoleReset()
    {
        Console.Clear();
        Console.WriteLine(HEADER);
    }
}

