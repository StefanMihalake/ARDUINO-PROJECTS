#include <PassoPasso.h>
const int buttonPin = 6;                  // the number of the pushbutton pin
const int ledPin = 11;                    // the number of the LED pin

PassoPasso onoffB(buttonPin, ledPin);

void setup() {
  pinMode(ledPin, OUTPUT);
  Serial.begin(9600);
}

void loop() {

onoffB.Start();

}
