using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public RectTransform healthBar;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene("Menu");
        }
        healthBar.sizeDelta = new Vector2((int)400*(currentHealth/100f), healthBar.sizeDelta.y);
    }
}
