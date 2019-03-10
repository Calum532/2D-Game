using UnityEngine;

public class EnduranceSpawner : MonoBehaviour
{
    public GameObject targetPrefab = null;
    public Vector2 center;
    public Vector2 size;

    public GameObject destroyEffect;
    public CameraShake cameraShake;

    GameObject target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target");
    }

    void Start()
    {
        SpawnTarget();
    }

    public void CameraShake()
    {
        StartCoroutine(cameraShake.Shake(.1f, .15f));
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
