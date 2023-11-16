import cv2

from cvzone.HandTrackingModule import HandDetector 
import socket

width, height = 1280, 720

cap = cv2.VideoCapture(0)
cap.set(3, width)
cap.set(4, height)

detector = HandDetector(maxHands=2, detectionCon=0.8)

sock = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serveraddressport = ("127.0.0.1", 5052)

while True:
    sucess, img = cap.read()

    hands, img = detector.findHands(img)

    data = []
    if len(hands) > 0:
        hand = hands[0]
        lmlist = hand['lmList']
        # print(lmlist)
        for lm in lmlist:
            data.extend([lm[0], height - lm[1], lm[2]])
            # print(data)

        sock.sendto (str.encode(str(data)), serveraddressport)

    cv2.imshow("Nida Namwob", img)

    if cv2.waitKey(1) & 0xff == ord("q"):
        break;