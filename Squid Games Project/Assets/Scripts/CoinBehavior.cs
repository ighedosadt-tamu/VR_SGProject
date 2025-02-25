using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;
    Vector3 myStartPosition;
    AudioSource myAudio;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        myStartPosition = transform.position;
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myStartPosition + new Vector3(0, Mathf.Sin(Time.time) / 10.0f, 0);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);

    }
    private void OnCollisionEnter(Collision other)
    {
        myAudio.Play();
        scoreManager.score++;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
    }
}
