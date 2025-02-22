using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] card;
    public List<Sprite> gameCard = new List<Sprite>();
    public List<Button> btns = new List<Button>();

    private bool firstGuess , seconGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex , seconGuessIndex;

    private string firstGuessCard , seconGuessCard ;

    public GameObject GameWin;

    void Awake()
    {
        card = Resources.LoadAll<Sprite>("Images/Ảnh/Monters");
    }
    // Start is called before the first frame update
    void Start()
    {
        GetButton ();
        AddList();
        AddgameCardes();
        Shuffle(gameCard);

        gameGuesses = gameCard.Count / 2;
    }

    void GetButton(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("cardBtns");
        for (int i = 0; i < objects.Length; i++ ){
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }

    }
    void AddgameCardes(){
        int looper = btns.Count;
        int index = 0;

        for(int i = 0; i <looper; i++){
            if(index == looper/2){
                index= 0;
            }
            gameCard.Add(card[index]);
            index++;
        }
    }
    void AddList(){
        foreach( Button btn in btns){
            btn.onClick.AddListener(() => PickCard());
        }
    }
    public void PickCard(){
       // string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        
        if(!firstGuess){
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        
            firstGuessCard = gameCard[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gameCard[firstGuessIndex];
        }
        else if(!seconGuess){
            
            seconGuess = true;
            seconGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
           
            seconGuessCard = gameCard[seconGuessIndex].name;
            btns[seconGuessIndex].image.sprite = gameCard[seconGuessIndex];

            if(firstGuessCard == seconGuessCard){
                print("Card đúng");
            }else{
                print("Card sai");
            }

            StartCoroutine(CheckTheCardDung());
        }
    }

    IEnumerator CheckTheCardDung(){
         yield return new WaitForSeconds(0.2f);
        if(firstGuessCard == seconGuessCard){
            yield return new WaitForSeconds(0.2f);
            btns[firstGuessIndex].interactable = false;
            btns[seconGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0 ,0);
            btns[seconGuessIndex].image.color = new Color(0, 0, 0 ,0);

            CheckTheGameFinished();
        }
        else{
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[seconGuessIndex].image.sprite = bgImage;
        }
         yield return new WaitForSeconds(0.2f);
         firstGuess = seconGuess = false;


    }
    void CheckTheGameFinished(){
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses){
            print("game finished");
            GameWin.SetActive(true);
            print("it tool you" + countGuesses + " ");
        }
    }
    public void Exit(){
        print("Exit");
    }
    void Shuffle(List<Sprite> list){
        for(int i = 0; i < list.Count; i++)
{
        Sprite temp = list[i];
        int randomIndex = Random.Range(i, list.Count);
        list[i] = list[randomIndex];
        list[randomIndex] = temp;
}    }
}
