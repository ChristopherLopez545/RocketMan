using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Missle;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // shots for the powerup 
    public List<GameObject> powerShots = new();
    public GameObject powerProPrefab;
    void Start()
    {
        playerMovement= GetComponent<PlayerMovement>();
        powerShots.Add(powerProPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)&& cooldownTimer > attackCooldown )
        {
                attack();
        }
       if (/*(Input.GetMouseButtonDown(1)*/ Input.GetKeyDown(KeyCode.LeftShift) && powerShots.Count > 0)
{
    GameObject shot = Instantiate(powerShots[0], firePoint.position, Quaternion.identity);
    shot.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    powerShots.RemoveAt(0);
}
        cooldownTimer += Time.deltaTime;
    }
    private void attack()
    {   
            // cooldownTimer =0;
            // Missle[FindMissle()].transform.position = firePoint.position;
            //   Missle[FindMissle()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
            cooldownTimer = 0;
    int index = FindMissle();

    GameObject missile = Missle[index];
    missile.transform.position = firePoint.position;
    missile.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private int FindMissle()
    {
        for(int i = 0 ; i < Missle.Length ; i++)
        {
            if(!Missle[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
