using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    [SerializeField]
    private float _blinkTransperency;

    public void Blink()
    {
        StartCoroutine(StartBlink());
    }

    private IEnumerator StartBlink()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var defaultColor = renderer.color;
        var blinkColor = new Color(defaultColor.r, defaultColor.g, defaultColor.b, _blinkTransperency);
        renderer.color = blinkColor;

        yield return new WaitForSeconds(0.1f);

        renderer.color = defaultColor;
    }
}
