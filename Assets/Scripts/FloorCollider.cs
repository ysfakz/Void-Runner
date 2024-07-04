using UnityEngine;

public class FloorCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        Player player = other.GetComponent<Player>();
        if (player != null) {
            GroundMove parent = GetComponentInParent<GroundMove>();
            if (parent != null) {
                parent.PlayerEnter();
            }
        }
    }
}
