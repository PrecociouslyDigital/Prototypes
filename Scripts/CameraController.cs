using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Transform player;
    void Start() {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update() {
        transform.position = player.position + new Vector3(0, 0, -10);
    }
}