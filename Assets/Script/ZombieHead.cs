using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHead : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void DieAniOver()
    {
        anim.enabled = false;
        Destroy(gameObject);
    }
}
