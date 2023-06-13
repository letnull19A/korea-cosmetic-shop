using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers;

public class PublicController : Controller
{

    private readonly IDataBaseContext _context;
    
    public PublicController(IDataBaseContext context) 
        => (_context) = (context);
    
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Registration()
    {
        return View();
    }
    
    /// <summary>
    /// Обработчик регистрации
    /// </summary>
    /// <param name="registrationModel">данные для регистрации</param>
    /// <returns>IActionResult</returns>
    [HttpPost]
    public async Task<IActionResult> Registration(RegistrationModel registrationModel)
    {
        // Валидация отправленной формы
        if (!ModelState.IsValid)
        {
            return Registration();
        }

        // проверяем есть ли хотя бы 1 пользователь
        bool usersIsExist = _context.Users.Any();
        RoleDto role = new();

        // если пользователя нет, то регистрируем его как админа
        if (!usersIsExist)
        {
            role  = _context
                .Roles
                .First(r => r.BackendName == "admin");
        }

        // Создаём объект пользователя
        var user = new UserDto
        {
            Name = registrationModel.Name,
            RoleId = role.Id,
            Surname = registrationModel.Surname,
            FatherName = registrationModel.FatherName,
            Login = registrationModel.Login,
            Email = registrationModel.Email,
            Password = registrationModel.Password,
            Phone = registrationModel.Phone,
            Role = role
        };

        // Добавляем пользователя в БД
        _context.Users.Add(user);

        // Добавляем ссылку в ролях
        role.Users.Add(user);

        // Сохраняем изменения
        await _context.SaveAsync();

        // Перенаправление в авторизацию
        return Redirect("/Public/Login");
    }

    /// <summary>
    /// Обработчик авторизации
    /// </summary>
    /// <param name="loginModel">Данные введённые в форму</param>
    /// <returns>IActionResult</returns>
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        // проверка пришедших данных на валидность
        if (!ModelState.IsValid)
        {
            return Login();
        }

        // Поиск пользователя по логину и паролю
        var user = await _context
            .Users
            .FirstOrDefaultAsync(user => 
                user.Login == loginModel.Login && 
                user.Password == loginModel.Password);

        // если пользователь не найден возвращаем сообщение
        if (user is null)
        {
            return NotFound("Пользователя не существует");
        }

        // у найденного пользователя ищем роль
        var backendName = _context.Roles.First(y => y.Id == user.RoleId);
        
        // создание утверждений с данными пользователя
        var claims = new List<Claim>
        {
            new("id", user.Id.ToString()),
            new("login", loginModel.Login),
            new("name", user.Name),
            new("surname", user.Surname),
            new("fatherName", user.FatherName ?? string.Empty),
            new("phone", user.Phone),
            new("email", user.Email),
            new(ClaimTypes.Role, backendName.BackendName)
        };
        
        // Созздание идентификатора
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        
        // Записываем данные авторизации в куки
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        // Если роль клиента админ перенаправляем его в админ-панель
        if (backendName.BackendName == "admin")
            return Redirect("/Categories/Add");

        // иначе перенаправляем в профиль
        return Redirect("/Authenticated/Profile");
    }
}