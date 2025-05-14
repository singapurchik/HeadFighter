using UnityEngine;
using VInspector;
using Zenject;

namespace HeadFighter.Player
{
	public class PlayerHandInstaller : MonoInstaller
	{
		[SerializeField] private PlayerHandAnimator _animator;
		[SerializeField] private PlayerHand _hand;

		public override void InstallBindings()
		{
			Container.BindInstance(_animator).WhenInjectedIntoInstance(_hand);
		}

#if UNITY_EDITOR
		[Button]
		private void FindDependencies()
		{
			_animator = GetComponentInChildren<PlayerHandAnimator>(true);
			_hand = GetComponentInChildren<PlayerHand>(true);
		}
#endif
	}
}