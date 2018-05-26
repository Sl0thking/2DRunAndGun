using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public RectTransform healthBar;

<<<<<<< HEAD
=======
	
	// Update is called once per frame
	void Update () {

    }

>>>>>>> 1a72cb6cd75af5cccbae4bd7be53b917fb07306b
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
