using UnityEngine;
using Zenject;
using System;

namespace HeadFighter.Player
{
	public class PlayerHands : MonoBehaviour
	{
		[Inject (Id = HandType.Right)] private PlayerHand _rightHand;
		[Inject (Id = HandType.Left)] private PlayerHand _leftHand;

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

		public void LeftAttack()
		{
			_leftHand.Punch();
			_rightHand.Wait();
		}

		public void RightAttack()
		{
			_rightHand.Punch();
			_leftHand.Wait();
		}
		
		private void InvokeOnAttackComplete() => OnAttackComplete?.Invoke();
	}
}
