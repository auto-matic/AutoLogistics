#Plan
- Protocoll for Socket Communication:
	1. C# Server gets Connection from Python Client
	2. Server sends scan request to Client
	3. Client scans qrcode
	4. Client sends decoded data back to Server

	- Requests:
		- "GET" starts the QR-Code Reader, tries to read the shown QR-Code and responds with the appropriat response
		- "CLOSE" closes the client
	- Responses:
		- "SUCCESS {read data of the QR-Code}"
		- "ERROR" 
- Datastructure for database:
	- Item
		- ID
		- Name
		- Category
		- Tags
		- Place
		- Description
		- Owner
		- Addition
		- Possesion