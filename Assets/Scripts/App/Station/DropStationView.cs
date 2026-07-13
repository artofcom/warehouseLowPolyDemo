using UnityEngine;

public class DropStationView : StationView
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void UnloadCargo(CargoComp cargoComp)
    {
        cargoComp.transform.SetParent(transform, false);
        cargoComp.transform.localPosition = new Vector3(.0f, 1.0f, 0.3f);
    }
}
