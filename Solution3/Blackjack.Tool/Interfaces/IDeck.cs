using Blackjack.Tool.Models;

namespace Blackjack.Tool.Interfaces
{
	public interface IDeck
	{
		void Shuffle();
		bool PopCard(out PlayingCard pCard);
	}
}
