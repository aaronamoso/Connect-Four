using System;

class ConnectFourGame
{
    static char[,] grid = new char[6, 7]; //poly for the rows and columns total 42
    static char currentPlayer = 'X'; 

    //MAIN FUNCTION TO CALL METHODS
    static void Main()
    {
        InitializeGrid(); // by calling this, it creates some type of loop to show the current state of the grid

        Console.WriteLine("Connect Four!");

        while (true)
        {
            DisplayGrid();
            Console.WriteLine("It is Player " + currentPlayer + "'s turn:");
            Console.WriteLine("Enter a number between 1 and 7 to choose a column to drop your piece.");

            int column = Convert.ToInt32(Console.ReadLine()) - 1;

            if (DropPiece(column))
            {
                if (CheckForWinner()) //winner
                { 
                    DisplayGrid(); 
                    Console.WriteLine("Player " + currentPlayer + " wins!");
                    break;
                }

                if (IsGridFull()) //draw
                {
                    DisplayGrid();
                    Console.WriteLine("It's a draw!");
                    break;
                }

                SwitchPlayer();
            }
        }
    }

    //methods: we can use two different for loops under the same method since it is a row v column?
    //create a board 6 by 7
    static void InitializeGrid()
    {
        for (int row = 0; row < 6; row++)  // rows
        {
            for (int col = 0; col < 7; col++) // cols
            {
                grid[row, col] = '-'; //shows a line for each cell that way user knows it is empty
            }
        }
    }

    //displays the current state and symbol of the game grid in the console
    static void DisplayGrid()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                Console.Write(grid[row, col] + " "); //shows the spaces in between the cells for more accurate reading
            }
            Console.WriteLine();
        }
        Console.WriteLine("1 2 3 4 5 6 7"); //selection for the user which number they want to use associated with the column
    }
    // when a player chooses the specific number to drop their symbol
    static bool DropPiece(int column)
    {
        for (int row = 5; row >= 0; row--)
        {
            if (grid[row, column] == '-')
            {
                grid[row, column] = currentPlayer; //currentPlayer = X.
                return true;
            }
        }

        Console.WriteLine("Column is full. Please choose another column."); //
        return false;
    }
    // checks for the winner
    static bool CheckForWinner()
    {
        //checks for four in a row
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 4; col++) 
            {
                if (grid[row, col] == currentPlayer && grid[row, col + 1] == currentPlayer && grid[row, col + 2] == currentPlayer && grid[row, col + 3] == currentPlayer)
                {
                    return true; // returns if the player won
                }
            }
        }

        //check for four in a column
        for (int col = 0; col < 7; col++)
        {
            for (int row = 0; row < 3; row++)
            {
                if (grid[row, col] == currentPlayer && grid[row + 1, col] == currentPlayer && grid[row + 2, col] == currentPlayer && grid[row + 3, col] == currentPlayer)
                {
                    return true;
                }
            }
        }

        //check for four in a diagonal
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (grid[row, col] == currentPlayer && grid[row + 1, col + 1] == currentPlayer && grid[row + 2, col + 2] == currentPlayer && grid[row + 3, col + 3] == currentPlayer)
                {
                    return true;
                }
            }
        }

        for (int row = 0; row < 3; row++)
        {
            for (int col = 3; col < 7; col++)
            {
                if (grid[row, col] == currentPlayer && grid[row + 1, col - 1] == currentPlayer && grid[row + 2, col - 2] == currentPlayer && grid[row + 3, col - 3] == currentPlayer)
                {
                    return true;
                }
            }
        }

        return false;
    }
    //how it works when its draw? 
    //
    static bool IsGridFull()
    {
        for (int col = 0; col < 7; col++)
        {
            //checks the columns current condition
            if (grid[0, col] == '-')
            {
                return false; //if found an empty space
            }
        }
        return true; //returns true when the grid is full
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; // switches player every after turn to O
    }
}