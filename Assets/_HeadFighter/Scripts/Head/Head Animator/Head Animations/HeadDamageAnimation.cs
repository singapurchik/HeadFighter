using HeadFighter.Animations;
using UnityEngine;
using DG.Tweening;
using System;

namespace HeadFighter.Heads.Animations
{
	[Serializable]
	public class HeadDamageAnimation : TweenAnimation
	{
		[Header("MOVE PROPERTIES")]
		[SerializeField] private Vector3 _endLocalPosition;
		[SerializeField] private float _moveDuration = 0.15f;
		[SerializeField] private Ease _moveEase;
		
		[Header("ROTATE PROPERTIES")]
		[SerializeField] private Vector3 _endLocalRotation;
		[SerializeField] private float _rotateDuration = 0.15f;
		[SerializeField] private Ease _rotateEase;

		[Header("PUNCH SCALE PROPERTIES")]
		[SerializeField] private Vector3 _punchScale;
		[SerializeField] private int _punchVibrato = 5;
		[SerializeField] private float _punchElasticity = 0.5f;
		[SerializeField] private float _punchScaleDuration;
		[SerializeField] private Ease _punchScaleEase;

		private Vector3 _startLocalPosition;
		private Vector3 _startLocalRotation;

		private Tween _punchScaleTween;
		private Tween _rotationTween;
		private Tween _moveTween;

		public override void Initialize(Transform transform)
		{
			base.Initialize(transform);
			_startLocalRotation = Transform.localEulerAngles;
			_startLocalPosition = Transform.localPosition;
		}

		protected override void CreateTween()
		{
			ResetTransforms();
			CreateRotationTween();
			CreateMoveTween();
			CreatePunchScaleTween();
		}

		private void ResetTransforms()
		{
			Transform.localEulerAngles = _startLocalRotation;
			Transform.localPosition = _startLocalPosition;
			Transform.localScale = Vector3.one;
		}

		private void CreateRotationTween()
		{
			_rotationTween = Transform.DOLocalRotate(_endLocalRotation, _rotateDuration)
				.SetEase(_rotateEase)
				.SetLoops(2, LoopType.Yoyo);
		}

		private void CreateMoveTween()
		{
			_moveTween = Transform.DOLocalMove(_endLocalPosition, _moveDuration)
				.SetEase(_moveEase)
				.SetLoops(2, LoopType.Yoyo);
		}

		private void CreatePunchScaleTween()
		{
			_punchScaleTween = Transform.DOPunchScale(_punchScale, _punchScaleDuration, _punchVibrato, _punchElasticity)
				.SetEase(_punchScaleEase);
		}

		public override void Stop()
		{
			_punchScaleTween?.Kill();
			_rotationTween?.Kill();
			_moveTween?.Kill();
		}
	}
}