using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject wepon;
    [SerializeField] GameObject aim;
    private void Start()
    {
        
    }
    public void ReloadGame()
    {
       int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex);
        Time.timeScale = 1;
        wepon.SetActive(true);
        aim.SetActive(true);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(3);
    }
    
}
