using UnityEngine;
using System.Collections;

public class Player : MoveEntity {
    private Vector2 mousePos = Vector2.zero;
    public float speed;

    public float slowTimeSpeed = 0.1f;
    private float fixedDeltaTime;

    private float lastTime = 0;

    public float maxHealth;
    public float health;
    public override void Start() {
        base.Start();
        health = maxHealth;
        fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update () {
        
        mousePos = (Vector2)Input.mousePosition - new Vector2(Screen.width / 2, Screen.height / 2);

        Vector2 velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * speed;

        body.velocity = velocity;
        if (Input.GetMouseButtonDown(1)) {
            Time.timeScale = slowTimeSpeed;
            Time.fixedDeltaTime = slowTimeSpeed * fixedDeltaTime;
        }
        if (Input.GetMouseButtonUp(1)) {
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedDeltaTime;
        }
        
        if (Time.fixedDeltaTime != lastTime) {
            Debug.Log("FixedDeltaTime at" + Time.fixedDeltaTime);
            lastTime = fixedDeltaTime;
        }
        if (Input.GetMouseButton(1)) {
            this.lookAt(mousePos);
            
        } else {
            this.lookAt(body.velocity);
        }
        if (Input.GetMouseButtonDown(0)) {
            this.shoot();
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedDeltaTime;
        }
        if (Input.GetMouseButton(0)) {
            this.fireCont();
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedDeltaTime;
        }

        health += Time.deltaTime/2;
        if (health > maxHealth) health = maxHealth;
	}
}
