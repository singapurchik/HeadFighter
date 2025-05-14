using HeadFighter.Animations.Heads;
using HeadFighter.Player;
using UnityEngine;
using Zenject;

namespace HeadFighter.Heads
{
	public class HeadDamageHandler : MonoBehaviour, IDamageableHead
	{
		[Inject] private HeadVisualEffects _visualEffects;
		[Inject] private HeadAnimator _animator;
		[Inject] private Health _health;

		public void TryTakeDamage(HandType handType, float damage)
		{
			switch (handType)
			{
				case HandType.Left:
					_animator.PlayTakeDamageRightSideAnim();
					_visualEffects.PlayRightHitEffect();
					break;
				case HandType.Right:
				default:
					_animator.PlayTakeDamageLeftSideAnim();
					_visualEffects.PlayLeftHitEffect();
					break;
			}
			_health.TryTakeDamage(damage);
		}
	}
}