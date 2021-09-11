using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    GameObject cameraObject;
    public float horizontalSensitivity = 1f;
    public float verticalSensitivity = 1f;
    public float forwardSpeed = 1f;
    public float horizontalSpeed = 1f;

    public float shiftMultiplier = 1.5f;

    private float shift = 1f;

    private GameObject planetFollowing = null;

    // Start is called before the first frame update
    void Start()
    {
        if (cameraObject == null)
            cameraObject = this.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            shift = shiftMultiplier;
        else
            shift = 1;

        performCameraTranslations();
        planetController();
        followPlanet();
        
    }

    private void performCameraTranslations()
    {
        if (planetFollowing == null)
        {
            cameraObject.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * verticalSensitivity * Time.deltaTime, Space.Self);
            cameraObject.transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * horizontalSensitivity * Time.deltaTime, Space.Self);
            Vector3 rotation = cameraObject.transform.rotation.eulerAngles;
            cameraObject.transform.rotation = Quaternion.Euler(new Vector3(rotation.x, rotation.y, 0));

            cameraObject.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * forwardSpeed * Time.deltaTime * shift);
            cameraObject.transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * forwardSpeed * Time.deltaTime * shift);
        }
    }

    private void planetController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector3 direction = cameraObject.transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(cameraObject.transform.position, direction * 10);
            if (Physics.Raycast(cameraObject.transform.position, direction, out hit, 1000, 1 << 8))
            {
                planetFollowing = hit.collider.gameObject;
                followOffset = Vector3.zero;
            }
        }
    }
    private Vector3 followOffset = Vector3.zero;
    private Vector3 followPosition;
    private void followPlanet()
    {
        if (planetFollowing != null)
        {
            cameraObject.transform.position = planetFollowing.transform.position + followOffset;
            Vector3 direction = cameraObject.transform.TransformDirection(Vector3.forward);
            followOffset += direction * Input.GetAxis("Mouse ScrollWheel");

        }
    }
}
