using UnityEngine;
using VInspector;
using Zenject;

namespace HeadFighter.Player
{
	public class Player : MonoBehaviour
	{
		[Inject] private PlayerInput _input;
		[Inject] private PlayerHands _hands;

		private void OnEnable()
		{
			_input.OnRightKeyClick += OnRightKeyClick;
			_input.OnLeftKeyClick += OnLeftKeyClick;
			_hands.OnAttackComplete += Idle;
		}

		private void OnDisable()
		{
			_input.OnRightKeyClick -= OnRightKeyClick;
			_input.OnLeftKeyClick -= OnLeftKeyClick;
			_hands.OnAttackComplete -= Idle;
		}

		private void Start()
		{
			_hands.Idle();
		}
		
		[Button]
		private void Idle() => _hands.Idle();

		[Button]
		private void OnRightKeyClick() => _hands.RightAttack();
		
		[Button]
		private void OnLeftKeyClick() => _hands.LeftAttack();
	}
}