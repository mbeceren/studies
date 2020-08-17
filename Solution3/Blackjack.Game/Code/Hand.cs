using Blackjack.Tool.Models;
using System.Collections.Generic;

namespace Blackjack.Game.Code
{
	public class Hand
	{
		public IList<PlayingCard> Cards { get; set; } = new List<PlayingCard>();

		public int GetHandValue()
		{
			if (Cards == null)
				return 0;
			return HandValueCalculator.CalculateValue(Cards);
		}
	}
}
