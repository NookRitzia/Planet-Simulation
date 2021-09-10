using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalOscillationManager : MonoBehaviour
{
    private GameObject movingBody;
    public Vector3 center;
    public Vector3 initial;
    public float amplitude = 1f;
    public float accelerationCoeffecient = 1f;
    public float velocity = 0;
    public float acceleration = 0;
    private float displacement;
    private float distance;
    void Start()
    {
        movingBody = this.gameObject;
        movingBody.transform.Translate(new Vector3(0, amplitude));
        displacement = initial.x - center.y;
        distance = Mathf.Abs(displacement);
        velocity = Mathf.Sqrt(2 * accelerationCoeffecient*(amplitude - distance));
        if (displacement < 0)
            velocity *= -1;
        movingBody.transform.position = initial;
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = -(movingBody.transform.position.y - center.y) * accelerationCoeffecient;
        velocity += acceleration * Time.deltaTime;
        gameObject.transform.Translate(new Vector3(0, velocity * Time.deltaTime));
        //gameObject.transform.Translate(new Vector3(.2f,0,0));
    }
}
