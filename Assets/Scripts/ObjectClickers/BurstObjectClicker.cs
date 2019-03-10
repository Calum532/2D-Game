using UnityEngine;

public class BurstObjectClicker : MonoBehaviour
{
    public GameObject Target = null;
    public BurstSpawner spawnerScript;
    GameObject player;
    GameObject go;
    public GameObject destroyEffect;
    public CameraShake cameraShake;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        go = GameObject.Find("Spawner");
        spawnerScript = (BurstSpawner)go.GetComponent(typeof(BurstSpawner));
        destroyEffect = go.GetComponent<BurstSpawner>().destroyEffect;
        cameraShake = go.GetComponent<BurstSpawner>().cameraShake;
}

    void Update()
    {
        if(Pause.gameIsPaused == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D coll = Target.GetComponent<Collider2D>();

                if (coll.OverlapPoint(wp))
                {
                    player.GetComponent<BurstScore>().targetsDestroyedCount();
                    Debug.Log("Target destoryed");
                    Destroy(gameObject);
                    Instantiate(destroyEffect, transform.position, Quaternion.identity);
                    go.GetComponent<BurstSpawner>().CameraShake();
                    FindObjectOfType<AudioManager>().Play("BurstBoom");
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("Laser");
                }
            }
        }
    }
}
