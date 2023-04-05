using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceAdventure.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] List<AttackPatternSO> _weapons;
        private int _index = 0;
        [SerializeField] AudioClip _weaponSwapSound;

        public bool shootingDelayed;

        [SerializeField] private AttackPatternSO _attackPattern;
        [SerializeField] private Transform _shootingStartPoint;

        public GameObject projectile;

        public AudioSource gunAudio;
        
        public void SwapWeapon()
        {
            _index++;
            if (_index >= _weapons.Count)
            {
                _index= 0;
            }
            _attackPattern = _weapons[_index];
            gunAudio.PlayOneShot(_weaponSwapSound);
        }

        public void PerformedAttack()
        {
            if (shootingDelayed == false)
            {
                shootingDelayed = true;
                gunAudio.PlayOneShot(_attackPattern.WeaponSFX);
                //GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);
                _attackPattern.Perform(_shootingStartPoint);
                StartCoroutine(DelayShooting());
            }
        }
        private IEnumerator DelayShooting()
        {
            yield return new WaitForSeconds(_attackPattern.AttackDelay);
            shootingDelayed = false;
        }

    }
}

