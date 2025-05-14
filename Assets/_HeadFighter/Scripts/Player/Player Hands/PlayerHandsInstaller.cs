using UnityEngine;
using VInspector;
using Zenject;

namespace HeadFighter.Player
{
	public class PlayerHandsInstaller : MonoInstaller
	{
		[SerializeField] private PlayerHand _rightHand;
		[SerializeField] private PlayerHand _leftHand;
		[SerializeField] private PlayerHands _hands;

		public override void InstallBindings()
		{
			Container.BindInstance(_rightHand).WithId(HandType.Right).WhenInjectedIntoInstance(_hands);
			Container.BindInstance(_leftHand).WithId(HandType.Left).WhenInjectedIntoInstance(_hands);
		}

#if UNITY_EDITOR
		[Button]
		private void FindDependencies()
		{
			_hands = GetComponentInChildren<PlayerHands>(true);
			
			foreach (Transform child in transform)
			{
				if (child.TryGetComponent(out PlayerHand hand))
				{
					switch (hand.Type)
					{
						case HandType.Left:
							_leftHand = hand;
							break;
						case HandType.Right:
							_rightHand = hand;
							break;
					}
				}
			}
		}
#endif
	}
}