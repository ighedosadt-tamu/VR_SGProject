using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    Vector3 playerSpeed;
    [SerializeField] SceneBehavior sceneBehavior;
    [SerializeField] List<Material> playerColors = new List<Material>();
    private int color_index = 0;
    public GameObject doorPivot;
    private bool door_closed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -5f)
        {
            sceneBehavior.RestartScene();
        }
        
        if (Input.GetKeyDown("space"))
        {
            playerSpeed = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(playerSpeed.x, speed, playerSpeed.z);
        }

        if (Input.GetKey("up"))
        {
            playerSpeed = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(playerSpeed.x, playerSpeed.y, speed);
        }

        if (Input.GetKey("down"))
        {
            playerSpeed = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(playerSpeed.x, playerSpeed.y, -speed);
        }

        if (Input.GetKey("right"))
        {
            playerSpeed = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(speed, playerSpeed.y, playerSpeed.z);
        }

        if (Input.GetKey("left"))
        {
            playerSpeed = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(-speed, playerSpeed.y, playerSpeed.z);
        }

    }
    private void OnTriggerEnter(Collider other) {
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

