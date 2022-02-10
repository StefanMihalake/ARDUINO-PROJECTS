#include <Dimmer.h>
#include <ButtonSignalFilter.h>

// I/O PIN
const int bPin = 6;                   // the number of the pushbutton pin
const int ledPin = 11;                     // the number of the LED pin

// INITIALIZE CLASS--------------------
ButtonSignalFilter button1(6);
ButtonSignalFilter button2(5);
//Dimmer(int ledPin, int minVal, int maxVal, unsigned long dimTemp,  unsigned long dimDelay)
Dimmer dimcheck1(11, 25, 255, 1500, 250);
Dimmer dimcheck2(10, 25, 255, 1500, 250);

void setup() {
  Serial.begin(9600);
}





void loop() {

  button1.Loop();
  dimcheck1.Start(button1.trigUp, button1.trigDown, button1.state);

  button2.Loop();
  dimcheck2.Start(button2.trigUp, button2.trigDown, button2.state);

}
