using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
    public virtual void takeDamage() {
        this.die();
    }
    public virtual void die() {
        GameObject.Destroy(gameObject);
    }
}
