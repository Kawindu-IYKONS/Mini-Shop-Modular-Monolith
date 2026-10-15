# Mini Shop - Modular Monolith Backend

Ye ek ASP.NET Core Web API project hai jo modular monolith architectural design pattern ko follow karte hue banaya gaya hai. Isme modular boundaries aur strict encapsulation rules implement kiye gaye hain.

---

##  Architectural Principles & Rules Followed

1. **Modular Encapsulation**: Har feature module (`Users`, `Products`, `Orders`) apne folder mein isolated hai.
2. **Internal Data Store & Models**: Data models aur in-memory data store classes `internal` rakhi gayi hain taaki koi bhi external module unhe directly access na kar sake.
3. **Public Interface & Services**: Sirf service interfaces (`IUserServices`, etc.) aur DTOs hi public expose kiye gaye hain.
4. **In-Memory Storage**: Data persistence ke liye koi external database use nahi kiya gaya; dynamic in-memory arrays (`Array.Resize`) use kiye gaye hain.
5. **Data Validation**: Request payloads ko Data Annotations aur business validations (jaise duplicate email check) ke zariye validate kiya gaya hai.
6. **Unified API Gateway / Controller**: Single `MainController` sabhi module services ko Dependency Injection (DI) ke zariye expose karta hai.

---

## Folder Structure

```text
Mini Shop/
├── Controllers/
│   └── MainController.cs
├── Modulers/
│   ├── Users/
│   │   ├── Users DTO's/
│   │   │   ├── CreateUserDto.cs
│   │   │   └── GetUserDto.cs
│   │   ├── Users Data Store/
│   │   │   └── UserDataStore.cs
│   │   └── Users Services/
│   │       ├── IUserServices.cs
│   │       └── UserServices.cs
│   ├── Products/  (In Progress)
│   └── Orders/    (Planned)
├── Program.cs
└── README.md