using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SequenceState
{
	Inactive,
	Preview,
	Input,
	Completed,
	Failed
}

public class SequenceController : MonoBehaviour
{
	public SequenceElement[] SequenceElements;

	[SerializeField] protected int StartSequenceLength = 1;

	[SerializeField] protected int MaxSequenceLength = 5;

	private List<SequenceElement> CurrentSequence;

	private int CurrentSequenceLength;

	private int FilledSequenceLength;

	public SequenceState CurrentState { get; private set; }

	void ResetSequence()
	{
		CurrentSequenceLength = 1;
		GenerateSequence(); 
		               
		PlaySequencePreview();
	}

	void GenerateSequence()
	{
		CurrentSequence = new List<SequenceElement>();
		for (int i = 0; i < MaxSequenceLength; i++)
		{
			CurrentSequence.Add(SequenceElements[Random.Range(0, SequenceElements.Length)]);
		}
	}

	void PlaySequencePreview()
	{
		CurrentState = SequenceState.Preview;
	}

	void OnPreviewFinished()
	{
		FilledSequenceLength = 0;
		CurrentState = SequenceState.Input;
	}

	public bool OnSequenceElementInput(SequenceElement sequenceElement)
	{
		if (CurrentState != SequenceState.Input)
		{
			return false;
		}

		if (CurrentSequence[FilledSequenceLength] == sequenceElement)
		{ 
			FilledSequenceLength++;
			if (FilledSequenceLength >= CurrentSequenceLength)
			{
				OnSequencedCompleted();
			}

			return true;
		}
		else
		{
			CurrentState = SequenceState.Failed;
			return false;
		}
	}

	void OnSequencedCompleted()
	{
		FilledSequenceLength = 0;
		CurrentSequenceLength++;
		if (CurrentSequenceLength > MaxSequenceLength)
		{
			Open();
		}
		else
		{
			PlaySequencePreview();
		}
	}

	void Open()
	{
		enabled = false;
	}
}
