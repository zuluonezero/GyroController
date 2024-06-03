using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject ship;
    public GameObject meteor;
    public GameObject barrier;
    public GameObject wall;
    public float waitTime = 2f;

    public float randTime = 0f;

    public float timeNow;
    public float distanceAhead = -100f;

    public bool wallOn;

    public Vector4 thisColor;
    public Color randomColor;
    public GameObject groundCube;
    public GameObject groundCylinder;
    public GameObject groundRect;
    public GameObject groundRectLarge;
    public float groundTimeNow;
    public float groundWaitTime = 6.1f;
    public float groundRandTime = 0f;
    public float groundSpawnTime = 0.2f;

    public bool bars;
    public GameObject bar;
    public GameObject barU;
    public GameObject barT;
    public GameObject barL;
    public GameObject barLu;
    public GameObject barR;
    public GameObject barRu;
    public GameObject barDouble;
    public float barTimeNow;
    public float barWaitTime = 6.1f;
    public float barRandTime = 0f;
    public float barSpawnTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        timeNow = Time.time + waitTime;
        groundTimeNow = Time.time + groundWaitTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeNow + randTime)
        {
            if (!wallOn)
            {
                if (randTime < 1)
                {
                    GameObject _meteor = Instantiate(meteor);
                    _meteor.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, ship.transform.position.z - distanceAhead);

                }

                if (randTime > 1)
                {
                    var randSpawnY = Random.Range(-1f, 1f);
                    //var randRot1 = Quaternion.Euler(0f, 90f, 90f);
                    GameObject _barrier = Instantiate(barrier);
                    _barrier.transform.position = new Vector3(ship.transform.position.x, randSpawnY, ship.transform.position.z - distanceAhead);
                    //_barrier.transform.rotation = randRot1;

                }

            } else
            {
                GameObject _wall = Instantiate(wall);
                _wall.transform.position = new Vector3(0f, 0f, ship.transform.position.z - distanceAhead);
            }


            randTime = Random.Range(0f, 2f);
            timeNow = Time.time + waitTime;
        }



        if (Time.time > groundTimeNow + groundSpawnTime)
        {
            thisColor = new Vector4(Random.value, Random.value, Random.value, 1.0f);
            if (groundRandTime < 0.5)
            {
                var randSpawnX = Random.Range(-3f, 3f);
                GameObject _groundItem = Instantiate(groundCube);
                _groundItem.transform.position = new Vector3(randSpawnX, -4.5f, ship.transform.position.z - distanceAhead);
                //_groundItem.GetComponent<Renderer>().material.SetColor("_Color", thisColor);
            }

            if (groundRandTime > 0.5 && groundRandTime < 1)
            {
                var randSpawnX = Random.Range(-3f, 3f);
                GameObject _groundItem = Instantiate(groundCylinder);
                _groundItem.transform.position = new Vector3(randSpawnX, -4.5f, ship.transform.position.z - distanceAhead);
                //_groundItem.GetComponent<Renderer>().material.SetColor("_Color", thisColor);
            }

            if (groundRandTime > 1 && groundRandTime < 1.5)
            {
                var randSpawnX = Random.Range(-3f, 3f);
                GameObject _groundItem = Instantiate(groundRect);
                _groundItem.transform.position = new Vector3(randSpawnX, -4.5f, ship.transform.position.z - distanceAhead);
                ///_groundItem.GetComponent<Renderer>().material.SetColor("_Color", thisColor);
            }

            if (groundRandTime > 1.5 && groundRandTime < 2)
            {
                var randSpawnX = Random.Range(-3f, 3f);
                GameObject _groundItem = Instantiate(groundRectLarge);
                _groundItem.transform.position = new Vector3(randSpawnX, -4.5f, ship.transform.position.z - distanceAhead);
                //_groundItem.GetComponent<Renderer>().material.SetColor("_Color", thisColor);
            }


            groundRandTime = Random.Range(0f, 2f);
            groundTimeNow = Time.time + groundWaitTime;
        }


        if (bars)
        {
            if (Time.time > barTimeNow + barSpawnTime)
            {
                var rndBar = Random.Range(0f, 8f);
                if (rndBar < 1)
                {
                    //var randSpawnX = Random.Range(-3f, 3f);
                    GameObject _barItem = Instantiate(bar);
                    _barItem.transform.position = new Vector3(0f, 2f, ship.transform.position.z - distanceAhead);
                }

                if (rndBar > 1 && rndBar < 2)
                {
                    //var randSpawnX = Random.Range(-3f, 3f);
                    GameObject _barItem = Instantiate(barU);
                    _barItem.transform.position = new Vector3(0f, 2f, ship.transform.position.z - distanceAhead);
                }

                if (rndBar > 2 && rndBar < 3)
                {
                    //var randSpawnX = Random.Range(-3f, 3f);
                    GameObject _barItem = Instantiate(barT);
                    _barItem.transform.position = new Vector3(0f, 2f, ship.transform.position.z - distanceAhead);
                }

                if (rndBar > 3 && rndBar < 4)
                {
                    //var randSpawnX = Random.Range(-3f, 3f);
                    GameObject _barItem = Instantiate(barL);
                    _barItem.transform.position = new Vector3(0f, 2f, ship.transform.position.z - distanceAhead);
                }

                if (rndBar > 4 && rndBar < 5)
                {
                    //var randSpawnX = Random.Range(-3f, 3f);
                    GameObject _barItem = Instantiate(barLu);
                    _barItem.transform.position = new Vector3(0f, 2f, ship.transform.position.z - distanceAhead);
                }

                if (rndBar > 5 && rndBar < 6)
                {
                    //var randSpawnX = Random.Range(-3f, 3f);
                    GameObject _barItem = Instantiate(barR);
                    _barItem.transform.position = new Vector3(0f, 2f, ship.transform.position.z - distanceAhead);
                }

                if (rndBar > 6 && rndBar < 7)
                {
                    //var randSpawnX = Random.Range(-3f, 3f);
                    GameObject _barItem = Instantiate(barRu);
                    _barItem.transform.position = new Vector3(0f, 2f, ship.transform.position.z - distanceAhead);
                }


                if (rndBar > 7 && rndBar < 8)
                {
                    //var randSpawnX = Random.Range(-3f, 3f);
                    GameObject _barItem = Instantiate(barDouble);
                    _barItem.transform.position = new Vector3(0f, 2f, ship.transform.position.z - distanceAhead);
                }
                
                barRandTime = Random.Range(0f, 2f);
                barTimeNow = Time.time + barWaitTime;
            }
        }
    } 
}
