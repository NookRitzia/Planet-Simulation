using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainPlanet;
    public GameObject revolvingPlanet;
    public float angularVelocity = 60;
    public float angle = 0; // In degrees
    public float radius = 115;
    void Start()
    {
        if (revolvingPlanet == null)
            revolvingPlanet = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = mainPlanet.transform.position;
        revolvingPlanet.transform.position = new Vector3(center.x + radius * Mathf.Cos(Mathf.Deg2Rad * angle), center.y, center.z + radius * Mathf.Sin(Mathf.Deg2Rad * angle));
        angle += angularVelocity * Time.deltaTime;
    }
}
