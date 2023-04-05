using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour, IHittable
{
    Rigidbody2D rb2d;

    private float _speed = 1f;

    [SerializeField] private Transform _meteorSprite;

    [SerializeField] private float _rotationSpeed = 15f;

    private Vector2 direction = Vector2.down;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _meteorSprite.Rotate(new Vector3(0, 0, _rotationSpeed * Time.deltaTime));
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();
        if(hittable != null && !collision.GetComponent<Player>())
        {
            Debug.Log(collision.gameObject.name);
            hittable.GetHit(1, gameObject);
            GetHit(1, collision.gameObject);
        }
    }

    public void GetHit(int damageValue, GameObject sender)
    {
        Vector2 newDirection = transform.position - sender.transform.position;
        direction = newDirection.normalized;
    }
}
