using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceAdventure.HealthSystem
{
    public class Health : MonoBehaviour, IHittable
    {
        [SerializeField] public int CurrentHealth;

        public UnityEvent OnDeath, OnHit;

        public void InitializeHealth(int startingHealth)
        {
            if (startingHealth < 0)
            {
                startingHealth = 0;
            }
            CurrentHealth = startingHealth;
        }

        public void GetHit(int damageValue, GameObject sender)
        {
            CurrentHealth -= damageValue;
            if (CurrentHealth <= 0)
            {
                OnDeath.Invoke();
            }
            else
            {
                OnHit.Invoke();
            }
        }
    }
}