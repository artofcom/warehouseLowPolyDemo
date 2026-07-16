using UnityEngine;

public class DropStationView : StationView
{
    [SerializeField] Transform cargoRoot;

    // Local position of the first dropped cargo, relative to cargoRoot.
    [SerializeField] Vector3 firstCargoLocalPos = new Vector3(.0f, 1.0f, 0.3f);

    // Per-cargo offset applied so subsequent cargo do not overlap.
    [SerializeField] Vector3 cargoOffset = new Vector3(.0f, .0f, 0.6f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void DropOffCargo(CargoComp cargoComp)
    {
        if(cargoRoot == null)
            return;

        // Existing children count equals the slot index for the incoming cargo.
        int slotIndex = cargoRoot.childCount;

        cargoComp.transform.SetParent(cargoRoot, false);
        cargoComp.transform.localPosition = firstCargoLocalPos + cargoOffset * slotIndex;
    }
}
