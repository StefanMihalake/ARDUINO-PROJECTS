const int bPin1 = 6;
const int bPin2 = 5;                   // the number of the pushbutton pin
const int led1 = 11;
const int led2 = 10;


class Dimmer {

  private:
    int _bPin;                                 // number of the pushbutton pin
    int _ledPin;                               // number of the led pin
    int _num;
    //-------------------------------- BUTTON FILTER VAR--------------------------------------

    // LED VARIABLE-----------------------
    float ledState;                           // the current state of the output pin
    float lastLedState;                       // laststate of the pin
    // BUTTON VARIABLE
    bool buttonState = false;                  // the current reading from the button pin
    bool lastButtonState;                      // the previous reading from the button pin
    bool buttonPress;                          // the actual reading from the button pin
    // DIM PARAMETERS------------------------
    unsigned long dimDelay;                    // time to wait before start dimmering
    unsigned long tDim = 0;                    //
    unsigned long _dimTemp;
    unsigned long _dimDelay;
    unsigned long _max;
    unsigned long _min;
    int dist;
    float onePCent;
    //---------------------------------------
    float count = 0;
    float newCount = 0;
    bool maxReach = false;
    bool dim = 0;
    // LOOP LIFE VARIABLE--------------------
    unsigned long startLoop = 0;
    //unsigned long loopInterval = 5;
    unsigned long t1 = 0;
    //-------------------------------- END BUTTON FILTER VAR--------------------------------------
    unsigned long tIn;
    bool _lastStatePin;
    bool _lastState;
    bool _buttonState = false;
    unsigned long _debounceDelay = 5;

    bool state;
    bool trigUp;
    bool trigDown;


  public:

    Dimmer(int ledPin, int buttonPin, int minVal, int maxVal, unsigned long dimTemp,  unsigned long dimDelay, int num) {
      pinMode(buttonPin, INPUT);
      pinMode(ledPin, OUTPUT);
      _ledPin = ledPin;
      _bPin = buttonPin;
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

    bool Loop() {
      startLoop = millis();
      _buttonState = digitalRead(_bPin);
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
    }


    void Start() {
      Loop();
      if (trigUp == true) {
        t1 = millis();
      }

      if (state == true) {
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

      if (trigDown == true ) {
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


    void ReadSerial(String comand) {
      String com = comand.substring(0, 3);                            // take the first 3 char
      if (com == "off") {
        count = 0;                                                    // turn off
        Serial.println("count 0");
      }
      if (com == "on") {                                              // turn on
        count = _max;
        Serial.print("count set from led: ");
        Serial.print(_num);
        Serial.print(": ");
        Serial.println("255");
      }
      if (com == "dim") {                                             // set dimmer value in percentual
        int c = comand.substring(4, 7).toInt() * _max / 100;
        if (c > _max) {
          Serial.println("WARNING max passed");
          count = _max;
        } else {
          count = c;
        }
        Serial.print("count dim from led: ");
        Serial.print(_num);
        Serial.print(": ");
        Serial.println(count);
      }
    }
};

class SerialCommand {
  private:

  public:
    void Start(Dimmer &b1, Dimmer &b2) {
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


Dimmer button1 = Dimmer(led1, bPin1, 25, 255, 1500, 250, 1);
Dimmer button2 = Dimmer(led2, bPin2, 25, 255, 1500, 250, 2);
SerialCommand serialCommand;


void setup() {
  Serial.begin(9600);

}

void loop() {
  serialCommand.Start(button1, button2);
  button1.Start();
  button2.Start();
}
