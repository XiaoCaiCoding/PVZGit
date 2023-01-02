using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIManager : Singleton<UIManager>
{
    public Text sunNumText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitUI()
    {
        sunNumText.text = GameManager.Instance.sunNum.ToString();
    }
    public void UpdateUI()
    {
        sunNumText.text = GameManager.Instance.sunNum.ToString();
    }
}
