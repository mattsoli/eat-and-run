using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    public float spinSpeed = 1;

    public int energyValue = 1;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, this.spinSpeed, 0);
    }
}
