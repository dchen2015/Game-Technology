using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    // Player Fields
    public float playerSpeed;
    public float jumpForce;
    public CharacterController controller;

    // Jumping & Physics
    private Vector3 moveDirection;
    public float gravityScale;

    //For moving animation
    public GameObject playerMesh;

    //For door opening
    public GameObject doors;

    //public Button changePerspective;

    public Camera firstPersonViewCamera;
    public Camera thirdPersonViewCamera;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //changePerspective.onClick.AddListener(ChangePerspective);
    }

    // Update is called once per frame
    void Update()
    {

        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * playerSpeed;
        moveDirection.y = yStore;

        if(controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        if(Input.GetKeyDown("f"))
        {
            ChangePerspective();
        }

        if(Input.GetKeyDown("r"))
        {
            transform.Find("Spot Light").GetComponent<Light>().enabled = !transform.Find("Spot Light").GetComponent<Light>().enabled;
        }

        if ((Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f) && controller.isGrounded)
        {
            playerMesh.GetComponent<Animator>().enabled = true;
        }
        else
        {
            playerMesh.GetComponent<Animator>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.transform.Find("Explosion Particles").gameObject.GetComponent<ParticleSystem>().Play();
            other.GetComponent<BoxCollider>().enabled = false;
            if (other.GetComponent<Collectable_Rotater>().roomNum == 1)
            {
                doors.GetComponent<doorScript>().firstRoomPickup -= 1;
            } 
            else if (other.GetComponent<Collectable_Rotater>().roomNum == 2)
            {
                doors.GetComponent<doorScript>().secondRoomPickup -= 1;
            }
            else if(other.GetComponent<Collectable_Rotater>().roomNum == 3)
            {
                doors.GetComponent<doorScript>().thirdRoomPickup -= 1;
            }
            other.transform.Find("Body").gameObject.SetActive(false);
        }
    }

    void ChangePerspective()
    {
        //print("perspective changed");
        firstPersonViewCamera.enabled = !firstPersonViewCamera.enabled;
        thirdPersonViewCamera.enabled = !thirdPersonViewCamera.enabled;
    }

}
