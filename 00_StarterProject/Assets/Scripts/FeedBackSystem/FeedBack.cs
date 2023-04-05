using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceAdventure.FeedBack
{
    public class FeedBack : MonoBehaviour
    {
        [SerializeField] private GameObject feedBackObject;

        public void CreateFeedBack() => Instantiate(feedBackObject,transform.position,Quaternion.identity);
    }
}