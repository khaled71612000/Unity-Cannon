using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;
    
    public GameObject Cannonball;
    public Transform ShotPoint;

    private float minimumx = -17f;
    private float maximumx = 17f;
    private float minimumy = -50f;
    private float maximumy= 50f; 
    private float minimumz = -15f;
    private float maximumz= 15f;

    private void Update()
    {

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            float x = Mathf.Clamp(pointToLook.x, minimumx, maximumx);
            float y = Mathf.Clamp(pointToLook.y, minimumy, maximumy);
            float z = Mathf.Clamp(pointToLook.z, minimumz, maximumz);
            transform.LookAt(new Vector3(x, y, z));
        }


        if (Input.GetMouseButtonDown(0))
        {
            GameObject CreatedCannonball =(GameObject) Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            Destroy(CreatedCannonball, 2f);
        }
    }


}
