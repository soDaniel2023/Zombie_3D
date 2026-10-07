using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public float lerpRate;
    public bool GameOver;
    private Vector3 offset;

    void Start()
    {
        offset = Player.transform.position - transform.position;
        GameOver = false;
    }

    void Update()
    {
        if(!GameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = Player.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate*Time.deltaTime);
        transform.position = pos;
    }
}