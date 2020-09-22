using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuarterHeartUI : MonoBehaviour
{
    [SerializeField] Image[] heartSlots;
    [SerializeField] Sprite[] hearts;

    int currentHealth;
    int maxHealth;
    int healthPerQuarter; //How much health points does each section represent
    int healthPerHeart;


    void Update()
    {

        //int wholeHearts = (int) (currentHealth % healthPerHeart);
        //int quaterHearts = (currentHealth - (wholeHearts * healthPerHeart)) % healthPerQuarter;
        //for (int i = 0; i < wholeHearts; i++)
        //{
        //    heartSlots[i].sprite = hearts[0];
        //}

        //heartSlots[wholeHearts].sprite = hearts[0];

    }

    public void Initialize (int maxHealth)
    {
        this.maxHealth = maxHealth;
        HealthChanged(maxHealth);

        healthPerQuarter = (int)(maxHealth / (heartSlots.Length * 4f));
        healthPerHeart = (int)(healthPerQuarter * 4f);
    }

    public void HealthChanged (int currentHealth)
    {
        this.currentHealth = currentHealth;
        if (currentHealth > 0)
        {
            int wholeHearts = currentHealth / healthPerHeart;
            int quaterHearts = (maxHealth - wholeHearts * healthPerHeart) % wholeHearts;
            for (int i = 0; i < quaterHearts; i++)
            {
                heartSlots[i].sprite = hearts[4];
            }

            for (int i = quaterHearts; i < heartSlots.Length; i++ )
            {
                heartSlots[i].sprite = hearts[0];
            }
            heartSlots[wholeHearts].sprite = hearts[quaterHearts];
        }
        else
        {
            for (int i = 0; i < heartSlots.Length; i++)
            {
                heartSlots[i].sprite = hearts[0];
            }
        }

       

        return;
        for (int i = 0; i < heartSlots.Length; i++)
        {
            if (currentHealth >= ((healthPerQuarter * 4) + healthPerQuarter * 4 * i))
            {
                heartSlots[i].sprite = hearts[0];
            }
            else if (currentHealth >= ((healthPerQuarter * 3)) + healthPerQuarter * 4 * i)
            {
                heartSlots[i].sprite = hearts[1];
            }
            else if (currentHealth >= ((healthPerQuarter * 2)) + healthPerQuarter * 4 * i)
            {
                heartSlots[i].sprite = hearts[2];
            }
            else if (currentHealth >= ((healthPerQuarter * 1)) + healthPerQuarter * 4 * i)
            {
                heartSlots[i].sprite = hearts[3];
            }
            else
            {
                heartSlots[i].sprite = hearts[4];
            }
        }
    }
}