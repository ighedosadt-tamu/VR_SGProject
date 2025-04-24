using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNPCController : MonoBehaviour
{

    public float moveSpeed = 3f;
    public GameObject player;

    
    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        Vector3 direction_to_player = player.transform.position - transform.position;
        
        transform.rotation = Quaternion.LookRotation(direction_to_player, Vector3.up);
        direction_to_player.y = 0f;
        Vector3 target_position = transform.position + direction_to_player;
        transform.position = Vector3.MoveTowards(transform.position, target_position, Time.deltaTime * moveSpeed);

    }
}
