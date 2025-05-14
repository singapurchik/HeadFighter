using Cinemachine;
using HeadFighter.Cameras;
using UnityEngine;
using Zenject;

namespace HeadFighter.Player
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private CinemachineImpulseSource _dealDamageImpulse;
		
		[Inject] private ICameraShaker _cameraShaker;
		[Inject] private PlayerInput _input;
		[Inject] private PlayerHands _hands;

		private void OnEnable()
		{
			_input.OnRightHandKeyClicked += OnRightHandKeyClicked;
			_input.OnLeftHandKeyClicked += OnLeftHandKeyClicked;
			_hands.OnAttackComplete += OnAttackComplete;
		}

		private void OnDisable()
		{
			_input.OnRightHandKeyClicked -= OnRightHandKeyClicked;
			_input.OnLeftHandKeyClicked -= OnLeftHandKeyClicked;
			_hands.OnAttackComplete -= OnAttackComplete;
		}

		private void Start()
		{
			_hands.Idle();
		}
		
		private void Idle() => _hands.Idle();

		private void OnRightHandKeyClicked() => Attack(HandType.Right);

		private void OnLeftHandKeyClicked() => Attack(HandType.Left);

		private void Attack(HandType handType)
		{
			_cameraShaker.Play(_dealDamageImpulse);

			switch (handType)
			{
				case HandType.Left:
					_hands.LeftAttack();
					break;
				case HandType.Right:
				default:
					_hands.RightAttack();
					break;
			}
		}
		
		private void OnAttackComplete()
		{
			Idle();
		}
	}
}