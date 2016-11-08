using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour 
{
	const string BACKGROUND1_TAG = "bg_1";
	const string BACKGROUND2_TAG = "bg_2";
	
	GameObject _bg1 = null;
	GameObject _bg2 = null;
	Vector3 _bg2Pos;
	float _currentXSpeed = -0.15f;
	bool _scrollable = true;

	void Start () 
	{
		_bg1 = GameObject.FindGameObjectWithTag(BACKGROUND1_TAG);
		_bg2 = GameObject.FindGameObjectWithTag(BACKGROUND2_TAG);
		_bg2Pos = _bg2.transform.position;
	}
	
	void Update () 
	{
		if(_scrollable)
		{
			_bg1.transform.Translate(_currentXSpeed, 0, 0);
			_bg2.transform.Translate(_currentXSpeed, 0, 0);
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if(c.tag == BACKGROUND1_TAG)
			_bg1.transform.position = _bg2Pos;
		else if(c.tag == BACKGROUND2_TAG)
			_bg2.transform.position = _bg2Pos;
	}

	public void StopScrolling()
	{
		_scrollable = false;
	}
}
