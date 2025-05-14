using System;

namespace HeadFighter
{
	public interface IReadOnlyHeath
	{
		public float CurrentHealth { get;}
		public float StartHealth { get;}
		
		public bool IsDead { get;}

		public event Action OnTakeDamage;
		public event Action OnDead;
	}
}