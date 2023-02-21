using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFirstARGame
{
    public class ScoreSingleton : MonoBehaviour
    {

        public static ScoreSingleton instance { get; private set; }
        public int value = 0;
        public bool gameStart = false;
        public float timeValue = 90f;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (gameStart)
            {
                timeValue -= Time.deltaTime;
            }
        
        }

        public void restart()
        {
            SceneManager.LoadScene("Game_PC", LoadSceneMode.Single);
        }
    }
}
