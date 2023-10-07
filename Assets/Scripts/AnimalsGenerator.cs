using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsGenerator : MonoBehaviour
{
    public GameObject[] animals;
    static public Vector3 vectorMovement;
    private Vector3 spawnPosition;
    [SerializeField] int chanceCreateAgressiveAnimals;
    [SerializeField] float timeSpawnAnimals; //will be "static"!
    private float timeStartCreating = 1.0f;

    //Start's point a normal animal
    private float randomPosition; //position X for normal animals and position Z for agressive animals
    private int animalIndex;
    //intal min/max position X
    [SerializeField] private float positionXminMax = 19.0f;
    private float positionX; //will be random
    private float positionY = 0.0f;
    private float positionZ = 35.0f; //also using as fixed position X for agressive animals

    //Start's point a agressive animals
    [SerializeField] private float positionZminMax = 12.0f;





    private void Start()
    {
        InvokeRepeating("CreateRandom", timeStartCreating, timeSpawnAnimals);

    }
    private void CreateNormalAnimals()
    {
        vectorMovement = Vector3.back;
        animalIndex = Random.Range(0, animals.Length);
        randomPosition = Random.Range(-positionXminMax, positionXminMax);
        spawnPosition = new Vector3 (randomPosition, positionY, positionZ);
        Instantiate(animals[animalIndex], spawnPosition, animals[animalIndex].transform.rotation = Quaternion.Euler(0, 180, 0));
    }
    private void CreateAgressiveAnimalsLeft()
    {
        vectorMovement = Vector3.right;
        animalIndex = Random.Range(0, animals.Length);
        randomPosition = Random.Range(-positionZminMax, positionZminMax);
        spawnPosition = new Vector3(-positionZ, positionY, randomPosition);
        Instantiate(animals[animalIndex], spawnPosition, animals[animalIndex].transform.rotation = Quaternion.Euler(0, 90, 0));
    }
    private void CreateAgressiveAnimalsRight()
    {
        vectorMovement = Vector3.left;
        animalIndex = Random.Range(0, animals.Length);
        randomPosition = Random.Range(-positionZminMax, positionZminMax);
        spawnPosition = new Vector3(positionZ, positionY, randomPosition);
        Instantiate(animals[animalIndex], spawnPosition, animals[animalIndex].transform.rotation = Quaternion.Euler(0, -90, 0));

    }
    private void CreateRandom()
    {
       chanceCreateAgressiveAnimals = Random.Range(0, 10);

        switch (chanceCreateAgressiveAnimals)
        {
            case 1:
                CreateAgressiveAnimalsLeft();
                break;
            case 2:
                CreateAgressiveAnimalsRight();
                break;
            default:
                CreateNormalAnimals();
                break;
        }
    }

}
