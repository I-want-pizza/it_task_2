using System;

namespace roman_paper_task_2.Models;

public class Turtle(string name) : LivingBeing(name)
{
    public override double MaxSpeed => 1.0;

    public override void Move()
    {
        if (Speed < MaxSpeed)
        {
            Speed += 0.1;
            if (Speed > MaxSpeed)
                Speed = MaxSpeed;
        }

        Console.WriteLine($"Черепаха медленно ползёт со скоростью {Speed:F1} км/ч.");
    }

    public override void Stop()
    {
        if (Speed > 0)
        {
            Speed -= 0.1;
            if (Speed < 0)
                Speed = 0;
        }

        Console.WriteLine($"Черепаха останавливается. Текущая скорость: {Speed:F1} км/ч.");
    }
}