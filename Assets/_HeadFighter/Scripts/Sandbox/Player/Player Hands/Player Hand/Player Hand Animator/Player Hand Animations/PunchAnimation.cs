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

		private bool _isFirstAnimStep = true;
		
		private Action _onPunchCompleteAction;
		private Action _onPunchAction;

		public override void Initialize(Transform transform)
		{
			base.Initialize(transform);
			_defaultLocalPosition = transform.localPosition;
		}

		public void Play(Action onPunchAction, Action onCompleteAction)
		{
			_onPunchCompleteAction = onCompleteAction;
			_onPunchAction = onPunchAction;

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
			_isFirstAnimStep = true;

			var targetPosition = Transform.position + Transform.forward * _punchOffset;

			_currentTween = Transform.DOMove(targetPosition, _punchDuration)
				.SetEase(_punchEase)
				.SetLoops(2, LoopType.Yoyo)
				.OnStepComplete(OnStepComplete)
				.OnComplete(OnAnimComplete);
		}

		private void OnStepComplete()
		{
			if (_isFirstAnimStep)
			{
				_isFirstAnimStep = false;
				_onPunchAction?.Invoke();
			}
		}

		private void OnAnimComplete()
		{
			_onPunchCompleteAction?.Invoke();
			_onPunchAction = null;
			_onPunchCompleteAction = null;
		}
	}
}