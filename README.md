# CoreFitness – ASP.NET MVC Gym Management System

CoreFitness är ett komplett träningshanteringssystem byggt med **ASP.NET MVC**, **Identity**, **Entity Framework Core** och en ren arkitektur med separerade lager för Domain, Application, Infrastructure och Web.

Projektet innehåller:

- Användarhantering (registrering, inloggning, profil)
- Medlemskapssystem
- Boka/avboka träningspass
- CRUD för träningspass (GymClass)
- CRUD för instruktörer (Teachers)
- Profilbilds‑upload
- MyPage med personlig översikt
- Validering på alla formulär
- Clean Architecture‑struktur

---

## Funktioner

### Identity & Användarhantering
- Registrering
- Inloggning
- Utloggning
- Profilinformation (namn, email, telefon)
- Profilbilds‑upload
- MyPage för inloggade användare

### Medlemskap
- Skapa medlemskap kopplat till användare
- Visa medlemskap på MyPage
- Validering av medlemskap (pris, typ)

### Gym Classes (Träningspass)
- Skapa träningspass
- Redigera träningspass
- Ta bort träningspass
- Lista alla pass
- Koppla instruktör till pass
- Validering av namn, datum, tid, kapacitet

### Bokningar
- Boka träningspass
- Avboka träningspass
- Visa bokningar på MyPage

### Teachers
- CRUD för instruktörer
- Koppling till GymClass

---

## Arkitektur

Projektet följer en **Clean Architecture‑inspirerad struktur**:

CoreFitness.Domain        → Entities (GymClass, Membership, Booking, Teacher)
CoreFitness.Application   → Interfaces, Services, DTOs
CoreFitness.Infrastructure → Repositories, Data access
CoreFitness.Web           → MVC Controllers, Views, Identity



Detta ger:

- Tydlig separation av ansvar
- Testbarhet
- Skalbarhet
- Ren kod

---

## Databas

Projektet använder:

- **Entity Framework Core**
- **SQL Server**
- **IdentityDbContext** för användare
- **CoreFitnessDbContext** för domänmodeller

---

##  Profilbilds‑upload

Användaren kan ladda upp en profilbild via:
-Account/UploadProfileImage


Bilden sparas i:
-wwwroot/images/profile/


Och visas på MyPage.

---

## Validering

Alla formulär har:

- `[Required]`
- `[EmailAddress]`
- `[Range]`
- `[Compare]`
- Razor‑validering (`asp-validation-for`)

Detta säkerställer att användaren inte kan skicka in ogiltiga värden.

---

##  Starta projektet

1. Klona repot  
2. Uppdatera `appsettings.json` med din SQL‑connection string  
3. Kör migrationer (om du använder dem)  
4. Starta projektet i Visual Studio  
5. Registrera en användare  
6. Logga in och testa funktionerna

---


