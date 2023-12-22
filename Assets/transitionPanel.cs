using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class transitionPanel : MonoBehaviour
{
    Animator transition;

    private void Start()
    {
        transition = GetComponent<Animator>();
        if(SceneManager.GetActiveScene().buildIndex!= 1)
            Cursor.visible = true;
    }
    public void loadGamePlay()
    {
        transition.SetTrigger("end");
        StartCoroutine(startLoadGamePlay());
    }
    public void loadMainMenu()
    {
        transition.SetTrigger("end");
        StartCoroutine(startMainMenu());
    }
    public void quitGame()
    {
        Application.Quit();
    }

    IEnumerator startLoadGamePlay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    IEnumerator startMainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
