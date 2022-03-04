#include <PassoPasso.h>


// I/O PIN
const int bPin = 6;                   // the number of the pushbutton pin
const int ledPin = 11;                     // the number of the LED pin

PassoPasso button1(bPin, ledPin);

void setup() {
  

}

void loop() {
  // put your main code here, to run repeatedly:
button1.Start();
}
