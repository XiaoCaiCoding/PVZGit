 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNormal : MonoBehaviour
{
    public Vector3 direction = new Vector3(-1, 0, 0);
    public float speed = 1.0f;
    private bool isWalk;
    private Animator anim;

    public float damage;
    public float damageInterval = 0.5f;
    private float damageTimer;

    public float health = 100;
    private float currentHealth;
    public float lostHeadHealth = 50;
    private GameObject head;
    private bool isLostHead;
    private bool isDie;
    private void Start()
    {
        isWalk = true;
        anim = GetComponent<Animator>();

        currentHealth = health;
        head = transform.Find("Head").gameObject;
        isLostHead = false;
        isDie = false;
    }
    private void Update()
    {
        if (isDie)
            return;
        if (isWalk)
        {
            Move();
        }
    }
    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Plant")
        {
            isWalk = false;
            anim.SetBool("Walk", isWalk);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (isDie)
            return;
        if(other.tag == "Plant")
        {
            //
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                //TODO: 对植物造成伤害
                Plant plant = other.GetComponent<Plant>();
                float newCurrentHealth = plant.ChangeHealth(-damage);
                if (newCurrentHealth <= 0)
                {
                    isWalk = true;
                    anim.SetBool("Walk", isWalk);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Plant")
        {
            //离开植物
            isWalk = true;
            anim.SetBool("Walk", isWalk);
        }
    }
    public void ChangeHealth(float num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
        if (currentHealth <= lostHeadHealth && !isLostHead)
        {
            isLostHead = true;
            anim.SetBool("LostHead", isLostHead);
            head.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            isDie = true;
            anim.SetTrigger("Die");
        }
    }
    public void DieAniOver()
    {
        anim.enabled = false;
        Destroy(gameObject);
    }
}
