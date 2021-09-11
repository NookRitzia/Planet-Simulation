using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpeedManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeMultiplier = 1f;
    public float scrollWheelSensitivity = 1f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            timeMultiplier += Input.GetAxis("Mouse ScrollWheel") * scrollWheelSensitivity;
            timeMultiplier = Mathf.Max(0f, timeMultiplier);
        }
    }

}
