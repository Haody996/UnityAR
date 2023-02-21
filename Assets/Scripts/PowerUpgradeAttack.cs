using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class PowerUpgradeAttack : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
				
				void OnCollisionEnter(Collision collision){
					Collider collider = collision.collider;
					if (collider.CompareTag("Ball")){
						// Debug.Log("Collided with " + collider.tag);
						// GameObject obj = GameObject.Find("Global");
            // global g = obj.GetComponent<global>();
					  // Debug.Log(g.isLargeSoccer);
						MyFirstARGame.global.isLargeSoccer = false;
						Debug.Log(MyFirstARGame.global.isLargeSoccer);
						PhotonNetwork.Destroy(gameObject);
					}
					if (collider.CompareTag("Projectile")){
						//defense get the attack resouce
						PhotonNetwork.Destroy(gameObject);
					}
				}
    }
}
