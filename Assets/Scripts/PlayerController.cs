using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    private float horizontalInput;
    private float verticalInput;
    //borders
    private float bordersX = 22.0f;
    private float borderMaxZ = -4.0f;
    private float borderMinZ = -13.0f;

    //testin Moved RB
    [SerializeField] static float speedRB = 20f;
    [SerializeField] Vector3 inputKey;
    public Rigidbody rb;

    private void Start()
    {
        //testing Moved rb
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //VerticalMoved();
        //HorizontallMoved();

        //testing moved RB
        HorizontalVerticalMoved();
    }
    private void HorizontallMoved()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        CheckPosition(transform, -bordersX, bordersX, "Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }
    private void VerticalMoved()
    {
        verticalInput = Input.GetAxis("Vertical");
        CheckPosition(transform, borderMinZ, borderMaxZ, "Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    }
    private void CheckPosition(Transform transform, float minValue, float maxValue, string axis)
    {
        switch (axis)
        {
            case "Horizontal":
                if (transform.position.x <= -bordersX)
                {
                    transform.position = new Vector3(minValue, transform.position.y, transform.position.z);
                }
                else if (transform.position.x >= maxValue)
                {
                    transform.position = new Vector3(maxValue, transform.position.y, transform.position.z);
                }
                break;
            case "Vertical":
                if (transform.position.z >= borderMaxZ)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, borderMaxZ);
                }
                else if (transform.position.z <= borderMinZ)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, borderMinZ);

                }
                break;
            default:
                break;
        }
    }
    //using MovePosition (RB) 
    private void HorizontalVerticalMoved()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //ChekedPositionRBMoved();
        inputKey = new Vector3(horizontalInput, 0, verticalInput);
        //ChekedPositionRBMoved();
        rb.MovePosition(transform.position + inputKey * speedRB * Time.deltaTime);
    }

    private void ChekedPositionRBMoved()
    {
        if (transform.position.x <= -bordersX)
        {
            transform.position = new Vector3(-bordersX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= bordersX)
        {
            transform.position = new Vector3(bordersX, transform.position.y, transform.position.z);
        }

        if (transform.position.z >= borderMaxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, borderMaxZ);
        }
        else if (transform.position.z <= borderMinZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, borderMinZ);

        }


    }
}
