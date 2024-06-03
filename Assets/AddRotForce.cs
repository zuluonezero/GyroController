using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRotForce : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Basically the same thing of rotating around the X axis just a different format
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);

    }

}
