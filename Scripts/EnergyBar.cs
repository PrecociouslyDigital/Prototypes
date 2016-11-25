using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {
    public float maxScale;
    public void set(float num) {
        transform.localScale = new Vector3(0.3f, Mathf.Clamp01(num) * maxScale, 1);
    }
}
