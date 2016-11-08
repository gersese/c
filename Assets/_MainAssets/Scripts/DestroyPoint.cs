using UnityEngine;
using System.Collections;

public class DestroyPoint : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.tag == "Obstacle")
			Destroy(c.gameObject);
	}
}
