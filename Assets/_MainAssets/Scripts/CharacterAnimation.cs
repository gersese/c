using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {

	Animator _animator;
	public void StopAnimation()
	{
		_animator = GetComponentInChildren<Animator>();
		_animator.SetBool("Stopped", true);
	}
}
