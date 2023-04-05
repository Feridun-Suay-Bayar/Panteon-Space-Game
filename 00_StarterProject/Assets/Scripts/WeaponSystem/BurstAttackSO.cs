using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceAdventure.WeaponSystem
{
    [CreateAssetMenu(menuName = "Attacks/Burst Attack")]
    public class BurstAttackSO : AttackPatternSO
    {
        [SerializeField] private float _offset;
        public override void Perform(Transform shootingStartPoint)
        {
            Vector3 offsetDirection = shootingStartPoint.rotation * new Vector3(0,_offset,0);

            Instantiate(_projectile, shootingStartPoint.position, shootingStartPoint.rotation);
            Instantiate(_projectile, shootingStartPoint.position + offsetDirection, shootingStartPoint.rotation);
            Instantiate(_projectile, shootingStartPoint.position - offsetDirection, shootingStartPoint.rotation);
        }
    }
}