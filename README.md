# Smart Match: Mentor–Mentee Matching System for Innovation Hubs

A Windows Forms desktop application that recommends the most suitable mentors to each mentee in an Innovation Hub. Users create profiles, the system ranks mentors with a similarity score, mentees send requests, and mentors accept or reject them. Matched users can schedule sessions, exchange messages and give feedback. The hub administrator manages accounts and views reports.

**Author:** Nirere Angelique (Student ID: 26564), Adventist University of Central Africa (AUCA), Kigali, Rwanda
**Assignment:** Lab 3, WinForms desktop application with a database, following the MVC architecture

---

## Features

### Mentee
- Register and log in
- Create and edit a profile (skills, interests, industry, goals, experience level, availability)
- See a ranked list of recommended mentors with a match percentage
- Send a mentorship request to a mentor (duplicate requests are blocked)
- Schedule, complete and cancel sessions with matched mentors
- Chat with matched mentors
- Rate completed sessions (1 to 5) and leave a comment
- Read notifications (the Dashboard shows the number of unread ones)

### Mentor
- Register and log in
- Create and edit a profile, including the maximum number of mentees
- See incoming requests and accept or reject them (accepting creates a match)
- Schedule sessions, chat with matched mentees, give feedback, read notifications

### Administrator
- View all users and suspend or reactivate accounts (a suspended user cannot log in)
- View a report: number of mentees and mentors, matches, pending requests, completed sessions, feedback received and the average rating

---

## How the matching works

Smart Match uses **content-based filtering with cosine similarity**:

1. The skills, interests, industry and goals of a profile are turned into word counts (a vector). Words are converted to lower case, common words (such as "and" and "the") are removed, and simple plurals are merged.
2. The mentee's vector is compared with each mentor's vector using cosine similarity. A score of 100% means the profiles share the same words, and 0% means they share none.
3. Mentors who already reached their maximum number of mentees are removed.
4. The remaining mentors are sorted from the highest score to the lowest and shown to the mentee.

The code is in `Models/MatchingService.cs`.

---

## Architecture (MVC)

| Layer | Folder | Responsibility |
|---|---|---|
| **Model** | `Models/` | Data classes and repositories. **All SQL and database code is here.** |
| **View** | `Views/` | Windows Forms. They read user input and display data, with **no SQL**. |
| **Controller** | `Controllers/` | Check the rules (login, roles, validation) and call the repositories. They do not touch any form control. |

Request flow, for example when a mentee sends a request:
`MentorsForm` (View) → `RequestController` (checks the rules) → `RequestRepository` (runs the SQL) → MariaDB → the form shows the result.

---

## Technology

| Area | Technology |
|---|---|
| Language | C# |
| Framework | .NET 8, Windows Forms |
| Database | MariaDB (XAMPP) |
| Data access | ADO.NET with the **MySqlConnector** package |
| Password hashing | **BCrypt.Net-Next** |
| Management tool | phpMyAdmin |

---

## Project structure

```
Smart match/
├── Controllers/
│   ├── AuthController.cs         Register, login, logout, current user
│   ├── ProfileController.cs      Read and save the user's profile
│   ├── MatchController.cs        Ranked mentor recommendations
│   ├── RequestController.cs      Send, accept and reject requests
│   ├── SessionController.cs      Schedule, complete and cancel sessions
│   ├── FeedbackController.cs     Ratings and comments
│   ├── NotificationController.cs Notifications and unread count
│   ├── MessageController.cs      Chat between matched users
│   └── AdminController.cs        Users and reports (admin only)
├── Models/
│   ├── Database.cs               Connection string and connection factory
│   ├── User.cs, Profile.cs, MentorshipRequest.cs, MentorMatch.cs
│   ├── MatchingService.cs        Cosine similarity algorithm
│   ├── *Repository.cs            SQL for users, profiles, mentors, requests,
│   │                             matches, sessions, feedback, notifications,
│   │                             messages and admin reports
│   └── RequestRow.cs, SessionRow.cs, MatchOption.cs, NotificationRow.cs,
│       MessageModels.cs, AdminModels.cs   Data shown in the screens
├── Views/
│   ├── LoginForm.cs, RegisterForm.cs, DashboardForm.cs
│   ├── ProfileForm.cs, MentorsForm.cs, RequestsForm.cs
│   ├── SessionsForm.cs, FeedbackForm.cs, NotificationsForm.cs
│   ├── MessagesForm.cs, UsersForm.cs, ReportsForm.cs
│   └── Theme.cs                  Green and black colours
├── database/
│   └── smartmatch.sql            Database structure and sample data
├── Program.cs                    Starts the app at LoginForm
└── README.md
```

---

## Database

The database is called `smartmatch` and has 8 tables:

| Table | Purpose |
|---|---|
| `users` | Accounts (name, email, hashed password, role, active flag) |
| `profiles` | One profile per user |
| `mentorship_requests` | Requests from mentees to mentors (Pending, Accepted, Rejected) |
| `matches` | Created when a request is accepted, with the match score |
| `sessions` | Mentoring sessions (Scheduled, Completed, Cancelled) |
| `feedback` | Rating (1 to 5) and comment for a session |
| `notifications` | Messages for users, with a read flag |
| `messages` | Chat messages between matched users |

---

## How to run the project

### 1. Requirements
- Windows with **Visual Studio** and the **.NET desktop development** workload (.NET 8)
- **XAMPP** (Apache and MySQL/MariaDB)

### 2. Set up the database
1. Open the **XAMPP Control Panel** and click **Start** next to **Apache** and **MySQL**.
2. Open **http://localhost/phpmyadmin/** in a browser.
3. Click **Databases**, create a database named `smartmatch` (collation `utf8mb4_unicode_ci`).
4. Select `smartmatch`, open the **Import** tab, choose `database/smartmatch.sql` and click **Import**.

### 3. Open and run the application
1. Open `Smart match.slnx` in Visual Studio (a recent version that supports the `.slnx` solution format), or open the project file `Smart match.csproj`.
2. Visual Studio restores the NuGet packages (`MySqlConnector`, `BCrypt.Net-Next`) automatically.
3. If your MariaDB uses another port or a password, edit the connection string in `Models/Database.cs`:
   ```csharp
   "Server=127.0.0.1;Port=3306;Database=smartmatch;User ID=root;Password=;"
   ```
4. Press **F5**.

### 4. Test accounts (included in `smartmatch.sql`)

| Role | Email | Password |
|---|---|---|
| Administrator | `admin@test.com` | `123456` |
| Mentee | `mentee@test.com` | `123456` |
| Mentor | `mentor1@test.com` | `123456` |
| Mentor | `mentor2@test.com` | `123456` |
| Mentor | `mentor3@test.com` | `123456` |

New mentees and mentors can register from the Login window. An administrator account is created directly in the database:
```sql
UPDATE users SET role = 'Admin' WHERE email = 'admin@test.com';
```

---

## Requirements coverage

| ID | Requirement | Status |
|---|---|---|
| FR1 | Register and log in as Mentee, Mentor or Admin | Done (the Admin role is set in the database) |
| FR2 | Create and edit a profile | Done |
| FR3 | Calculate a match score | Done (cosine similarity) |
| FR4 | Ranked list of recommended mentors | Done |
| FR5 | Mentee sends a mentorship request | Done |
| FR6 | Mentor accepts or rejects a request | Done |
| FR7 | Schedule mentoring sessions | Done |
| FR8 | Notifications | Done (in-app notifications for requests, answers and messages) |
| FR9 | Feedback and ratings after a session | Done |
| FR10 | Admin manages users, overrides matches, views reports | Partly: manage users and reports are done, overriding matches is not |
| FR11 | Password reset by email | Not implemented (future work) |
| FR12 | Messages between matched users | Done |
| FR13 | Admin suspends or deletes accounts | Partly: suspend and activate are done, delete is not |
| FR14 | Reports | Done |

---

## Security

- Passwords are stored as **BCrypt hashes**, never as plain text.
- All SQL uses **parameterized commands**, which prevents SQL injection.
- **Role checks are in the controllers**, so a user cannot use functions that belong to another role even if a form is opened by mistake.
- Messages and sessions are only available between **matched** users.
- Suspended accounts cannot log in.

---

## Manual testing performed

| Feature | Result |
|---|---|
| Register a user (password stored as a BCrypt hash in the database) | Works |
| Login with a correct and with a wrong password | Works, wrong password is rejected |
| Save and update a profile (only one row per user) | Works |
| Mentor ranking (the best match is first, no common words gives 0%) | Works |
| Send a request, and block a second request to the same mentor | Works |
| Mentor accepts a request, and a match with its score is created | Works |
| Schedule a session and mark it as completed | Works |
| Mentee submits feedback, and the session leaves the "to rate" list | Works |
| Notifications are created and the unread count is shown on the Dashboard | Works |
| Sending a chat message creates a notification for the receiver | Works |
| Admin report shows the correct counts and the average rating | Works |
| Admin suspends a mentor, the mentor cannot log in, and activation restores access | Works |
| Dashboard shows different buttons for Mentee, Mentor and Admin | Works |

---


