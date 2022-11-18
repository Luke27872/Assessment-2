using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject target;
    private float targetPosX;
    public float moveSpeed = 5f;
    private Vector3 mousePos;
    public Vector3 currentPos;

    public Animator animator;
    public GameObject deathEffect;
    public GameController gameController;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameController.startTimer = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        targetPosX = target.transform.position.x;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        currentPos = gameObject.transform.position;

        if (targetPosX < mousePos.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (targetPosX > mousePos.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Damage");

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        gameController.startTimer = false;
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(0.42f);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}