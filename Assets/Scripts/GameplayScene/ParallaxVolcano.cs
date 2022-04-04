using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxVolcano : MonoBehaviour
{
    private float _startpos;

    public GameObject _cam;

    public float _parallaxEffect;

    static public bool _volcano = true;

    static public float _zoneCheckX = 0;

    void Start()
    {
        _startpos = transform.position.x;
    }

    void FixedUpdate()
    {
        if (_volcano)
        {
            float _dist = (_cam.transform.position.x - _zoneCheckX) * _parallaxEffect;

            transform.position = new Vector2(_startpos + _dist, transform.position.y);
        }
    }
}
