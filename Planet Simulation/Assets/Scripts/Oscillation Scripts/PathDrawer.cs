using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer lineRenderer;
    public GameObject movingBody;
    void Start()
    {
        movingBody = this.gameObject;
        movingBody.AddComponent<LineRenderer>();
        lineRenderer = movingBody.GetComponent<LineRenderer>();
        lineRenderer.positionCount--;
    }

    // Update is called once per frame
    
    void Update()
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, movingBody.transform.position);
        
        
    }
}
