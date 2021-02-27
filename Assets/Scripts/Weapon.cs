using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private Missile _missile;
        [SerializeField]
        private Vector3 _missileInstantialeOffset;

        public void LaunchMissile(Quaternion rotation)
        {
            AudioController.Instance.PlayMissileLaunch();
            Instantiate(_missile, transform.position + _missileInstantialeOffset, rotation);
        }

        public void LaunchMissile()
        {
            AudioController.Instance.PlayMissileLaunch();
            Instantiate(_missile, transform.position + _missileInstantialeOffset, transform.rotation);
        }
    }
}
