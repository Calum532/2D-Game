using UnityEngine;

public class BurstSpawner : MonoBehaviour
{
    public GameObject targetPrefab = null;
    public Vector2 center;
    public Vector2 size;

    public GameObject destroyEffect;
    public Animator camAnim;

    GameObject target;
    GameObject player;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        for(int i = 0; i < 40; i++)
        {
            SpawnTarget();
        }
    }

    void Update()
    {
        if (Pause.gameIsPaused == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                player.GetComponent<BurstScore>().clicksCount();
            }
        }
    }

    public void SpawnTarget()
    {
        Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
        Instantiate(targetPrefab, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
