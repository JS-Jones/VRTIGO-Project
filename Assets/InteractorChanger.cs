using UnityEngine;

public class InteractorChanger : MonoBehaviour
{
    public HandednessTouchTest manager;

    private void OnTriggerEnter(Collider other)
    {
            // Use *this* GameObject’s name to decide handedness
            string handedness = transform.name.Contains("Left") ? "Left" : "Right";

            Debug.Log($"Triggered by {other.name} at {transform.name}, setting handedness: {handedness}");
            manager.handedness = handedness;
    }
}
