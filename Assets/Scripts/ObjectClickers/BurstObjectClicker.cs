using UnityEngine;

public class BurstObjectClicker : MonoBehaviour
{
    public GameObject Target = null;
    public BurstSpawner spawnerScript;
    GameObject player;
    GameObject go;
    public GameObject destroyEffect;
    public Animator camAnim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        go = GameObject.Find("Spawner");
        spawnerScript = (BurstSpawner)go.GetComponent(typeof(BurstSpawner));
        destroyEffect = go.GetComponent<BurstSpawner>().destroyEffect;
        camAnim = go.GetComponent<BurstSpawner>().camAnim;
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
                    camAnim.SetTrigger("shake");
                }
            }
        }
    }
}
