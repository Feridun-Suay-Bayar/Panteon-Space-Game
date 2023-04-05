using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceAdventure.WeaponSystem
{
    [CreateAssetMenu(menuName = "Attacks/Double Barrel Attack")]
    public class DoubleBarrelAttackSO : AttackPatternSO
    {
        [SerializeField] private float _offsetFromShootingPoint = 0.3f;
        public override void Perform(Transform shootingStartPoint)
        {
            Vector3 offsetVector = shootingStartPoint.rotation * new Vector3(_offsetFromShootingPoint,0,0);

            Vector3 point1 = shootingStartPoint.position + offsetVector;
            Vector3 point2 = shootingStartPoint.position - offsetVector;

            Instantiate(_projectile, point1, shootingStartPoint.rotation);
            Instantiate(_projectile, point2, shootingStartPoint.rotation);
        }

    }
}