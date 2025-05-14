using System;
using UnityEngine;
using Zenject;

namespace HeadFighter.Player
{
	public class PlayerHand : MonoBehaviour
	{
		[field: SerializeField] public HandType Type { get; private set; }

		[Inject] private PlayerHandAnimator _animator;

		private Quaternion _defaultRotation;
		private Vector3 _defaultPosition;

		public event Action OnPunchCompete;
		
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
			_animator.PlayPunchAnim(OnPunchCompete);
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
