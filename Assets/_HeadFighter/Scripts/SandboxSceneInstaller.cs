using HeadFighter.Heads;
using HeadFighter.Player;
using UnityEngine;
using VInspector;
using Zenject;

namespace HeadFighter
{
	public class SandboxSceneInstaller : MonoInstaller
	{
		[SerializeField] private HeadDamageHandler _headDamageHandler;

		public override void InstallBindings()
		{
			Container.Bind<IDamageableHead>()
				.FromInstance(_headDamageHandler)
				.WhenInjectedInto<PlayerHandDamageDealer>();
		}

#if UNITY_EDITOR
		[Button]
		private void FindDependencies()
		{
			_headDamageHandler = FindObjectOfType<HeadDamageHandler>(true);
		}
#endif
	}
}