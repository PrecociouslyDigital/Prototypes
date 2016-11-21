using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed;
    public LayerMask layer;
    public void setUp(Vector2 origin, Quaternion rotation, int layer) {
        transform.position = origin;
        transform.rotation = rotation;
        this.layer = ~LayerMask.GetMask(LayerMask.LayerToName(layer));
    }
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, Time.deltaTime * speed, layer.value);
        Debug.Log(transform.up);
        if (hit.transform == null)
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        else {
            Entity e = hit.collider.GetComponent<Entity>();
            if(e!=null)
                e.takeDamage();
            GameObject.Destroy(gameObject);
        }
        Debug.DrawRay(transform.position, transform.up, Color.white);
        //Debug.Break();
    }
}
