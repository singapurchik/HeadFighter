using System;

namespace HeadFighter.Player
{
	public interface IReadOnlyDamageDealer
	{
		public event Action OnDealDamage;
	}
}