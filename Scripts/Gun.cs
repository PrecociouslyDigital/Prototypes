using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour{
    public GameObject bullet;
    public short bullets;
    public float rof;
    public float accuracy;
    public float nextFireTime = 0;
    public abstract void fire();
    public abstract void fireCont();
    public void destroy() {
        
    }

}