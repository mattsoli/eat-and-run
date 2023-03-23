using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxEnergy(int energy) {
        this.slider.maxValue = energy;
        this.slider.value = energy;

        this.fill.color = this.gradient.Evaluate(energy/100);
    }

    public void SetEnergy(int energy)
    {
        this.slider.value = energy;

        this.fill.color = this.gradient.Evaluate(this.slider.normalizedValue);
    }
}
