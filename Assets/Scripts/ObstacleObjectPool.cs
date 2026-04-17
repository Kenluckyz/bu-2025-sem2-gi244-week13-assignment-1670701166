using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public GameObject obstacleBarrelPrefab;
    public GameObject obstacleBarrierPrefab;
    public GameObject obstacleStoneWallPrefab;
    public int poolSize = 10;

    private List<GameObject> obstacleBarrelPool;
    private List<GameObject> obstacleBarrierPool;
    private List<GameObject> obstacleStoneWallPool;

    void Awake()
    {
        obstacleBarrelPool = new List<GameObject>();
        obstacleBarrierPool = new List<GameObject>();
        obstacleStoneWallPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj1 = Instantiate(obstacleBarrelPrefab);
            obj1.SetActive(false);
            obstacleBarrelPool.Add(obj1);

            GameObject obj2 = Instantiate(obstacleBarrierPrefab);
            obj2.SetActive(false);
            obstacleBarrierPool.Add(obj2);

            GameObject obj3 = Instantiate(obstacleStoneWallPrefab);
            obj3.SetActive(false);
            obstacleStoneWallPool.Add(obj3);
        }
    }

    public GameObject Acquire(int obstacleType)
    {
        if (obstacleType == 0)
        {
            for (int i = 0; i < obstacleBarrelPool.Count; i++)
            {
                if (!obstacleBarrelPool[i].activeInHierarchy)
                {
                    return obstacleBarrelPool[i];
                }
            }

            GameObject obj = Instantiate(obstacleBarrelPrefab);
            obj.SetActive(false);
            obstacleBarrelPool.Add(obj);
            return obj;
        }

        else if (obstacleType == 1)
        {
            for (int i = 0; i < obstacleBarrierPool.Count; i++)
            {
                if (!obstacleBarrierPool[i].activeInHierarchy)
                {
                    return obstacleBarrierPool[i];
                }
            }

            GameObject obj = Instantiate(obstacleBarrierPrefab);
            obj.SetActive(false);
            obstacleBarrierPool.Add(obj);
            return obj;
        }

        else
        {
            for (int i = 0; i < obstacleStoneWallPool.Count; i++)
            {
                if (!obstacleStoneWallPool[i].activeInHierarchy)
                {
                    return obstacleStoneWallPool[i];
                }
            }

            GameObject obj = Instantiate(obstacleStoneWallPrefab);
            obj.SetActive(false);
            obstacleStoneWallPool.Add(obj);
            return obj;
        }
    }

    public void Release(GameObject obstacle, int obstacleType)
    {
        obstacle.SetActive(false);
    }
}