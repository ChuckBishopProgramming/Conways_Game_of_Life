//create a grid
//get starting input
//validate starting input

public class Program
{    
    static string[,] grid = new string[30, 120];

    const string HEADER = "CONWAY'S GAME OF LIFE";
    static void Main(string[] args)
    {
        Console.WriteLine("It's Alive!!!!");

        string fillingDead = ".";
        string fillingAlive = "O";

        //FILL GRID W DEAD CELLS
        Fill(fillingDead);

        //PROMPT FOR CELL #
        int noOfCells = PromptForCellNumber();


        //loop number of cells times, 

        //$"\nPlease enter a valid number"
        int x = GetXPos();
        int y = GetYPos();

        grid[x-1, y-1] = fillingAlive;

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

    static public int GetXPos()
    {
        string startingPosPrompt = "Please enter the x position for your first cell:";
        string startingPosFPrompt = "\nPlease enter a valid number between 1 and 30";

        int maxLength = startingPosPrompt.Length + startingPosFPrompt.Length;
        int xPos = 0;

        bool xPosValid = false;

        while (!xPosValid)
        {
            xPos = GetNumberFromUser(startingPosPrompt, startingPosFPrompt, maxLength);
            if (!(xPos < 1 || xPos > 30))
            {
                xPosValid = true;
            }
        }
        return xPos;
    }
    static public int GetYPos()
    {
        string startingPosPrompt = "Please enter the y position for your first cell:";
        string startingPosFPrompt = "\nPlease enter a valid number between 1 and 120";

        int maxLength = startingPosPrompt.Length + startingPosFPrompt.Length;
        int yPos = 0;

        bool yPosValid = false;

        while (!yPosValid)
        {
            yPos = GetNumberFromUser(startingPosPrompt, startingPosFPrompt, maxLength);
            if (!(yPos < 1 || yPos > 120))
            {
                yPosValid = true;
            }
        }
        return yPos;
    }
    static public int PromptForCellNumber()
    {
        bool userInputValidNumber = false;
        int number = 0;

        while (!userInputValidNumber)
        {
            Console.WriteLine("How many cells do you want to place in total?");
            string userInput = Console.ReadLine();

            userInputValidNumber = int.TryParse(userInput, out number);            
        }
        return number;
    }
}

