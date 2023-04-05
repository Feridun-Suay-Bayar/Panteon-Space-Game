using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceAdventure.WeaponSystem
{
    [CreateAssetMenu(menuName = "Attacks/Spreat Attack")]
    public class SpreatAttackSO : AttackPatternSO
    {
        [SerializeField] private float _angle = 5f;

        public override void Perform(Transform shootingStartPoint)
        {
            Instantiate(_projectile, shootingStartPoint.position, shootingStartPoint.rotation);
            Instantiate(_projectile, shootingStartPoint.position, shootingStartPoint.rotation * Quaternion.Euler(Vector3.forward * _angle));
            Instantiate(_projectile, shootingStartPoint.position, shootingStartPoint.rotation * Quaternion.Euler(Vector3.forward * -_angle));
        }
    }
}