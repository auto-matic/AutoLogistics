# Communication Specifications
## Protocoll for Socket Communication:
	1. Python Server gets Connection from C# Client
	2. Server sends scan request to Client
	3. Client tries to scan QR-Code
	4. Client sends decoded data back to Server

## Requests and Responses
- Requests:
	- "GET" starts the QR-Code Reader, tries to read the shown QR-Code and responds with the appropriate response
	- "TERMINATE" terminates the server
	- "DISCONNECT" signals the client disconnecting from the server
- Responses:
	- "SUCCESS {read data of the QR-Code}"
	- "ERROR" an error ocurred while processing the request
	- "INVALID" the given request is invalid

## Format for SUCCESS responses
The format is checked on the client side. The server just passes the raw data through.
```
Id\ue001Name\ue001Category_id\ue001Tags\ue001Place_id\ue001Description\ue001Owner_id\ue001Amount\ue001Unit\ue001Addition\ue001Possession
```
The '\ue001' character is used to separate the individual fields. The reason for choosing this specific character is, that it is part of the unicode Private-Use Characters which are perfectly suited for this application. In C# it can be decoded like this:
``` c#
System.Text.RegularExpressions.Regex.Unescape(@"\ue001");
```
Though this is unnecessary as the escape works fine in C#