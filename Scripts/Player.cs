using UnityEngine;
using System.Collections;

public class Player : MoveEntity {
    public float acceleration;
    public float topSpeed;
    private Vector2 mousePos = Vector2.zero;
    public EnergyBar energyBar;

    public float maxEnergy;
    public float energyRegenRate;
    private float energy;

    public float maxHealth;
    public float health;
    public override void Start() {
        base.Start();
        energy = maxEnergy;
        if (energyBar == null)
            energyBar = GameObject.Find("EnergyBar").GetComponent<EnergyBar>();
        health = maxHealth;
    }
    void Update () {
        if (!Input.GetMouseButton(1)) {
            mousePos = (Vector2)Input.mousePosition - new Vector2(Screen.width / 2, Screen.height / 2);
        }
        Vector2 velocity = Vector2.MoveTowards(body.velocity, mousePos.normalized * topSpeed, acceleration * Time.deltaTime);

        energy += energyRegenRate * Time.deltaTime;
        energy -= (body.velocity - velocity).magnitude;
        if(energy < 0) {
            this.die();
            Debug.Log("died of low energy");
        }
        if (energy > maxEnergy)
            energy = maxEnergy;
        energyBar.set(energy / maxEnergy);

        body.velocity = velocity;
        this.lookAt(body.velocity);
        if (Input.GetMouseButtonDown(0)) {
            this.shoot();
        }

        health += Time.deltaTime/2;
        if (health > maxHealth) health = maxHealth;
	}
}
