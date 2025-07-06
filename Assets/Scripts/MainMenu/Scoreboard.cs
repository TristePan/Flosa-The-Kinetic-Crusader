using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
public class Scoreboard : MonoBehaviour
{
 public Transform entryContainer;
    public Transform entryTemplate;

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private List <HighscoreEntry> unsortedScoreBoard;

    private List <HighscoreEntry> sortedScoreBoard;

    private List<Transform> entries;

    Scores scoreboard;

    public static Scoreboard Instance;

    private void Awake(){
        if (Instance == null) Instance = this;
        entryTemplate.gameObject.SetActive(false);
        highscoreEntryTransformList = new List<Transform>();
        string jsonString = PlayerPrefs.GetString("scoreboard", string.Empty);
        if (!string.IsNullOrEmpty(jsonString))
        {
            scoreboard = JsonUtility.FromJson<Scores>(jsonString);
        }
        else
        {
            scoreboard = new Scores { scoreboardEntryList = new List<HighscoreEntry>() };
        }
        //Debug.Log(jsonString);
        if (scoreboard != null && scoreboard.scoreboardEntryList != null)
        {
            instantiateScoreboard(scoreboard.scoreboardEntryList);
        }
    }

    private void instantiateScoreboard(List<HighscoreEntry> scoreBoard){
        foreach(HighscoreEntry highscoreEntry in scoreBoard){
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
        public void deleteScoreboard()
        {
            foreach (Transform entryTransform in highscoreEntryTransformList)
            {
                Destroy(entryTransform.gameObject);
                Debug.Log("Deleted!");
            }
            highscoreEntryTransformList.Clear();
        }

        public void eraseScoreboard(){
            deleteScoreboard();
            PlayerPrefs.DeleteKey("scoreboard");
            if(sortedScoreBoard != null)
                sortedScoreBoard.Clear();
            scoreboard.scoreboardEntryList.Clear();
        }

    public void AddScoreEntry(int score)
    {
        string jsonString = PlayerPrefs.GetString("scoreboard", string.Empty);
        Debug.Log("Retrieved scoreboard JSON: " + jsonString);
        Debug.Log("Adding new score!");

        Scores scores;
        if (string.IsNullOrEmpty(jsonString))
        {
            scores = new Scores { scoreboardEntryList = new List<HighscoreEntry>() };
        }
        else
        {
            scores = JsonUtility.FromJson<Scores>(jsonString);
        }

        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score };

        // Aggiungi il nuovo punteggio alla lista
        scores.scoreboardEntryList.Add(highscoreEntry);

        // Ordina la lista in ordine decrescente di punteggio
        scores.scoreboardEntryList.Sort((entry1, entry2) => entry2.score.CompareTo(entry1.score));

        // Mantieni solo i primi 10 punteggi
        if (scores.scoreboardEntryList.Count > 10)
        {
            scores.scoreboardEntryList.RemoveAt(scores.scoreboardEntryList.Count - 1);
        }

        // Serializza l'oggetto Scores in JSON e salvalo nei PlayerPrefs
        string json = JsonUtility.ToJson(scores);
        Debug.Log("Converted updated Scores object to JSON: " + json);

        PlayerPrefs.SetString("scoreboard", json);
        PlayerPrefs.Save();
        Debug.Log("Saved updated scoreboard to PlayerPrefs.");
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList){
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count+1;
        string rankString;
        switch(rank){
            default:
                rankString = rank + "TH";
                break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        int score = highscoreEntry.score;
        entryTransform.Find("positionValue").GetComponent<TMP_Text>().text = rankString;
        entryTransform.Find("scoreValue").GetComponent<TMP_Text>().text = score.ToString();

        transformList.Add(entryTransform);
    }

    private class Scores{
        public List<HighscoreEntry> scoreboardEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry{
        public int score;
    }
}
