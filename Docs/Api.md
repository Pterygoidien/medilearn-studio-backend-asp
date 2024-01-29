# MediLearn Studio
Documentation for the Medilearn Studio microservice REST Api

## Course

### Create a new course 

```js
POST {{host}}/course/
```

#### CreateCourse Request

```json
{
    "title": "Title (string)",
}
```
```js
200 OK
```
