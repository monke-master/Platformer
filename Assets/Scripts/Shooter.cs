using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform spawnPoint;
    
    public void Shoot(float direction)
    {
        GameObject currentBullet = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
        var rigidbody = currentBullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(fireSpeed * direction, rigidbody.velocity.y);
        
    }
}
