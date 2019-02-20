using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public Transform targetTransform;

    public Vector3 offset;

    public float rotateSpeed;

    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        offset = targetTransform.position - transform.position;

        pivot.transform.position = targetTransform.transform.position;
        pivot.transform.parent = targetTransform.transform;

        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Get x position of the mouse and rotate the target
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            targetTransform.Rotate(0, horizontal, 0);

            // Get Y Position of the mouse and rotat the pivot
            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
            pivot.Rotate(-vertical, 0, 0);

            float desiredYAngle = targetTransform.eulerAngles.y;
            float desiredXAngle = pivot.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
            transform.position = targetTransform.position - (rotation * offset);

            transform.LookAt(targetTransform);
        }
    }
}