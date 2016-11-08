using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour 
{
	const float MIN_SPAWN_RATE = 1.9f;
	const float MAX_SPAWN_RATE = 4.0f;

	[SerializeField]
	GameObject[] _obstacles;

	GameManager _gameManager;

    float _nextSpawn = 0.0f;

    bool _isSpawnable = false;

    void Start()
    {
    	StartCoroutine(BeginSpawn());
    }

	void Update () 
	{
		if (Time.time > _nextSpawn) 
		{
            Spawn();
            _nextSpawn = Time.time + Random.Range(MIN_SPAWN_RATE, MAX_SPAWN_RATE);
        }
	}

	void Spawn()
	{
		if(_isSpawnable)
		{
			GameObject obstacle = GetRandomObstacle();
			GameObject obj = Instantiate(obstacle, Vector3.zero, Quaternion.identity) as GameObject;
			obj.transform.parent = transform.parent;
			obj.transform.localPosition = obstacle.transform.localPosition;
			obj.transform.localScale = obstacle.transform.localScale;
			obj.transform.localRotation = obstacle.transform.localRotation;
		}

	}

	GameObject GetRandomObstacle()
	{
		return _obstacles[Random.Range(0, _obstacles.Length)];
	}

	public void StopSpawning()
	{
		_isSpawnable = false;
	}

	IEnumerator BeginSpawn()
	{
		yield return new WaitForSeconds(9);
		_isSpawnable = true;
	}
}
