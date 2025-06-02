using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour //intention was to build a game manger to initialise the different panels I had set up in unity
{

        public GameObject pauseMenuUI;
        public GameObject gameOverMenuUI;

        //Title scene variable
        //Control scheme scene variable
        //Game scene variable

        public bool GameIsOver = false;
        public bool GameIsPaused = false;
        
    
        private PlayerController playerControllerScript;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        input manager to player action map
        
        */
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        if gameover in playercontrollerscript.isdead == false and  game is NOT! paused 
        {
            pause();        
        } 
        
        else if in playercontrollerscript.isdead == false  and game is paused  
         {
            resume();        
        } 

        */
    }
    
   

     /* 

     void play game
     {
        scene management loadscene get active scene().buildindex
     }

     void Resume()
     {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
     }

     void Pause()
     {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
     }

     void GameOver()
     {
        if(playercontrollerscript.isDead == true)
        {
            gameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsOver = true
        }
     }


      void gameover
      {
      pause menu ui set active (true)
      time.timescale = 0f
      gam eis over = true

      switch input manager to ui action map
      }

      */




}
