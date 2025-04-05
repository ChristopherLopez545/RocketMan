using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Missle;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement= GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)&& cooldownTimer > attackCooldown )
        {
                attack();
        }

        cooldownTimer += Time.deltaTime;
    }
    private void attack()
    {
            cooldownTimer =0;
            Missle[FindMissle()].transform.position = firePoint.position;
              Missle[FindMissle()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

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
