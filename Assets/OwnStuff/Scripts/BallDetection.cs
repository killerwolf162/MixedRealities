using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetection : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    private Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    private void Start()
    {
        col.enabled = true;
    }

    private void Update()
    {
        if(col.enabled != true)
        {
            col.enabled = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collison on GoalDetectionLayer");
        Ball ball = collision.rigidbody.GetComponent<Ball>();

        if (ball.canTriggerScore == true)
        {
            ball.canTriggerScore = false;
            scoreManager.IncreaseScore();
        }
    }

}
