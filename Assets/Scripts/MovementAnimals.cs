using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimals : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private Rigidbody rb;

    //difinition of rotation 
    private Vector3 moved;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        moved = AnimalsGenerator.vectorMovement;
    }
    private void FixedUpdate()
    {
        rb.velocity = moved * speed;
    }

    
}
