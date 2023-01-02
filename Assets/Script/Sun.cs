using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float duration;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            timer = 0;
            Destroy(this.gameObject);
        }
    }
    private void OnMouseDown()
    {
        //TODO:播放阳光飞向文本框的动画
        Destroy(gameObject);
        //增加阳光数量
        GameManager.Instance.ChangeSunNum(25);
    }
}
