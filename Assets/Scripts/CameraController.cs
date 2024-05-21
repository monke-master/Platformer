using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Vector3 offset = new Vector3(0, -1, -10);
    [SerializeField] private Transform player;
    
    void Update()
    {
        transform.position = player.position + offset;
    }
}
