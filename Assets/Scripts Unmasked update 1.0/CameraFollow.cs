using UnityEngine;
using System.Collections;


public class CameraFollow : MonoBehaviour
{
    //Varibles 
    public Transform TargetObject;
    public float followDistance = 5f;
    public float followHeight = 2f;
    public bool smoothedFollow = false;        
    public float smoothSpeed = 5f;
    public bool useFixedLookDirection = false;      
    public Vector3 fixedLookDirection = Vector3.one;


    
    void Update()
    {
      
        //Postions the camera to face towards the target 
        Vector3 lookToward = TargetObject.position - transform.position;
        if (useFixedLookDirection)
            lookToward = fixedLookDirection;


        //Changes the transform to the same as the target's and then follows the target transform
        Vector3 newPos;
        newPos = TargetObject.position - lookToward.normalized * followDistance;
        newPos.y = TargetObject.position.y + followHeight;

        if (!smoothedFollow)
        {
            transform.position = newPos;    
        }
        else  
        {
            transform.position += (newPos - transform.position) * Time.deltaTime * smoothSpeed;
        }
    }
}