# webfejlesztes-2023
Unideb - Webdevelopment Project work 

**Használt technológiák:**
* React + DevExtreme (UI components)
* .NET CORE 7 (API)
* PostgreSQL (DB)

Az alábbi projektben egy egyszerű projekt / feladatkezelés látható. Tudunk regisztrálni az oldalra. Majd projekteket létrehozni ehhez pedig feladatokat.
Tudunk projektbe embereket meghívni email cím alapján. Ez realtime notification-t küld az adott személyeknek `Microsoft - SignalR`-en keresztül.
Tudunk az adott projekthez felvenni feladatokat. A feladatokhoz meg tudunk adni olyan metaadatokat mint pl: _Kategória, Státusz, Prioritás._
Ezeket ÉN szótáraknak hívom, mivel egyszerű adatstruktúrával rendelkeznek és egy ős osztályból tudjuk őket örökölteni. Ehhez tartozó implementációt a `DictionaryManager` végzi.

A felhasználó / jogosultság kezelést a .NET Core Indentity végzi mely össze van kapcsolva a hitelesítő szervízzel.
Az hitelesítést JWT vel csináltam, amibe beleraktam a kliens oldali információkat, tartalmazva pl a jogokat, felhasználónév stb.

**Claims** - AuthService.cs
```csharp
var userRoles = await _userManager.GetRolesAsync(user);

var authClaims = new List<Claim>
{
   new Claim(ClaimTypes.Name, user.UserName),
   new Claim(ClaimTypes.Email, user.Email),
   new Claim(ClaimTypes.GivenName, user.FirstName[0].ToString().ToUpper() + user.LastName[0].ToString().ToUpper()),
   new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
};

foreach (var userRole in userRoles) {
    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
}
```
A projekten belüli dolgokhoz mint pl a feladatok lekérdezésre lett csinálva egy Auth Policy ( _UserInProject_) mely
azt tudja hogy csak azoknak a felhasználóknak engedi lekérdezi a projekthez tartozó
feladatokat akik benne vannak az adott projektbe.

## Db séma
![Untitled](https://github.com/moL3sz/webfejlesztes-2023/assets/54034894/3b4a05ea-e418-4d42-84a7-d7c2073f0681)

## Swagger
# api
## Version: 1.0

### /api/DictionaryManager/{EntityName}/getAllByProject/{projectId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| projectId | path |  | Yes | integer |
| EntityName | path |  | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/DictionaryManager/{EntityName}/getById/{Id}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| Id | path |  | Yes | integer |
| EntityName | path |  | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/DictionaryManager/{EntityName}/insert/{projectId}

#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| projectId | path |  | Yes | integer |
| EntityName | path |  | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/DictionaryManager/{EntityName}/update/{projectId}

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| projectId | path |  | Yes | integer |
| EntityName | path |  | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/DictionaryManager/{EntityName}/delete/{Id}

#### DELETE
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| Id | path |  | Yes | integer |
| EntityName | path |  | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Ticket/getAll

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Ticket/getAllByProject/{projectId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| projectId | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Ticket/getById/{Id}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| Id | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Ticket/insert

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Ticket/update

#### PUT
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Ticket/delete/{Id}

#### DELETE
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| Id | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Ticket/updateStatus

#### PUT
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/User/getById/{userId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| userId | path |  | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Auth/login

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Auth/register

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Auth/getAll

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/ProjectUser/getProjectsByUser/{userId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| userId | path |  | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/ProjectUser/getUsersByProject/{projectId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| projectId | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/ProjectUser/getPendingProjectsByUser/{userId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| userId | path |  | Yes | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/ProjectUser/acceptProject/{projectId}

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| projectId | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/ProjectUser/invitePeople/{projectId}

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| projectId | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Project/getAll

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Project/getById/{Id}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| Id | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Project/insert

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Project/update

#### PUT
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Project/delete/{Id}

#### DELETE
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| Id | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Project/getProjectBurnDownChart/{projectId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| projectId | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Project/getKanbanBoard/{projectId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| projectId | path |  | Yes | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |



