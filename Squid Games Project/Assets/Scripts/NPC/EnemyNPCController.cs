using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNPCController : MonoBehaviour
{

    public float moveSpeed = 3f;
    public GameObject player;
    public Material ghostBody;
    private bool dying = false;
    public GhostKill ghostKill;
    public PassthroughManager ptGM;
    
    // Update is called once per frame
    void Update()
    {
        if(!dying)
            FollowPlayer();
    }

    public void FollowPlayer()
    {
        Vector3 direction_to_player = player.transform.position - transform.position;
        
        transform.rotation = Quaternion.LookRotation(direction_to_player, Vector3.up);
        //direction_to_player.y = 0f;
        Vector3 target_position = transform.position + direction_to_player;
        transform.position = Vector3.MoveTowards(transform.position, target_position, Time.deltaTime * moveSpeed);
    }

    public void KillGhost(){
        if (!dying){
            dying = true;
            StartCoroutine(KillingGhost());
            Debug.Log("Killing ghost!");
        }
    }

    IEnumerator KillingGhost(){
        ghostBody.color = Color.white;
        yield return new WaitForSeconds(1);
        ghostBody.color = Color.black;
        ghostKill.IncrementGhost();
        Destroy(this.gameObject);
    }

    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
            ptGM.timeRemaining = 0;
            ptGM.CheckItemPickupTimeLimit();
    }
}
