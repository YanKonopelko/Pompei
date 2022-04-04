using UnityEngine;

public class LavaObstacle : MonoBehaviour
{
    private float _rotationSpeed = 4;
    private bool isDroped = false;
    [SerializeField] GameObject _stone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.GetComponent<ScenesManager>().Lose();
        }
        if (collision.CompareTag("Ground"))
        {
            if (Random.Range(1, 3) > 1)
            {
                transform.GetComponent<Rigidbody2D>().isKinematic = true;
                transform.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                transform.GetComponent<CircleCollider2D>().isTrigger = false;
                isDroped = true;
                var spawnpos = new Vector2(transform.position.x, -0.32f);
                Instantiate(_stone, spawnpos, Quaternion.identity);
            }
                Destroy(gameObject);
        }
    }
    
}
