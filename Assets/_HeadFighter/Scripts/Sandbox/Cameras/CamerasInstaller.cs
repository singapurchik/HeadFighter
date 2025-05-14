using Cinemachine;
using UnityEngine;
using Zenject;

namespace HeadFighter.Cameras
{
	public class CamerasInstaller : MonoInstaller
	{
		[SerializeField] private CinemachineVirtualCamera _gameCamera;

		public override void InstallBindings()
		{
			Container.BindInstance(_gameCamera).WithId(CameraType.Game).AsSingle();
		}
	}
}