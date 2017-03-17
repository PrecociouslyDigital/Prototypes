using UnityEngine;
using System.Collections;

public class MoveEntity : Entity {
    public Gun currentGun;
    protected Rigidbody2D body;
    public virtual void Start() {
        body = gameObject.GetComponent<Rigidbody2D>();
        if(currentGun == null)
            currentGun = gameObject.GetComponentInChildren<Gun>();
    }
    protected void lookAt(Vector2 target) {
        if (target.Equals(Vector2.zero))
            return;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target);
    }
    protected void shoot() {
        if(currentGun != null)
            currentGun.fire();
        else {

        }
    }
    protected void fireCont() {
        if (currentGun != null)
            currentGun.fireCont();
    }

}