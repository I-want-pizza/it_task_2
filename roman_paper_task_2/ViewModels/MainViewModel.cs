using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using roman_paper_task_2.Models;

namespace roman_paper_task_2.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<LivingBeing> beings;
    [ObservableProperty] private LivingBeing selectedBeing;

    [ObservableProperty] private string log;

    public MainViewModel()
    {
        Beings = new ObservableCollection<LivingBeing>
        {
            new Panther("Alice"),
            new Dog("Barker"),
            new Turtle("Ugwei")
        };

        foreach (var being in Beings)
        {
            if (being is Interfaces.IVoice voiceBeing)
            {
                voiceBeing.OnMakeSound += sound => AppendLog(sound);
            }
        }

        Log = "Выберите животное и управляйте им.";
    }

    private void AppendLog(string message)
    {
        Log += $"\n{message}";
    }

    [RelayCommand]
    private void Move()
    {
        if (SelectedBeing == null)
        {
            AppendLog("Выберите животное.");
            return;
        }

        SelectedBeing.Move();
        AppendLog($"{SelectedBeing.GetType().Name} двигается. Скорость: {SelectedBeing.Speed}");
    }

    [RelayCommand]
    private void Stop()
    {
        if (SelectedBeing == null)
        {
            AppendLog("Выберите животное.");
            return;
        }

        SelectedBeing.Stop();
        AppendLog($"{SelectedBeing.GetType().Name} останавливается. Скорость: {SelectedBeing.Speed}");
    }

    [RelayCommand]
    private void MakeSound()
    {
        if (SelectedBeing is Interfaces.IVoice voiceBeing)
        {
            voiceBeing.MakeSound();
        }
        else
        {
            AppendLog($"{SelectedBeing.GetType().Name} не умеет издавать звук.");
        }
    }

    [RelayCommand]
    private void ClimbTree()
    {
        if (SelectedBeing is Interfaces.IClimb climber)
        {
            climber.ClimbTree();
            AppendLog($"{SelectedBeing.GetType().Name} залезает на дерево.");
        }
        else
        {
            AppendLog($"{SelectedBeing.GetType().Name} не умеет лазить по деревьям.");
        }
    }
}
