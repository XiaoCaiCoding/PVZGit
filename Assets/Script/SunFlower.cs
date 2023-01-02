using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : Plant
{
    public float readyTime;
    private float timer;

    public GameObject sunPrefab;
    private int sunNum;

    protected override void Start()
    {
        base.Start();
        timer = 0;
        sunNum = 0;
    }
    private void Update()
    {
        if (!start)
            return;
        timer += Time.deltaTime;
        if (timer >= readyTime)
        {
            anim.SetBool("Ready",true);
        }
    }
    /// <summary>
    /// AnimationEvent
    /// </summary>
    public void BornSunOver()
    {
        BornSun();
        anim.SetBool("Ready", false);
        timer = 0;
    }
    private void BornSun()
    {
        GameObject newSun = Instantiate(sunPrefab);
        //阳光在植物两边生成
        sunNum += 1;
        float randomX;
        if (sunNum % 2 == 1)
        {
            randomX = Random.Range(transform.position.x - 30, transform.position.x - 20);
        }
        else
        {
            randomX = Random.Range(transform.position.x + 20, transform.position.x + 30);
        }
        float randomY = Random.Range(transform.position.y - 20, transform.position.y + 20);
        //TODO: 需要优化动画，不能直接在目标位置生成阳光
        newSun.transform.position = new Vector2(randomX, randomY);
    }
}
