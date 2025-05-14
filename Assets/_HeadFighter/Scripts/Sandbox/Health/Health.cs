using UnityEngine;
using System;

namespace HeadFighter
{
	public class Health : MonoBehaviour, IReadOnlyHeath
	{
		[SerializeField] private int _startHealth = 100;
		
		public float CurrentHealth { get; private set; }
		public float StartHealth => _startHealth;
		
		public bool IsDead => CurrentHealth <= 0;

		public event Action OnTakeDamage;
		public event Action OnDead;

		private void Awake()
		{
			CurrentHealth = _startHealth;
		}

		public virtual void TryTakeDamage(float amount)
		{
			if (CurrentHealth > 0)
			{
				CurrentHealth -= amount;
				OnTakeDamage?.Invoke();

				if (CurrentHealth <= 0)
				{
					CurrentHealth = 0;
					Kill();
				}	
			}
		}

		protected virtual void Kill()
		{
			OnDead?.Invoke();
		}

	}
}