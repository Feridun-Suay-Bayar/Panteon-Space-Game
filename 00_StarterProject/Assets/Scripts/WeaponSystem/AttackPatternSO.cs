using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceAdventure.WeaponSystem
{
    public abstract class AttackPatternSO : ScriptableObject
    {
        [SerializeField] protected GameObject _projectile;
        [SerializeField] protected float _attackDelay = 0.2f;
        public float AttackDelay => _attackDelay;

        [SerializeField] protected AudioClip _weaponSFX;
        public AudioClip WeaponSFX => _weaponSFX;

        public abstract void Perform(Transform shootingStartPoint);

    }
}

