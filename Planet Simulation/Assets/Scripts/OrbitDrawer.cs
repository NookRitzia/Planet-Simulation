﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDrawer : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer lineRenderer;

    public OrbitManager orbitManager;

    GameObject revolvingPlanet;

    public float anglesToDraw = 360;

    public bool drawOrbit = true;

    private bool stopDrawingOrbit = false;
    void Start()
    {
        revolvingPlanet = this.gameObject;    

        if (lineRenderer == null && drawOrbit)
        {
            this.gameObject.AddComponent(typeof(LineRenderer));
            lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        }
        
        orbitManager = revolvingPlanet.GetComponent<OrbitManager>();
        revolvingPlanet.transform.position = orbitManager.finalPosition(orbitManager.angle);
        lineRenderer.SetPosition(0, revolvingPlanet.transform.position);
        lineRenderer.SetPosition(1, revolvingPlanet.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (lineRenderer != null && !stopDrawingOrbit && drawOrbit)
        {
            if (orbitManager.angle >= anglesToDraw)
                stopDrawingOrbit = true;
            lineRenderer.positionCount += 1;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, revolvingPlanet.transform.position);
        }
    }
}
