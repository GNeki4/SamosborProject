using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public float damage;
    public float range;
    public float attackCD;

    public Camera fpsCam;
    private AudioSource attackSound;
    private float attackTimer;

    private void Start()
    {
        attackSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;

        if (Input.GetButton("Fire1") && attackTimer >= attackCD)
        {
            Attack();
        }
    }

    void Attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                attackSound.Play();
                target.TakeDamage(damage);
            }
        }
        attackTimer = 0;
    }
}
