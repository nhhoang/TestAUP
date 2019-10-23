using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAUP : MonoBehaviour {
  // Start is called before the first frame update
  public Transform parentTransform;

  public static double startLoadTime;

  void Start() {
    // Invoke("LoadAssets", 1.0f);

    Invoke("LoadAsyncAssets", 1.0f);
  }

  // Update is called once per frame
  void LoadAssets() {
    double t = Time.realtimeSinceStartup;
    startLoadTime = Time.realtimeSinceStartup;

    PerformanceTuner.Mode = PerformanceTuner.PerformanceMode.Loading;
    for (int i = 1; i <= 20; i++) {
      GameObject go = Instantiate(Resources.Load("Prefabs/build_" + i)) as GameObject;
      go.transform.parent = parentTransform;
    }

    PerformanceTuner.Mode = PerformanceTuner.PerformanceMode.Gameplay;
    Debug.Log("-----LoadAssets done in " + (Time.realtimeSinceStartup - t));
  }

  void LoadAsyncAssets() {
    startLoadTime = Time.realtimeSinceStartup;
    StartCoroutine(LoadAsyncAssetsCoroutine());
  }

  IEnumerator LoadAsyncAssetsCoroutine() {
    // PerformanceTuner.Mode = PerformanceTuner.PerformanceMode.Loading;
    double t = Time.realtimeSinceStartup;
    for (int i = 1; i <= 20; i++) {
      ResourceRequest request = Resources.LoadAsync<GameObject>("Prefabs/build_" + i);
      while (!request.isDone) {
        yield return 0;
      }

      GameObject go = Instantiate(request.asset) as GameObject;
      go.transform.parent = parentTransform;
      // yield return null;
    }

    // PerformanceTuner.Mode = PerformanceTuner.PerformanceMode.Gameplay;
    Debug.Log("-----LoadAsyncAssets done in " + (Time.realtimeSinceStartup - t));
  }
}