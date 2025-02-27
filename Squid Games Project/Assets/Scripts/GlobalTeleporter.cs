using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTeleporter : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;
        Quaternion playerRot = player.rotation;
        if (player.position.z >= 28.0f)
            playerPos.z -= 54.193f;

        else if (player.position.z <= -28.0f )
            playerPos.z += 54.193f;
        
        player.SetPositionAndRotation(playerPos,playerRot);
    }

    // private void OnTriggerEnter(Collider other) {
    //     string tag = other.gameObject.tag;

    //     if (tag == "Player")
    //     {
    //         Vector3 playerPos = player.position;
    //         Quaternion playerRot = player.rotation;

    //         if (player.position.z >= 28.0f)
    //             playerPos.z -= 54.193f;

    //         else if (player.position.z <= -28.0f )
    //             playerPos.z += 54.193f;

    //         player.SetPositionAndRotation(playerPos,playerRot);
    //     }
    // }
}


