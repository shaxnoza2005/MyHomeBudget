---

## MyHomeBudget — Личный бюджет

### 👤 Дефолтный логин:
```
Login: admin
Parol: 123456
```

### 📖 О проекте (Russian)
MyHomeBudget — это простое веб-приложение для учета личных доходов и расходов. Пользователь может войти в систему по логину/паролю и вести записи о доходах и расходах.

---

### ⚡ Технологии:
- ASP.NET Core MVC
- Entity Framework Core + SQLite
- Bootstrap 5
- C# (.NET 8)

---

### 🔹 Функционал:
- Авторизация способом логин/пароль
- Создание, редактирование, удаление записей доходов/расходов
- Статьи доходов (енум перечень)
- Сумма, дата, комментарий
- Общая статистика (доходы, расходы, баланс)
- Последние 5 транзакций

---

### ✅ Как запустить:

#### 1. Исходный код (Visual Studio):
- Откройте `MyHomeBudget.sln`
- Соберите и запустите (F5)

#### 2. Готовый `.exe` путь:
- Откройте папку `publish/`
- Запустите `MyHomeBudget.exe`

---



---

### 🔗 Примечание:
Проект сделан для тестового задания с упором на удобное и простое UI.
Категории заданы через enum. CRUD-функции добавления категорий могут быть добавлены позже как расширение.






## MyHomeBudget — Shaxsiy Budjetni Boshqarish Tizimi

### 🔖 Loyiha haqida (Uzbek)
MyHomeBudget — bu ASP.NET Core MVC asosida yozilgan shaxsiy budjetni yuritish dasturidir. Foydalanuvchi tizimga login/parol orqali kiradi va kirim/chiqim yozuvlarini qo‘shadi, ularni ko‘rish, tahrirlash va o‘chirish imkoniyatiga ega.

---

### 🎓 Texnologiyalar
- ASP.NET Core MVC
- Entity Framework Core + SQLite
- Bootstrap 5
- C# (.NET 8)

---

### ✅ Asosiy imkoniyatlar:
- Login/Parol bilan kirish (oddiy autentifikatsiya)
- Kirim va chiqim yozuvlarini CRUD orqali boshqarish
- Har bir yozuvda:
  - Sana (default: bugungi sana)
  - Kirim yoki chiqim turi
  - Kategoriya (enumdan tanlanadi)
  - Summa
  - Komment (ixtiyoriy)
- Umumiy statistika (kirim, chiqim, balans)
- Oxirgi 5 ta tranzaksiyani ko‘rsatish
- Yaxshi responsive UI (Bootstrap bilan)

---

### ⚖️ Loyihani ishga tushurish (2 xil usul):

#### 1. Koddan foydalanish (Visual Studio)
1. `MyHomeBudget.sln` faylini Visual Studio bilan oching
2. `dotnet ef database update` orqali bazani yaratish mumkin
3. `F5` yoki `dotnet run` orqali ishga tushiring

#### 2. Tayyor faylni ishga tushirish (publish papka)
1. `publish/` papkasini oching
2. `MyHomeBudget.exe` faylini ishga tushiring

---

### 👤 Default foydalanuvchi:
```
Login: admin
Parol: 123456
```

---

### 🔒 Qo‘shimcha:
- Loyiha soddalashtirilgan holda tuzilgan
- Kategoriya enum orqali tanlanadi (CRUD emas)
- Toast yoki modal funksiyalar ixtiyoriy tarzda qo‘shilishi mumkin

