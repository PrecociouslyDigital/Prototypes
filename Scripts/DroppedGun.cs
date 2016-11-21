using UnityEngine;
using System.Collections;

public class DroppedGun {
    public GameObject bullet;
    public short bullets;
    public float rof;
    public float accuracy;
    public void reconstruct(GameObject g) {
        Gun gun = g.AddComponent<Gun>();
        gun.accuracy = accuracy;
        gun.bullet = bullet;
        gun.bullets = bullets;
        gun.rof = rof;
        gun.nextFireTime = 0;
        g.GetComponent<MoveEntity>().currentGun = gun;
    }
}
