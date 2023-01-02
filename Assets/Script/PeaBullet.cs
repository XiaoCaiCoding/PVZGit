using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float bulletDamage;
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombie")
        {
            other.GetComponent<ZombieNormal>().ChangeHealth(-bulletDamage);
            //TODO:������Ч��Ȼ��ݻ��ӵ�
            Destroy(gameObject);
        }
    }

}
