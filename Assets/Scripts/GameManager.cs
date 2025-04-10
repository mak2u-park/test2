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
        if (firstCard.idx == secondCard.idx)   // 첫번째 카드와 두번째 카드가 같을때
        {
            firstCard.anim.SetBool("isMatched", true);  // 첫번째 카드의 애니메이터 파라미터 isMatched를 true로 바꿔준다.
            secondCard.anim.SetBool("isMatched", true); // 두번째 카드의 애니메이터 파라미터 isMatched를 true로 바꿔준다.
            Invoke("DestroyCard", 1f);               // 1초 후에 DestroyCard 함수를 호출한다.

            cardCount -= 2;             // 카드의 개수를 2개 줄인다.
            if (cardCount == 0)         // cardCount가 0이 되었을때
            {
                Invoke("GameEnd", 1f);  // 1초 후에 GameEnd 함수를 호출한다.
            }
        }
        else                               // 첫번째 카드와 두번째 카드가 다를때
        {
            firstCard.CloseCard();       // 첫번째 카드의 CloseCard 함수를 호출한다.
            secondCard.CloseCard();      // 두번째 카드의 CloseCard 함수를 호출한다.
            firstCard = null;            // 첫번째 카드를 null로 초기화한다.
            secondCard = null;           // 두번째 카드를 null로 초기화한다.
        }
 
    }

    public void GameEnd()                  // 게임 종료 함수
    {
        Time.timeScale = 0.0f;
        EndTxt.SetActive(true);
    }

    public void DestroyCard()              // 카드 파괴 함수
    {
        firstCard.Destroy();               // 첫번째 카드의 Destroy 함수를 호출한다.
        secondCard.Destroy();              // 두번째 카드의 Destroy 함수를 호출한다.
        firstCard = null;                  // 첫번째 카드를 null로 초기화한다.
        secondCard = null;                 // 두번째 카드를 null로 초기화한다. 
    }


}
