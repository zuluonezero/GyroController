using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GyroController : MonoBehaviour
{
    Gyroscope gyro;
    //public Vector3 rotationRate = Vector3.zero;
    //public Vector3 unbiaseRotationRate = Vector3.zero;
    //public Vector3 userAccelleration = Vector3.zero;
    public Vector3 gravity = Vector3.zero;
    public double gravityX = 0;
    public double gravityZ = 0;

    public float speed = 20;
    public Vector3 targetPosition;
    //public Quaternion attitudeInSpace;
    public Vector3 attitude = Vector3.zero;
    //public float updateInterval;
    public bool _isTurboOn;
    public float _shakeMagnitude = 0.2f;
    private Vector4 myColor;
    public SkinnedMeshRenderer cubeRenderer;
    public ParticleSystem parti;

    // Start is called before the first frame update
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        cubeRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        myColor = cubeRenderer.material.color;
        parti = GetComponentInChildren<ParticleSystem>();   
    }

    // Update is called once per frame
    void Update()
    {
        //rotationRate = gyro.rotationRate;
        //unbiaseRotationRate = gyro.rotationRate;
        //updateInterval = gyro.updateInterval;
        //userAccelleration = gyro.userAcceleration;
        gravity = gyro.gravity;
        gravityX = System.Math.Round(gravity.x, 2);
        gravityZ = System.Math.Round(gravity.z, 2);
        //attitudeInSpace = gyro.attitude;
        //attitude = attitudeInSpace.eulerAngles;
        if (gyro.gravity.x > 0.50f)
            targetPosition.x = 3f; 

        if (gyro.gravity.x > 0.30f && gyro.gravity.x < 0.50f)
            targetPosition.x = 2f; 

        if (gyro.gravity.x > 0.10f && gyro.gravity.x < 0.30f)
            targetPosition.x = 1f; 

        if (gyro.gravity.x > -0.10f && gyro.gravity.x < 0.10f)
            targetPosition.x = 0f;    


        if (gyro.gravity.x > -0.30f && gyro.gravity.x < -0.10f)
            targetPosition.x = -1f; 

        if (gyro.gravity.x > -0.50f && gyro.gravity.x < -0.30f)
            targetPosition.x = -2f; 

        if (gyro.gravity.x < -0.50f)
            targetPosition.x = -3f;



        if (gyro.gravity.x < 0f)
            attitude = new Vector3(0, 0, -20f);


        if (gyro.gravity.x > 0f)
            attitude = new Vector3(0, 0, 20f);



        if (gyro.gravity.z < -0.80f)
            targetPosition.y = 1f;

        if (gyro.gravity.z < -0.70f && gyro.gravity.z > -0.80f)
        {
            if (gyro.gravity.x > -0.10f && gyro.gravity.x < 0.10f)
            {
                targetPosition.x = -1f;
            }
            else
            {
                targetPosition.y = 0f;
            }
                

        }
            

        if (gyro.gravity.z > -0.70f)
            targetPosition.y = -1f;

        if (_isTurboOn)
        {
            Time.timeScale = 3f;
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            gameObject.transform.localPosition = gameObject.transform.localPosition + (Random.insideUnitSphere * _shakeMagnitude);
            transform.eulerAngles = attitude;
            parti.Play();
        }
        else
        {
            Time.timeScale = 1f;
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            transform.eulerAngles = attitude;
            parti.Stop();
        }

    }

    public void TurboSwitch()
    {
        _isTurboOn = !_isTurboOn;
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("collision");
        StartCoroutine(OnColl());
        
    }

    IEnumerator OnColl()
    {

        cubeRenderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSecondsRealtime(1);
        cubeRenderer.material.SetColor("_Color", myColor);
    }

    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40;
        myStyle.normal.textColor = Color.green;
        GUI.Label(new Rect(100, 60, 500, 20), "Gravity X: " + gravityX, myStyle);
        GUI.Label(new Rect(100, 20, 500, 20), "Gravity Z: " + gravityZ, myStyle);
        GUI.Label(new Rect(100, 100, 500, 20), "Position: " + transform.position.x +  ", " + transform.position.y, myStyle);
    }
}
