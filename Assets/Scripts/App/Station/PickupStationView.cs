using UnityEngine;

public class PickupStationView : StationView
{
    [SerializeField] Transform cargoRoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public CargoComp GetAvailableCargo()
    {
        if(cargoRoot == null)
            return null;

        for(int q = 0; q < cargoRoot.childCount; ++q)
        {
            var compCargo = cargoRoot.GetChild(q).GetComponent<CargoComp>();
            if(compCargo != null)
                return compCargo;
        }
        return null;
    }
}
