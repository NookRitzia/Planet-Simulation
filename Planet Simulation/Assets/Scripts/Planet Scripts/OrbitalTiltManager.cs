using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalTiltManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float tiltAngle = 0f; // In degrees
    public float referenceOrbitalIntersectionOffset = 0f; // In degrees
    private Vector3 center;
    private OrbitManager orbitManager;
    void Start()
    {
        orbitManager = this.gameObject.GetComponent<OrbitManager>();
        center = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, orbitManager.semiMajorAxis * Mathf.Sin(Mathf.Deg2Rad * tiltAngle) * Mathf.Sin(Mathf.Deg2Rad * orbitManager.angle)));
         //this.transform.position = this.transform.position + new Vector3(0, orbitManager.semiMajorAxis * Mathf.Sin(Mathf.Deg2Rad * tiltAngle) * Mathf.Sin(Mathf.Deg2Rad * orbitManager.angle));
        //this.transform.position = this.transform.position + new Vector3(100, 100, 100);
    }
}
