using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private string previousScene;

    [SerializeField]
    private Sprite bgAnh;

    public Sprite[] card;

    public List<Sprite> gameCard = new List<Sprite>();
    public List<Button> btns = new List<Button>();

    private bool firsyGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGueses;

    private int firstGuessIndex, secondGuessIndex;

    private string firsyGuessCard, secondGuessCard;

    public GameObject WinGame;
    private void Awake(){
        card = Resources.LoadAll<Sprite>("Ảnh/AnhCard");
    }
    // Start is called before the first frame update
    void Start()
    {
        GetButton();
        AddListener();
         AddGameCard();
        
        Shuffle(gameCard);

         gameGueses = gameCard.Count / 2;
         previousScene = PlayerPrefs.GetString("PreviousScene", "Map1");
    }

    void GetButton(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("cardBtns");
        for (int i = 0; i < objects.Length; i++) {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgAnh;
        }
    }

    void AddGameCard(){
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++){
            if (index == looper/2){
                index = 0;
            }
            gameCard.Add(card[index]);
            index++;
        }
    }
    void AddListener(){
        foreach (Button btn in btns){
            btn.onClick.AddListener(() => Pickcard());
        }
    }
    public void Pickcard(){
        //string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        
        if(!firsyGuess){
            firsyGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firsyGuessCard = gameCard[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gameCard[firstGuessIndex];
        }else if (!secondGuess){
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            
            secondGuessCard = gameCard[secondGuessIndex].name;
           
            btns[secondGuessIndex].image.sprite = gameCard[secondGuessIndex];

            if(firsyGuessCard == secondGuessCard){
                print("Card đúng");
            }
            else{
                print("Card sai");
            }
            StartCoroutine(checkTheCardMatch());
        }


    }
    IEnumerator checkTheCardMatch(){
         yield return new WaitForSeconds(0.5f);

        if (firsyGuessCard == secondGuessCard){
            yield return new WaitForSeconds(0.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable= false;

            btns[firstGuessIndex].image.color = new Color( 0, 0,0, 0 );  
            btns[secondGuessIndex].image.color = new Color(0, 0,0, 0 );

            CheckTheGameFinished();

        }   
        else {
            btns[firstGuessIndex].image.sprite= bgAnh;
            btns[secondGuessIndex].image.sprite = bgAnh;
        }
         yield return new WaitForSeconds(0.2f);

         firsyGuess = secondGuess = false;  
    }
    void CheckTheGameFinished(){
        countCorrectGuesses ++;

        if(countCorrectGuesses == gameGueses){

            print("game finished");
            WinGame.SetActive(true);
            print("it took you" + countGuesses + " ");

        }
    }

    public void NextBtnClick(){
        print("next click");
    }
    public void RetryBtnClick(){
        print("retry click");
    }
    
    void Shuffle(List <Sprite>  list){
        for (int i = 0; i < list.Count ; i++) {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i , list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
