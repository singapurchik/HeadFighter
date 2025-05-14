using UnityEngine;

namespace HeadFighter.Heads
{
	public class HeadVisualEffects : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _rightHitEffect;
		[SerializeField] private ParticleSystem _leftHitEffect;
		
		public void PlayRightHitEffect() => _rightHitEffect.Play();
		
		public void PlayLeftHitEffect() => _leftHitEffect.Play();
	}
}