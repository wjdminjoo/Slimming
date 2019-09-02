using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private void Start()
    {
        //DeleteAll();
        FillList();
    }
    private void FillList()
    {
        clickAudio = GameObject.Find("pop").GetComponent<AudioSource>();

        for (var i = 0; i < 5; i++)
        {
            GameObject newbutton = Instantiate(Levelbutton, levelList[i].pos) as GameObject;

            NewLevelButton button = newbutton.GetComponent<NewLevelButton>();
            button.levelText.text = levelList[i].levelText;
            button.StageText.text = levelList[i].StageText;
            button.StageText.GetComponent<Text>().enabled = false;
            button.StageTextOutPut.text = "STAGE " + button.StageText.text + " - ";
            
            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") == 3)
            {
                levelList[i + 1].Unlocked = 1;
                levelList[i + 1].IsInteractable = true;
            }
            button.unlocked = levelList[i].Unlocked;
            button.GetComponent<Button>().interactable = levelList[i].IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => { transform.localScale = new Vector3(0.8f, 0.8f, 1.0f); clickAudio.Play(); LoadStageValue("Stage_" + button.StageText.text + "_" + button.levelText.text); });

            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") >= 1)
                button.crown1.SetActive(true);
            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") >= 2)
                button.crown2.SetActive(true);
            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") >= 3)
                button.crown3.SetActive(true);


            if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "S")
            {
                button.RankS.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "A")
            {
                button.RankA.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "B")
            {
                button.RankB.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "C")
            {
                button.RankC.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "D")
            {
                button.RankD.SetActive(true);
            }
            else
            {
                button.RnakLock.SetActive(true);
            }
            if (button.unlocked == 1)
            {
                button.RnakLock.SetActive(false);
            }

            if(button.StageText.text == "2" && button.levelText.text == "1"){
                if (PlayerPrefs.GetInt("Stage_" + 1 + "_" + 6 + "_score") == 3)
                {
                levelList[i + 1].Unlocked = 1;
                levelList[i + 1].IsInteractable = true;
                }else
                {
                    levelList[i + 1].Unlocked = 0;
                    levelList[i + 1].IsInteractable = false;
                }
            }

            button.timeText.text = string.Format("{0}", PlayerPrefs.GetFloat("Stage_" + button.StageText.text + "_" + button.levelText.text + "Timer"));

            newbutton.transform.SetParent(spacer);
        }
        for (var i = 5; i < 6; i++)
        {
            GameObject newbutton = Instantiate(BossLevelbutton, levelList[i].pos) as GameObject;

            NewLevelButton button = newbutton.GetComponent<NewLevelButton>();
            button.levelText.text = levelList[i].levelText;
            button.StageText.text = levelList[i].StageText;
            button.StageTextOutPut.text = "STAGE " + button.StageText.text + " - ";

            button.StageText.GetComponent<Text>().enabled = false;
            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") == 3)
            {
                levelList[i + 1].Unlocked = 1;
                levelList[i + 1].IsInteractable = true;
            }

            button.unlocked = levelList[i].Unlocked;
            button.GetComponent<Button>().interactable = levelList[i].IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => { transform.localScale = new Vector3(0.8f, 0.8f, 1.0f); clickAudio.Play(); LoadStageValue("Stage_" + button.StageText.text + "_" + button.levelText.text); });

            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") >= 1)
                button.crown1.SetActive(true);
            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") >= 2)
                button.crown2.SetActive(true);
            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") >= 3)
                button.crown3.SetActive(true);


            if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "S")
            {
                button.RankS.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "A")
            {
                button.RankA.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "B")
            {
                button.RankB.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "C")
            {
                button.RankC.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "D")
            {
                button.RankD.SetActive(true);
            }
            else
            {
                button.RnakLock.SetActive(true);
            }
            if (button.levelText.text == "1")
            {
                button.RnakLock.SetActive(false);
            }

            button.timeText.text = string.Format("{0}", PlayerPrefs.GetFloat("Stage_" + button.StageText.text + "_" + button.levelText.text + "Timer"));


            newbutton.transform.SetParent(spacer);
        }
        for (var i = 6; i < levelList.Count; i++)
        {
            GameObject newbutton = Instantiate(Levelbutton, levelList[i].pos) as GameObject;

            NewLevelButton button = newbutton.GetComponent<NewLevelButton>();
            button.levelText.text = levelList[i].levelText;
            button.StageText.text = levelList[i].StageText;
            button.StageTextOutPut.text = "STAGE " + button.StageText.text + " - ";
            button.StageText.GetComponent<Text>().enabled = false;
            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") == 3)
            {
                levelList[i + 1].Unlocked = 1;
                levelList[i + 1].IsInteractable = true;
            }

            button.unlocked = levelList[i].Unlocked;
            button.GetComponent<Button>().interactable = levelList[i].IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => { transform.localScale = new Vector3(0.8f, 0.8f, 1.0f); clickAudio.Play(); LoadStageValue("Stage_" + button.StageText.text + "_" + button.levelText.text); });

            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") >= 1)
                button.crown1.SetActive(true);
            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") >= 2)
                button.crown2.SetActive(true);
            if (PlayerPrefs.GetInt("Stage_" + button.StageText.text + "_" + button.levelText.text + "_score") >= 3)
                button.crown3.SetActive(true);


            if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "S")
            {
                button.RankS.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "A")
            {
                button.RankA.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "B")
            {
                button.RankB.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "C")
            {
                button.RankC.SetActive(true);
            }
            else if (PlayerPrefs.GetString("Stage_" + button.StageText.text + "_" + button.levelText.text + "Rank") == "D")
            {
                button.RankD.SetActive(true);
            }
            else
            {
                button.RnakLock.SetActive(true);
            }
            if (button.levelText.text == "1")
            {
                button.RnakLock.SetActive(false);
            }

            button.timeText.text = string.Format("{0}", PlayerPrefs.GetFloat("Stage_" + button.StageText.text + "_" + button.levelText.text + "Timer"));


            newbutton.transform.SetParent(spacer2);
        }
        SaveAll();
    }

    private void SaveAll()
    {
        GameObject[] allbuttons = GameObject.FindGameObjectsWithTag("LevelButton");
        for (int i = 0; i < allbuttons.Length; i++)
        {
            NewLevelButton button = allbuttons[i].GetComponent<NewLevelButton>();
            PlayerPrefs.SetInt("Stage_" + button.StageText.text + "_" + button.levelText.text, button.unlocked);
        }
    }

    private void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    private void LoadStageValue(string value)
    {
        Application.LoadLevel(value);
    }

    [System.Serializable]
    public class Level
    {
        public string StageText;
        public string levelText;
        public int Unlocked;
        public bool IsInteractable;
        public Transform pos;
    }
    public List<Level> levelList;
    public GameObject Levelbutton;
    public GameObject BossLevelbutton;
    public Transform spacer;
    public Transform spacer2;
    public AudioSource clickAudio;

}
