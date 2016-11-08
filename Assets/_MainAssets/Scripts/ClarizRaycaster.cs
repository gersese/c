using UnityEngine;
using System.Collections;

public class ClarizRaycaster : MonoBehaviour 
{
	const string GERALD_TAG = "Gerald";

	Vector2 _raycastDist;
	Vector2 _currentPosition;

	bool _hasReachedGerald = false;

	void Start()
	{
		_raycastDist = new Vector2(2, 0); 
		_currentPosition = new Vector2(transform.position.x + 1f, transform.position.y);
	}

	void Update () {

		Debug.DrawRay(transform.position, _raycastDist, Color.blue);
        
        RaycastHit2D hit = Physics2D.Raycast(_currentPosition, _raycastDist, 10);

        if (hit != null) 
        	if(hit.transform.tag == GERALD_TAG)
        		 _hasReachedGerald = true;
	}

	public bool HasReachedGerald()
	{
		return _hasReachedGerald;
	}
}
