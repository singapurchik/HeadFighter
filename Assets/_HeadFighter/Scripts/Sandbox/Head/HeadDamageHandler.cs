using HeadFighter.Animations.Heads;
using System.Collections.Generic;
using HeadFighter.Player;
using UnityEngine;
using Zenject;
using System;

namespace HeadFighter.Heads
{
	public class HeadDamageHandler : MonoBehaviour, IDamageableHead
	{
		[Serializable]
		private struct DamageStepData
		{
			public Mesh Mesh;
			public float PercentageToSelect;
		}
		
		[SerializeField] private List<DamageStepData> _damageSteps;
		
		[Inject] private HeadVisualEffects _visualEffects;
		[Inject] private HeadAnimator _animator;
		[Inject] private MeshFilter _meshFilter;
		[Inject] private Health _health;

		private int _nextStepIndex;

		public void TryTakeDamage(HandType handType, float damage)
		{
			switch (handType)
			{
				case HandType.Left:
					_animator.PlayTakeDamageRightSideAnim();
					_visualEffects.PlayRightHitEffect();
					break;
				case HandType.Right:
				default:
					_animator.PlayTakeDamageLeftSideAnim();
					_visualEffects.PlayLeftHitEffect();
					break;
			}
			
			_health.TryTakeDamage(damage);

			var healthInPercentage = Mathf.InverseLerp(0, _health.StartHealth, _health.CurrentHealth) * 100;
			
			if (_nextStepIndex < _damageSteps.Count
			    && healthInPercentage < _damageSteps[_nextStepIndex].PercentageToSelect)
					ChangeDamageStep();
		}

		private void ChangeDamageStep()
		{
			_meshFilter.mesh = _damageSteps[_nextStepIndex].Mesh;
			_nextStepIndex++;
		}
	}
}