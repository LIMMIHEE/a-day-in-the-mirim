using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject Book;
    private static GameManager _instence;
    public static GameManager instence
    {
        get
        {
            if (_instence == null)
            {
                _instence = FindObjectOfType<GameManager>();

            }
            return _instence;
        }
    }

    public int score;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        CreateBook();
        StartCoroutine(CrateBookRotation());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CrateBookRotation()
    {
        while (true)
        {
            CreateBook();
            yield return new WaitForSeconds(1);
        }
            
    }


    public void Score()
    {
        score++;
        ScoreText.text = "Score : " + score;
    }
    private void CreateBook()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f,1.0f),1.1f,0));
        pos.z = 0.0f;
        Instantiate(Book, pos, Quaternion.identity);    // Quaternion.identity = 회전 하지 않음/
    }
}
