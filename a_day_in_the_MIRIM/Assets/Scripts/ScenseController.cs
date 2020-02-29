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

    private bool isbool = false;

    [SerializeField] private MainCard originCard;
    [SerializeField] private Sprite[] image;
    public float LimiTime;

    [SerializeField] public TextMesh socreLable;
    public GameObject panel;
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
    private void Update()
    {
        if (LimiTime > 0)
        {
            LimiTime -= Time.deltaTime;
            socreLable.text = "T I M E : " + (int)LimiTime;
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
            Destroy(gameObject);

            GameObject ScoreOb = GameObject.Find("SoundObject");
            ScoreOb.GetComponent<N_score>().Score_up(10 * ScoreOb.GetComponent<N_score>().CardGame);
            ScoreOb.GetComponent<N_score>().CardGame = 2;
        }
     }

    public void NextScence()
    {
        SceneManager.LoadScene("AfterSchoolB_Scene");
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
        isbool = true;
        SceneManager.LoadScene("CardGame");     // 씬 전환으로 해서 시간데이터를 전달하면 될거같은데 데이터 전달할줄 몰라요...^^
    }
}
