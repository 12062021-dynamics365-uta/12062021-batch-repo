using System;
using System.Collections.Generic;

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
			Mapper mapper = new Mapper();
			DataBaseAccess dbAccess	= new DataBaseAccess(mapper);
			GamePlayLogic game = new GamePlayLogic(dbAccess);

			do//this loop will run till the logged in person decided to log out.
			{
				logout = false;
				Console.WriteLine("Hello. Welcome to Rock-Paper-Scissors Game!");
				Console.WriteLine("To Log in, What is your First Name?");
				string userFName = Console.ReadLine();
				Console.WriteLine("What is your Last Name?");
				string userLName = Console.ReadLine();

				// log in the player
				game.Login(userFName, userLName);

				//this wil jsut a test of the Db Connection.
				List<Player> players = game.GetAllPlayers();

				foreach (Player p in players)
                {
					Console.WriteLine($"{p.PlayerId}\t{p.Fname}\t{p.Lname}\t{p.Wins}\t{p.Losses}.");
                }

				//give the choice to play a game of print our theri game history.
				Console.WriteLine("\tPlease choose what you want to do.");

				do
				{
					Console.WriteLine("\n\tEnter 1 to play a game.\n\tEnter 2 to see a history of your games played.\n\tEnter 3 to Quit");
					string menuChoice = Console.ReadLine(); 
					userChoice = game.ValidateUserChoice(menuChoice);
					if (userChoice == Choice.invalid)
					{
						Console.WriteLine("Hey, buddy...that wasn't a 1 or 2 or 3!");
					}
				

					switch (userChoice)
					{
						case Choice.Rock:
							break;
						case Choice.Paper:// call PrintUsersGames() to get a list of games played
							List<Game> usersGames = game.PrintUsersGames();
							//call method below to print out details of the games
							PrintUsersGames1(usersGames);
							break;
						case Choice.Scissors:
							Environment.Exit(1);
							break;
                        default:
							Console.WriteLine("This is the default in the switch statement");
							break;
					}
				} while (userChoice == Choice.invalid);
				//loop here till one player has won 2 rounds
				bool playAgain = true;
				userChoice = Choice.invalid;
				do
				{
					game.StartNewGame();
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
								Console.WriteLine("Hey, buddy...that wasn't a 1 or 2 or 3!");
							}
						} while (userChoice == Choice.invalid);

						// get the computers choice
						computerChoice = game.GetComputerChoice();
						Console.WriteLine($"The computers choice is {computerChoice}");
						Player roundWinner = game.PlayRound(computerChoice, userChoice);
                        //have this try catch for when there is no round winner and the Fname/Lname lfields are NULL.

                        //verify that there is a winner to avoid an Excdeption
                        if (roundWinner != null)
                        {
							Console.WriteLine($"The winner of this round is {roundWinner.Fname} {roundWinner.Lname}");
						}
                        else
                        {
							Console.WriteLine("This round was a tie");
						}
						#region
						//try
						//{
						//	Console.WriteLine($"The winner of this round is {roundWinner.Fname} {roundWinner.Lname}");
						//}
						//catch (SystemException ex)
						//{
						//	Console.WriteLine("This round was a tie");
						//	//Console.WriteLine($"Congrats! This is the SystemException class. => {ex.Message}");
						//}
						//catch (Exception ex)
						//{
						//	Console.WriteLine($"An unknown exception was thrown in Program.cs try/catch => {ex.Message}");
						//}
						//the finally block ALWAYS runs!!!
						//              finally
						//              {
						//Console.WriteLine("This is the finally block");
						//              }
						#endregion

					}

                    Console.WriteLine($"\t\tThe game is over.");
					Console.WriteLine($"The computer won {game.GetComputerWins()} games.");
					Console.WriteLine($"You won {game.GetUserWins()} games.");
					Console.WriteLine($"There were {game.GetTies()} ties.");
					Console.WriteLine($"This game was {game.GetNumRounds()} rounds long..");
					Console.WriteLine($"Would you like to play again?\nEnter no if you don't want to play again.\nOtherwise, do anything else.");
					string playAgainInput = Console.ReadLine();
					
					if (playAgainInput.ToLower().Equals("no"))//method chaining
					{
						playAgain = false;
						logout = true;
					}
				} while (playAgain);
				game.ResetGame();
				//loop to log someone else in HERE
			} while (logout);
		}//EoMain

		public static void PrintUsersGames1(List<Game> games)
        {
			int counter = 0;
			Console.WriteLine($"There are {games.Count} games in your history ");
			foreach (Game game in games)
            {
				counter++;
				Console.WriteLine($"This game {counter}.");
				Console.WriteLine($"This game was between {game.Player1.Fname} {game.Player1.Lname} and {game.Player2.Fname} {game.Player2.Lname}.");
                //loop over the rounds. printing the choices.
				
                foreach (Round r in game.Rounds)
                {
                    if (r.Winner != null)
                    {
						Console.WriteLine($"\tThe computer played {r.Player1} and you played {r.Player2} so {r.Winner.Fname} won. ");
					}
                    else
                    {
						Console.WriteLine($"\tThe computer played {r.Player1} and you played {r.Player2} so no one won. ");
                    }
				}
			}
		}
	}//EoC
}//EoN
