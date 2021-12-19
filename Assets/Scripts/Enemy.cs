using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] GameObject enemyBullet;
   
    [Header("Sound Effect")]
    [SerializeField] GameObject enemySparklesVFX;
    [SerializeField] AudioClip enemyDeadSound;
    [SerializeField] AudioClip enemyShootSound;
    [Range(0, 10)] [SerializeField] float enemyDeathVolume = 0.7f;
    [Range(0, 10)] [SerializeField] float enemyShootVolume = 0.7f;

    [Header("Values")]
    [SerializeField] float Health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShorts = 0.2f;
    [SerializeField] float maxTimeBetweenShorts = 3f;
    [SerializeField] float enemyProjectileSpeed = 1f;
    [SerializeField] float deathTime;
    [SerializeField] int scoreValue = 80;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShorts, maxTimeBetweenShorts);
    }
    void Update()
    {
        CountDownAndShot();
    }

    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter<=0f)
        {          
            EnemyFire();
            shotCounter = Random.Range(minTimeBetweenShorts, maxTimeBetweenShorts);
        }
    }

    private void EnemyFire()
    {
        GameObject laser = Instantiate(enemyBullet, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyProjectileSpeed);
        AudioSource.PlayClipAtPoint(enemyShootSound, Camera.main.transform.position, enemyShootVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        Health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (Health <= 0)
        {  
            TriggerSparklesVFX();
            TriggerSparklesSFX();
        }
    }

    private void TriggerSparklesSFX()
    {
        FindObjectOfType<GameStatus>().AddToScore(scoreValue);
        AudioSource.PlayClipAtPoint(enemyDeadSound, Camera.main.transform.position,enemyDeathVolume);
    }

    private void TriggerSparklesVFX()
    {
        Destroy(gameObject);
        GameObject sparkles = Instantiate(enemySparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles,deathTime);
    }
}
