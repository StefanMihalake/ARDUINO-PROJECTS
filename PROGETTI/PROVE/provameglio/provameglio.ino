#include <ButtonSignalFilter.h>

// I/O PIN
const int bPin = 6;                   // the number of the pushbutton pin
const int ledPin = 11;                     // the number of the LED pin

// LED VARIABLE-----------------------
float ledState = 0;                       // the current state of the output pin
float lastLedState = 255;
// BUTTON VARIABLE
bool buttonState = false;                  // the current reading from the input pin
bool lastButtonState;                      // the previous reading from the input pin
bool buttonPress;
// DIM VARIALBE------------------------
unsigned long dimDelay = 250;
unsigned long tDim = 0;
// DELAY DIM VARIABLE------------------
float count = 0;
float newCount = 0;
bool maxReach = false;
bool dim = 0;
// LOOP LIFE VARIABLE------------------
unsigned long startLoop = 0;
unsigned long loopInterval = 10;
unsigned long t1 = 0;


// INITIALIZE CLASS--------------------
ButtonSignalFilter button1(6);


void setup() {
  pinMode(ledPin, OUTPUT);
  Serial.begin(9600);
}





void loop() {
  startLoop = millis();

  buttonPress = button1.Loop();


  if (button1.trigUp == true) {
    t1 = millis();
  }

  if (buttonPress == true) {
    if (millis() - t1 >  dimDelay) {

      if (dim == false) {
        tDim = millis();
        dim = true;
      }

      float time = (float)1500 / (float)2.55;
      newCount = (float)(90 * (millis() - tDim) / time);
      if (newCount > 0) {
        tDim = millis();
        if (maxReach == true) {
          count = count - newCount;
          Serial.println(count);
        } else {
          count = count + newCount;
          Serial.println(count);
        }

        if (count <= 25) {
          count = 25;
          maxReach = false;
        }
        if (count >= 255) {
          count = 255;
          maxReach = true;
        }
      }

    }
  }


  if (button1.trigDown == true ) {
    dim = false;
    if (millis() - t1 < dimDelay) {
      if (count > 0) {
        lastLedState = count;
        count = 0;
      } else {
        count = lastLedState;
      }
    }

  }
  ledState = count;
  analogWrite(ledPin, count);
  lastButtonState = buttonPress;
  //while ((millis() - startLoop) < loopInterval) {}

}
