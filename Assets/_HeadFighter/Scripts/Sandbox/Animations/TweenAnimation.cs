using UnityEngine;

namespace HeadFighter.Animations
{
	public abstract class TweenAnimation
	{
		protected Transform Transform;

		public virtual void Initialize(Transform transform)
		{
			Transform = transform;
		}

		public virtual TweenAnimation Play()
		{
			Stop();
			CreateTween();
			return this;
		}

		public abstract void Stop();
		
		protected abstract void CreateTween();
	}
}