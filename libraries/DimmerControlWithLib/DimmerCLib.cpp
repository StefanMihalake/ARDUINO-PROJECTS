#include "Arduino.h"
#include "DimmerCLib.h"


class ButtonSignalFilter{
    private:
    unsigned long tIn;
    void State(int pin);
    int _pin;
    bool _lastStatePin;
    bool _lastState;
    bool _buttonState = false;
    unsigned long _debounceDelay = 5;
    ButtonSignalFilter(int pin) {
      State(pin);
    }

  public:
    bool state;
    bool trigUp;
    bool trigDown;
    ButtonSignalFilter(int pin);
    bool Loop();



  State(int pin) {
    pinMode(pin, INPUT);
    _pin = pin;
  }

  Loop() {
    _buttonState = digitalRead(_pin);

    if (_buttonState != _lastState) {
      tIn = millis();
    } else {
      if ((millis() - tIn) > _debounceDelay) {
        if (_buttonState != _lastStatePin) {

          if (_buttonState == LOW) {
            trigUp = false;
            trigDown = true;
          }
          else {
            trigUp = true;
            trigDown = false;
          }

        }
        else {
          trigUp = false;
          trigDown = false;
        }
        state = _buttonState;
        _lastStatePin = _buttonState;
      }
    }
    _lastState = _buttonState;
    return state;
  }
}


DimmerCLib::DimmerCLib(int ledPin, int buttonPin, int minVal, int maxVal, unsigned long dimTemp,  unsigned long dimDelay, int num) : ButtonSignalFilter(buttonPin) {
     _bPin = buttonPin;
     ButtonSignalFilter filter(_bPin);
     pinMode(buttonPin, INPUT);
     pinMode(ledPin, OUTPUT);
     _ledPin = ledPin;
     _dimTemp = dimTemp;
     _dimDelay = dimDelay;
     _max = maxVal;
     _min = minVal;
     //float v = _max - _min;
     //dist = (v / _max) * 100;                  // distanze to travel in percentual
     dist = 100 - (_min * 100 / _max); //90;
     onePCent = (float)_max / 100;
     lastLedState = maxVal;
     _num = num;
   }

// bool DimmerCLib::Loop() {
//       //startLoop = millis();
//       _buttonState = digitalRead(_bPin);
//       if (_buttonState != _lastState) {
//         tIn = millis();
//       } else {
//         if ((millis() - tIn) > _debounceDelay) {
//           if (_buttonState != _lastStatePin) {

//             if (_buttonState == LOW) {
//               trigUp = false;
//               trigDown = true;
//             }
//             else {
//               trigUp = true;
//               trigDown = false;
//             }

//           }
//           else {
//             trigUp = false;
//             trigDown = false;
//           }
//           state = _buttonState;
//           _lastStatePin = _buttonState;
//         }
//       }
//       _lastState = _buttonState;
//     }

    void DimmerCLib::Start() {
      //Loop();
      bFilter = filter.Loop();
      if (filter.trigUp == true) {
        t1 = millis();
      }

      if (filter.state == true) {
        if (millis() - t1 >  _dimDelay) {

          if (dim == false) {
            tDim = millis();
            dim = true;
          }

          float time = (float)_dimTemp / (float)onePCent;
          newCount = (float)((dist) * (millis() - tDim) / time);
          if (newCount > 0) {
            tDim = millis();
            if (maxReach == true) {
              count = count - newCount;
              //Serial.println(count);
            } else {
              count = count + newCount;
              //Serial.println(count);
            }

            if (count <= _min) {
              count = _min;
              maxReach = false;
              Serial.println(0);
            }
            if (count >= _max) {
              count = _max;
              maxReach = true;
              Serial.println(1);
            }
          }

        }
      }

      if (filter.trigDown == true ) {
        dim = false;
        if (millis() - t1 < _dimDelay) {
          if (count > 0) {
            lastLedState = count;
            count = 0;
          } else {
            count = lastLedState;
          }
        }
      }

      ledState = count;
      analogWrite(_ledPin, count);
      lastButtonState = state;
      //while ((millis() - startLoop) < loopInterval) {}
    }

void DimmerCLib::ReadSerial(String comand) {
      String com = comand.substring(0, 3);                            // take the first 3 char
      if (com == "off") {
        count = 0;                                                    // turn off
        Serial.println("count 0");
      }
      if (com == "on") {                                              // turn on
        count = _max;
      }
      if (com == "dim") {                                             // set dimmer value in percentual
        int c = comand.substring(4, 7).toInt() * _max / 100;
        if (c > _max) {
          Serial.println("WARNING: max passed");
          count = _max;
        } else {
          count = c;
        }
      }
    }


