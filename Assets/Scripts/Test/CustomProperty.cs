using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class CustomProperty : MonoBehaviour
    {

        private ExitGames.Client.Photon.Hashtable customProperty = new ExitGames.Client.Photon.Hashtable();
        
        // Start is called before the first frame update
        void Start()
        {
            customProperty["score"] = 0;
            customProperty["gameStart"] = false;
            customProperty["timeValue"] = 90f;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
