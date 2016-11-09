using UnityEngine;
using System.Collections;

public class GeraldMovement : MonoBehaviour 
{
	const float JUMP_FORCE = 8.8f;
	const float MOVEMENT_SPEED = 5.9f;

	Vector2 _direction;
	bool _isCaught = false;
	
	void Start () 
	{
		_direction = new Vector2(
			GameObject.FindGameObjectWithTag("Clariz")
				.GetComponent<Transform>().localPosition.x,
			transform.localPosition.y);
	}
	

	void Update () 
	{
		if(!_isCaught)
		{
			transform.localPosition = Vector2.MoveTowards(
				transform.localPosition, _direction, MOVEMENT_SPEED * Time.deltaTime);
		}
	}

	public void StopMovement()
	{
		_isCaught = true;
	}

}
