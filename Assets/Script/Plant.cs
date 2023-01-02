using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public float health;
    protected float currentHealth;

    protected bool start;
    protected Animator anim;
    protected BoxCollider2D boxColl;

    protected virtual void Start()
    {
        currentHealth = health;
        start = false;
        anim = GetComponent<Animator>();
        boxColl = GetComponent<BoxCollider2D>();
        anim.speed = 0;
        boxColl.enabled = false;
    }

    public void SetPlantStart()
    {
        start = true;
        anim.speed = 1;
        boxColl.enabled = true;
    }
    public virtual float ChangeHealth(float num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        return currentHealth;
    }
}
