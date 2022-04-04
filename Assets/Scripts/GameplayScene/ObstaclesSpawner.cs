using UnityEngine;
using System.Collections;
public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _groundObstacle;
    [SerializeField] private GameObject[] _flyingObstacle;
    [SerializeField] private GameObject _lavaObstacle;
    [SerializeField] private GameObject[] _mudObstacle;


    [SerializeField] private GameObject _lavaObstacleSpawner;

    private float _groundObstacleMaxSpawnTime = 4.5f;
    private float _groundObstacleMinSpawnTime = 2f;

    private float _mudObstacleMaxSpawntime = 13f;
    private float _mudObstacleMinSpawntime = 8f;

    private float _lavaObstaclesMinForce = 480;
    private float _lavaObstaclesMaxForce = 520;


    private float _obstacleMinSpawnDistance = 9;
    private float _obstacleMAxSpawnDistance = 20;

    public int zonecounter = 0;

    private void Start()
    {
        StartCoroutine("GroundObstacleSpawn");
        StartCoroutine("MudObstacleSpawn");
    }

    IEnumerator GroundObstacleSpawn()
    {
        yield return new WaitForSeconds(Random.Range(_groundObstacleMinSpawnTime, _groundObstacleMaxSpawnTime));
        var spawnpos = new Vector2(transform.position.x + Random.Range(_obstacleMinSpawnDistance, _obstacleMAxSpawnDistance), -0.32f);
        int i = Random.Range(zonecounter * 2, zonecounter * 2 + 2);
        Instantiate(_groundObstacle[i], spawnpos, _groundObstacle[i].transform.rotation);
        StartCoroutine("GroundObstacleSpawn");
    }
    IEnumerator LavaObstacleSpawn()
    {
        yield return new WaitForSeconds(1);
        var Obstacle = Instantiate(_lavaObstacle, new Vector2(_lavaObstacleSpawner.transform.position.x, _lavaObstacleSpawner.transform.position.y+Random.Range(0.1f,0.3f)), Quaternion.identity);
        Obstacle.GetComponent<Rigidbody2D>().AddForce
            (new Vector2(Random.Range(_lavaObstaclesMinForce*2, _lavaObstaclesMaxForce * 2),
           Random.Range(-_lavaObstaclesMinForce/2, -_lavaObstaclesMaxForce / 2)));
        Obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2( Random.Range(1.3f,1.5f) , Random.Range(1.3f, 1.5f));
    }
    IEnumerator MudObstacleSpawn()
    {
        yield return new WaitForSeconds(Random.Range(_mudObstacleMinSpawntime, _mudObstacleMaxSpawntime));
        var spawnpos = new Vector2(transform.position.x + Random.Range(_obstacleMinSpawnDistance, _obstacleMAxSpawnDistance)+3, -0.5f);
        Instantiate(_mudObstacle[zonecounter], spawnpos, Quaternion.identity);
        StartCoroutine("MudObstacleSpawn");
    }
}
