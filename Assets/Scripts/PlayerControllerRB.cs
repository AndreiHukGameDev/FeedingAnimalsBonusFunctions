using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRB : MonoBehaviour
{
    [SerializeField] Vector3 inputKey;
    private Rigidbody rigidbody;
    private float horizontalInput;
    private float verticalInput;
    private float vectorY = 0.0f; //blocked
    [Header("On/Off freeze Rotation")]
    [SerializeField] static float speed = 20.0f;

    //food
    public GameObject[] foodList;
    private int randomChooseFood;
    private Vector3 foodOffset;
    

    private void Awake()
    {
        AddComponentsToObject();
    }
    private void FixedUpdate()
    {
        MovementPlayer();
    }
    private void Update()
    {
        RunFood();
        
    }

    private void MovementPlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        inputKey = new Vector3(horizontalInput, vectorY, verticalInput);
        rigidbody.velocity = inputKey * speed;
    }
    private void AddComponentsToObject()
    {
        //RB
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;
    }

    private void RunFood()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomChooseFood = Random.Range(0, foodList.Length);
            foodOffset = transform.position + new Vector3(0f, 1.5f, 0f);
            Instantiate(foodList[randomChooseFood], foodOffset, foodList[randomChooseFood].transform.rotation);
        }
        
    }

}
