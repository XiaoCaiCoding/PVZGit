using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Plant
{
    public float interval;
    public float timer;

    public GameObject peaBullet;
    public Transform bulletPos;


    private void Update()
    {
        if (!start)
            return;
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0;
            Instantiate(peaBullet, bulletPos.position, Quaternion.identity);
        }
    }

}
