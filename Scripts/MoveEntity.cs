using UnityEngine;
using System.Collections;

public class MoveEntity : Entity {
    public float speed;
    public Gun currentGun;
    protected Rigidbody2D body;
    protected virtual void Start() {
        body = gameObject.GetComponent<Rigidbody2D>();
        currentGun = gameObject.GetComponent<Pistol>();
    }
    protected void moveTowards(Vector2 target) {
        body.velocity = target.normalized * speed;
        lookAt(target);
    }
    protected void lookAt(Vector2 target) {
        if (target.Equals(Vector2.zero))
            return;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan(target.y / target.x) + (target.x < 0 ? 90 : -90)));
    }
    protected void shoot() {
        if(currentGun != null)
            currentGun.fire();
        else {

        }
    }

}