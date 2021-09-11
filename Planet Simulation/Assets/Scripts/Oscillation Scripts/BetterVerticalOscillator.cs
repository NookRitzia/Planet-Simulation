using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterVerticalOscillator : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 center;
    public float amplitude;
    public GameObject movingBody;
    public float oscillationOffset = 0;
    public float speed = 1f;
    public Vector3 oscillationDirection = Vector3.up;

    

    void Start()
    {
        movingBody = this.gameObject;
        if (center == null)
            center = movingBody.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        movingBody.transform.position = center + oscillationDirection * amplitude * Mathf.Sin( Mathf.Deg2Rad * (speed * Time.time % 360 + oscillationOffset));
    }
}
