using UnityEngine;
using System.Collections;

public class ClarizHealth : MonoBehaviour 
{
	const int MAX_HITS = 3;

	int _hitsLeft = 0;

	void Start () 
	{
		_hitsLeft = MAX_HITS;
	}
	
	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.tag == "Obstacle")
		{
			GetComponent<AudioSource>().Play();
			--_hitsLeft;
			c.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
		}
	}

	public int GetRemainingHits()
	{
		return _hitsLeft;
	}
}
