using Blackjack.Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Game.Code
{
	public class Game
	{
		private Round _lastRound;
		private readonly IList<Round> _rounds = new List<Round>();
		private readonly IList<Deck> _decks = new List<Deck>();

		public readonly Player Dealer = new Player("Dealer");
		public readonly Player Player = new Player("Player");

		public Round GetCurrentRound()
		{
			return _rounds.LastOrDefault();
		}

		public Game(int deckCount)
		{
			if (deckCount <= 0)
				deckCount = 1;

			for (int i = 0; i < deckCount; i++)
			{
				var deck = new Deck();
				deck.Shuffle();
				_decks.Add(deck);
			}
		}

		#region Public Methods

		public void NewRound()
		{
			if (IsGameOver())
			{
				Console.WriteLine("Game over!");
				return;
			}

			_lastRound = GetCurrentRound();
			var round = new Round((_lastRound?.Number ?? 0) + 1, Dealer, Player);
			_rounds.Add(round);
			DealCards();
		}

		public bool IsGameOver()
		{
			return RemainingCardCount() < 4;
		}

		public void PickCard()
		{
			if (RemainingCardCount() < 1)
			{
				Console.WriteLine("There is no remaining card in the deck.");
				GetCurrentRound().EndRoundAndDecideWinner();
				return;
			}

			var round = GetCurrentRound();
			round.GetPlayersHand(Player).Cards.Add(GetCard());
		}

		public void PrintScoreBoard()
		{
			var playersCount = 0;
			var dealersCount = 0;
			foreach (var round in _rounds)
			{
				if (round.Winner == Player)
					playersCount++;			
				else if (round.Winner == Dealer)
					dealersCount++;
				else
				{
					Console.WriteLine("Round {0} = Draw & Score: Dealer({1}) - Player({2}) & Hands: Dealer({3}), Player({4})"
						, round.Number
						, dealersCount
						, playersCount
						, round.GetPlayersHand(Dealer).GetHandValue()
						, round.GetPlayersHand(Player).GetHandValue());
					continue;
				}

				Console.WriteLine("Round {0} = Winner: {1} & Score: Dealer({2}) - Player({3}) & Hands: Winner({4}), Loser({5})"
					, round.Number
					, round.GetWinnersName()
					, dealersCount
					, playersCount
					, round.GetPlayersHand(round.Winner).GetHandValue()
					, round.GetPlayersHand(round.Loser).GetHandValue());
			}

			Console.WriteLine("********************************************");
			if (playersCount < dealersCount)
				Console.WriteLine("**************Winner is {0}**************", Dealer.Name);
			else if (playersCount > dealersCount)
				Console.WriteLine("**************Winner is {0}**************", Player.Name);
			else
				Console.WriteLine("******************Draw******************");
			Console.WriteLine("********************************************");
		}

		#endregion

		#region Private Methods

		private void DealCards()
		{
			var round = GetCurrentRound();
			var dealersHand = round.GetPlayersHand(Dealer);
			dealersHand.Cards.Add(GetCard());
			dealersHand.Cards.Add(GetCard());

			var playersHand = round.GetPlayersHand(Player);
			playersHand.Cards.Add(GetCard());
			playersHand.Cards.Add(GetCard());

			PrepareDealer();
		}

		private void PrepareDealer()
		{
			var dealersHand = GetCurrentRound().GetPlayersHand(Dealer);
			if (dealersHand.GetHandValue() >= 16)
				return;
			dealersHand.Cards.Add(GetCard());
			PrepareDealer();
		}

		private PlayingCard GetCard()
		{
			var deck = _decks.FirstOrDefault(f => f.RemainingCardCount > 0);
			if (deck != null && deck.PopCard(out PlayingCard pCard))
				return pCard;
			return null;
		}

		private int RemainingCardCount()
		{
			return _decks.Sum(sum => sum.RemainingCardCount);
		}

		#endregion
	}
}
