import qr_code as qr
import socket
import sys


def main():
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.connect(('127.0.0.1', 5005))
    while True:
        msg = ''
        try:
            msg = s.recv(1024).decode("utf-8")
        except:
            continue
        if msg == "GET":
            print()
            qr_decoded = None
            try:
                qr_decoded = qr.get()
            except:
                qr_decoded = "ERROR"
            finally:
                s.send(qr_decoded.encode("utf-8"))
        elif msg == "CLOSE":
            sys.exit()


if __name__ == '__main__':
    main()
