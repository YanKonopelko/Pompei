using System.Collections;
using UnityEngine;

public class EarthShakeGenerator : MonoBehaviour
{
    private float _minShaketime = 7;
    private float _maxShaketime = 12;

    private void Start()
    {
        StartCoroutine("EarthShake");
    }

    IEnumerator EarthShake()
    {
        yield return new WaitForSeconds(Random.Range(_minShaketime, _maxShaketime));
        SoundManager.PlaySound(SoundManager.instance.VolcanoSound);
        if (GameObject.Find("Player").GetComponent<PlayerController>()._moveSpeed > 2)
        {
            GameObject.Find("Player").GetComponent<PlayerController>()._moveSpeed = 2;
        }
        Camera.main.transform.parent.GetComponent<Animation>().Play("CameraShake");
        GameObject.Find("Spawner").GetComponent<ObstaclesSpawner>().StartCoroutine("LavaObstacleSpawn");
        StartCoroutine("EarthShake");
    }
}
