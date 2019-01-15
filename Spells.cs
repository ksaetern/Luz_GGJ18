using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenvaVR;

public class Spells : MonoBehaviour {

    public ObjectPool Fire;
    public ObjectPool Ice;
    public ObjectPool Light;
    public ObjectPool Heal;
    private Transform Boss;
    public PlayerHealth playa;

    private void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Cast(string element)
    {
        switch (element)
        {
            case "Fire":
                Spellcast(Fire);
                break;
            case "Ice":
                Spellcast(Ice);
                break;
            case "Light":
                Spellcast(Light);
                break;
            case "Heal":
                Healz(Heal);
                break;

        }
    }

    private void Healz(ObjectPool prefab)
    {
        //GameObject spell = Instantiate(prefab, transform.position, transform.rotation);
        GameObject spell = prefab.GetObj();
        if (spell)
        {
            spell.transform.position = transform.position;
            spell.transform.rotation = transform.rotation;
        }
        playa.Heal(20f);
    }


    public void Spellcast(ObjectPool prefab)
    {
        LookAtBoss();
        //GameObject spell = Instantiate(prefab, transform.position, transform.rotation);
        GameObject spell = prefab.GetObj();
        if (spell)
        {
            spell.transform.position = transform.position;
            spell.transform.rotation = transform.rotation;
            spell.GetComponent<Rigidbody>().velocity = spell.transform.forward * 10f;
        }
        
    }

    public void LookAtBoss()
    {
        // Debug.Log("Look mofo");

        Vector3 direction = (Boss.position - transform.position).normalized;
        direction.y = 0;
        if (direction == Vector3.zero)
            direction = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0f);
    }
}
