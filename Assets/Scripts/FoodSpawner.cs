using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public List<GameObject> foodList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false; // disabled mesh of the food spawner
        int randomValue = Random.Range(0, this.foodList.Count); // random pick of the list food

        GameObject foodSpawned = Instantiate(this.foodList[randomValue], this.transform.position, Quaternion.identity); // instatiate a food from the list

        foodSpawned.transform.parent = this.transform;
    }

}
