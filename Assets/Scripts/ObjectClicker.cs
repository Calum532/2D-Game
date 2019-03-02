using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public GameObject Target = null;
    public Spawner spawnerScript;
    GameObject player;
    GameObject go;
    public GameObject destroyEffect;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        go = GameObject.Find("Spawner");
        spawnerScript = (Spawner)go.GetComponent(typeof(Spawner));
        destroyEffect = go.GetComponent<Spawner>().destroyEffect;
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
                    player.GetComponent<Score>().targetsDestroyedCount();
                    Debug.Log("Target destoryed");
                    Destroy(gameObject);
                    Instantiate(destroyEffect, transform.position, Quaternion.identity);
                    spawnerScript.SpawnTarget();
                }
                else
                {
                    player.GetComponent<Score>().clicksMissedCount();
                }
            }
        }
    }
}
