using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager loadSceneManager;

    // シーン移動に関するデータファイル
    [SerializeField] private SceneMovementData sceneMovementData;
    
    // フェードプレハブ
    [SerializeField] private GameObject fadePrefab;
    
    // フェードインスタンス
    private GameObject fadeInstance;
    
    // フェードの画像
    private Image fadeImage;

    [SerializeField] private float fadeSpeed = 5f;
    
    private void Awake()
    {
        // LoadSceneManagerは常に1つ
        if (loadSceneManager == null)
        {
            loadSceneManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 次のシーン呼び出し
    public void GoToNextScene(SceneMovementData.SceneType scene)
    {
        sceneMovementData.SetSceneType(scene);
        StartCoroutine(FadeAndLoadScene(scene));
    }

    IEnumerator FadeAndLoadScene(SceneMovementData.SceneType scene)
    {
        // フェードUIのインスタンス化
        fadeInstance = Instantiate<GameObject>(fadePrefab);
        fadeImage = fadeInstance.GetComponentInChildren<Image>();
        
        // フェードアウト処理
        yield return StartCoroutine(Fade(1f));
        
        // シーン読み込み
        if (scene == SceneMovementData.SceneType.FirstRuins)
            yield return StartCoroutine(LoadScene("FirstRuins"));
        else if (scene == SceneMovementData.SceneType.FirstRuinsToVillage)
            yield return StartCoroutine(LoadScene("WASDTest"));

        // フェードUIのインスタンス化
        fadeInstance = Instantiate(fadePrefab);
        fadeImage = fadeInstance.GetComponentInChildren<Image>();
        fadeImage.color = new Color(0f, 0f, 0f, 1f);

        // フェードイン処理
        yield return StartCoroutine(Fade(0f));
        
        Destroy(fadeInstance);
    }
    
    // フェード処理
    IEnumerator Fade(float alpha)
    {
        var fadeImageAlpha = fadeImage.color.a;

        while (Mathf.Abs(fadeImageAlpha - alpha) > .01f)
        {
            fadeImageAlpha = Mathf.Lerp(fadeImageAlpha, alpha, fadeSpeed * Time.deltaTime);
            fadeImage.color = new Color(0f, 0f, 0f, fadeImageAlpha);
            yield return null;
        }
    }
    
    // シーン読み込む処理
    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone) yield return null;
    }
}
