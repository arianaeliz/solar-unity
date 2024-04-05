using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster : MonoBehaviour
{

    public float boostSpeed = 50.0f;

    Renderer rend;
    public float strobeSpeed = 1.0f;

    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color pigment = rend.materials[0].color;
        pigment.a = Mathf.PingPong(Time.time * strobeSpeed, 1);
        rend.materials[0].color = pigment;

        Color pigment1 = rend.materials[1].color;
        pigment1.a = Mathf.PingPong(Time.time * strobeSpeed, 2);
        rend.materials[1].color = pigment1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("vehicle"))
        {
            move whee = other.gameObject.GetComponent<move>();
            StartCoroutine("BoostTime", whee);
        }
    }

    IEnumerator BoostTime(move whee)
    {
        whee.maxSpeed += boostSpeed;
        yield return new WaitForSeconds(4);
        whee.maxSpeed -= boostSpeed;
    }
}
