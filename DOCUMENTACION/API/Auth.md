# Rutas de autenticación

- [Buber Breakfast API](#buber-breakfast-api)
  - [Registro Usuarios](#registro-usuarios)
    - [Registro Usuarios Request](#registro-usuarios-request)
    - [Registro Usuarios Response](#registro-usuarios-response)
  - [Login](#login)
    - [Login Request](#login-request)
    - [Login Response](#login-response)

## RegistroUsuarios 

### Registro Usuarios Request

```js
POST /auth/registroUsuarios
```

```json
{
    "nombrePersona": "Rafael Alejandro Fabiani Cortes",
    "fechaNacPersona": "2003-09-19",
    "mailPersona": "rafafabiani1909@gmail.com",
    "direccionPersona": "calle Rosendo Gutierrez #312",
    "userPersona": "rafafabiani",
    "passwordPersona": "12345678"
}
```

### Registro Usuarios Response

```js
200 Usuario registrado correctamente
```

```js
400 Error al registrar al usuario
    Error: error
```



## Login

### Login Request

```js
POST /auth/login
```

```json
{
    "userPersona": "rafafabiani",
    "passwordPersona": "12345678"
}
```


### Login Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Update Breakfast

### Update Breakfast Request

```js
PUT /breakfasts/{{id}}
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Update Breakfast Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
```

## Delete Breakfast

### Delete Breakfast Request

```js
DELETE /breakfasts/{{id}}
```

### Delete Breakfast Response

```js
204 No Content
```