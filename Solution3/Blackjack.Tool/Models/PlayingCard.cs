using Blackjack.Tool.Enums;

namespace Blackjack.Tool.Models
{
	public class PlayingCard
	{
		private readonly PlayingCardType _type;
		private readonly PlayingCardRank _rank;
		public PlayingCard(PlayingCardType type, PlayingCardRank rank)
		{
			_type = type;
			_rank = rank;
		}
		public PlayingCardRank Rank => _rank;
		public PlayingCardType Type => _type;
	}
}
