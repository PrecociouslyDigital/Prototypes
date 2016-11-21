using UnityEngine;
using System.Collections;

public class Player : MoveEntity {
    float aimTime = 0;
    float slowRate = 0.04F;
	void Update () {
        Vector2 mousePos = (Vector2)Input.mousePosition - new Vector2(Screen.width/2, Screen.height/2);
        this.moveTowards(mousePos);
        if (Input.GetMouseButtonDown(0)) {
            this.shoot();
        }
                
        if (Input.GetMouseButtonDown(1))
            TimeController.targetTime = slowRate;
	}
}
