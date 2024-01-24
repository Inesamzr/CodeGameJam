using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 50;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)){
            takeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.H)){
            heal(20);
        }
        
    }

    void updateHealthBar()
    {
        healthBar.value = currentHealth;

    }

    public void takeDamage(float damage){
        this.currentHealth=currentHealth - damage;
        if (this.currentHealth<=0){
            this.currentHealth = 0;
            SceneManager.LoadScene("GameOverScene");
        }
        Debug.Log(currentHealth);
        updateHealthBar();
    }

    public void heal(float health){
        this.currentHealth+=health;
        if (this.currentHealth>=this.maxHealth){
            this.currentHealth = this.maxHealth;
        }
        Debug.Log(currentHealth);
        updateHealthBar();

    }
}
