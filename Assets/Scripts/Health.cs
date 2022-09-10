using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    public bool isPlayer;

    GameManager gameManager;

    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth <= 0)
        {
            //anim.SetTrigger("hurt");
            gameManager.GameOver();
        }
        
    }

    public void takeDamageEnemy(float damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth < 0)
        {
            //anim.SetTrigger("hurt");
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ProjectilePlayer" && !isPlayer)
        {
            takeDamageEnemy(1);
        }

        if(other.tag == "ProjectileEnemy" && isPlayer)
        {
            takeDamage(1);
        }

        if (other.tag == "Enemy" && isPlayer)
        {
            takeDamage(1);
        }
    }
}
