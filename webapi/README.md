# ASP .NET Core 

## TODO

- [ ] Импортировать вид из базы данных
  - [ ] Найти функционал EF Core
  - [ ] Для каждого вида создать контроллер

- [ ] Поменять item и video api контроллеры (там композитные ключи)


## Теги
- EntityFramework Core
  - Fluent API
  - 4 категории SQL:
  - DDL

## 4 категории SQL 

Мне кажется, что EntityFramework всего лишь обертка над SQL. Почему? 

Рассмотрим базовую структуру классов. Всего бывают 2 разновидности:
- модель
- контроллер

Пример модели:
```
using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class User
    {
      // Constructor
        public User()
        {
            IteminVideosforUser = new HashSet<IteminVideosforUser>();
            VoteforVideo = new HashSet<VoteforVideo>();
        }
      // Columns
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
      
        public ICollection<IteminVideosforUser> IteminVideosforUser { get; set; }
        public ICollection<VoteforVideo> VoteforVideo { get; set; }
    }
}
```


1. **DDL(Data Definition Language)**
   
    DDL или язык определения данных состоит из команд SQL, которые можно использовать для определения схемы базы данных
Examples of DDL commands:

   CREATE – используется для создания базы данных или ее объектов (таких как таблица, индекс, функция, представления, процедура хранения и триггеры).
   CREATE -> Fluent API

   DROP – используется для удаления объектов из базы данных.
   
   ALTER - используется для изменения структуры базы данных.
   
   TRUNCATE–используется для удаления всех записей из таблицы, включая все места, выделенные для записей.

   COMMENT –используется для добавления комментариев в словарь данных.
   RENAME –используется для переименования объекта, существующего в базе данных.
   ```

   
2. DML(Data Manipulation Language)
   
   Используем CRUD 
   | SQL -> | CRUD -> | HTTP Request |
   | ------ | ------- | ------------ |
   | SELECT | READ    | GET          |
   | INSERT | CREATE  | POST         |
   | UPDATE | UPDATE  | PUT          |
   | DELETE | DELETE  | DELETE       |

  
3. DCL (Data Control Language)
4. TCL (Transaction Control Language))

# Документация (частично)

## Сессия

https://stackoverflow.com/questions/9594229/accessing-session-using-asp-net-web-api


- dotnet add package Microsoft.AspNetCore.Session -v 2.1.1

**Startup.cs**


```
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        ...

        services.AddDistributedMemoryCache();
        services.AddSession();
````


и в функции настройки добавляем UseSession:
```
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
    ILoggerFactory loggerFactory)
    {
        app.UseSession();
        app.UseMvc();

```
**SessionController.cs**

Не забываем о 

- using Microsoft.AspNetCore.Http;


а затем используем **HttpContext.Session**:

```    [HttpGet("set/{data}")]
    public IActionResult setsession(string data)
    {
        HttpContext.Session.SetString("keyname", data);
        return Ok("session data set");
    }

    [HttpGet("get")]
    public IActionResult getsessiondata()
    {
        var sessionData = HttpContext.Session.GetString("keyname");
        return Ok(sessionData);
    }
```

## CORSS

To enable a CORS policy across all of your MVC controllers you have to build the policy in the AddCors extension within the ConfigureServices method and then set the policy on the CorsAuthorizationFilterFactory

```
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Cors.Internal;
    ...
    public void ConfigureServices(IServiceCollection services) {
        // Add AllowAll policy just like in single controller example.
        services.AddCors(options => {
            options.AddPolicy("AllowAll",
               builder => {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
            });
        });

        // Add framework services.
        services.AddMvc();

        services.Configure<MvcOptions>(options => {
            options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
        });
    }

    public void Configure(IApplicationBuilder app) {
        app.useMvc();
        // For content not managed within MVC. You may want to set the Cors middleware
        // to use the same policy.
        app.UseCors("AllowAll");
    }
```
This CORS policy can be overwritten on a controller or action basis, but this can set the default for the entire application.