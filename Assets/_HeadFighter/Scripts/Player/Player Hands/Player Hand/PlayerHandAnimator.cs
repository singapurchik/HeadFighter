using System;
using DG.Tweening;
using UnityEngine;

namespace HeadFighter.Player
{
	public class PlayerHandAnimator : MonoBehaviour
	{
		[Header("Idle Anim Properties")]
		[SerializeField] private float _idleOffset = -0.1f;
		[SerializeField] private float _idleDuration = 0.5f;
		[SerializeField] private Ease _idleEase;
		
		[Header("Punch Anim Properties")]
		[SerializeField] private float _punchOffset = 1f;
		[SerializeField] private float _punchDuration = 0.5f;
		[SerializeField] private Ease _punchEase;

		private Tween _currentAnim;
		
		public void TryStopCurrentAnim()
		{
			_currentAnim?.Kill();
		}
		
		public void PlayIdleAnim()
		{
			_currentAnim = transform.DOLocalMoveY(transform.localPosition.y - _idleOffset, _idleDuration)
				.SetEase(_idleEase)
				.SetLoops(-1, LoopType.Yoyo);
		}

		public void PlayPunchAnim(Action onPunchAction, Action onCompleteAction = null)
		{
			var isFirstStep = true;

			var targetPosition = transform.position + (transform.forward * _punchOffset);

			_currentAnim = transform.DOMove(targetPosition, _punchDuration)
				.SetEase(_punchEase)
				.SetLoops(2, LoopType.Yoyo)
				.OnStepComplete(() =>
				{
					if (isFirstStep)
					{
						onPunchAction?.Invoke();
						isFirstStep = false;
					}
				})
				.OnComplete(() => onCompleteAction?.Invoke());
		}
	}
}