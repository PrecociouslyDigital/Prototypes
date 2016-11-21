using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {
    public static float changeSpeed = 4;
    public static float targetTime = 1;
    private static float fixedDeltaTime;
    public static bool slowed;
    void Start() {
        fixedDeltaTime = Time.fixedDeltaTime;
    }
	void Update () {
        Time.timeScale = Mathf.Clamp(Time.timeScale - Time.deltaTime * changeSpeed,targetTime,1);
        slowed = Time.timeScale != 1;
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
	}
    public static void reset() {
        targetTime = 1;
        Time.timeScale = 1;
    }
}
