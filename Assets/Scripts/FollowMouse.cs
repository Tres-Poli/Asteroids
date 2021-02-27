using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class FollowMouse : MonoBehaviour
    {
        void Update()
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = mousePos - transform.position;
            var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        }
    }
}
