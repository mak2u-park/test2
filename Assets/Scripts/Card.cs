using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    public GameObject front;
    public GameObject back;

    public Animator anim;

    public int idx = 0;

    public bool isOpen = false;

    public SpriteRenderer frontImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite =Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return; // secondCard�� null�� �ƴ� ��쿡�� ī�� ���� �Ұ�

        anim.SetBool("isOpen", true);
        
        // firstCard�� ����ִٸ� 
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard�� �� ������ �Ѱ��ش�.
            GameManager.Instance.firstCard = this;

        }

        // firstCard�� ������� �ʴٸ�
        else
        {
            // secondCard�� �� ������ �Ѱ��ش�.
            GameManager.Instance.secondCard = this;
            // Matched �Լ��� ȣ���Ѵ�.
            GameManager.Instance.Matched();
        }
    }
    
     public void CardFlip()
    {
        front.SetActive(true);
        back.SetActive(false);
    }




    public void ReverseFlip()
    {
        front.SetActive(false);
        back.SetActive(true);
    }






     /*
    public void FlipCard()
    {

        float targetRotationY = isFlipped ? 0f : 180f; // ���� ī�� ���¿� ���� ȸ���� ���� ���� 
                                                       // isFlipped�� true��� 0��, false��� 180��

        transform.DORotate(new Vector3(0f, targetRotationY, 0f), 1f)   // ȸ�� �ִϸ��̼�


        .OnUpdate(() =>
        {
            if (transform.rotation.eulerAngles.y > 90f)
            {
                front.SetActive(false);
                back.SetActive(true);

            }
            else
            {
                front.SetActive(true);
                back.SetActive(false);
            }
        }).OnComplete(() =>
        {
            isFlipped = !isFlipped;
        });
        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }

    }


    
    public void Rotate()
    {

        if (isFlipped) return; // ī�尡 �̹� ������ ������ �ƹ��͵� ���� ����

        isFlipped = true; // ī�尡 ���������� ǥ��

        var sequence = DOTween.Sequence();   // �ִϸ��̼� �ܰ踦 ���������� ����

        // 90������ ȸ��, �߰��������� front ��Ȱ��ȭ, back Ȱ��ȭ
        sequence.Append(this.transform.DORotate(this.transform.eulerAngles + new Vector3(0f, 90f, 0f), 0.4f)).SetEase(Ease.Linear); // 90�� ȸ��, 0.4�� �ҿ�, SetEase�� �ִϸ��̼� ��/���� ȿ�� ����

        // ȸ�� �� front ��Ȱ��ȭ, back Ȱ��ȭ
        sequence.AppendCallback(() =>
        {
           frontImage.sprite = (this.transform.eulerAngles.y < 180) ? frontSpt.sprite : backSpt.sprite; // ������Ʈ y�� ȸ�� ������ 180���� �۴ٸ� forntspt�� ��������Ʈ�� ǥ��, �׷��� �ʴٸ� backSpt�� ��������Ʈ�� ǥ��
        });                                                                                             // ȸ�� �� front ��Ȱ��ȭ, back Ȱ��ȭ

        sequence.Append(this.transform.DORotate(this.transform.eulerAngles + new Vector3(0f, 180f, 0f), 0.4f)).SetEase(Ease.Linear); // �ٽ� �ѹ� 180�� ȸ��, 0.4�� �ҿ�
        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }


    }

    */

    public void Destroy()
    {
        Invoke("DestroyCardInvoke", 1f);
    }


    public void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }


    public void CloseCard()
    {
        isOpen = false;
        Invoke("ClosedCardInvoke", 0.5f);
    }


    public void ClosedCardInvoke()
    {
        anim.SetBool("isOpen", false);
    }

    public void OpenCompletely()
    {
        isOpen = true;
    }



}
