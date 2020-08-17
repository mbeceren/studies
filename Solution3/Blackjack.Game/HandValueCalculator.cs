using Blackjack.Tool.Enums;
using Blackjack.Tool.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Game
{
	public static class HandValueCalculator
	{
		private static int total;
		public static int CalculateValue(IList<PlayingCard> playingCards)
		{
			total = 0;
			
			foreach (var card in playingCards.OrderBy(obd => obd.Rank == PlayingCardRank.Ace))
			{
				total += GetCardValue(card.Rank);
			}

			return total;
		}

		private static int GetCardValue(PlayingCardRank rank)
		{
			var value = 0;
			switch (rank)
			{
				case PlayingCardRank.Jack:
				case PlayingCardRank.Queen:
				case PlayingCardRank.King:
					value = 10;
					break;
				case PlayingCardRank.Ace:
					if (total + 11 <= 21)
						value = 11;
					else
						value = 1;
					break;
				default:
					value = (int)rank;
					break;
			}
			return value;
		}
	}
}
