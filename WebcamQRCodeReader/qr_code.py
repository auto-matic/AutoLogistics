import cv2


def get():
    cap = cv2.VideoCapture(0)
    detector = cv2.QRCodeDetector()

    while True:
        _, img = cap.read()
        data, bbox, _ = detector.detectAndDecode(img)
        if bbox is not None:
            if data:
                print("QR Code detected, data:", data)
                break
    cap.release()
    cv2.destroyAllWindows()
    return data
