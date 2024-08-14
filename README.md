Приложение BasketballBot - Telegram бот.

Предназначено для помощи модератору Telegram группы для занятий баскетболом.

Функции приложения:
1. Создание опросов в группе с автоматическим определением даты ближайшей тренировки.
2. Напоминание в группе по необходимости взять 2 комплекта формы (темную и светлую)
3. Напоминание о сборе денег за аренду зала с ручным указанием модератором суммы (меняется в зависимости от количества проголосовавших).
4. Администрирование на сайте членов группы. Изменение позиций игроков, изменение рейтинга.
5. Деление на команды в зависимости от рейтинга игроков по результатам голосования в опросе (в разработке)

Стек технологий:
backend - dotnet 6.0 C#
frontend - Angular 17 (typescript)
Telegram Bot Api на основе WebHooks.

Хостинг приложения на бесплатном somee.com с ограниченными квотами.
В качестве хранения информации используются файлы json.

Основные методы API:
- GET api/adminpanel/persons - получение списка всех игроков группы
- GET api/adminpanel/person/${id} - получение конкретного игрока по его идентификатору
- PUT api/adminpanel/person/${person.id} - изменение конкретного игрока по его идентификатору
- POST api/message/update - перехват сообщения в бот для парсинга команды и выполнения необходимых действий

Возможные команды telegram боту:
/start - Команда для получения тестового сообщения от бота. 
/cmamount - Команда для сообщения со сбором денег , где amount - сумма для сбора. Пример /cm300
/cpN - Команда создания опроса для посещения тренировки /cp1 - опрос для зала №1; /cp2 - опрос для зала №2
/tj - Команда напоминания необходимости взять темную и светлую формы