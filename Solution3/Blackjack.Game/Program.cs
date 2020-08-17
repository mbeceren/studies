using System;
using System.Linq;
using System.Threading;

namespace Blackjack.Game
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				var answer = GetYesNoAnswer("Do you want to start game?(Y/N)");
				if (answer != "y")
					break;

				Console.WriteLine("Welcome to Blackjack!");
				
				Play();
			}
		}

		private static void Play()
		{
			var deckCount = 1;
			var game = new Code.Game(deckCount);

			while (true)
			{
				if (game.IsGameOver())
				{
					Console.WriteLine("Game is over!.");
					break;
				}

				var answer = GetYesNoAnswer("Do you want to start round?(Y/N)");
				if (answer != "y")
					break;

				game.NewRound();
				var round = game.GetCurrentRound();
				Console.WriteLine("*****************");
				Console.WriteLine("Round {0} started", round.Number);
				var playersHand = round.GetPlayersHand(game.Player);

				Console.WriteLine("Player's hand: [{0}]", string.Join(", ", playersHand.Cards.Select(s => string.Format("{0} of {1}s", s.Rank.ToString(), s.Type.ToString()))));
				Console.WriteLine("Players hand value is: {0}", playersHand.GetHandValue());

				while (true)
				{
					if (round.CanRoundContinue())
					{
						var answer2 = GetYesNoAnswer("Do you wish to pick card?(Y/N)");
						if (answer2 == "y")
						{
							game.PickCard();
							Console.WriteLine("{0} picked [{1}]", game.Player.Name, string.Format("{0} of {1}s", playersHand.Cards.Last().Rank.ToString(), playersHand.Cards.Last().Type.ToString()));
							Console.WriteLine("{0}'s hand: [{1}]", game.Player.Name, string.Join(", ", playersHand.Cards.Select(s => string.Format("{0} of {1}s", s.Rank.ToString(), s.Type.ToString()))));
							Console.WriteLine("{0}'s hand value is: {1}", game.Player.Name, playersHand.GetHandValue());
						}
						else if (answer2 == "n")
							break;
					}
					else
						break;

					Thread.Sleep(1000);
				}

				round.EndRoundAndDecideWinner();
				Console.WriteLine("***Winner is: {0}***", round.GetWinnersName());

				Console.WriteLine("{0}'s hand: [{1}]", game.Dealer.Name, string.Join(", ", round.GetPlayersHand(game.Dealer).Cards.Select(s => string.Format("{0} of {1}s", s.Rank.ToString(), s.Type.ToString()))));
				Console.WriteLine("{0}'s hand value is: {1}", game.Dealer.Name, round.GetPlayersHand(game.Dealer).GetHandValue());

				Console.WriteLine("{0}'s hand: [{1}]", game.Player.Name, string.Join(", ", round.GetPlayersHand(game.Player).Cards.Select(s => string.Format("{0} of {1}s", s.Rank.ToString(), s.Type.ToString()))));
				Console.WriteLine("{0}'s hand value is: {1}", game.Player.Name, round.GetPlayersHand(game.Player).GetHandValue());

				Console.WriteLine("Round {0} ended.", round.Number);
			}

			game.PrintScoreBoard();
		}


		public static string GetYesNoAnswer(string question)
		{
			string answer = string.Empty;
			while (true)
			{
				Console.WriteLine(question);
				var input = Console.ReadLine().ToLower();
				if (input == "y" || input == "n")
				{
					answer = input;
					break;
				}
			}
			return answer;
		}
	}
}
