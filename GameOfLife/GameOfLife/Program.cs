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

        //FILL GRID W DEAD CELLS
        Fill(fillingDead);

        //$"\nPlease enter a valid number"

        string startingPosPrompt = "Please enter some starting positions:";
        string startingPosFPrompt = "\nPlease enter a valid number";
        int maxLength = 68; 
        GetNumberFromUser(startingPosPrompt, startingPosFPrompt, maxLength);


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
    static public int GetNumberFromUser(string prompt, string failPrompt, int failPromptLength)
    {
        bool userInputValidNumber = false;
        int number = 0;
        string msg = prompt;

        while (!userInputValidNumber)
        {           
            if (msg.Length > failPromptLength)
            {
                msg = prompt + failPrompt;
            }

            ConsoleReset();

            Console.WriteLine(msg);

            string userInput = Console.ReadLine();

            userInputValidNumber = int.TryParse(userInput, out number);

            msg += failPrompt;

        }

        return number;
    }
}

