#include <StefanMLibrery.h>

const int bPin1 = 5;
const int bPin2 = 6;
const int bPin3 = 7;

const int led1 = 8;
const int led2 = 9;
const int led3 = 10;


//Dimmer (id, bPin, ledPin, minVal, maxVal, dimTemp, dimDelay)
Dimmer butLed1(13, bPin1, led1, 25, 255, 1500, 250);
Dimmer butLed2(52, bPin2, led2, 25, 255, 1500, 250);
//Dimmer butLed3(50, bPin3, led2, 25, 255, 1500, 250);


// ISTANCE LIST
Dimmer dimmers[] = {butLed1, butLed2};

//idDispositivo, porta Com, itemNumber, startCoil, startHReg, startIReg, startDIReg)
Orchestrator orch(1, 9600, 3, 100, 200, 100, 100);

void setup() {
  Serial.begin(9600);
  
}

void loop() {

  orch.Start(dimmers, led);
}
