using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    public GameObject Fade;
    public void HandleNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void HandleQuit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    IEnumerator FadeInAndLoad(bool reload = false, bool load = true)
    {
        Fade.SetActive(true);
        Color tcolor = Fade.GetComponent<Image>().color;
        tcolor.a = 0;
        Fade.GetComponent<Image>().color = tcolor;
        while (true)
        {
            Color color = Fade.GetComponent<Image>().color;
            color.a += 0.005f;
            Fade.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
            if (color.a >= 1)
            {
                break;
            }
        }
       if(load) HandleLoadNextScene(reload);
    }

    IEnumerator FadeOut()
    {
        Fade.SetActive(true);
        Color tcolor = Fade.GetComponent<Image>().color;
        tcolor.a = 1;
        Fade.GetComponent<Image>().color = tcolor;
        while (true)
        {
            Color color = Fade.GetComponent<Image>().color;
            color.a -= 0.005f;
            Fade.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
            if (color.a <= 0)
            {
                break;
            }
        }
        Fade.SetActive(false);
    }


    public void HandleFadeAndLoadNextScene(bool load = true)
    {
        StartCoroutine(FadeInAndLoad(false, load));
    }

    public void HandleFadeAndReload()
    {
        StartCoroutine(FadeInAndLoad(true));
    }

    public void HandleLoadNextScene(bool reload = false)
    {
        int index = reload ? SceneManager.GetActiveScene().buildIndex : SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }


    // Start is called before the first frame update
    void Start()
    {
        if(Fade!=null) StartCoroutine(FadeOut());
    }
}
