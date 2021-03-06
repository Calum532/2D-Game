﻿using UnityEngine;

public class RushObjectClicker : MonoBehaviour
{
    public GameObject Target = null;
    public RushSpawner spawnerScript;
    GameObject player;
    GameObject go;
    public GameObject destroyEffect;
    public CameraShake cameraShake;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        go = GameObject.Find("Spawner");
        spawnerScript = (RushSpawner)go.GetComponent(typeof(RushSpawner));
        destroyEffect = go.GetComponent<RushSpawner>().destroyEffect;
        cameraShake = go.GetComponent<RushSpawner>().cameraShake; ;
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
                    player.GetComponent<RushScore>().targetsDestroyedCount();
                    Debug.Log("Target destoryed");
                    Destroy(gameObject);
                    Instantiate(destroyEffect, transform.position, Quaternion.identity);
                    go.GetComponent<RushSpawner>().CameraShake();
                    spawnerScript.SpawnTarget();
                    FindObjectOfType<AudioManager>().Play("RushBoom");
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("Laser");
                    player.GetComponent<RushScore>().clicksMissedCount();
                }
            }
        }
    }
}
