using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour{
    public short bullets;
    public float rof;
    public float accuracy;
    public float nextFireTime = 0;
    public LineRenderer bulletRenderer;
    public bool automatic = false;
    public AudioClip fireSound;
    public AudioClip click;
    public AudioSource audioSource;
    public LayerMask[] layersPotential;
    public Light flare;
    private float flareEndTime = 0f;
    public float flarePersistTime = 0.1f;
    
    public void Start() {
        if(bulletRenderer == null) {
            bulletRenderer = GetComponent<LineRenderer>();
        }
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if(flare == null)
            flare = GetComponentInChildren<Light>();
    }
    public void Update() {
        if (flareEndTime != 0) {
            if(Time.time > flareEndTime) {
                flareEndTime = 0;
                bulletRenderer.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
                flare.enabled = false;
            }
        }
    }

    public virtual void fire() {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + 1 / rof;
        if(bullets < 1) {
            audioSource.PlayOneShot(click);
            return;
        }
        Vector3 direction = transform.up + (Vector3)Random.insideUnitCircle * accuracy;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up, direction, 100, layersPotential[Random.Range(0, layersPotential.Length)]);
        if (hit) {
            if (hit.transform.name == "Player") {
                //Debug.Break();
                Player player = hit.transform.GetComponent<Player>();
                player.health -= 1;
                
                if (player.health < 0) {
                    player.die();
                }
                fire();
            } else {
                if (hit.transform.GetComponent<Entity>()) {
                    hit.transform.GetComponent<Entity>().die();
                }
                bulletRenderer.SetPositions(new Vector3[] { transform.position, hit.point });
                //Debug.Log(hit.point);
                //Debug.Break();
            }
        } else {
            bulletRenderer.SetPositions(new Vector3[] { transform.position, transform.position + direction * 100 });
        }
        audioSource.PlayOneShot(fireSound);
        flare.enabled = true;
        flareEndTime = Time.time + flarePersistTime;
    }
    public virtual void fireCont() {
        if (automatic)
            fire();
    }
    public void destroy() {
        
    }

}