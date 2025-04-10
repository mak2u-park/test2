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
        if (firstCard.idx == secondCard.idx)   // ù��° ī��� �ι�° ī�尡 ������
        {
            firstCard.anim.SetBool("isMatched", true);  // ù��° ī���� �ִϸ����� �Ķ���� isMatched�� true�� �ٲ��ش�.
            secondCard.anim.SetBool("isMatched", true); // �ι�° ī���� �ִϸ����� �Ķ���� isMatched�� true�� �ٲ��ش�.
            Invoke("DestroyCard", 1f);               // 1�� �Ŀ� DestroyCard �Լ��� ȣ���Ѵ�.

            cardCount -= 2;             // ī���� ������ 2�� ���δ�.
            if (cardCount == 0)         // cardCount�� 0�� �Ǿ�����
            {
                Invoke("GameEnd", 1f);  // 1�� �Ŀ� GameEnd �Լ��� ȣ���Ѵ�.
            }
        }
        else                               // ù��° ī��� �ι�° ī�尡 �ٸ���
        {
            firstCard.CloseCard();       // ù��° ī���� CloseCard �Լ��� ȣ���Ѵ�.
            secondCard.CloseCard();      // �ι�° ī���� CloseCard �Լ��� ȣ���Ѵ�.
            firstCard = null;            // ù��° ī�带 null�� �ʱ�ȭ�Ѵ�.
            secondCard = null;           // �ι�° ī�带 null�� �ʱ�ȭ�Ѵ�.
        }
 
    }

    public void GameEnd()                  // ���� ���� �Լ�
    {
        Time.timeScale = 0.0f;
        EndTxt.SetActive(true);
    }

    public void DestroyCard()              // ī�� �ı� �Լ�
    {
        firstCard.Destroy();               // ù��° ī���� Destroy �Լ��� ȣ���Ѵ�.
        secondCard.Destroy();              // �ι�° ī���� Destroy �Լ��� ȣ���Ѵ�.
        firstCard = null;                  // ù��° ī�带 null�� �ʱ�ȭ�Ѵ�.
        secondCard = null;                 // �ι�° ī�带 null�� �ʱ�ȭ�Ѵ�. 
    }


}
