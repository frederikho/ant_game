using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator playerAnimator;
	public Animator queenAnimator;
	public Animator antsAnimator;
	
	
	void Start()
	{
	}
	
	public void PlayAnimation()
	{
		playerAnimator.Play("New State");
		queenAnimator.Play("New State");
		antsAnimator.Play("New State");
	}
}
