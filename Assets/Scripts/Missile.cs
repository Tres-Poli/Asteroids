using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class Missile : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private void Start()
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * _speed;
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var target = collision.GetComponent<Damage>();
            if (target != null)
            {
                target.Hit();
            }

            Destroy(gameObject);
        }
    }
}
