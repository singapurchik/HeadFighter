using DG.Tweening;
using UnityEngine;
using System;

namespace HeadFighter.Animations.Player
{
	[Serializable]
	public class IdleAnimation : TweenAnimation
	{
		[SerializeField] private float _idleOffset = -0.1f;
		[SerializeField] private float _idleDuration = 0.25f;
		[SerializeField] private Ease _idleEase = Ease.InFlash;
		
		private Vector3 _defaultLocalPosition;
		
		private Tween _currentTween;
		
		public override void Initialize(Transform transform)
		{
			base.Initialize(transform);
			_defaultLocalPosition = transform.localPosition;
		}

		public override void Stop()
		{
			_currentTween?.Kill();
			Transform.localPosition = _defaultLocalPosition;
		}

		protected override void CreateTween()
		{
			_currentTween = Transform.DOLocalMoveY(Transform.localPosition.y - _idleOffset, _idleDuration)
				.SetEase(_idleEase)
				.SetLoops(-1, LoopType.Yoyo);
		}
	}
}