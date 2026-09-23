using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimButtonController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Button animButton;


    [SerializeField] private string idleState = "Idle";
    [SerializeField] private string flightState = "Flight";

    private bool flightPlaying = false;

    private void Start()
    {

        animator.Play(idleState, 0, 0f);


        animButton.interactable = true;
    }

    public void PlayFlight()
    {

        if (flightPlaying)
            return;

        StartCoroutine(FlightAnimation());
    }

    private IEnumerator FlightAnimation()
    {
        flightPlaying = true;
        animButton.interactable = false;


        animator.Play(flightState, 0, 0f);


        while (true)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName(flightState) &&
                stateInfo.normalizedTime >= 1f &&
                !animator.IsInTransition(0))
            {
                break;
            }

            yield return null;
        }


        animator.Play(idleState, 0, 0f);


        animButton.interactable = true;
        flightPlaying = false;
    }
}