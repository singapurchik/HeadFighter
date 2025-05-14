using UnityEngine;
using Zenject;

namespace HeadFighter.Heads
{
	public class Head : MonoBehaviour
	{
		[Inject] private HeadVisualEffects _visualEffects;
		[Inject] private MeshRenderer _meshRenderer;
		[Inject] private IReadOnlyHeath _heath;

		private void OnEnable()
		{
			_heath.OnDead += OnDead;
		}

		private void OnDisable()
		{
			_heath.OnDead -= OnDead;
		}

		private void OnDead()
		{
			_meshRenderer.enabled = false;
			_visualEffects.PlayDestroyEffect();
		}
	}
}