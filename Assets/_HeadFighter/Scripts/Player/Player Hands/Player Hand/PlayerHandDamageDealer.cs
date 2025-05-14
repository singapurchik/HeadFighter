using HeadFighter.Heads;
using UnityEngine;
using Zenject;

namespace HeadFighter.Player
{
	public class PlayerHandDamageDealer : MonoBehaviour, IHandDamageDealer
	{
		[SerializeField] private float _damage = 5f;
		
		[Inject] private IDamageableHead _head;

		public void DealDamage(HandType handType) => _head.TryTakeDamage(handType, _damage);
	}
}