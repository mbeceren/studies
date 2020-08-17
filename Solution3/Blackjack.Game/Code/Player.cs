namespace Blackjack.Game.Code
{
	public class Player
	{
		private readonly string _name;
		public string Name => _name;

		public Player(string name)
		{
			_name = name;
		}
	}
}
