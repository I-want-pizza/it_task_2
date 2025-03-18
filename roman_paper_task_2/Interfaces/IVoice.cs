using System;

namespace roman_paper_task_2.Interfaces;

public interface IVoice
{
    event Action<string> OnMakeSound;
    void MakeSound();
}