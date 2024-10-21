using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFootball : MonoBehaviour
{
    [SerializeField] private GameObject footBall;

    public List<GameObject> ballList = new List<GameObject>();


    public void SpawnBall()
    {
        if(ballList.Count != 0)
        {
            DeleteBall();
        }
        GameObject newBall = Instantiate(footBall, this.transform.position, this.transform.rotation);
        ballList.Add(newBall);
    }

    public void DeleteBall()
    {
        Destroy(ballList[0]);
        ballList.Remove(ballList[0]);
    }

    public IEnumerator BallGame()
    {
        yield return new WaitForSeconds(4f);

        SpawnBall();

        StartCoroutine(BallGame());
    }

    public void StartBallGame()
    {
        StartCoroutine(BallGame());
    }
    public void StopBallGame()
    {
        StopCoroutine(BallGame());
    }


}
