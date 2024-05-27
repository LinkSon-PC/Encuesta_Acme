
# Encuesta ACME
- [Encuesta ACME](#encuesta-acme)
  - [DESCRIPCIÓN DEL PROYECTO](#descripción-del-proyecto)
  - [TECNOOLOGÍAS](#tecnoologías)
  - [ENDPOINTS](#endpoints)
    - [AUTENTICACIÓN](#autenticación)
      - [REGISTRO DE USUARIOS](#registro-de-usuarios)
      - [LOGIN DE USUARIOS](#login-de-usuarios)
    - [ENCUESTAS](#encuestas)
      - [CREAR NUEVA ENCUESTA](#crear-nueva-encuesta)
      - [VER ENCUESTAS CREADAS](#ver-encuestas-creadas)
      - [VER ENCUESTAS ESPECÍFICA](#ver-encuestas-específica)
      - [VER RESPUESTAS DE ENCUESTA](#ver-respuestas-de-encuesta)
      - [ELIMINAR ENCUESTA](#eliminar-encuesta)
    - [CUESTIONARIOS](#cuestionarios)
      - [VER CUESTIONARIO](#ver-cuestionario)
      - [RESPONDER CUESTIONARIO](#responder-cuestionario)



## DESCRIPCIÓN DEL PROYECTO
El cliente Acme se dedica a realizar encuestas en línea, por lo que se esta solicitando unos servicios web que le permita realizar las encuestas de forma dinámica y eficiente, al momento de crear una nueva encuesta se generará un link el cual podrá ser accedido por cualquier persona y permitirá llenar la encuesta. Se hizo un levantado de requerimientos con el cliente y se acordó que en esta primera fase se necesitan las siguientes

## TECNOOLOGÍAS

-   SQL SERVER
-   ASP.NET CORE

## ENDPOINTS



### AUTENTICACIÓN

Módulo de autenticación de usuarios. Implementado con JWT para la autorización.

#### REGISTRO DE USUARIOS

Método

> POST

Ruta

> **{URL}**/api/cuentas/registrar

Autenticación

> **NO REQUERIDA**

Entrada

```json
{
    "email": "user@example.com",
    "password": "aA12345678!"
}
```

Ejemplo

```json
{
    "email": "user@example.com",
    "password": "aA12345678!"
}
```

Respuesta Esperada

Status Code HTTP: `201 Created `

```json
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImRlbW8yQGV4YW1wbGUuY29tIiwiZXhwIjoxNzE2NzczOTAxfQ.59ze3nGBAlM--SxwkTqkKNe-juVDTetmwGqN9kQ8j0c",
    "expiracion": "2024-05-27T01:38:21.4623692Z"
}
```

#### LOGIN DE USUARIOS

Método

> POST

Ruta

> **{URL}**/api/cuentas/login

Autenticación

> **NO REQUERIDA**

Entrada

```json
{
    "email": "string",
    "password": "string"
}
```

Ejemplo

```json
{
    "email": "user@example.com",
    "password": "aA12345678!"
}
```

Respuesta Esperada

Status Code HTTP: `200 OK`

```json
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImRlbW8yQGV4YW1wbGUuY29tIiwiZXhwIjoxNzE2NzczOTAxfQ.59ze3nGBAlM--SxwkTqkKNe-juVDTetmwGqN9kQ8j0c",
    "expiracion": "2024-05-27T01:38:21.4623692Z"
}
```

### ENCUESTAS

#### CREAR NUEVA ENCUESTA

Método

> POST

Ruta

> **{URL}**/api/Encuesta

Autenticación

> **REQUERIDA: BEARER TOKEN**


Entrada

Para especificar el tipo del campo utilizar las siguientes opciones.

```
tipoCampo
-  0: STRING
-  1: INT
-  2: DATE
```

```json
{
  "nombre": "string",
  "descripcion": "string",
  "campos": [
    {
      "nombre": "string",
      "titulo": "string",
      "requerido": true,
      "tipoCampo": 0
    }
  ]
}
```

Ejemplo

```json
{
  "nombre": "Nueva Encuesta",
  "descripcion": "Formulario de Datos",
  "campos": [
    {
      "nombre": "Nombre",
      "titulo": "¿Cuál es su nombre?",
      "requerido": true,
      "tipoCampo": 0
    },
    {
      "nombre": "Experiencia",
      "titulo": "¿Cuántos años ha trabajado?",
      "requerido": true,
      "tipoCampo": 1
    },
    {
      "nombre": "Expectativa",
      "titulo": "¿De cuánto es su expectativa salarial?",
      "requerido": false,
      "tipoCampo": 1
    },
    {
      "nombre": "Nacimiento",
      "titulo": "Ingrese su fecha de nacimiento",
      "requerido": true,
      "tipoCampo": 2
    }
  ]
}
```

Respuesta Esperada

Headers

Donde `{id}` es el `ID` de la encuesta generada

> Location : **{url}**/api/Cuestionario/**{id}**

Status Code HTTP: `201 Created`

```json
{
    "crearEncuesta": {
        "nombre": "Encuesta 1",
        "descripcion": "Formulario de datos 1",
        "campos": [
            {
                "nombre": "Nombre",
                "titulo": "Ingrese su nombre",
                "requerido": true,
                "tipoCampo": 0
            },
            {
                "nombre": "Edad",
                "titulo": "Ingrese su Edad",
                "requerido": true,
                "tipoCampo": 1
            },
            {
                "nombre": "Fecha",
                "titulo": "Ingrese su Fecha de Nacimiento",
                "requerido": true,
                "tipoCampo": 2
            }
        ]
    },
    "url": "/api/Cuestionario/6"
}
```

#### VER ENCUESTAS CREADAS

Método

> GET

Ruta

> **{URL}**/api/Encuesta

Autenticación

> **REQUERIDA: BEARER TOKEN**

Respuesta Esperada

Dónde tipoCampo es una de las siguientes opciones.

```
tipoCampo
-  0: STRING
-  1: INT
-  2: DATE
```

Status Code HTTP: `200 OK`

```json
[
    {
        "id": 1,
        "nombre": "Encuesta 2",
        "descripcion": "Formulario de datos 2",
        "campos": [
            {
                "id": 1,
                "nombre": "Nombre",
                "titulo": "Ingrese su nombre",
                "requerido": true,
                "tipoCampo": 0
            },
            {
                "id": 2,
                "nombre": "Sexo",
                "titulo": "Ingrese su Sexo",
                "requerido": false,
                "tipoCampo": 0
            }
        ]
    },
    {
        "id": 3,
        "nombre": "Encuesta 1",
        "descripcion": "Formulario de datos 1",
        "campos": [
            {
                "id": 6,
                "nombre": "Nombre",
                "titulo": "Ingrese su nombre",
                "requerido": true,
                "tipoCampo": 0
            },
            {
                "id": 7,
                "nombre": "Edad",
                "titulo": "Ingrese su Edad",
                "requerido": true,
                "tipoCampo": 1
            },
            {
                "id": 8,
                "nombre": "Fecha",
                "titulo": "Ingrese su Fecha de Nacimiento",
                "requerido": true,
                "tipoCampo": 2
            }
        ]
    }
]
```


#### VER ENCUESTAS ESPECÍFICA

Método

> GET

Ruta

Donde `{id}` es el `ID` de la encuesta específica.

> **{URL}**/api/Encuesta/**{id}**

Autenticación

> **REQUERIDA: BEARER TOKEN**

Respuesta Esperada

Status Code HTTP: `200 OK`

Dónde tipoCampo es una de las siguientes opciones.

```
tipoCampo
-  0: STRING
-  1: INT
-  2: DATE
```

```json
{
    "id": 1,
    "nombre": "Encuesta 2",
    "descripcion": "Formulario de datos 2",
    "campos": [
        {
            "id": 1,
            "nombre": "Nombre",
            "titulo": "Ingrese su nombre",
            "requerido": true,
            "tipoCampo": 0
        },
        {
            "id": 2,
            "nombre": "Sexo",
            "titulo": "Ingrese su Sexo",
            "requerido": false,
            "tipoCampo": 0
        }
    ]
}
```

#### VER RESPUESTAS DE ENCUESTA

Método

> GET

Ruta

Donde `{id}` es el `ID` de la encuesta específica.

> **{URL}**/api/Encuesta/respuestas/**{id}**

Autenticación

> **REQUERIDA: BEARER TOKEN**

Respuesta Esperada

Status Code HTTP: `200 OK`

```json
[
    {
        "id": 4,
        "campoRespuestas": [
            {
                "campoId": 6,
                "respuesta": "Anthony S."
            },
            {
                "campoId": 7,
                "respuesta": "23"
            },
            {
                "campoId": 8,
                "respuesta": "2024-06-15"
            }
        ]
    },
    {
        "id": 5,
        "campoRespuestas": [
            {
                "campoId": 6,
                "respuesta": "Anthony S."
            },
            {
                "campoId": 7,
                "respuesta": "23"
            },
            {
                "campoId": 8,
                "respuesta": "2024-06-15"
            }
        ]
    }
]
```

#### ELIMINAR ENCUESTA

Método

> DELETE

Ruta

Donde `{id}` es el `ID` de la encuesta específica.

> **{URL}**/api/Encuesta/**{id}**

Autenticación

> **REQUERIDA: BEARER TOKEN**

Respuesta Esperada

Status Code HTTP: `204 No Content`


### CUESTIONARIOS

#### VER CUESTIONARIO

Método

> GET

Ruta

Donde `{id}` es el `ID` de la encuesta a responder.

> **{URL}**/api/Cuestionario/**{id}**

Autenticación

> **NO REQUERIDA**

Respuesta esperada

Status Code HTTP: `200 Ok`

```json
{
    "id": 3,
    "nombre": "Encuesta 1",
    "descripcion": "Formulario de datos 1",
    "campos": [
        {
            "id": 6,
            "nombre": "Nombre",
            "titulo": "Ingrese su nombre",
            "requerido": true
        },
        {
            "id": 7,
            "nombre": "Edad",
            "titulo": "Ingrese su Edad",
            "requerido": true
        },
        {
            "id": 8,
            "nombre": "Fecha",
            "titulo": "Ingrese su Fecha de Nacimiento",
            "requerido": true
        }
    ]
}
```


#### RESPONDER CUESTIONARIO

Método

> POST

Ruta

Donde `{id}` es el `ID` de la encuesta a responder.

> **{URL}**/api/Cuestionario/**{id}**

Autenticación

> **NO REQUERIDA**

Entrada

```json
{
  "encuestaId": 0,
  "campoRespuestas": [
    {
      "campoId": 0,
      "respuesta": "string"
    }
  ]
}
```

Ejemplo
```json
{
  "encuestaId": 3,
  "campoRespuestas": [
    {
      "campoId": 6,
      "respuesta": "Anthony S."
    },    
    {
      "campoId": 7,
      "respuesta": "23"
    },
    {
      "campoId": 8,
      "respuesta": "2024-06-15"
    }
  ]
}
```

Respuesta esperada

Status Code HTTP: `201 Created`

```json
{
    "encuestaId": 3,
    "campoRespuestas": [
        {
            "campoId": 6,
            "respuesta": "Anthony S."
        },
        {
            "campoId": 7,
            "respuesta": "23"
        },
        {
            "campoId": 8,
            "respuesta": "2024-06-15"
        }
    ]
}
```

eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJleHAiOjE3MTY3NzE0OTB9.OdetoqVEr9SjEBnCdEgifxHdL5LL1uer7bfmrk16yvk

