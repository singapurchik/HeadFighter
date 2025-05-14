using Cinemachine;
using UnityEngine;
using Zenject;

namespace HeadFighter.Cameras
{
	public class GameCameraRotator : MonoBehaviour
	{
		[SerializeField] private float _rotateSideAngle = 5f;
		[SerializeField] private float _rotateSideSpeed = 10f;

		[Inject (Id = CameraType.Game)] private CinemachineVirtualCamera _camera;
		
		private bool _isRotateSideRequested;
		private float _requestedSideAngle;

		private Quaternion _defaultRotation;
		private Quaternion _targetRotation;

		private void Awake()
		{
			_defaultRotation = _camera.transform.localRotation;
			_targetRotation = _defaultRotation;
		}

		public void RotateRight() => RequestRotateSide(_rotateSideAngle);
		
		
		public void RotateLeft() => RequestRotateSide(-_rotateSideAngle);

		private void RequestRotateSide(float angle)
		{
			_requestedSideAngle = angle;
			_isRotateSideRequested = true;
		}

		private void RotateSide()
			=> 	_camera.transform.localRotation = Quaternion.RotateTowards(
					_camera.transform.localRotation, _targetRotation, _rotateSideSpeed * Time.deltaTime);

		private void LateUpdate()
		{
			if (_isRotateSideRequested)
			{
				_targetRotation = _defaultRotation * Quaternion.Euler(0f, 0f, _requestedSideAngle);
				_isRotateSideRequested = false;
			}
			else
			{
				_targetRotation = _defaultRotation;
			}

			if (Quaternion.Angle(_camera.transform.localRotation, _targetRotation) > 0.01f)
				RotateSide();
		}
	}
}