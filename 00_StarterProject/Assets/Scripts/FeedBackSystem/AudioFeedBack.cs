using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceAdventure.FeedBack
{
    public class AudioFeedBack : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        // Start is called before the first frame update
        void Start()
        {
            _audioSource.PlayOneShot(_audioClip);
            StartCoroutine(DestroyAfterFinishedPlayed());
        }

        private IEnumerator DestroyAfterFinishedPlayed()
        {
            yield return new WaitForSeconds(_audioClip.length);
            Destroy(gameObject);
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}