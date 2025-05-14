using HeadFighter.Cameras;
using System.Collections;
using HeadFighter.Player;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace HeadFighter
{
	public class Sandbox : MonoBehaviour
	{
		[SerializeField] private CinemachineImpulseSource _gameOverImpulse;
		
		[SerializeField] private float _slowdownTimeScale = 0.25f;
		[SerializeField] private float _slowdownDuration = 1f;
		[SerializeField] private float _slowdownDelay = 0.25f;
		[SerializeField] private float _returnToNormalDuration = 1f;

		[Inject] private ICameraShaker _cameraShaker;
		[Inject] private IPlayerInputEnabler _input;
		[Inject] private IReadOnlyHeath _heath;

		private const float DEFAULT_TIME_SCALE = 1f;

		private void OnEnable()
		{
			_heath.OnDead += GameOver;
		}

		private void OnDisable()
		{
			_heath.OnDead -= GameOver;
		}

		private void GameOver()
		{
			_input.Disable();
			StartCoroutine(GameOverRoutine());
		}

		private IEnumerator GameOverRoutine()
		{
			_cameraShaker.Play(_gameOverImpulse);
			yield return new WaitForSeconds(_slowdownDelay);
			
			Time.timeScale = _slowdownTimeScale;
			yield return new WaitForSecondsRealtime(_slowdownDuration);

			var elapsed = 0f;

			while (elapsed < _returnToNormalDuration)
			{
				elapsed += Time.unscaledDeltaTime;
				Time.timeScale = Mathf.Lerp(_slowdownTimeScale, 1f, elapsed / _returnToNormalDuration);
				yield return null;
			}

			Time.timeScale = DEFAULT_TIME_SCALE;
		}
	}
}