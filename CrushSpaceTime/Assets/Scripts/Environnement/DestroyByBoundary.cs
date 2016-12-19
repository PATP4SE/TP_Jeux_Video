using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "SpaceShip")
        Destroy(other.gameObject);
    }

}
