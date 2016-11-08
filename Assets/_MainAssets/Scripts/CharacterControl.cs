using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	const float JUMP_FORCE = 8.8f;
	Rigidbody2D _rigidBody;
	Vector3 _initialPosition;
	bool _isJumping = false;
	bool _isControllable = true;

	void Start () 
	{
		_rigidBody = GetComponent<Rigidbody2D>();
		_initialPosition = transform.position;
	}
	
	void Update () 
	{
		if(CanJump())
		{
			UnfreezeYConstraint();
			Jump();
		}
	}

	void Jump()
	{
		_rigidBody.velocity = new Vector2(0, JUMP_FORCE);
		_isJumping = true;
	}

	void FreezeYConstraint()
	{
		_rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
	}

	void UnfreezeYConstraint()
	{
		_rigidBody.constraints = RigidbodyConstraints2D.None;
	}

	bool CanJump()
	{
		return Input.GetMouseButton(0) && !_isJumping && _isControllable;
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.tag == "Ground")
		{
			transform.position = _initialPosition;
			FreezeYConstraint();
			_isJumping = false;
		}
	}

	public void DisableControl()
	{
		_isControllable = false;
	}
}
