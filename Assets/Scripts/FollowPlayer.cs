using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;  
    }

    
    void LateUpdate()
    {
        transform.position = playerTransform.position;
    }
}
