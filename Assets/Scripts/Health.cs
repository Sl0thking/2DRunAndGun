using UnityEngine;
using UnityEngine.SceneManagement;
using RunAndGun2D.CustomEvents;

public class Health : MonoBehaviour
{
    [Header ("Events")]
	public UnityEventFloat healthPercentageUpdate;

    [Header ("Attributes")]
    public int maxHealth = 100;

    [HideInInspector]
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;

            if (this.transform.root.tag == "Player")
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        // Notify UI about change of health percentage
        healthPercentageUpdate.Invoke((float) currentHealth / maxHealth);
    }
}