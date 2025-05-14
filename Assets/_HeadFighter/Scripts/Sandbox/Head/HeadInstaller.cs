using HeadFighter.Animations.Heads;
using UnityEngine;
using VInspector;
using Zenject;

namespace HeadFighter.Heads
{
	public class HeadInstaller : MonoInstaller
	{
		[SerializeField] private HeadDamageHandler _damageHandler;
		[SerializeField] private HeadVisualEffects _visualEffects;
		[SerializeField] private HeadAnimator _headAnimator;
		[SerializeField] private MeshRenderer _meshRenderer;
		[SerializeField] private MeshFilter _meshFilter;
		[SerializeField] private Health _health;
		[SerializeField] private Head _head;

		public override void InstallBindings()
		{
			Container.BindInstance(_meshFilter).WhenInjectedIntoInstance(_damageHandler);
			Container.BindInstance(_health).WhenInjectedIntoInstance(_damageHandler);
			Container.BindInstance(_meshRenderer).WhenInjectedIntoInstance(_head);
			Container.Bind<IReadOnlyHeath>().FromInstance(_health).AsSingle();
			Container.BindInstance(_visualEffects).AsSingle();
			Container.BindInstance(_headAnimator).AsSingle();
		}

#if UNITY_EDITOR
		[Button]
		private void FindDependencies()
		{
			_visualEffects = GetComponentInChildren<HeadVisualEffects>(true);
			_damageHandler = GetComponentInChildren<HeadDamageHandler>(true);
			_meshRenderer = GetComponentInChildren<MeshRenderer>(true);
			_headAnimator = GetComponentInChildren<HeadAnimator>(true);
			_meshFilter = GetComponentInChildren<MeshFilter>(true);
			_health = GetComponentInChildren<Health>(true);
			_head = GetComponentInChildren<Head>(true);
		}
#endif
	}
}