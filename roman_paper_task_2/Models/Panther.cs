using System;
using roman_paper_task_2.Interfaces;

namespace roman_paper_task_2.Models;

public class Panther(string name) : LivingBeing(name), IVoice, IClimb
{
    public override double MaxSpeed => 80.0;

    public event Action<string> OnMakeSound;

    public override void Move()
    {
        if (Speed < MaxSpeed)
        {
            Speed += 10;
            if (Speed > MaxSpeed)
                Speed = MaxSpeed;
        }

        Console.WriteLine($"Пантера двигается со скоростью {Speed} км/ч.");
    }

    public override void Stop()
    {
        if (Speed > 0)
        {
            Speed -= 10;
            if (Speed < 0)
                Speed = 0;
        }

        Console.WriteLine($"Пантера замедляется. Текущая скорость: {Speed} км/ч.");
    }

    public void MakeSound()
    {
        OnMakeSound?.Invoke("Пантера рычит!");
    }

    public void ClimbTree()
    {
        Console.WriteLine("Пантера ловко залезла на дерево!");
    }
}