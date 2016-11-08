using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour {

	public void ChangeSprite(Transform parent, GameObject spritePrefab)
	{
		Transform head = parent.GetChild(0);
		Destroy(head.transform.GetChild(0).gameObject);

		GameObject newSprite = Instantiate(spritePrefab, Vector3.zero, Quaternion.identity)
			as GameObject;

		newSprite.transform.parent = head;
		newSprite.transform.localPosition = spritePrefab.transform.localPosition;
		newSprite.transform.localScale = spritePrefab.transform.localScale;
		newSprite.transform.localRotation = spritePrefab.transform.localRotation;

	}
}
