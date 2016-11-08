using UnityEngine;
using System.Collections;

public class GiftWobbler : MonoBehaviour 
{

 	const float WOBBLE_ANGLE_DEGREES = 40;
 	const float WOBBLE_SPEED = 7.5f;
	bool isLeft = true;
	void Update () 
	{
		float zAngle = Mathf.Round(transform.localEulerAngles.z);

    	if(zAngle > WOBBLE_ANGLE_DEGREES)
    		zAngle -= 360;

        if(zAngle == -WOBBLE_ANGLE_DEGREES)
        	isLeft = true;
        else if(zAngle == WOBBLE_ANGLE_DEGREES)
        	isLeft = false;

        transform.rotation = isLeft 
        	? Quaternion.RotateTowards(
        		transform.rotation, 
        		Quaternion.Euler(0, 0, WOBBLE_ANGLE_DEGREES), 
        		WOBBLE_SPEED)
        	: Quaternion.RotateTowards(
        		transform.rotation, 
        		Quaternion.Euler(0, 0, -WOBBLE_ANGLE_DEGREES), 
        		WOBBLE_SPEED);
	}
}
