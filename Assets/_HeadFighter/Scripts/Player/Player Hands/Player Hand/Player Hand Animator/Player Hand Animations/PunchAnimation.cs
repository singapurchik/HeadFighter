using DG.Tweening;
using UnityEngine;
using System;

namespace HeadFighter.Animations.Player
{
	[Serializable]
	public class PunchAnimation : TweenAnimation
	{
		[SerializeField] private float _punchOffset = -1.1f;
		[SerializeField] private float _punchDuration = 0.1f;
		[SerializeField] private Ease _punchEase;

		private Vector3 _defaultLocalPosition;
		private Tween _currentTween;
		
		private Action _currentOnCompleteAction;
		private Action _currentOnPunchAction;

		public override void Initialize(Transform transform)
		{
			base.Initialize(transform);
			_defaultLocalPosition = transform.localPosition;
		}

		public void Play(Action onPunchAction = null, Action onCompleteAction = null)
		{
			_currentOnPunchAction = onPunchAction;
			_currentOnCompleteAction = onCompleteAction;

			Stop();
			CreateTween();
		}

		public override void Stop()
		{
			_currentTween?.Kill();
			_currentTween = null;
			if (Transform != null)
				Transform.localPosition = _defaultLocalPosition;
		}

		protected override void CreateTween()
		{
			var isFirstStep = true;

			var targetPosition = Transform.position + Transform.forward * _punchOffset;

			_currentTween = Transform.DOMove(targetPosition, _punchDuration)
				.SetEase(_punchEase)
				.SetLoops(2, LoopType.Yoyo)
				.OnStepComplete(() =>
				{
					if (isFirstStep)
					{
						isFirstStep = false;
						_currentOnPunchAction?.Invoke();
					}
				})
				.OnComplete(() =>
				{
					_currentOnCompleteAction?.Invoke();
					_currentOnPunchAction = null;
					_currentOnCompleteAction = null;
				});
		}
	}
}