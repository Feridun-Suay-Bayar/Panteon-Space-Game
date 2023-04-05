using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceAdventure.WeaponSystem
{
    [CreateAssetMenu(menuName = "Attacks/Default Attack")]
    public class DefaultAttackSO : AttackPatternSO
    {
        public override void Perform(Transform shootingStartPoint)
        {
            Instantiate(_projectile,shootingStartPoint.position,shootingStartPoint.rotation);
        }
    }
}

