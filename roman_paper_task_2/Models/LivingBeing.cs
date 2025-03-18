namespace roman_paper_task_2.Models;

public abstract class LivingBeing
{
    protected LivingBeing(string name)
    {
        Name = name;
    }

    public double Speed { get; protected set; }
    public string Name { get; protected set; }

    public abstract double MaxSpeed { get; }

    // Абстрактные методы
    public abstract void Move();
    public abstract void Stop();
}