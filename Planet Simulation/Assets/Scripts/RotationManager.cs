using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject planet;
    public float angularVelocity = 60; // In degrees/sec
    private int rot = 0;
    void Start()
    {
        if (planet == null)
            planet = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        planet.transform.Rotate(new Vector3(0, angularVelocity * Time.deltaTime));
    }
}
