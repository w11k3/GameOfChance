﻿public class Craps
{
    // create random-number generator for use in method RollDice
    private static Random randomNumbers = new Random();

    // enumeration with constants that represent the game status
    private enum Status { CONTINUE, WON, LOST }

    // enumeration with constants that represent common rolls of the dice
    private enum DiceNames
    {
        SNAKE_EYES = 2,
        TREY = 3,
        SEVEN = 7,
        YO_LEVEN = 11,
        BOX_CARS = 12
    }

    // plays on game of craps
    public static void Main(string[]args)
    {
        // gameStatus can contain CONTINUE, WON, LOST
        Status gameStatus = Status.CONTINUE;
        int myPoint = 0; // point if no win or loss on first roll

        int sumOfDice = RollDice(); // first roll of the dice

        // determine game status and point based on first roll
        switch ((DiceNames) sumOfDice)
        {
            case DiceNames.SEVEN: // win with 7 on first roll
            case DiceNames.YO_LEVEN: // win with 11 on first roll
                gameStatus = Status.WON;
                break;

            case DiceNames.SNAKE_EYES: // lose with 2 on first roll
            case DiceNames.TREY: // lose with 3 on first roll
            case DiceNames.BOX_CARS: // lose with 12 on first roll
                gameStatus = Status.LOST;
                break;

            default: // did not win or lose, so remember point
                gameStatus = Status.CONTINUE; // game is not over
                myPoint = sumOfDice; // remember the point 
                Console.WriteLine($"Point is {myPoint}");
                break;
        } // end switch

        // while game is not complete
        while (gameStatus == Status.CONTINUE) // game not WON or LOST
        {
            sumOfDice = RollDice(); // roll dice again

            // determine game status
            if (sumOfDice == myPoint) // win by making point
                gameStatus = Status.WON;
            else
                // lose by rolling 7 before point
                if (sumOfDice == (int)DiceNames.SEVEN)
                gameStatus = Status.LOST;
        } // end while

        // display won or lost message
        if (gameStatus == Status.WON)
        {
            Console.WriteLine("Player wins!");
        }
        else
            Console.WriteLine("Player loses");
    } // end Main

    // roll dice, calculate sum and display results
    private static int RollDice()
    {
        // pick random die values
        int die1 = randomNumbers.Next(1, 7); // first die roll
        int die2 = randomNumbers.Next(1, 7); // second die roll

        int sum = die1 + die2; // sum of die values

        // display results of this roll
        Console.WriteLine($"Player rolled {die1} + {die2} = {sum}");
        return sum; // return sum of dice
    } // end method RollDice
} // enc class Craps
