using UnityEngine;
using UnityEngine.SceneManagement;
public class LavaClass : MonoBehaviour
{
    public float _movespeed = 2;
    [SerializeField] private GameObject _player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.GetComponent<ScenesManager>().Lose();
        }
    }
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + _movespeed * Time.deltaTime, transform.position.y);
        if(_player.GetComponent<PlayerController>()._moveSpeed < 4 && Mathf.Abs(transform.position.x - _player.transform.position.x) > 19)
        {
            transform.position = new Vector2(_player.transform.position.x - 17f, transform.position.y);
        } 
    }
}
