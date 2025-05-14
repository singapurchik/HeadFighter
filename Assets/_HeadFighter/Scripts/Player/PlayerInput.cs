using UnityEngine;
using System;

namespace HeadFighter.Player
{
	public class PlayerInput : MonoBehaviour
	{
		public event Action OnRightKeyClick;
		public event Action OnLeftKeyClick;
		
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Q))
				OnLeftKeyClick?.Invoke();
			else if (Input.GetKeyDown(KeyCode.E))
				OnRightKeyClick?.Invoke();
		}
	}
}