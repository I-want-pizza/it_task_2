using System;
using roman_paper_task_2.Interfaces;

namespace roman_paper_task_2.Models;

public class Dog(string name) : LivingBeing(name), IVoice
{
    public override double MaxSpeed => 40.0;

    public event Action<string> OnMakeSound;

    public override void Move()
    {
        if (Speed < MaxSpeed)
        {
            Speed += 5;
            if (Speed > MaxSpeed)
                Speed = MaxSpeed;
        }

        Console.WriteLine($"Собака бежит со скоростью {Speed} км/ч.");
    }

    public override void Stop()
    {
        if (Speed > 0)
        {
            Speed -= 5;
            if (Speed < 0)
                Speed = 0;
        }

        Console.WriteLine($"Собака замедляется. Текущая скорость: {Speed} км/ч.");
    }

    public void MakeSound()
    {
        OnMakeSound?.Invoke("Собака лает!");
    }
}