#include <TimerOne.h>
const int stacji = 2;
int pStac[stacji][7] = { //0 pin  sterwania ruchu, 1 pin sterowania kierunku, 2 czestotliwosc nuty ilosc interwalow, 3 licznik interwalow, 4 pozycja glowicy, 5 kierunek 0 low 1 hig , 6 stan portu
  { 2, 3, 0, 1, 0, 1, 0 },
  { 4, 5, 0, 1, 0, 1, 0 },
  //  { 6, 7, 0, 1, 0, 1, 0 },
  //  { 8, 9, 0, 1, 0, 1, 0 },
  //  { 10, 11, 0, 1, 0, 1, 0 },
  //  { 12, 13, 0, 1, 0, 1, 0 }
};
byte incomingByte;
//a w s e d f t g y h u j k
//c1  cis1  d1  dis1  e1  f1  fis1  g1  gis1  a1  ais1  h1  c2



int interwaly[61] = {
  1219, 1152, 1087, 1025, 966, 913, 863, 812, 768, 726, 684, 645, 609, 574, 543, 512, 484, 456, 431, 407, 384, 362, 342, 323, 305, 288, 271, 256, 242, 228, 215, 203, 121, 114, 108, 102, 96, 91, 85, 81, 76, 72, 68, 64, 60, 57, 54, 51, 48, 45, 43, 40, 38, 36, 34, 32, 30, 29, 27, 25, 24

};




byte pled = 13;
boolean pledON = true;
boolean firstRun = true;
int tInterval = 40;



boolean ledBlink = true;


void setup()
{
  for (byte i = 0; i < stacji; i++)
  {
    pinMode(pStac[i][0], OUTPUT);
    pinMode(pStac[i][1], OUTPUT);
  }
  Serial.begin(9600);
  // Serial.setTimeout(1);
  Timer1.initialize(tInterval);
  Timer1.attachInterrupt(tRun);

  pinMode(pled, OUTPUT);

}


void loop()
{
  if (firstRun)
  {
    resetStacji();
    firstRun = false;
  }


  if (Serial.available() > 0) {
    incomingByte = Serial.read();



    //  Serial.println(incomingByte);

    if (incomingByte == 254)
    {
      for (byte i = 0; i < stacji; i++)
      {
        pStac[i][2] = 0;
      }
      // resetStacji();
    }

    else
    {

      if (incomingByte > 90) {
        int interwal = interwaly[incomingByte - 91]; // wyczytac z tablicy
        //    Serial.println(interwal);
        for (byte i = 0; i < stacji; i++) {
          if (pStac[i][2] == interwal) {
            pStac[i][2] = 0;
            pStac[i][3] = 0;
          }
        }
      }
      if (incomingByte <= 90) {
        int interwal = interwaly[incomingByte - 31]; // wyczytac z tablicy
        Serial.println(interwal);
        boolean nowy = true;
        for (byte i = 0; i < stacji; i++)
          if (pStac[i][2] == interwal) {
            nowy = false;
            //break;
          }
        if (nowy) {
          byte indstac = 0;
          // for (byte z = 0; z < 2; z++) {
          for (indstac = 0; indstac < stacji; indstac++)
            if (pStac[indstac][2] == 0) break;
          if (indstac < stacji)
            pStac[indstac][2] = interwal;
          // }
        }
      }
    }

  }


}


void tRun()
{
  for (byte i = 0; i < stacji; i++) {
    if (pStac[i][2] > 0)
      if (pStac[i][2] == pStac[i][3]) {
        pStac[i][3] = 1;
        pZnie(i);
      }
      else
        pStac[i][3]++;

  }

}
void pZnie(byte stacja) {


  if (pStac[stacja][5] == 1)
    pStac[stacja][4]++;
  else
    pStac[stacja][4]--;


  if (pStac[stacja][4] >= 154) {
    pStac[stacja][5] = 0;
    pStac[stacja][4]--;
    pStac[stacja][4]--;
    digitalWrite(pStac[stacja][1], LOW);
  }


  if (pStac[stacja][4] <= 4)
  {
    pStac[stacja][5] = 1;
    pStac[stacja][4]++;
    pStac[stacja][4]++;
    digitalWrite(pStac[stacja][1], HIGH);
  }


  if (pStac[stacja][6] == 0)  {
    digitalWrite(pStac[stacja][0], HIGH);
    pStac[stacja][6] = 1;

  }
  else {
    digitalWrite(pStac[stacja][0], LOW);
    pStac[stacja][6] = 0;

  }

}

void resetStacji() {
  for (byte i = 0; i < stacji; i++)
    digitalWrite(pStac[i][1], LOW);
  for (byte s = 0; s < 80; s++) {
    for (byte i = 0; i < stacji; i++)
      digitalWrite(pStac[i][0], HIGH);
    delay(5);
    for (byte i = 0; i < stacji; i++)
      digitalWrite(pStac[i][0], LOW);
  }

  for (byte i = 0; i < stacji; i++)
    digitalWrite(pStac[i][1], HIGH);
  delay(5);
}

