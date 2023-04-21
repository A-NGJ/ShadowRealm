using UnityEngine;

public class DesktopCameraController : MonoBehaviour
{
    public float sensitivity = 1.0f;
    public Transform target;

    private Vector2 rotation = Vector2.zero;
    // private bool useMouse = true;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null) {
            target = transform.parent;
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        // Use mouse if connected
        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * sensitivity;

        rotation.y = Mathf.Clamp(rotation.y, -90.0f, 90.0f);

        transform.rotation = Quaternion.Euler(rotation.y, rotation.x, 0.0f);
        // transform.position = target.position - transform.forward * 10.0f;
    }
}
