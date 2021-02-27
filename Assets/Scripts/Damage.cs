using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Asteroids
{
    public class Damage : MonoBehaviour
    {
        [SerializeField]
        private int _lifes;
        [SerializeField]
        private ParticleSystem _destroyEffect;
        [SerializeField]
        private UnityEvent _destroyAudio;
        [SerializeField]
        private Blinker _blinker;

        public void Hit()
        {
            if (_blinker != null)
            {
                _blinker.Blink();
            }

            _lifes--;
            if (_lifes == 0)
            {
                var particle = Instantiate(_destroyEffect, transform.position, Quaternion.identity);
                particle.Play();
                _destroyAudio.Invoke();
                Destroy(particle.gameObject, particle.main.duration + particle.main.startLifetime.constant);
                Destroy(gameObject);
            }
        }
    }
}