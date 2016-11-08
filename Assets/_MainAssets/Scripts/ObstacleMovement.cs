using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {

	float _currentSpeed = 7;
	bool _isMovable = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(_isMovable)
			transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
	}

	public void Stop()
	{
		_isMovable = false;
	}
}
