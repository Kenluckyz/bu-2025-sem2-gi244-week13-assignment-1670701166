using UnityEngine;

public class MoveLeft : MonoBehaviour

{

    public float speed = 10f;

    void Start()

    {

    }

    void Update()

    {

        // 1.17 stop moving left when the game is over

        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;
        if (isGameOver)

        {

            speed = 0f;

        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -15 && gameObject.CompareTag("Obstacle"))
        {

            ObstacleObjectPool pool = FindObjectOfType<ObstacleObjectPool>();

            if (gameObject.name.Contains("Obstacle"))
            {
                pool.Release(gameObject, 0);
            }
            else if (gameObject.name.Contains("Barrier"))
            {
                pool.Release(gameObject, 1);
            }
            else if (gameObject.name.Contains("StoneWall"))

            {
                pool.Release(gameObject, 2);
            }

        }

    }

}
