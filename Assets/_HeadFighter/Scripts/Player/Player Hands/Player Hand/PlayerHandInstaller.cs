using UnityEngine;
using VInspector;
using Zenject;

namespace HeadFighter.Player
{
	public class PlayerHandInstaller : MonoInstaller
	{
		[SerializeField] private PlayerHandDamageDealer _handDamageDealer;
		[SerializeField] private PlayerHandAnimator _animator;
		[SerializeField] private PlayerHand _hand;

		public override void InstallBindings()
		{
			Container.Bind<IHandDamageDealer>().FromInstance(_handDamageDealer).WhenInjectedIntoInstance(_hand);
			Container.BindInstance(_animator).WhenInjectedIntoInstance(_hand);
		}

#if UNITY_EDITOR
		[Button]
		private void FindDependencies()
		{
			_handDamageDealer = GetComponentInChildren<PlayerHandDamageDealer>(true);
			_animator = GetComponentInChildren<PlayerHandAnimator>(true);
			_hand = GetComponentInChildren<PlayerHand>(true);
		}
#endif
	}
}