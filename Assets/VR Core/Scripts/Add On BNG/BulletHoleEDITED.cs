using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace BNG
{

    public class BulletHoleEDITED : BulletHole
    {
        [SerializeField] SphereCollider sCollider;
        protected override void Start()
        {
            base.Start();
            sCollider = this.AddComponent<SphereCollider>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (sCollider != null)
            {
                Destroy(collision.gameObject);
            }
        }

    }
}