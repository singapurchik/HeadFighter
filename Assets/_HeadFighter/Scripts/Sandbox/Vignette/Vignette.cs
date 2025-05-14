using UnityEngine.UI;
using UnityEngine;

namespace HeadFighter
{
	[RequireComponent(typeof(Image))]
	public class Vignette : MonoBehaviour, IVignetteEffect
	{
		[SerializeField] private float _maxAlpha = 0.5f;
		[SerializeField] private float _increaseAlphaStep = 0.1f;
		[SerializeField] private float _fadeSpeed = 1f;

		private Image _image;

		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		public void IncreaseAlpha()
		{
			var color = _image.color;
			color.a = Mathf.Min(color.a + _increaseAlphaStep, _maxAlpha);
			_image.color = color;
		}

		private void Update()
		{
			var color = _image.color;

			if (color.a > 0f)
			{
				color.a = Mathf.Max(0f, color.a - _fadeSpeed * Time.deltaTime);
				_image.color = color;
			}
		}
	}	
}