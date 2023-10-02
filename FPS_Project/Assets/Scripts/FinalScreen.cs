using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] string mainMenu;

    [SerializeField] float timeBetweenShowing = 1f;

    [SerializeField] GameObject textBox, returnButton;

    [SerializeField] Image blackScreen;

    [SerializeField] float blackScreenFade = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowObjectsCo());
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, blackScreenFade * Time.deltaTime));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public IEnumerator ShowObjectsCo()
    {
        yield return new WaitForSeconds(timeBetweenShowing);

        textBox.SetActive(true);

        yield return new WaitForSeconds(timeBetweenShowing);

        returnButton.SetActive(true);
    }
}
