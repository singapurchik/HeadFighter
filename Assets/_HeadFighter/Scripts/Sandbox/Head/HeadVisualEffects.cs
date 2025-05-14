using UnityEngine;

namespace HeadFighter.Heads
{
	public class HeadVisualEffects : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _rightHitEffect;
		[SerializeField] private ParticleSystem _leftHitEffect;
		[SerializeField] private ParticleSystem _destroyEffect;
		
		public void PlayRightHitEffect() => _rightHitEffect.Play();
		
		public void PlayLeftHitEffect() => _leftHitEffect.Play();
		
		public void PlayDestroyEffect() => _destroyEffect.Play();
		
	}
}