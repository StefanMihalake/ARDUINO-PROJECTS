#include <DimmerC.h>


const int b1 = 6;
const int b2 = 5;                   // the number of the pushbutton pin
const int led1 = 11;
const int led2 = 10;


class TserialCommand {
  private:

  public:
    void Start(DimmerC &b1, DimmerC &b2) {
      if (Serial.available()) {
        String line = Serial.readStringUntil('\n');                 // take the incoming message til find the ENTER button
        int led = line.substring(0, 1).toInt();                     // find for who is the message
        String comand = line.substring(2, 9);                       // take the message
        switch (led) {
          case 1:
            b1.ReadSerial(comand);                              // send the message
            break;
          case 2:
            b2.ReadSerial(comand);                              // send the message
            break;
        }
      }
    }
};


DimmerC dimBut1 = DimmerC(led1, b1, 25, 255, 1500, 250, 1);
DimmerC dimBut2 = DimmerC(led2, b2, 25, 255, 1500, 250, 2);
TserialCommand serialCommand;


void setup() {
  Serial.begin(9600);

}

void loop() {
  serialCommand.Start(dimBut1, dimBut2);
  dimBut1.Start();
  dimBut2.Start();
}
