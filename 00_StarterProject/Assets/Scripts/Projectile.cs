using SpaceAdventure.HealthSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _initialHealth;
    [SerializeField] private Health _health;

    public float speed = 10;
    public Rigidbody2D rb2d;
    public float deathDelay = 5;

    public bool disabled = false;

    // Start is called before the first frame update
    void Start()
    {
        _health= GetComponent<Health>();
        _health.InitializeHealth(_initialHealth);
        rb2d.velocity = transform.up * speed;
        StartCoroutine(DeathAfterDelay(deathDelay));
    }

    private IEnumerator DeathAfterDelay(float deathDelay)
    {
        yield return new WaitForSeconds(deathDelay);
        _health.GetHit(1, gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();
        if(hittable != null)
        {
            hittable.GetHit(1, gameObject);
            _health.GetHit(1, gameObject);
            Destroy(gameObject);
        }
    }
}
