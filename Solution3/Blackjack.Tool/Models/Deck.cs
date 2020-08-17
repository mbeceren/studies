using System;
using System.Collections.Generic;
using System.Linq;
using Blackjack.Tool.Enums;
using Blackjack.Tool.Interfaces;

namespace Blackjack.Tool.Models
{
	public class Deck : IDeck
	{
		private readonly Random _rnd = new Random();
		private IList<PlayingCard> _playingCards;
		private readonly IList<PlayingCard> _poppedCards = new List<PlayingCard>();

		public int RemainingCardCount => GetRemainingCards().Count;
		private IList<PlayingCard> GetRemainingCards()
		{
			return _playingCards.Except(_poppedCards).ToList();
		}

		public Deck()
		{
			GenerateCards();
		}

		//Fisher–Yates shuffle
		public void Shuffle()
		{
			Reset();
			int n = _playingCards.Count;
			while(n > 1)
			{
				n--;
				int k = _rnd.Next(n + 1);
				var value = _playingCards[k];
				_playingCards[k] = _playingCards[n];
				_playingCards[n] = value;
			}
		}

		public bool PopCard(out PlayingCard pCard)
		{
			pCard = null;
			var remainingCards = GetRemainingCards();
			if (remainingCards.Count == 0)
				return false;

			pCard = remainingCards.Last();
			_poppedCards.Add(pCard);
			return true;
		}

		private void GenerateCards()
		{
			IList<PlayingCard> playingCards = new List<PlayingCard>();
			foreach (PlayingCardType cardType in Enum.GetValues(typeof(PlayingCardType)))
			{
				foreach (PlayingCardRank cardRank in Enum.GetValues(typeof(PlayingCardRank)))
				{
					playingCards.Add(new PlayingCard(cardType, cardRank));
				}
			}

			_playingCards = playingCards;
		}

		private void Reset()
		{
			_poppedCards.Clear();
		}
	}
}
