using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    public AudioClip bulletSound;
    public AudioClip explosionSound; 

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        AudioSource.PlayClipAtPoint(bulletSound,
        gameObject.transform.position);
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;
        if(bullet.position.y >= 10)
        {
            Destroy(gameObject); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //Destroy the enemy 
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(explosionSound, other.gameObject.transform.position);
            //Destroy the bullet itself 
            Destroy(gameObject);
            //Increase Player score if we hit an enemy 
            PlayerScore.playerScore += 10;

        }
        else if(other.tag == "Base")
        {
            Destroy(gameObject); 
        }
    }
     // Update is called once per frame
    void Update()
    {
        
    }
}
