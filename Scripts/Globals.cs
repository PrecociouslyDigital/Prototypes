using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour{
    public bool debug = true;
    public LayerMask PathfindStoppers = new LayerMask();
    public static Globals get() {
        return GameObject.Find("Globals").GetComponent<Globals>();
    }
}
