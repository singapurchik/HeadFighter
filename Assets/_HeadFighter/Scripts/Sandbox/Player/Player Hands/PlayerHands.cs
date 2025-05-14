using UnityEngine;
using Zenject;
using System;
using HeadFighter.Cameras;
using UnityEngine.XR;

namespace HeadFighter.Player
{
	public class PlayerHands : MonoBehaviour
	{
		[Inject (Id = HandType.Right)] private PlayerHand _rightHand;
		[Inject (Id = HandType.Left)] private PlayerHand _leftHand;

		[Inject] private GameCameraRotator _cameraRotator;
		
		private HandType _currentAttackHand;
		
		private bool _isAttackProcess;
		
		public event Action OnAttackComplete;

		private void OnEnable()
		{
			_rightHand.OnPunchCompete += InvokeOnAttackComplete;
			_leftHand.OnPunchCompete += InvokeOnAttackComplete;
		}

		private void OnDisable()
		{
			_rightHand.OnPunchCompete -= InvokeOnAttackComplete;
			_leftHand.OnPunchCompete -= InvokeOnAttackComplete;
		}

		public void Idle()
		{
			_rightHand.Idle();
			_leftHand.Idle();
		}

		public void RightAttack() => Attack(_rightHand, _leftHand);

		public void LeftAttack()=> Attack(_leftHand, _rightHand);

		private void Attack(PlayerHand attackHand, PlayerHand waitingHand)
		{
			attackHand.Punch();
			waitingHand.Wait();
			_currentAttackHand = attackHand.Type;
			_isAttackProcess = true;
		}
		
		private void InvokeOnAttackComplete()
		{
			_isAttackProcess = false;
			OnAttackComplete?.Invoke();
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
