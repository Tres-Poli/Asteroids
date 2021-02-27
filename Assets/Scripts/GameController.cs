using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [SerializeField]
        private GameObject _playerShip;
        [SerializeField]
        private Vector3 _playerInstantiatePoint;
        [SerializeField]
        private GameObject _saucer;
        [SerializeField]
        private GameObject[] _asteroids;
        [SerializeField]
        private int _asteroidInstantiateRadius;
        // Rate per minute
        [SerializeField]
        private float _asteroidInstantiateRate;
        // Rate per minute
        [SerializeField]
        private float _saucerInstantiateRate;

        public GameObject CurrentPlayerShip { get; private set; } = null;

        public int Scores { get; private set; } = 0;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CurrentPlayerShip = Instantiate(_playerShip, _playerInstantiatePoint, Quaternion.identity);
            StartCoroutine(SpawnAsteroidsForLevel());
            StartCoroutine(SpawnSaucersForLevel());
        }

        private void InstantiateAsteroid()
        {
            var spawnPoint = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * _asteroidInstantiateRadius;
            Instantiate(_asteroids[Random.Range(0, _asteroids.Length)], spawnPoint, Quaternion.identity);
        }

        private void InstantiateSaucer()
        {
            var camWidth = Camera.main.pixelWidth;
            var camHeight = Camera.main.pixelHeight;
            var spawnPoint = new Vector2(Random.Range(camWidth / 6, camWidth - camWidth / 6), Random.Range(camHeight / 6, camHeight - camHeight / 6));
            spawnPoint = Camera.main.ScreenToWorldPoint(spawnPoint);
            Instantiate(_saucer, spawnPoint, Quaternion.identity);
        }

        private IEnumerator SpawnAsteroidsForLevel()
        {
            while (true)
            {
                InstantiateAsteroid();
                yield return new WaitForSeconds(60f / _asteroidInstantiateRate);
            }
        }

        private IEnumerator SpawnSaucersForLevel()
        {
            while (true)
            {
                InstantiateSaucer();
                yield return new WaitForSeconds(60f / _saucerInstantiateRate);
            }
        }
    }
}
