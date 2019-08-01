using UnityEngine;

public class StatScreenAnimation : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ScrollRide()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DeadState"))
            animator.SetBool("scrollRide", true);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ScrollAnim"))
            animator.SetBool("scrollRide", false);
    }
}
