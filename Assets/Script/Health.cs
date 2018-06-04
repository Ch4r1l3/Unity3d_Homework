using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{

    public const int maxHealth = 1000;
    public int currentHealth = 0;
    public Image healthBar;

    

    public void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void FixedUpdate()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }


}