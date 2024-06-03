using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float speed = 20f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime);
        if (transform.position.z < -20)
            Destroy(gameObject);
    }
}
