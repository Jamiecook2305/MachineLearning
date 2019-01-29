using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float turnSpeed = 4.0f;



    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 desiredPosition = Player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = smoothedPosition;


        transform.LookAt(Player);

    }
}
