using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{

    public Vector3 shootDirection = new Vector3(0, 0, 0);

    public List<Vector3> shootingDirections = new List<Vector3>()
    {
        new Vector3(5,2.5f,0),
        new Vector3(6,2.5f,0),
        new Vector3(7,2.5f,0),
        new Vector3(5,2f,0),
        new Vector3(6,2f,0),
        new Vector3(7,2f,0),

    };
    public List<Vector3> ballRotationForce = new List<Vector3>()
    {
        new Vector3(0,0,1.5f),
        new Vector3(0,0,0.5f),
        new Vector3(0,0,1f),
        new Vector3(0,0,-1.5f),
        new Vector3(0,0,-0.5f),
        new Vector3(0,0,-1f)
    };

    private Vector3 startPos;

    private Rigidbody rig;

    private int RGN1;
    private int RGN2;

    void Start()
    {



        rig = GetComponent<Rigidbody>();
        startPos = this.transform.position;
        if(shootingDirections.Count > 0)
        {
            RGN1 = Random.Range(0, shootingDirections.Count);
            shootDirection = shootingDirections[RGN1];
        }

        if(ballRotationForce.Count > 0)
        {
            RGN2 = Random.Range(0, ballRotationForce.Count);
        }

        ShootBall();

    }

    void Update()
    {
        if (ballRotationForce.Count > 0)
        {
            rig.AddForce(ballRotationForce[RGN2], ForceMode.Force);
        }    

    }

    public void ShootBall()
    {
        rig.AddForce(shootDirection, ForceMode.Impulse);
    }
}
