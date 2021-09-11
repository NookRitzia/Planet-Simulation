using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject entityToSpawn;
    public int count;
    public Vector3 directionSpawned = Vector3.right;
    public Shader shader;
    public float offset = 1f;

    public Color col;
    public bool solidColor = false;

    void Start()
    {
        
        for (int i = 1; i <= count; i++)
        {
            GameObject temp = entityToSpawn;
            
            temp.GetComponent<MeshRenderer>().material = new Material(shader);
            GameObject instantiated = GameObject.Instantiate(temp, directionSpawned * ( 2f * i )/4, new Quaternion());
            // ----------

            // ----------
            //instantiated.GetComponent<MeshRenderer>().material.color = new Color(i / (count * 1.0f), 1 - i / (count * 1.0f), 0);
            instantiated.GetComponent<MeshRenderer>().material.color = rainbowColor(i * 1f / count);
            instantiated.GetComponent<BetterVerticalOscillator>().oscillationOffset = i * 2;
            //instantiated.GetComponent<BetterVerticalOscillator>().center = new Vector3(offset * i, 0, 0);
            instantiated.GetComponent<BetterVerticalOscillator>().center = directionSpawned * offset * i;

        }
    }

    private Color rainbowColor(float percentage)
    {
        if (solidColor)
            return col;
        return new Color(1 - percentage, Mathf.Pow(percentage, 3), percentage);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
