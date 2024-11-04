using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{

    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private LifeManager lifeManger;

    public Vector3 shootDirection = new Vector3(0, 0, 0);

    public List<float> shootingSpeed = new List<float>() // first value in vector 3
    {
        5,6,7

    };
    public List<float> shootingHeight = new List<float>() // second value in vector 3
    {
        1,1.5f,2,2.25f
    };

    public List<float> shootingDirection = new List<float>() // third value in vector 3
    {
        -0.45f,-0.35f,-0.25f,-0.15f,0,0.15f, 0.25f, 0.35f,0.45f
    };

    public List<Vector3> ballRotationForce = new List<Vector3>() // keeps being added for swerve
    {
        new Vector3(0,0,1f),
        new Vector3(0,0,0.5f),
        new Vector3(0,0,0.25f),
        new Vector3(0,0,-1f),
        new Vector3(0,0,-0.5f),
        new Vector3(0,0,-0.25f)
    };

    private Rigidbody rig;

    private int RGN1, RGN2, RGN3, RGN4;

    public bool canTriggerScore = true;

    void Start()
    {
        

        scoreManager = FindObjectOfType<ScoreManager>();
        lifeManger = FindObjectOfType<LifeManager>();

        rig = GetComponent<Rigidbody>();

        if (shootingSpeed.Count > 0)
        {
            RGN1 = Random.Range(0, shootingSpeed.Count);
            shootDirection.x = shootingSpeed[RGN1];
        }
        if (shootingHeight.Count > 0)
        {
            RGN2 = Random.Range(0, shootingHeight.Count);
            shootDirection.y = shootingHeight[RGN2];
        }
        if (shootingDirection.Count > 0)
        {
            RGN3 = Random.Range(0, shootingDirection.Count);
            shootDirection.z = shootingDirection[RGN3];
        }
        if (ballRotationForce.Count > 0)
        {
            RGN4 = Random.Range(0, ballRotationForce.Count);
        }

        ShootBall();

    }

    void Update()
    {
        if (ballRotationForce.Count > 0)
        {
            rig.AddForce(ballRotationForce[RGN4], ForceMode.Force);
        }

    }

    public void ShootBall()
    {
        rig.AddForce(shootDirection, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            lifeManger.DecreaseHealth();
        }
    }

}
