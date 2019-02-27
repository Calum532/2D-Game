using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public GameObject Target = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D coll = Target.GetComponent<Collider2D>();

            if (coll.OverlapPoint(wp))
            {
                Debug.Log("Target destoryed");
                Destroy(gameObject);
            }
        }
    }
}
