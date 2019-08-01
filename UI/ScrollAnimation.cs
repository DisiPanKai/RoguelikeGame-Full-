using UnityEngine;

public class ScrollAnimation : MonoBehaviour
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
