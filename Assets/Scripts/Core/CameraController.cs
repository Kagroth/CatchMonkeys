using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject mainVirtualCamera;
    [SerializeField] GameObject slingshotCamera;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = mainVirtualCamera.GetComponent<Animator>();
    }

    public void SwitchToSlingshotCamera() {
        slingshotCamera.GetComponent<CinemachineVirtualCamera>().m_Priority = 100;
    }

    public void SwitchToMainCamera() {
        slingshotCamera.GetComponent<CinemachineVirtualCamera>().m_Priority = 8;
    }

    public void StartApeCatchedAnimation() {
        // anim.Play("Rotate Around Ape");
    }
}
