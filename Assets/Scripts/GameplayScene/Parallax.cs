using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _startpos;

    public GameObject _cam;

    public float _parallaxEffect;

    static public bool _plain = false;

    static public float _zoneCheckX;

    void Start()
    {
        _startpos = transform.position.x;
    }

    void FixedUpdate()
    {
        if (_plain)
        {
            float _dist = (_cam.transform.position.x - _zoneCheckX) * _parallaxEffect;

            transform.position = new Vector2(_startpos + _dist, transform.position.y);
        }
    }
}
