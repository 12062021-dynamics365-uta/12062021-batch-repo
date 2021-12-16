using System;

namespace Rock_Paper_Scissors_Demo1
{

	// add the ability to play again as the logged in person.
	// add the ability to log out and someone else logs in.
	// have the option to look up their win/loss record after the game ends.

	class Program
	{
		static void Main(string[] args)
		{
			Choice computerChoice;
			Choice userChoice = Choice.invalid;
			bool logout = false;
			GamePlayLogic game = new GamePlayLogic();

			do
			{
				logout = false;
				Console.WriteLine("Hello. Welcome to Rock-Paper-Scissors Game!");

				Console.WriteLine("To Log in, What is your First Name?");
				string userFName = Console.ReadLine();
				Console.WriteLine("What is your Last Name?");
				string userLName = Console.ReadLine();

				// log in the player
				game.Login(userFName, userLName);
				game.StartNewGame();
				//loop here till one player has won 2
				//call the WinnerYet method to see i there's a
				//
				bool playAgain = true;
				do
				{
					while (game.WinnerYet() == null)
					{
						//get user choice and validate
						do
						{
							Console.WriteLine("Please enter enter 1 for ROCK, 2 for PAPER, 3 for SCISSORS.\n");
							string userInput = Console.ReadLine();
							userChoice = game.ValidateUserChoice(userInput);
							if (userChoice == Choice.invalid)
							{
								Console.WriteLine("Hey, buddy... that wasn't a 1 or 2 or 3!");
							}
						} while (userChoice == Choice.invalid);

						// get the computers choice
						computerChoice = game.GetComputerChoice();
						Console.WriteLine($"The computers choice is {computerChoice}");
						Player roundWinner = game.PlayRound(computerChoice, userChoice);
						//have this try catch for when there is no round winner and the Fname/Lname lfields are NULL.
						try
						{
							Console.WriteLine($"The winner of this round is {roundWinner.Fname} {roundWinner.Lname}");
						}
						catch (SystemException ex)
						{
							Console.WriteLine("This round was a tie");
							//Console.WriteLine($"Congrats! This is the SystemException class. => {ex.Message}");
						}
						catch (Exception ex)
						{
							Console.WriteLine($"An unknown exception was thrown in Program.cs try/catch => {ex.Message}");
						}
						//the finally block ALWAYS runs!!!
						//              finally
						//              {
						//Console.WriteLine("This is the finally block");
						//              }
					}

					//Player gameWinner = game.GetWinnerOfLastGame();

					Console.WriteLine($"The game is over.");
					Console.WriteLine($"The computer won {game.GetComputerWins()} games.");
					Console.WriteLine($"You won {game.GetUserWins()} games.");
					Console.WriteLine($"There were {game.GetTies()} ties.");
					Console.WriteLine($"This game was {game.GetNumRounds()} rounds long..");
					Console.WriteLine($"Would you like to play again?\nEnter no if you don't want to play again.\nOtherwise, do anything else.");
					string playAgainInput = Console.ReadLine();
					
					game.ResetGame();

					if (playAgainInput.ToLower().Equals("no"))//method chaining
					{
						playAgain = false;
						logout = true;
					}
				} while (playAgain);

				//loop to log someone else in HERE
			} while (logout);
		}//EoMain


	}//EoC
}//EoN
