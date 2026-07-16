using UnityEngine;

public class StationView : AView
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[OnTriggerEnter] {other.name} has collided on the station!");
    }
}
