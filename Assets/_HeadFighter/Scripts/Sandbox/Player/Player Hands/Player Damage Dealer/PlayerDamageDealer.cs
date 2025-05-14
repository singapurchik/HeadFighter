using HeadFighter.Heads;
using UnityEngine;
using Zenject;
using System;

namespace HeadFighter.Player
{
	public class PlayerDamageDealer : MonoBehaviour, IReadOnlyDamageDealer, IHandDamageDealer
	{
		[SerializeField] private float _damage = 5f;
		
		[Inject] private IDamageableHead _head;

		public event Action OnDealDamage;

		public void DealDamage(HandType handType)
		{
			_head.TryTakeDamage(handType, _damage);
			OnDealDamage?.Invoke();
		}
	}
}