using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public int maxEnergy = 100;
    public int minEnergy = 0;
    public int startingEnergy = 50;
    public int currentEnergy = 0;
    public int quantityBurningEnergy = 1;
    public float timeBurningEnergy = 1;

    public EnergyBarController energyBar;
    private PlayerController playerCtrl;

    private void Start()
    {
        this.playerCtrl = GetComponent<PlayerController>();
        this.currentEnergy = this.startingEnergy;
        StartCoroutine(this.BurnEnergy());
    }

    private void Update()
    {
        this.energyBar.SetEnergy(this.currentEnergy);

        if (this.currentEnergy == 0 || this.currentEnergy == 100)
        {
            this.playerCtrl.isAlive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            other.gameObject.SetActive(false);
            this.currentEnergy += other.gameObject.GetComponent<FoodBehaviour>().energyValue;

            if (this.currentEnergy > (this.maxEnergy - 1)) // max energy
            { this.currentEnergy = this.maxEnergy; }
        }
    }

    public void Restart()
    {
        this.currentEnergy = this.startingEnergy;
        StartCoroutine(this.BurnEnergy());
    }

    private IEnumerator BurnEnergy()
    {
        Debug.Log("TIME: " + Time.timeScale);

        while (this.playerCtrl.isAlive) // if the game is running
        {
            if (Time.timeScale == 1)
            {
                this.currentEnergy = this.currentEnergy - this.quantityBurningEnergy;
            }

            if (this.currentEnergy < (this.minEnergy + 1)) // min energy
            { this.currentEnergy = this.minEnergy; }

            yield return new WaitForSecondsRealtime(this.timeBurningEnergy);

        }

    }

}
