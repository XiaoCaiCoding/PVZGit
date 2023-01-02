using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int sunNum;

    public GameObject bornParent;
    public GameObject zombiePrefab;
    public float createZombieTime;
    private int zOrderIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.InitUI();
        CreateZombie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSunNum(int value)
    {
        sunNum += value;
        if (sunNum <= 0)
        {
            sunNum = 0;
        }
        UIManager.Instance.UpdateUI();
    }
    public void CreateZombie()
    {
        StartCoroutine(DelayCreateZombie());
    }
    IEnumerator DelayCreateZombie()
    {
        yield return new WaitForSeconds(createZombieTime);
        GameObject zombie = Instantiate(zombiePrefab);
        int index = Random.Range(0, 5);
        Transform zombieLine = bornParent.transform.Find("born" + index.ToString());
        zombie.transform.parent = zombieLine;
        zombie.transform.localPosition = Vector3.zero;
        zombie.GetComponent<SpriteRenderer>().sortingOrder = zOrderIndex;
        zOrderIndex++;

        StartCoroutine(DelayCreateZombie());
    }
}
