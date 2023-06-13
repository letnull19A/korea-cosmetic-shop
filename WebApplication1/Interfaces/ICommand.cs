using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Interfaces;

/// <summary>
/// Интерфейс команды
/// </summary>
public interface ICommand 
{
    public void Execute();
}