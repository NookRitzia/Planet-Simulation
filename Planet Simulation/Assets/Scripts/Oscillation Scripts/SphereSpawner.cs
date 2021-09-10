using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject entityToSpawn;
    public int count;
    public Shader shader;
    void Start()
    {
        
        for (int i = 1; i <= count; i++)
        {
            GameObject temp = entityToSpawn;
            
            temp.GetComponent<MeshRenderer>().material = new Material(shader);
            temp.GetComponent<MeshRenderer>().material.color = new Color(i * 255f / count,i,i);
            GameObject.Instantiate(temp, Vector3.right * ( 2f * i )/4, new Quaternion());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
