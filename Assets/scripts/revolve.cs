using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolve : MonoBehaviour
{

    public float revolveSpeed = 10.0f;
    public GameObject pivotObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, 1, 0), revolveSpeed * Time.deltaTime);
    }
}
