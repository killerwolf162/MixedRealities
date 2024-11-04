using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactive : MonoBehaviour
{

    [SerializeField] private float delay;

    private void Update()
    {
        if(this.gameObject.activeSelf == true)
            Invoke("_SetInactive", delay);
    }

    private void _SetInactive()
    {
        this.gameObject.SetActive(false);
    }
}
