using HeadFighter.Cameras;
using HeadFighter.Player;
using HeadFighter.Heads;
using UnityEngine;
using VInspector;
using Zenject;

namespace HeadFighter
{
	public class SandboxInstaller : MonoInstaller
	{
		[SerializeField] private PlayerDamageDealer _playerDamageDealer;
		[SerializeField] private HeadDamageHandler _headDamageHandler;
		[SerializeField] private GameCameraRotator _cameraRotator;
		[SerializeField] private CameraShaker _cameraShaker;
		[SerializeField] private PlayerInput _playerInput;
		[SerializeField] private Sandbox _sandbox;
		[SerializeField] private Health _health;

		public override void InstallBindings()
		{
			Container.Bind<IDamageableHead>()
				.FromInstance(_headDamageHandler)
				.WhenInjectedIntoInstance(_playerDamageDealer);

			Container.Bind<IPlayerInputEnabler>().FromInstance(_playerInput).WhenInjectedIntoInstance(_sandbox);
			Container.Bind<IReadOnlyDamageDealer>().FromInstance(_playerDamageDealer).AsSingle();
			Container.Bind<ICameraShaker>().FromInstance(_cameraShaker).AsSingle();
			Container.Bind<IReadOnlyHeath>().FromInstance(_health).AsSingle();
			Container.BindInstance(_cameraRotator).AsSingle();
		}

#if UNITY_EDITOR
		[Button]
		private void FindDependencies()
		{
			_playerDamageDealer = FindObjectOfType<PlayerDamageDealer>(true);
			_headDamageHandler = FindObjectOfType<HeadDamageHandler>(true);
			_cameraRotator = FindObjectOfType<GameCameraRotator>(true);
			_cameraShaker = FindObjectOfType<CameraShaker>(true);
			_playerInput = FindObjectOfType<PlayerInput>(true);
			_sandbox = FindObjectOfType<Sandbox>(true);
			_health = FindObjectOfType<Health>(true);
		}
#endif
	}
}