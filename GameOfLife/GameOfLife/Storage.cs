public class Storage
{
    public static int[] initialX;
    public static int[] initialY;

    public static void CreateInitialArrays(int numberOfCells)
    {
        initialX = new int[numberOfCells];
        initialY = new int[numberOfCells];
    }
    public static void AddToInitialX(int[] initialX, int xToAdd, int counter)
    {
        initialX[counter] = xToAdd; 
    }

}