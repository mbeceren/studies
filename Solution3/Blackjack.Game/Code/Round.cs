using System;
using System.Collections.Generic;

namespace Blackjack.Game.Code
{
	public class Round
	{
		public readonly int _wictoryCondition = 21;
		private readonly int _number;
		private readonly Player _dealer;
		private readonly Player _player;
		private Dictionary<Player, Hand> playerHands = new Dictionary<Player, Hand>();
		private bool _isRoundEnd;

		public int Number => _number;
		public Player Winner { get; private set; }

		public Player Loser
		{
			get
			{
				if (Winner == _player)
					return _dealer;
				if (Winner == _dealer)
					return _player;
				return null;
			}
			
		}
		public string GetWinnersName()
		{
			return Winner?.Name ?? "Draw";
		}

		public Round(int roundNumber, Player dealer, Player player)
		{
			_number = roundNumber;
			_dealer = dealer;
			_player = player;
			playerHands.Add(dealer, new Hand());
			playerHands.Add(player, new Hand());
		}

		public Hand GetPlayersHand(Player player)
		{
			if (!playerHands.ContainsKey(player))
				return null;
			return playerHands[player];
		}

		public bool CanRoundContinue()
		{
			return GetPlayersHand(_player).GetHandValue() < _wictoryCondition 
				&& GetPlayersHand(_dealer).GetHandValue() < _wictoryCondition
				&& !_isRoundEnd;
		}

		public void EndRoundAndDecideWinner()
		{
			_isRoundEnd = true;
			var playersHandValue = playerHands[_player].GetHandValue();
			if (playersHandValue > _wictoryCondition)
			{
				Winner = _dealer;
				Console.WriteLine("{0} is bust!", _player.Name);
				return;
			}

			var dealersHandValue = playerHands[_dealer].GetHandValue();
			if (dealersHandValue > _wictoryCondition)
			{
				Winner = _player;
				Console.WriteLine("{0} is bust!", _dealer.Name);
				return;
			}

			if (playersHandValue.Equals(dealersHandValue))
			{
				Winner = null;
				return;
			}

			if (playersHandValue > dealersHandValue)
			{
				Winner = _player;
				if (playersHandValue == _wictoryCondition)
					Console.WriteLine("{0} is hit!", _player.Name);
				return;
			}

			if (dealersHandValue == _wictoryCondition)
				Console.WriteLine("{0} is hit!", _dealer.Name);
			Winner = _dealer;
		}
		

	}
}
