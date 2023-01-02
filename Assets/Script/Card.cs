using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject curGameObject;
    private GameObject darkBg;
    private GameObject progress;
    public float waitTime;
    public int useSun;
    private float timer;
    private void Start()
    {
        darkBg = transform.Find("dark").gameObject;
        progress = transform.Find("progress").gameObject;
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        UpdateProgress();
        UpdateDarkBg();
    }
    private void UpdateProgress()
    {
        float per = Mathf.Clamp(timer / waitTime, 0, 1);
        progress.GetComponent<Image>().fillAmount = 1 - per;
    }
    private void UpdateDarkBg()
    {
        //TODO: && useSun>��ǰ����������
        if (progress.GetComponent<Image>().fillAmount == 0 && GameManager.Instance.sunNum >= useSun)
            darkBg.SetActive(false);
        else
            darkBg.SetActive(true);
    }

    //��ק��ʼ
    public void OnBeginDrag(BaseEventData data)
    {
        if (darkBg.activeSelf)
            return;
        //Debug.Log("OnBeginDrag" + data.ToString());
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject = Instantiate(objectPrefab);
        curGameObject.transform.position = TranslateScreenToWorld(pointerEventData.position);
    }
    public void OnDrag(BaseEventData data)
    {
        if(curGameObject == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject.transform.position = TranslateScreenToWorld(pointerEventData.position);
    }
    public void OnEndDrag(BaseEventData data)
    {
        //Debug.Log("OnEndDrag" + data.ToString());
        if(curGameObject == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        //�õ��������λ�õ���ײ��
        Collider2D[] coll = Physics2D.OverlapPointAll(TranslateScreenToWorld(pointerEventData.position));
        foreach (var c in coll)
        {
            if(c.tag=="land"&&c.transform.childCount == 0)
            {
                //�ѵ�ǰ�������Ϊ�����ص�������
                curGameObject.transform.parent = c.transform;
                curGameObject.transform.localPosition = Vector3.zero;
                curGameObject.GetComponent<Plant>().SetPlantStart();

                //����Ĭ��ֵ�����ɽ���
                curGameObject = null;
                GameManager.Instance.ChangeSunNum(-useSun);
                //���ü�ʱ��
                timer = 0;

                break;
            }
        }

        if (curGameObject != null)
        {
            GameObject.Destroy(curGameObject);
            curGameObject = null;
        }
    }

    public static Vector3 TranslateScreenToWorld(Vector3 positon)
    {
        Vector3 cameraTranslatePos = Camera.main.ScreenToWorldPoint(positon);
        return new Vector3(cameraTranslatePos.x, cameraTranslatePos.y, 0);
    }
}
