# Communication
## Protocoll for Socket Communication:
	1. C# Server gets Connection from Python Client
	2. Server sends scan request to Client
	3. Client scans qrcode
	4. Client sends decoded data back to Server

## Communication Specifications
- Requests:
	- "GET" starts the QR-Code Reader, tries to read the shown QR-Code and responds with the appropriate response
	- "CLOSE" closes the client
- Responses:
	- "SUCCESS {read data of the QR-Code}"
	- "ERROR" 
