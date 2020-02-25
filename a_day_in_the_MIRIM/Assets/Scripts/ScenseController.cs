using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenseController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 4f;
    public const float offsetY = 4.5f;

    [SerializeField] private MainCard originCard;
    [SerializeField] private Sprite[] image;

    private void Start()
    {
        Vector3 startPos = originCard.transform.position;   //The position of the frist card. All other cards are offset from here.

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);    //This is a funtion we will create in a minute!

        for(int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j<gridRows; j++)
            {
                MainCard card;
                if( i==0 && j==0)
                {
                    card = originCard;
                }
                else
                {
                    card = Instantiate(originCard) as MainCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, image[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i =0; i<newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    //------------------------------------------------------------------------------------------------------------------

    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    private int _score = 0;
    [SerializeField] private TextMesh socreLable;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if(_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            socreLable.text = "Score : " + _score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unrevel();
            _secondRevealed.Unrevel();
        }

        _firstRevealed = null;
        _secondRevealed = null;

        if (_score == 4)
        {
            Invoke("Restart", 2);
        }
    }

    public void Restart()
    {
        Debug.Log("다시시작2");
        SceneManager.LoadScene("CardGame");
    }
}
