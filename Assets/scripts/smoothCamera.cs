using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamera : MonoBehaviour
{

    public GameObject targetObject;
    public float cameraFllwSpd = 10.0f;
    public float cameraRotSpd = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Vector3.Lerp(this.transform.position, targetObject.transform.position, cameraFllwSpd * Time.deltaTime);

        Quaternion lookDirection;
        Quaternion smoothRotation;

        lookDirection = Quaternion.LookRotation(targetObject.transform.forward);
        smoothRotation = Quaternion.Slerp(this.transform.rotation, lookDirection, cameraRotSpd * Time.deltaTime);

        this.transform.position = cameraPos;
        this.transform.rotation = smoothRotation;
    }
}
