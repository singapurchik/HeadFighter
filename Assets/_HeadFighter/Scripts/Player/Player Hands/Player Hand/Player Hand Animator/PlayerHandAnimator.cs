using HeadFighter.Animations.Player;
using HeadFighter.Animations;
using UnityEngine;
using System;

public class PlayerHandAnimator : MonoBehaviour
{
	[SerializeField] private PunchAnimation _punchAnim;
	[SerializeField] private IdleAnimation _idleAnim;

	private TweenAnimation _currentAnim;

	private void Awake()
	{
		_punchAnim.Initialize(transform);
		_idleAnim.Initialize(transform);
	}

	public void TryStopCurrentAnim() => _currentAnim?.Stop();

	public void PlayIdleAnim() => _idleAnim.Play();

	public void PlayPunchAnim(Action onPunchAction, Action onCompleteAction = null)
		=> _punchAnim.Play(onPunchAction, onCompleteAction);
}