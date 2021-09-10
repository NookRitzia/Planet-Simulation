using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalOscillationManager : MonoBehaviour
{
    private GameObject movingBody;
    public Vector3 center;
    public Vector3 initial;
    public float delay = 0f;
    public float amplitude = 1f;
    public float accelerationCoeffecient = 1f;
    public float velocity = 0;
    public float acceleration = 0;
    private float displacement;
    private float distance;
    private float startTime;
    void Start()
    {
        movingBody = this.gameObject;
        displacement = initial.y - center.y;
        distance = Mathf.Abs(displacement);
        velocity = 0;
        movingBody.transform.Translate(new Vector3(0, amplitude));
        if (displacement < 0)
            velocity *= -1;
        //movingBody.transform.position = initial;
        
        startTime = Time.time;
        delay = movingBody.transform.position.x / 10f;
        startTime += 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > delay)
        {
            acceleration = -(movingBody.transform.position.y - center.y) * accelerationCoeffecient;
            velocity += acceleration * Time.deltaTime;
            gameObject.transform.Translate(new Vector3(0, velocity * Time.deltaTime));
        }
        gameObject.transform.Translate(new Vector3(0f,0,0));
    }
}
