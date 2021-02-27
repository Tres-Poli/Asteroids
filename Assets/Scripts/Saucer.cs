using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Saucer : MonoBehaviour
    {
        [SerializeField]
        private float _fireCooldown;
        [SerializeField]
        private ParticleSystem _spawn;
        private GameObject _target;

        private void Awake()
        {
            _target = GameController.Instance.CurrentPlayerShip;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        private void Start()
        {
            var spawn = Instantiate(_spawn, transform.position, Quaternion.identity);
            spawn.Play();
            Destroy(spawn.gameObject, spawn.main.duration + spawn.main.startLifetime.constant);
            StartCoroutine(SpawnDelay(spawn.main.duration));
        }

        private void Update()
        {
            transform.Rotate(0, 0, 0.5f);
        }

        public void CallDestroySound()
        {
            AudioController.Instance.PlayShipDestroy();
        }

        private IEnumerator SpawnDelay(float delay)
        {
            yield return new WaitForSeconds(delay);

            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            LockTarget();
        }

        public void LockTarget()
        {
            StartCoroutine(TargetLockFire());
        }

        public void UnlockTarget()
        {
            StopCoroutine(TargetLockFire());
        }

        private IEnumerator TargetLockFire()
        {
            yield return new WaitForSeconds(_fireCooldown);
            while (_target != null)
            {
                var missileDirection = _target.transform.position - transform.position;
                var angle = Mathf.Atan2(missileDirection.x, missileDirection.y) * Mathf.Rad2Deg;
                GetComponent<Weapon>().LaunchMissile(Quaternion.AngleAxis(-angle, Vector3.forward));
                yield return new WaitForSeconds(_fireCooldown);
            }
        }
    }
}
