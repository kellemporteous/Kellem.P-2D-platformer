using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class UI_Manager : MonoBehaviour {

    Sound_Manager soundManager;

    public GameObject pauseMenu;
    Game_Manager gameManager;
    Player player;

    public AudioClip buttonSound;
    public AudioClip clickSound;

    public float time;

    public Text score;
    public Text health;
    public Text timer;
    public Text currentTime;
    public Text currentScore;

	// Use this for initialization
	void Start ()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Game_Manager>();
        soundManager = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<Sound_Manager>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        score.text = "Score: " + gameManager.score;
        health.text = player.currentHealth + "/3";
        timer.text = "Time: " + time;
        currentScore.text = "Current Score: " + gameManager.score;
        currentTime.text = "Current Time: " + time;
        Pause();
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundManager.PlaySound(buttonSound);

            if (Time.timeScale == 1)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void Restart()
    {
        soundManager.PlaySound(clickSound);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        soundManager.PlaySound(clickSound);
        SceneManager.LoadScene("Main Menu");
    }
}
