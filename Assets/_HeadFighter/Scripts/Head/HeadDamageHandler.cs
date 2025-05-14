using HeadFighter.Heads.Animations;
using HeadFighter.Player;
using UnityEngine;
using Zenject;

namespace HeadFighter.Heads
{
	public class HeadDamageHandler : MonoBehaviour, IDamageableHead
	{
		[Inject] private HeadAnimator _animator;
		[Inject] private Health _health;

		public void TryTakeDamage(HandType handType, float damage)
		{
			switch (handType)
			{
				case HandType.Left:
					_animator.PlayTakeDamageRightSideAnim();
					break;
				case HandType.Right:
				default:
					_animator.PlayTakeDamageLeftSideAnim();
					break;
			}
			_health.TryTakeDamage(damage);
		}
	}
}