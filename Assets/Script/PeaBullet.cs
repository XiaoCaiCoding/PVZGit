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
            //TODO:播放特效，然后摧毁子弹
            Destroy(gameObject);
        }
    }

}
