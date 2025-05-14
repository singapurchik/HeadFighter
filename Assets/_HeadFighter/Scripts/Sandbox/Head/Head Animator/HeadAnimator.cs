using UnityEngine;

namespace HeadFighter.Animations.Heads

{
	public class HeadAnimator : MonoBehaviour
	{
		[SerializeField] private TakeDamageAnimation _takeDamageRightSideAnim;
		[SerializeField] private TakeDamageAnimation _takeDamageLeftSideAnim;

		private TweenAnimation _currentAnim;

		private void Awake()
		{
			_takeDamageRightSideAnim.Initialize(transform);
			_takeDamageLeftSideAnim.Initialize(transform);
		}

		public void TryStopCurrentAnim() => _currentAnim?.Stop();

		public void PlayTakeDamageRightSideAnim()
		{
			TryStopCurrentAnim();
			_currentAnim = _takeDamageRightSideAnim.Play();
		}

		public void PlayTakeDamageLeftSideAnim()
		{
			TryStopCurrentAnim();
			_currentAnim = _takeDamageLeftSideAnim.Play();
		}
	}
}