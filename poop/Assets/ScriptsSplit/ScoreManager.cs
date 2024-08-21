using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameDirector gameDirector;

    public float score;

    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
       score += Time.deltaTime / 0.001f * 0.01f;
       gameDirector.score = score;
    }
}
