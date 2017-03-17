using UnityEngine;
using System.Collections;

public class EnemySimple : Entity {
    public Transform player;
    public float speed = 0.2f;
    public float fireDist = 2f;
    public Gun gun;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate((player.transform.position - this.transform.position).normalized * speed * Time.deltaTime, Space.World);
        lookAt((player.transform.position - this.transform.position).normalized);
        if((player.transform.position - this.transform.position).magnitude < fireDist) {
            gun.fire();
        }
	}
    protected void lookAt(Vector2 target) {
        if (target.Equals(Vector2.zero))
            return;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target);
    }
}
