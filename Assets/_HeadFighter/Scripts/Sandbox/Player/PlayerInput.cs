using UnityEngine;
using System;

namespace HeadFighter.Player
{
	public class PlayerInput : MonoBehaviour, IPlayerInputEnabler
	{
		[SerializeField] private KeyCode _rightHandKey = KeyCode.E;
		[SerializeField] private KeyCode _leftHandKey = KeyCode.Q;

		private bool _isActive = true;
		
		public event Action OnRightHandKeyClicked;
		public event Action OnLeftHandKeyClicked;

		public void Disable() => _isActive = false;
		
		public void Enable() => _isActive = true;

		public void ReadInput()
		{
			if (Input.GetKeyDown(_leftHandKey))
				OnLeftHandKeyClicked?.Invoke();
			else if (Input.GetKeyDown(_rightHandKey))
				OnRightHandKeyClicked?.Invoke();
		}
		
		private void Update()
		{
			if (_isActive)
				ReadInput();
		}
	}
}