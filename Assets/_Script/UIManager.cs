using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    #region Inspector Properties
    [SerializeField] Text gameOverText;
    [SerializeField] Text InitText;
    [SerializeField] Text startText;
    [SerializeField] Text playerLivesText;
    [SerializeField] Text playerCoinsText;
    [SerializeField] Text playerTime;
    #endregion
    
    void Awake()
    {
        if(UIManager.Instance == null){
            UIManager.Instance = this.GetComponent<UIManager>();
        }
        else if (UIManager.Instance != null && UIManager.Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
    public void HideGameOver()
    {
        gameOverText.gameObject.SetActive(false);
    }
    public void ShowInitText()
    {
        InitText.gameObject.SetActive(true);
    }
    public void HideInitText()
    {
        InitText.gameObject.SetActive(false);
    }
    public void ShowTextStart()
    {
        startText.gameObject.SetActive(true);
    }
    public void HideTextStart()
    {
        startText.gameObject.SetActive(false);
    }

    public void UpdateLives(int lives)
    {
        playerLivesText.text = "x " + lives;
    }

    public void UpdateCoins(int coins)
    {
        playerCoinsText.text = "x " + coins;
    }

    public void UpdateTime(int tiempo)
    {
        playerTime.text = "Time " + tiempo;
    }   
    
}
