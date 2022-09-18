using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_gameOverText;
    [SerializeField] TextMeshProUGUI m_timerText;
    [SerializeField] Score m_playerScore;
    [SerializeField] Score m_opponentScore;
    [SerializeField] float m_gameTimeInSeconds=60f;
    float m_timer;
    bool m_gameIsPlaying=false;
    public static float RespawnHeight = 0.25f;


    void Start()
    {
        //set timescale to 0 to pause game
        Time.timeScale=0f;
        //set timer to game time in current round 
        m_timer=m_gameTimeInSeconds;
        //Update the timer to timer text UpdateTime()
        UpdateTimer();
    }
    void UpdateTimer()
    {
        //{0:0}:{1:00}
        m_timerText.text= string.Format("{0:0}:{1:00}",Mathf.Floor(m_timer/60),Mathf.Floor(m_timer%60));
    }
    void FixedUpdate()
    {
        if(!m_gameIsPlaying)return;
        //Subtract the done time to total time
        m_timer-=Time.fixedDeltaTime;
        //If timer hits 0 then we need to enter 0 state
        if(m_timer<=0){
            GameOver();
            m_timer=0;
        }
        UpdateTimer();
    }

    void GameOver()
    {
        m_gameIsPlaying=false;
        Time.timeScale=0f;
        string gameovertext;
        if(m_playerScore.ScoreValue>m_opponentScore.ScoreValue)
        {
            gameovertext="YOU WIN!";
        }
        else if(m_playerScore.ScoreValue<m_opponentScore.ScoreValue)
        {
            gameovertext="YOU LOSE!";
        }
        else
        {
            gameovertext="TIE";
        }

        m_gameOverText.text=gameovertext +"\n\nPress SPACE To Restart";

        m_gameOverText.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        if(!m_gameIsPlaying)
        {
            Time.timeScale=1f;
            m_gameOverText.gameObject.SetActive(false);
            m_timer=m_gameTimeInSeconds;
            m_gameIsPlaying=true;
        }
    }
}
