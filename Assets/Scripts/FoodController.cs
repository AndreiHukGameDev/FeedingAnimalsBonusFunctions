using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 15.0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed;
        transform.Rotate(0, speed * 0.5f , 0, Space.Self);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
