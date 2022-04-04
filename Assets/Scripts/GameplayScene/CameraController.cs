using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _player;


    private void FixedUpdate()
    {
        transform.parent.position = new Vector3(_player.position.x, transform.parent.position.y, -10);
    }


}
