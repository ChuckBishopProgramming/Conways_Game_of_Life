//create a grid
//get starting input
//validate starting input
//

public class Program
{
    public static string[,] grid = new string[30, 120];

    const string HEADER = "CONWAY'S GAME OF LIFE";
    const string fillingDead = ".";
    const string fillingAlive = "O";
    static void Main(string[] args)
    {
        Console.WriteLine("It's Alive!!!!");

        //FILL GRID W DEAD CELLS
        //++++++++++++++++++++++++++++++++++
        Fill(fillingDead);

        //PROMPT FOR CELL #
        //++++++++++++++++++++++++++++++++++
        int noOfCells = PromptForCellNumber();
                
        LoopForCells(noOfCells);
        ConsoleReset();
        Print(grid);        
    }

    //CORE MECHANICS
    //++++++++++++++++++++++++++++++++++
    static public void LoopForCells(int numberOfCells)
    {
        for (int i = 0; i < numberOfCells; i++)
        {

            int x = GetXPos(i + 1);
            int y = GetYPos(i + 1);

            if (grid[x - 1, y - 1] == fillingAlive)
            {
                CellFilled();
                i--;
            }
            else
            {
                grid[x - 1, y - 1] = fillingAlive;
            }
        }
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
    //MECHANICAL HELPERS
    //++++++++++++++++++++++++++++++++++
    static public void ConsoleReset()
    {
        Console.Clear();
        Console.WriteLine(HEADER);
    }
    //DISPLAY
    //++++++++++++++++++++++++++++++++++
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

    //PROMPT
    //++++++++++++++++++++++++++++++++++
    static public void CellFilled()
    {
        Console.WriteLine("That cell was already activated, please pick another. Press Enter to Continue");
        Console.ReadKey();
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
    static public int GetXPos(int cellNo)
    {
        string startingPosPrompt = $"Please enter the x position for cell number {cellNo}: (1 to 30)";
        string startingPosFPrompt = "\nPlease enter a valid number";

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
    static public int GetYPos(int cellNo)
    {
        string startingPosPrompt = $"Please enter the y position for cell number {cellNo} (1 to 120):";
        string startingPosFPrompt = "\nPlease enter a valid number";

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
}

