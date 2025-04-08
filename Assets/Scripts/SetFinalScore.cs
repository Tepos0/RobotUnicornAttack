using UnityEngine;

public class SetFinalScore : MonoBehaviour
{
    
  
    private void SaveHighScore(int score)
    {
        int oldScore = PlayerPrefs.GetInt("HighScore",0);
        if (score > oldScore)
        {
            PlayerPrefs.SetInt("HighScore", score)
            PlayerPrefs.Save();
        }
        else
        {
            score = oldScore;
        }
        onSetHighScore?.inoke(score.ToString());
    }
}
