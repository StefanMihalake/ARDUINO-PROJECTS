// I/O PIN
const int bPin = 6;                   // the number of the pushbutton pin
const int ledPin = 11;

unsigned long startLoop = 0;
unsigned long loopInterval = 5;
int vMin, vMax, led;
String comand;

class Dimmer {

  private:
    int _bPin;                   // the number of the pushbutton pin
    int _ledPin;
    //-------------------------------- BUTTON FILTER VAR--------------------------------------
    // LED VARIABLE-----------------------
    float ledState = 0;                       // the current state of the output pin
    float lastLedState;
    // BUTTON VARIABLE
    bool buttonState = false;                  // the current reading from the input pin
    bool lastButtonState;                      // the previous reading from the input pin
    bool buttonPress;
    // DIM PARAMETERS------------------------
    unsigned long dimDelay;
    unsigned long tDim = 0;
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

    Dimmer(int ledPin, int buttonPin, int minVal, int maxVal, unsigned long dimTemp,  unsigned long dimDelay) {
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
      analogWrite(ledPin, count);
      lastButtonState = state;
      //while ((millis() - startLoop) < loopInterval) {}

    }

};



Dimmer dimButton = Dimmer(ledPin, bPin, 25, 255, 1500, 250);

void setup() {
  Serial.begin(9600);
}

void loop() {

  
  if (Serial.available()) {
    String comands = Serial.readStringUntil('\n');
    if (comands.length() > 0) {
      Serial.println("comand.length > 0");
      int m = 0;
      int n = comands.indexOf(";");
      int indice = 0;
      while (n > 0) {
        Serial.println("while");
        String token = comands.substring(n, m);
        m = n + 1;
        n = comands.indexOf(";", n + 1);

        processToken(indice, token);
        indice++;
      }
      setLed();
    }
  }

  dimButton.Start();
}


void processToken(int i, String str) {
  switch (i) {
    case 0:                            // led da impostare
       led = str.toInt();
       Serial.println(led);
      break;
    case 1:                            // luce massima in caso di dimmer
      vMax = str.toInt();
      Serial.println(vMax);
      break;

  }
}

void setLed() {
  analogWrite(led, vMax);
  Serial.println("luce set");
}
