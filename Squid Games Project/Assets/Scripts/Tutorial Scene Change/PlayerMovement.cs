using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] SceneBehavior sceneBehavior;
    [SerializeField] List<Material> playerColors = new List<Material>(); 
    public GameObject doorPivot; 
    

    private bool door_closed = false;
    private Rigidbody rb;
    private int color_index = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow

        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X"); // Mouse Left/Right movement

        Vector3 rotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseX * rotationSpeed * Time.fixedDeltaTime, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(rotation);

        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "levelend")
        {
            if (!door_closed)
            {
                doorPivot.GetComponent<Animation>().Play("DoorClose");
                door_closed = true;
            }

            StartCoroutine(delayEnd());


        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "obstacle")
        {
            if (color_index == 3)
            {
                sceneBehavior.RestartScene();
            }
            else
            {
                color_index++;
                GetComponent<MeshRenderer>().material = playerColors[color_index];
            
            }
            
        }
    }

    IEnumerator delayEnd()
    {
        yield return new WaitForSeconds(5f);
        sceneBehavior.NextScene(2);
    }
}

