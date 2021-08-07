using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Rect spawn = new Rect(-9.5f, 4.625f, 10f, 3f);
    public GameObject player;
    public GameObject dingy;
    public GameObject ship;
    public GameObject Lship;
    public GameObject DualLship;
    public int amountShip = 3;
    public GameObject GO;
    public GameObject progress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerManager>().health == 0)
        {
            amountShip = 0;
            Instantiate(GO);
        }
        if (progress.transform.localPosition.x >= 9f)
            SceneManager.LoadScene("pirateBoss");
        if(Random.Range(0, 1000000) % 100 == 0 && amountShip > 0)
        {
            switch(Random.Range(0,3))
            {
                case 0:
                    Instantiate(dingy, new Vector3(Random.Range(spawn.xMin, spawn.xMax), Random.Range(spawn.yMin, spawn.yMax)), Quaternion.identity);
                    amountShip--;
                    break;
                case 1:
                    Instantiate(ship, new Vector3(Random.Range(spawn.xMin, spawn.xMax), Random.Range(spawn.yMin, spawn.yMax)), Quaternion.identity);
                    amountShip--;
                    break;
                case 2:
                    Instantiate(Lship, new Vector3(Random.Range(spawn.xMin - 1, spawn.xMax - 1),3), Quaternion.identity);
                    amountShip--;
                    break;
                case 3:
                    Destroy(Instantiate(DualLship, Vector3.zero, Quaternion.identity), 5f);
                    break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
