using UnityEngine;
using System;

namespace HeadFighter.Player
{
	public class PlayerInput : MonoBehaviour
	{
		[SerializeField] private KeyCode _rightHandKey = KeyCode.E;
		[SerializeField] private KeyCode _leftHandKey = KeyCode.Q;
		
		public event Action OnRightHandKeyClicked;
		public event Action OnLeftHandKeyClicked;
		
		private void Update()
		{
			if (Input.GetKeyDown(_leftHandKey))
				OnLeftHandKeyClicked?.Invoke();
			else if (Input.GetKeyDown(_rightHandKey))
				OnRightHandKeyClicked?.Invoke();
		}
	}
}