using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {

	Animator _animator;

	void Start()
	{
		_animator = GetComponentInChildren<Animator>();
	}

	public void StopAnimation()
	{
		_animator.SetBool("Stopped", true);
	}

	public void Jump()
	{
		_animator.SetBool("Jumping", true);
		_animator.SetBool("Grounded", false);
	}

	public void Grounded()
	{
		_animator.SetBool("Jumping", false);
		_animator.SetBool("Grounded", true);
	}
}
