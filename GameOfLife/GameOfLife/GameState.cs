public class GameState
{
    private bool _running = false;
    private bool _paused = false;

    // PREP
    //lots of prompts
    //create tracking array/list/ll
    //add prompted cells to buffer AND tracking array


    // RUNNING
    // a loop, never ending except for prompt
    // Exit on esc, or Q

    // PAUSED

    // STOP
    public static void OneGeneration()
    {
        Program.currentGrid = Program.UpdateGrid();
        Program.Print2DString(Program.currentGrid);
        Console.ReadKey();

    }

}
