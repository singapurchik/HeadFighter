using HeadFighter.Player;

namespace HeadFighter.Heads
{
	public interface IDamageableHead
	{
		public void TryTakeDamage(HandType handType, float damage);
	}
}