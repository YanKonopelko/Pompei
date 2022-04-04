using UnityEngine;

public class ZoneChanger : MonoBehaviour
{
    private bool isRotate;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            GameObject.Find("Spawner").GetComponent<ObstaclesSpawner>().zonecounter += 1;
            switch (GameObject.Find("Spawner").GetComponent<ObstaclesSpawner>().zonecounter)
            {
                case 1:
                    isRotate = true;
                    ParallaxVolcano._volcano = false;
                    Parallax._plain = true;
                    Parallax._zoneCheckX = transform.position.x;
                    break;
                case 2:

                    Parallax._plain = false;
                    Parallax1._town = true;
                    Parallax1._zoneCheckX = transform.position.x;
                    break;
                case 3:
                    ManageEnd.DoEnd(3);
                    break;
            }
            //Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(isRotate)
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 1.0f);
    }


}
