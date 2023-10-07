using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject FrontBorder;
    private Vector3 offset = new Vector3 (0, 0, -1f);
    private float temp = 2f;
    private void Start()
    {
        InvokeRepeating("MovedBorderToPlayer", 1f, temp);
    }

    private void MovedBorderToPlayer()
    {
        CheckPosition();
        FrontBorder.transform.Translate(Vector3.back);
    }
    private void CheckPosition()
    {
        if (FrontBorder.transform.position.z <= -5)
        {
            CancelInvoke();
        }
    }
}
