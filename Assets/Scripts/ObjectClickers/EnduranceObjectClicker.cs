using UnityEngine;

public class EnduranceObjectClicker : MonoBehaviour
{
    public GameObject Target = null;
    public EnduranceSpawner spawnerScript;
    GameObject player;
    GameObject go;
    public GameObject destroyEffect;
    public CameraShake cameraShake;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        go = GameObject.Find("Spawner");
        spawnerScript = (EnduranceSpawner)go.GetComponent(typeof(EnduranceSpawner));
        destroyEffect = go.GetComponent<EnduranceSpawner>().destroyEffect;
        cameraShake = go.GetComponent<EnduranceSpawner>().cameraShake; ;
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
                    player.GetComponent<EnduranceScore>().targetsDestroyedCount();
                    Debug.Log("Target destoryed");
                    Destroy(gameObject);
                    Instantiate(destroyEffect, transform.position, Quaternion.identity);
                    go.GetComponent<EnduranceSpawner>().CameraShake();
                    spawnerScript.SpawnTarget();
                    FindObjectOfType<AudioManager>().Play("EnduranceBoom");
                    player.GetComponent<EnduranceCountdown>().addTime();
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("Laser");
                    player.GetComponent<EnduranceScore>().clicksMissedCount();
                }
            }
        }
    }
}
