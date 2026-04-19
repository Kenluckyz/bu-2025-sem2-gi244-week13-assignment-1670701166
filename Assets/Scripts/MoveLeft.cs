using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    public int obstacleType;

    private ObstacleObjectPool pool;

    void Start()
    {
        pool = FindObjectOfType<ObstacleObjectPool>();
    }

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;

        if (isGameOver)
        {
            return;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -15 && gameObject.CompareTag("Obstacle"))
        {
            pool.Release(gameObject, obstacleType);
        }
    }
}