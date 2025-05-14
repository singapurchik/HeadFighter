using Cinemachine;

namespace HeadFighter.Cameras
{
	public interface ICameraShaker
	{
		public void Play(CinemachineImpulseSource impulse);
	}
}