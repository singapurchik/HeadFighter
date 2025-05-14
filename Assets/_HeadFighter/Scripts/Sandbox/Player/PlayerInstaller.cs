using UnityEngine;
using VInspector;
using Zenject;

namespace HeadFighter.Player
{
	public class PlayerInstaller : MonoInstaller
	{
		[SerializeField] private PlayerDamageDealer _damageDealer;
		[SerializeField] private PlayerInput _input;
		[SerializeField] private PlayerHands _hands;
		[SerializeField] private Player _player;
		
		public override void InstallBindings()
		{
			Container.Bind<IHandDamageDealer>().FromInstance(_damageDealer).AsSingle();
			Container.BindInstance(_input).WhenInjectedIntoInstance(_player);
			Container.BindInstance(_hands).WhenInjectedIntoInstance(_player);
		}

#if UNITY_EDITOR
		[Button]
		private void FindDependencies()
		{
			_damageDealer = GetComponentInChildren<PlayerDamageDealer>(true);
			_input = GetComponentInChildren<PlayerInput>(true);
			_hands = GetComponentInChildren<PlayerHands>(true);
			_player = GetComponentInChildren<Player>(true);
		}
#endif
	}
}