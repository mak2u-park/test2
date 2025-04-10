using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public Text timeTxt;
    public GameObject EndTxt;


    public int cardCount = 0;
    float time = 0f;

    public Card firstCard;
    public Card secondCard;
    public Card Card;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time > 30.0f)
        {
            Time.timeScale = 0.0f;
            EndTxt.SetActive(true);
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            firstCard.anim.SetBool("isMatched", true);
            secondCard.anim.SetBool("isMatched", true);
            Invoke("DestroyCard", 1f);

            cardCount -= 2;
            if (cardCount == 0)
            {
                Invoke("GameEnd", 1f);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            firstCard = null;
            secondCard = null;
        }
 
    }

    public void GameEnd()
    {
        Time.timeScale = 0.0f;
        EndTxt.SetActive(true);
    }

    public void DestroyCard()
    {
        firstCard.Destroy();
        secondCard.Destroy();
        firstCard = null;
        secondCard = null;
    }


}
