using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int apesCount;
    private int apesCatched;
    private bool isFinished;

    // Start is called before the first frame update
    void Start()
    {
        apesCatched = 0;
        isFinished = false;    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApeCatched() {
        apesCatched++;

        if (apesCatched == apesCount) {
            Debug.Log("Level completed!");
            isFinished = true;
        }
    }
}
