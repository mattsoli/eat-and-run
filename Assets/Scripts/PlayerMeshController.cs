using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeshController : MonoBehaviour
{
    public EnergyController energyCtrl;

    // Start is called before the first frame update
    void Start()
    {
        ChangeMeshScale();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMeshScale();
    }

    private void ChangeMeshScale()
    {

        float energy = this.energyCtrl.currentEnergy;
        float scaleY = this.transform.localScale.y;

        float scaleX = (energy / 100) + .5f;
        float scaleZ = (energy / 100) + .5f;

        this.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }

}
