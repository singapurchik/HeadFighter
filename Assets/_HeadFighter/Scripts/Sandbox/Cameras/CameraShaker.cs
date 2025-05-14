using Cinemachine;
using UnityEngine;

namespace HeadFighter.Cameras
{
	public class CameraShaker : MonoBehaviour, ICameraShaker
	{
		public void Play(CinemachineImpulseSource impulse) => impulse.GenerateImpulse();
	}
}