using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyFirstARGame
{
    public class TextShowScoreScript : MonoBehaviour
    {

        public Text content;
        public int score;
        
        // Start is called before the first frame update
        void Start()
        {
            score = 0;
            content.text = "";
        }

        // Update is called once per frame
        void Update()
        {
            GameObject nm = GameObject.Find("NetworkManager(Clone)");
            if (nm != null)
            {
                NetworkCommunication nc = nm.GetComponent<NetworkCommunication>();
                content.text = "Score: " + nc.score.ToString()
                + "\nTime left: " + ShowTime(nc.timeLeft);
            }

        }

        string ShowTime(float timeVal)
        {
            string result = "";
            if(timeVal < 0f)
            {
                timeVal = 0f;
            }
            float minutes = Mathf.FloorToInt(timeVal / 60);
            float seconds = Mathf.FloorToInt(timeVal % 60);

            result = string.Format("{0:00}:{1:00}", minutes, seconds);
            return result;
        }
    }
}
