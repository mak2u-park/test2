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
        if (GameManager.Instance.secondCard != null) return; // secondCard가 null이 아닐 경우에는 카드 오픈 불가

        anim.SetBool("isOpen", true);
        
        // firstCard가 비어있다면 
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard에 내 정보를 넘겨준다.
            GameManager.Instance.firstCard = this;

        }

        // firstCard가 비어있지 않다면
        else
        {
            // secondCard에 내 정보를 넘겨준다.
            GameManager.Instance.secondCard = this;
            // Matched 함수를 호출한다.
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

        float targetRotationY = isFlipped ? 0f : 180f; // 현재 카드 상태에 따라 회전할 각도 설정 
                                                       // isFlipped가 true라면 0도, false라면 180도

        transform.DORotate(new Vector3(0f, targetRotationY, 0f), 1f)   // 회전 애니메이션


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

        if (isFlipped) return; // 카드가 이미 뒤집혀 있으면 아무것도 하지 않음

        isFlipped = true; // 카드가 뒤집혔음을 표시

        var sequence = DOTween.Sequence();   // 애니메이션 단계를 순차적으로 실행

        // 90도까지 회전, 중간지점에서 front 비활성화, back 활성화
        sequence.Append(this.transform.DORotate(this.transform.eulerAngles + new Vector3(0f, 90f, 0f), 0.4f)).SetEase(Ease.Linear); // 90도 회전, 0.4초 소요, SetEase는 애니메이션 가/감속 효과 설정

        // 회전 후 front 비활성화, back 활성화
        sequence.AppendCallback(() =>
        {
           frontImage.sprite = (this.transform.eulerAngles.y < 180) ? frontSpt.sprite : backSpt.sprite; // 오브젝트 y축 회전 각도가 180보다 작다면 forntspt의 스프라이트를 표시, 그렇지 않다면 backSpt의 스프라이트를 표시
        });                                                                                             // 회전 후 front 비활성화, back 활성화

        sequence.Append(this.transform.DORotate(this.transform.eulerAngles + new Vector3(0f, 180f, 0f), 0.4f)).SetEase(Ease.Linear); // 다시 한번 180도 회전, 0.4초 소요
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
