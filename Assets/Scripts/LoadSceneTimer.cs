using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTimer : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] float _delayTime = 5f;

    public void LoadGameOverScreenDelay()
    {
        StartCoroutine(LoadSceneAfterDealy());
    }

    IEnumerator LoadSceneAfterDealy()
    {
        yield return new WaitForSeconds(_delayTime);
        SceneManager.LoadScene(_sceneName);
    }
}
