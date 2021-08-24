using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float tiltAngle = 0f; // In degrees
    public float referenceOrbitalIntersectionOffset = 0f; // In degrees
    public Vector3 center;
    private OrbitManager orbitManager;

    public TiltManager(float tA, float rOIO, Vector3 c, OrbitManager oM) 
    {
        tiltAngle = tA;
        referenceOrbitalIntersectionOffset = rOIO;
        center = c;
        orbitManager = oM;
    }

    void Start()
    {
        orbitManager = this.gameObject.GetComponent<OrbitManager>();
        center = this.transform.position;
    }

    // Update is called once per frame
    public void updatePosition()
    {
            this.transform.Translate(new Vector3(0, orbitManager.semiMajorAxis * Mathf.Sin(Mathf.Deg2Rad * tiltAngle) * Mathf.Sin(Mathf.Deg2Rad * orbitManager.angle)));
    }
}
