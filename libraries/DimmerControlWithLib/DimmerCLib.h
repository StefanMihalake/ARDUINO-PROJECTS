#ifndef DimmerCLib_h
#define DimmerCLib_h
#include "Arduino.h"


class ButtonSignalFilter{
    private:
    unsigned long tIn;
    void State(int pin);
    int _pin;
    bool _lastStatePin;
    bool _lastState;
    bool _buttonState = false;
    unsigned long _debounceDelay = 5;

  public:
    bool state;
    bool trigUp;
    bool trigDown;
    bool Loop();
};

class DimmerCLib : public ButtonSignalFilter{

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
    DimmerCLib(int ledPin, int buttonPin, int minVal, int maxVal, unsigned long dimTemp,  unsigned long dimDelay, int num) : ButtonSignalFilter(buttonPin){};
    void Start();
    void ReadSerial(String comand);
    bool Loop();


};
#endif