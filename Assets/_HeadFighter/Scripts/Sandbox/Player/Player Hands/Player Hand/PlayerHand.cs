using UnityEngine;
using Zenject;
using System;

namespace HeadFighter.Player
{
	public class PlayerHand : MonoBehaviour
	{
		[field: SerializeField] public HandType Type { get; private set; }

		[Inject] private PlayerHandAnimator _animator;

		private Quaternion _defaultRotation;
		private Vector3 _defaultPosition;

		public event Action OnPunchAnimCompete;
		public event Action OnPunch;
		
		private void Awake()
		{
			_defaultPosition = transform.localPosition;
			_defaultRotation = transform.localRotation;
		}

		public void Idle()
		{
			ResetProperties();
			_animator.PlayIdleAnim();
		}

		public void Punch()
		{
			ResetProperties();
			_animator.PlayPunchAnim(OnPunch, OnPunchAnimCompete);
		}

		public void Wait()
		{
			ResetProperties();
		}

		private void ResetProperties()
		{
			_animator.TryStopCurrentAnim();
			transform.SetLocalPositionAndRotation(_defaultPosition, _defaultRotation);
		}
	}	
}
