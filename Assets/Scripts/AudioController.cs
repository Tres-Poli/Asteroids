using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _asteroidDestroy;
        [SerializeField]
        private AudioSource _shipDestroy;
        [SerializeField]
        private AudioSource _missileLaunch;

        public static AudioController Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayAsteroidDestoy()
        {
            _asteroidDestroy.Play();
        }

        public void PlayShipDestroy()
        {
            _shipDestroy.Play();
        }

        public void PlayMissileLaunch()
        {
            _missileLaunch.Play();
        }
    }
}
