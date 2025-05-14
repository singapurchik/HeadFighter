using HeadFighter.Cameras;
using UnityEngine;
using Zenject;
using System;

namespace HeadFighter.Player
{
	public class PlayerHands : MonoBehaviour
	{
		[Inject (Id = HandType.Right)] private PlayerHand _rightHand;
		[Inject (Id = HandType.Left)] private PlayerHand _leftHand;

		[Inject] private GameCameraRotator _cameraRotator;
		[Inject] private IHandDamageDealer _damageDealer;
		[Inject] private IVignetteEffect _vignetteEffect;
		
		private HandType _currentAttackHand;
		
		private bool _isAttackProcess;
		
		public event Action OnAttackComplete;

		private void OnEnable()
		{
			_rightHand.OnPunchAnimCompete += InvokeOnAttackComplete;
			_leftHand.OnPunchAnimCompete += InvokeOnAttackComplete;
			_rightHand.OnPunch += OnPunch;
			_leftHand.OnPunch += OnPunch;
		}

		private void OnDisable()
		{
			_rightHand.OnPunchAnimCompete -= InvokeOnAttackComplete;
			_leftHand.OnPunchAnimCompete -= InvokeOnAttackComplete;
			_rightHand.OnPunch -= OnPunch;
			_leftHand.OnPunch -= OnPunch;
		}

		public void Idle()
		{
			_rightHand.Idle();
			_leftHand.Idle();
		}

		public void RightAttack() => Attack(_rightHand, _leftHand);

		public void LeftAttack() => Attack(_leftHand, _rightHand);

		private void Attack(PlayerHand attackHand, PlayerHand waitingHand)
		{
			attackHand.Punch();
			waitingHand.Wait();
			_currentAttackHand = attackHand.Type;
			_isAttackProcess = true;
		}

		private void OnPunch()
		{
			_vignetteEffect.IncreaseAlpha();
			_damageDealer.DealDamage(_currentAttackHand);
		}
		
		private void InvokeOnAttackComplete()
		{
			OnAttackComplete?.Invoke();
			_isAttackProcess = false;
		}

		private void Update()
		{
			if (_isAttackProcess)
			{
				switch (_currentAttackHand)
				{
					case HandType.Left:
						_cameraRotator.RotateRight();
						break;
					case HandType.Right:
						_cameraRotator.RotateLeft();
						break;
				}
			}
		}
	}
}
