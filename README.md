# jwtApi
## JSON Web Token Play

### Build
- Open a command window on `JwtApi` project
- dotnet build

### Execute Locally
- `dotnet run`
- Access https://localhost:5001/swagger/index.html in browser

Swagger UI displays in default Web browser

![JwtApi/doc/Swaggerui.png](JwtApi/doc/Swaggerui.png)

#### PUT
Click *PUT* to expand a form to create a base64-coded JWT string from payload model
form inputs that you supply.

The payload model has a series of string values that Swagger defaults to 
"string". Freely change these. For example:

````json
{
  "sub": "JWT API",
  "iss": "Demo",
  "aud": "Developers",
  "exp": "1571435961964",
  "claimA": "To be or not to be,",
  "claimB": "that is the question"
}
````


Click `Execute`. The JWT appears in
the 200 success result. 

```string
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBdWQiOiJEZXZlbG9wZXJzIiwiQ2xhaW1BIjoiVG8gYmUgb3Igbm90IHRvIGJlLCIsIkNsYWltQiI6InRoYXQgaXMgdGhlIHF1ZXN0aW9uIiwiRXhwIjoiMTU3MTQzNTk2MTk2NCIsIklzcyI6InN0cmluZyIsIlN1YiI6IkpXVCBBUEkifQ.I8hKqpe-X54-Ozlb13usL2YX60EJWUShR517O8imIqw
```
Swipe and copy it to the clipboard.

#### GET
Click *GET* to expand a form to decode the payload of the JWT string parameter.

Paste the JWT into the token parameter field. Click `Execute`. The payload
:

```json
{
  "algorithmName": "HS256",
  "payload": {
    "sub": "JWT API",
    "iss": "Demo",
    "aud": "Developers",
    "exp": "1571435961964",
    "claimA": "To be or not to be,",
    "claimB": "that is the question"
  },
  "canSign": true,
  "serializer": null
}
```

### JWT Debugger
Validate the demo API JWT encode and decode process by using 
the JWT Debbuger from https://jwt.io/#debugger. 

The following screen capture shows the base64-encoded JWT pasted 
into the Encoded panel. If you alter one of the values in the 
Decoded panel, the string will change accordingly.

![JwtApi/doc/jwt.debugger.png](JwtApi/doc/jwt.debugger.png)

