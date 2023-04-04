[![Typing SVG](https://readme-typing-svg.herokuapp.com?color=%2336BCF7&lines=WEb+API+Angular+ASP.Net)](https://git.io/typing-svg)
<br>

<h1>Учебный проект с Web API и Angular</h1>
Это простой учебный проект, который демонстрирует, как использовать Web API в качестве бэкэнда и Angular в качестве фронтэнда. Этот проект позволит вам создавать, читать, обновлять и удалять элементы списка задач.

Технологии
Этот проект использует следующие технологии:

Web API - для создания RESTful API и хранения данных в базе данных SQL Server.
Angular - для создания фронтэнда приложения.

#Требования
Для запуска этого проекта вам понадобятся следующие компоненты:

`.NET 7`
`Angular CLI`
`Node.js 10.5xx`
`Запуск приложения`



cd TodoApi
dotnet run
В отдельном терминале запустите клиентскую часть (Angular):



ng serve
Откройте веб-браузер и перейдите по адресу http://localhost:4200/. Вы должны увидеть приложение.

#Описание API
API предоставляет следующие конечные точки:

`GET /api/todos - получить все элементы списка задач`
`GET /api/todos/{id} - получить элемент списка задач по ID`
`POST /api/todos - создать новый элемент списка задач`
`PUT /api/todos/{id} - обновить элемент списка задач по ID`
`DELETE /api/todos/{id} - удалить элемент списка задач по ID`
Дополнительные ресурсы
Документация Angular
Документация .NET