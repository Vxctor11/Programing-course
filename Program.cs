//*****************************************************************************\
|*                                                                           *|
\*****************************************************************************/
using Microsoft.SqlServer.Server;
using System;
using System.Security.Cryptography;

public class Hangman
{
    /**************************************************************************\
    |* Game Constants                                                         *|
    \**************************************************************************/

    /**************************************************************************\
    |* Game State                                                             *|
    \**************************************************************************/

    String[] words;
    String selectedWord;
    bool[] guessedLetters;
    int guessCount;
    String[] gallows;
    int tries;

    /**************************************************************************\
    |* Other Game Data Objects and Components                                 *|
    \**************************************************************************/
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public static void Main(string[] arg)
    {
        Hangman ag = new Hangman();
        ag.Start();
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public Hangman()
    {
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public void Start()
    {
        string input;

        Init(); // 1. Initialize Variables
        ShowGameStartScreen(); // 2. Show Game Start Screen
        do
        {
            ShowBoard(); // 3. Show Board / Scene / Map
            do
            {
                ShowInputOptions(); // 4. Show Input Options
                input = GetInput(); // 5. Get Input
            }
            while (!IsValidInput(input)); // 6. Validate Input
            ProcessInput(input); // 7. Process Input
            UpdateGameState(); // 8. Update Game State
        }
        while (!IsGameOver()); // 9. Check for Termination Conditions
        ShowGameOverScreen(); // 10. Show Game Results
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public void Init()
    {
        words = new string[] { "house", "space", "floor", "diamond" };

        Random ran = new Random();
        int rIndex = ran.Next(words.Length);
        selectedWord = words[rIndex];

        guessedLetters = new bool[selectedWord.Length];

        guessCount = 0;
        tries = 6;
        gallows = new string[]
        {
                          "____   \n"+
                         "|   |   \n" +
                         "|       \n" +
                         "|       \n" +
                         "|       \n" +
                         "|______ \n",

                          "_____   \n" +
                         "| |     \n" +
                         "| O     \n" +
                         "|       \n" +
                         "|       \n" +
                         "|______ \n" ,

                         "_____   \n" +
                         "| |     \n" +
                         "| O     \n" +
                         "| |     \n" +
                         "|       \n" +
                         "|______ \n" ,

                        "_____   \n" +
                        "|  |     \n" +
                        "|  O     \n" +
                        "| /|     \n" +
                        "|        \n" +
                        "|______  \n" ,

                         "_____    \n" +
                        "|   |     \n" +
                        "|   O     \n" +
                        "|  /|\\   \n" +
                        "|         \n" +
                        "|______   \n" ,

                         "_____    \n" +
                         "|   |    \n" +
                         "|   O    \n" +
                         "|  /|\\  \n" +
                         "|  /     \n" +
                         "|______  \n" ,

                         "_____   \n" +
                        "|   |    \n" +
                        "|   O    \n" +
                        "|  /|\\  \n" +
                        "|  / \\  \n" +
                        "|______  \n"
        };

        gallows[0] = "_____   \n" +
                     "|   |   \n" +
                     "|       \n" +
                     "|       \n" +
                     "|       \n" +
                     "|______ \n";

        gallows[1] = "_____   \n" +
                     "| |     \n" +
                     "| O     \n" +
                     "|       \n" +
                     "|       \n" +
                     "|______ \n";

        gallows[2] = "_____   \n" +
                     "| |     \n" +
                     "| O     \n" +
                     "| |     \n" +
                     "|       \n" +
                     "|______ \n";

        gallows[3] = "_____   \n" +
                    "|  |     \n" +
                    "|  O     \n" +
                    "| /|     \n" +
                    "|        \n" +
                    "|______  \n";

        gallows[4] = "_____    \n" +
                    "|   |     \n" +
                    "|   O     \n" +
                    "|  /|\\   \n" +
                    "|         \n" +
                    "|______   \n";

        gallows[5] = "_____    \n" +
                     "|   |    \n" +
                     "|   O    \n" +
                     "|  /|\\  \n" +
                     "|  /     \n" +
                     "|______  \n";

        gallows[6] = "_____   \n" +
                    "|   |    \n" +
                    "|   o    \n" +
                    "|  /|\\  \n" +
                    "|  / \\  \n" +
                    "|______  \n";
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public void ShowGameStartScreen()
    {
        Console.WriteLine(" Welcome player this is Hangman! ");
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public void ShowBoard()
    {
        Console.WriteLine(selectedWord);
        Console.WriteLine(gallows[guessCount]);
        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (guessedLetters[i] == true)
            {
                Console.Write(selectedWord[i] + " ");
            }
            else
            {
                Console.Write("_" + " ");
            }
        }
       
        Console.WriteLine("You have " + tries + " tries left!");


    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public void ShowInputOptions()
    {
        Console.Write(" Enter any letter: ");
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public string GetInput()
    {
        string guessedLetters = Console.ReadLine();
        string guessdLetter = guessedLetters.Trim();
        return guessedLetters;
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public bool IsValidInput(string input)
    {
        string word = input;
        int len = input.Length;
        Char.IsLetter();
        Char.IsLower();
        return true;
    }

    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public void ProcessInput(string input)
    {
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (selectedWord[i] == input[0])
            {
                guessedLetters[i] = true;
            }
            guessCount = +1;
        }
    }

    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public void UpdateGameState()
    {

    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public bool IsGameOver()
    {
        return (CheckWin() || CheckLoss());
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public bool CheckWin()
    {


        return false;
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/
    public bool CheckLoss()
    {


        return false;
    }
    /**************************************************************************\
    |*                                                                        *|
    \**************************************************************************/

    public void ShowGameOverScreen()
    {
        Console.WriteLine("Game Over!");
        if (CheckWin())
        {
            Console.WriteLine(" You Won and this are your numbers of error " + guessCount);
        }
        else if (CheckLoss())
        {
            Console.WriteLine(" You Lost, The word was " + selectedWord + "!");
        }
        else
        {
            Console.WriteLine("Something went really wrong! This is never supposed to happen!");
        }
    }
}
