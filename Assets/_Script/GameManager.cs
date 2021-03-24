using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    #region Private Properties

    public int _coinCount = 0;
    public int _livesCount = 1;
    int _scoreCount = 0;
    int _time = 400;
    int _currentLevel = 0;
    bool _isGameOver = false;
    bool _isStart = true;
    bool _isPaused = false;
        
    #endregion

    void Awake()
    {
        if(GameManager.Instance == null){
            GameManager.Instance = this.GetComponent<GameManager>();
        }
        else if (GameManager.Instance != null && GameManager.Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }    
    
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.UpdateLives(_livesCount);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart)
        {
            UIManager.Instance.ShowInitText();
            UIManager.Instance.ShowTextStart();
            if (Input.GetButtonDown("Submit"))
            {
                UIManager.Instance.HideInitText();
                UIManager.Instance.HideTextStart();
                _isStart = false;
            }
        }
        if (_isGameOver)
        {
            UIManager.Instance.ShowGameOver();
            UIManager.Instance.ShowTextStart();
            if (Input.GetButtonDown("Submit"))
            {
                UIManager.Instance.HideGameOver();
                UIManager.Instance.HideTextStart();
                SceneManager.LoadScene(0);
                _isStart = true;
                _isGameOver = false;
            }
        }

        UIManager.Instance.UpdateCoins(_coinCount);
        //UIManager.Instance.UpdateTime(_time);
        FuntionTime();
    }

    public void FuntionTime(){
        _time--;
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
	yield return new WaitForSeconds(1000);
    }

    public void AddCoin(){
        _coinCount++;
    }

    public void UpdateLives(int lives){

        _livesCount += lives;

        if (_livesCount < 0)
        {
            _isGameOver = true;            
        }else{
            SceneManager.LoadScene(0);
            UIManager.Instance.UpdateLives(_livesCount);
        }
    }
    
}
