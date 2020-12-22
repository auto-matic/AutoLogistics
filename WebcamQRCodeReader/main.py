import qr_code as qr
import socket
import sys


def main():
    print("Starting...")
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.bind(('127.0.0.1', 5005))
    while True:
        print("Listening for new connection...")
        s.listen(5)
        client, address = s.accept()
        print("Got new connection...")
        while True:
            msg = ""
            if client is None:
                print("Client is inactive")
                break
            try:
                print("Trying to get message")
                try:
                    msg = client.recv(1024).decode("utf-16")
                except ConnectionResetError:
                    print("Connection lost")
                    msg = None
                if msg is None:
                    break
                print("Received message:", msg)
            except Exception as e:
                print(e.with_traceback())
                print("Something went wrong while trying to receive the message sent by the client")
                continue
            if "GET" == msg:
                print("Received GET request")
                qr_decoded = None
                try:
                    qr_decoded = qr.get()
                except:
                    qr_decoded = "ERROR"
                    print("An error ocurred trying to decode a QR Code")
                finally:
                    client.send(qr_decoded.encode("utf-16"))
            elif msg == "TERMINATE":
                print("Received TERMINATE request")
                sys.exit()
            elif msg == "DISCONNECT":
                print("Received DISCONNECT request")
                client.close()
                break
            else:
                print("Unknown request")
                client.send("INVALID Id\ue001Name\ue001Category_id\ue001Tags\ue001Place_id\ue001Description\ue001Owner_id\ue001Amount\ue001Unit\ue001Addition\ue001Possession".encode("utf-16"))


if __name__ == '__main__':
    main()
