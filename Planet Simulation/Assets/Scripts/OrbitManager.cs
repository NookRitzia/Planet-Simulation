using System.Collections;
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
    public LineRenderer lineRenderer;

    public bool drawOrbit = true;

    private bool stopDrawingOrbit = false;
    void Start()
    {
        if (revolvingPlanet == null)
            revolvingPlanet = this.gameObject;
            semiMinorAxis = semiMajorAxis * Mathf.Sqrt(1 - eccentricity * eccentricity);

        if (lineRenderer == null && drawOrbit)
        {
            this.gameObject.AddComponent(typeof(LineRenderer));
            lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = mainPlanet.transform.position;
        
        Vector3 originPosition;
        if (invertAxes)
        {
            originPosition = new Vector3(semiMajorAxis * Mathf.Cos(Mathf.Deg2Rad * angle), 0, semiMinorAxis * Mathf.Sin(Mathf.Deg2Rad * angle)); 
        }
        else 
        {
            originPosition = new Vector3(semiMinorAxis * Mathf.Cos(Mathf.Deg2Rad * angle), 0, semiMajorAxis * Mathf.Sin(Mathf.Deg2Rad * angle));
        }
        
        Vector3 finalOffset = new Vector3(center.x + offset.x, center.y + offset.y, center.z + offset.z);
        revolvingPlanet.transform.position = new Vector3(finalOffset.x + originPosition.x, finalOffset.y, finalOffset.z + originPosition.z);
        angle += angularVelocity * Time.deltaTime;
        angle %= 720;
        

        if (lineRenderer != null && !stopDrawingOrbit && drawOrbit)
        {
            lineRenderer.positionCount += 1;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, revolvingPlanet.transform.position);
            if (angle >= 405)
                stopDrawingOrbit = true;
        }
    }
}
