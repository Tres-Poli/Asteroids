using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PolygonCollider2D))]
    [RequireComponent(typeof(Damage))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        void Start()
        {
            var camera = Camera.main;
            var rawDirection = new Vector3(Random.Range(camera.pixelWidth / 6, camera.pixelWidth - camera.pixelWidth / 6),
                transform.position.y > 0 ? 0 : camera.pixelHeight, 0);
            var direction = (camera.ScreenToWorldPoint(rawDirection) - transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * _speed;
        }

        private void Update()
        {
            transform.Rotate(new Vector3(0, 0, 0.5f));
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        public void CallDestroySound()
        {
            AudioController.Instance.PlayAsteroidDestoy();
        }
    }
}
