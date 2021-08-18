﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainPlanet;
    public GameObject revolvingPlanet;
    public Vector3 offset = Vector3.zero;
    public float angularVelocity = 60;
    public float angle = 0; // In degrees
    public float semiMajorAxis = 5;
    public float eccentricity = 0;
    public float semiMinorAxis;
    public bool invertAxes = false;
    
    void Start()
    {
        if (revolvingPlanet == null)
            revolvingPlanet = this.gameObject;
        semiMinorAxis = semiMajorAxis * Mathf.Sqrt(1 - eccentricity * eccentricity);

        
        
        
    }

    // Update is called once per frame
    void Update()
    {

        revolvingPlanet.transform.position = finalPosition(angle);
        angle += angularVelocity * Time.deltaTime;
        

        
        
    }

    public Vector3 finalPosition(float rotationAngle) {
        Vector3 center = mainPlanet.transform.position;

        Vector3 originPosition;
        if (invertAxes)
        {
            originPosition = new Vector3(semiMajorAxis * Mathf.Cos(Mathf.Deg2Rad * rotationAngle), 0, semiMinorAxis * Mathf.Sin(Mathf.Deg2Rad * rotationAngle));
        }
        else
        {
            originPosition = new Vector3(semiMinorAxis * Mathf.Cos(Mathf.Deg2Rad * rotationAngle), 0, semiMajorAxis * Mathf.Sin(Mathf.Deg2Rad * rotationAngle));
        }

        Vector3 finalOffset = new Vector3(center.x + offset.x, center.y + offset.y, center.z + offset.z);
        Vector3 finalPosition = new Vector3(finalOffset.x + originPosition.x, finalOffset.y + originPosition.y, finalOffset.z + originPosition.z);
        return finalPosition;
    }
}
