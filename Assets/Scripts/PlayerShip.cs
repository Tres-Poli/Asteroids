using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Damage))]
    public class PlayerShip : MonoBehaviour, IAudioModule
    {
        [SerializeField]
        private float _speed;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Weapon>().LaunchMissile();
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                var movement = transform.up * _speed  * Time.deltaTime;
                transform.Translate(movement, Space.World);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var target = collision.GetComponent<Damage>();
            if (target != null)
            {
                target.Hit();
            }

            GetComponent<Damage>().Hit();
        }

        public void CallDestroySound()
        {
            AudioController.Instance.PlayShipDestroy();
        }
    }
}
