using UnityEngine;
using System.Collections;

public class Pistol : Gun {
    public override void fire() {
        if (Time.time < nextFireTime)
            return;
        if(--bullets == 0)
            this.
        nextFireTime = Time.time + rof;
        Debug.Log(transform.up);
        GameObject.Instantiate(bullet).GetComponent<Bullet>().setUp(transform.position, transform.rotation, gameObject.layer);
        
    }
    public override void fireCont() { 
         
    }
}
